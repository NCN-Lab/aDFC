using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineSpikeDetection
{
    class DelayedController
    {
        double dt;

        // Oscillator:
        double T; // oscillation period secs
        public const double pi = 3.1415926535897931;
        double w;
        double x_now = 0;
        double x_pre = 0;
        double x_pre_pre = 0;
        double osctr_value = 0; // x_dot

       // double osclt_gain;
        double minStim_interval = 0.05;

        double min_stimFreq_Hz = 1; // if the stimulation freq is below min_stimFreq_Hz the stimulus is not sent


        // Period Adaptation Parameter
        List<double> IBI_batch = new List<double>(new double[5]); // batch of last 5 Inter Burst Intervals 

        // Feedback Controller:
        double delay_frac; // Percentage of oscillation_T
        double[] osctr_memory; // Array to store oscillator signal - circular memory
        int osctr_memory_size; // Size of array - maximum number of points that an half cycle can have  
        int delay_size; // size of T/2 --> actual space occupied by the circular memory inside osctr_memory
        double FB_stim; // FB_stimulation = StimGain*(oscillator(i-tau) - oscillator(i))
        double delay;    

        int add_pos = 0;     // index to add oscillator signal
        int delayed_pos = 1; // index to read delayed oscillator

        // Feedback Stimulation
        double StimGain; // Stimulation Frequency Gain
        double lastStim_t = -1;
               

        public DelayedController()
        {
            dt = 0.0001; // 10 kHz sampling rate

            // Initialize Oscillator
             T = 1; 
             w = 2 * pi / T;

            // Initialize Feedback Controller:
            delay_frac = 0.5; // Percentage of oscillation_T
            StimGain = 1; // controller Gain
            osctr_memory_size = (int)Math.Round(T / dt);
            delay = T * delay_frac;
            osctr_memory = new double[osctr_memory_size]; // Store One Full Cycle -- WATCH OUT: if there is a delay bigger than the initial T, the vector needs to be initialized again

            // Initialize batch
            for (int i = 0; i<IBI_batch.Count; i++)
            {
                IBI_batch[i] = T;
            }
            
            // Stimulation Parameters:
            StimGain = 1;
        }


        public DelayedController(double period, double delayFrac, double stimGain, double delta_t, double maxFreq)
        {
            dt = delta_t; // 10 kHz sampling rate

            // Initialize Oscillator
            T = period;
            w = 2 * pi / T;

            // Initialize Feedback Controller:
            delay_frac = delayFrac; // Percentage of oscillation period
            StimGain = stimGain;   // controller Gain
            osctr_memory_size = (int)Math.Round(T / dt); // Store One Full Cycle -- WATCH OUT: if there is a delay bigger than the initial T, the vector needs to be initialized again
            delay = T * delay_frac;
                        
            // Burst Adaptation Paramenters:
            osctr_memory = new double[osctr_memory_size];

            // Initialize batch
            for (int i = 0; i < IBI_batch.Count; i++)
            {
                IBI_batch[i] = T;
            }

            // Maximum Stimulation frequency [Hz]:
            minStim_interval = 1 / maxFreq;
        }


        public int CalcDelayedFeedback(double fireRate_Hz, double clock_s)
        {
            CalcOscillatorValue(fireRate_Hz); // Update oscillator value: osctr_value

            // Add new oscillator value to memory
            osctr_memory[add_pos] = osctr_value;

            // Calculate Feedback signal:
            FB_stim = StimGain * (osctr_memory[delayed_pos] - osctr_value);  // Feedback value: stim freq input

            // Check if you need to send stimulation
            int sendStimulus = SendStimulation(clock_s, FB_stim);

            // Advance pos in Circular Memory:
            add_pos++;
            delayed_pos++;

            // Back to begginig of circular vector:
            if (add_pos >= osctr_memory_size)
                add_pos = 0;

            // set position of delayed signal
            if (add_pos >= delay_size)
                delayed_pos = add_pos - delay_size; // the delayed position in memory is after the current position
            else
                delayed_pos = osctr_memory_size - (delay_size - add_pos);  // the delayed position in memory is before the current position

            return sendStimulus;
        }


        public void UpdatePeriodicty(double IBI)
        {            
                IBI_batch.RemoveAt(0);
                IBI_batch.Add(IBI);

                List<double> batch_clone = new List<double>(IBI_batch);

                // Calculate new T and delay:
                T = Median(batch_clone);
                w = 1 / T * 2 * pi;
                delay = T * delay_frac;
                delay_size = (int)Math.Round(delay / dt);

                if (delay_size > osctr_memory_size)
                {
                    // Expand Memory (Reset - NOT IDEAL) --> replace by matlab code
                    osctr_memory_size = (int)Math.Round(T / dt);
                    osctr_memory = new double[osctr_memory_size];
                    add_pos = 0;
                    delayed_pos = 1;

                    Console.WriteLine("Very Large T, Memory reset!");

                    /*  Matlab Code:
                            % Expand Memory according to new T
                            if delay_size > osctr_memory_size
                                % If delay size is bigger than memory, you need to reset the memory array

                                new_osctr_memory_size = round(T / dt);
                                split = osctr_memory_size - add_pos;

                                % Order memory:
                                osctr_memory(1:split) = osctr_memory(add_pos + 1:end);
                                osctr_memory(split + 1:osctr_memory_size) = osctr_memory(1:add_pos);

                                new_osctr_memory = zeros(1, new_osctr_memory_size);
                                new_osctr_memory(1:osctr_memory_size) = osctr_memory;

                                osctr_memory = new_osctr_memory;
                                osctr_memory_size = new_osctr_memory_size;

                                disp(['memory increased at t = ' num2str(clock_s)])
                            end
                    */
                }
        }


        public void CalcOscillatorValue(double fireRate_Hz)
        {
            // Oscillator:
            x_now = (w * fireRate_Hz * dt * dt + 2 * x_pre - x_pre_pre + w * dt * x_pre) / (1 + w * dt + dt * dt * w * w); // Amplitude of oscillator is "more constant" now because the driving strenght K is now W

            osctr_value = (x_now - x_pre) / dt; // x_dot

            x_pre_pre = x_pre;
            x_pre = x_now;
        }


        // Calculate When to Stimulute
        public int SendStimulation(double t, double FB_stim_value)
        {
            double stimInterval = 1 / FB_stim_value;
            int stimulate = 0;

            if (FB_stim_value > min_stimFreq_Hz  &&  t > lastStim_t + stimInterval) //  &&  t - lastStim_t > minStim_interval )
            {
                lastStim_t = t;

                // SEND STIMULUS!
                stimulate = 1;
            }

            return stimulate;
        }

        public void Set_dt(double delta_t)
        {
            dt = delta_t;
        }

        public void Set_T(double period)
        {
            osctr_memory_size = (int)Math.Round(delay_frac * period / dt);
            osctr_memory= new double[osctr_memory_size];
            add_pos = 0;
            delayed_pos = 1;

            T = period;
            w = 2 * pi / T;             
        }

        public void Set_delayFrac(double delay)
        {
            delay_frac = delay;
        }

        public void Set_ControlGain(double gain)
        {
            StimGain = gain;
        }

        public void Set_StimFreqGain(double gain)
        {
            StimGain = gain;
        }

        public void Set_Max_Freq_Hz(double maxFreq)
        {
            //maxFreq_Hz = maxFreq;
            minStim_interval = 1/maxFreq;
        }

        public void Set_Min_Stim_Interv_sec(double min_stim_interv_sec)
        {
            //maxFreq_Hz = maxFreq;
            minStim_interval = min_stim_interv_sec;
        }

        public void Initialize_osctr_signal()
        {
            osctr_memory_size = (int)Math.Round(delay_frac * T / dt);
            osctr_memory= new double[osctr_memory_size];
        }

        public double Get_oscillator_value()
        {
            return osctr_value;
        }

        public double Get_delayed_oscillator()
        {
            return osctr_memory[delayed_pos];
        }

        public double Get_FB_StimFreq_Hz()
        {
            return FB_stim;
        }

        public double Get_Stim_Gain()
        {
            return StimGain;
        }

        public double Get_Delay_Fraction()
        {
            return delay_frac;
        }

        public double Get_Period_s()
        {
            return T;
        }

        public double Get_Max_Freq_Hz()
        {
            return 1/minStim_interval;
        }

        public void Reset_IBI_Batch()
        {
            // Initialize batch
            for (int i = 0; i < IBI_batch.Count; i++)
            {
                IBI_batch[i] = T;
            }
        }

        public void Reset_IBI_Batch(double period)
        {
            // Initialize batch
            for (int i = 0; i < IBI_batch.Count; i++)
            {
                IBI_batch[i] = period;
            }
        }

        public static T Median<T>(List<T> Values)
        {
            Values.Sort();
            return Values[(Values.Count / 2)];
        }
        
        public void Set_min_StimFreq_Hz(double min_stimFreq)
        {
            min_stimFreq_Hz = min_stimFreq;
        }


        public double Get_min_StimFreq_Hz()
        {
           return min_stimFreq_Hz;
        }

    }
}
