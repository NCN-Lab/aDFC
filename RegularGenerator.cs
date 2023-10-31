using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OnlineSpikeDetection
{
    class RegularGenerator
    {
        double freq_Hz;
        double minInterval_s;
        double nextEventTime_s;
        List<double> allEventsTime_s = new List<double>();
        Timer timer = new Timer();
        Action timerElapsed;

        public RegularGenerator(double freq)
        {
            freq_Hz = freq;
            nextEventTime_s = 1 / freq_Hz;

            timer.Interval = 1 / freq_Hz * 1000;
            timer.Elapsed += Timer_Elapsed;
        }


        public RegularGenerator(double freq, double min_interval_s)
        {
            freq_Hz = freq;
            minInterval_s = min_interval_s;
            nextEventTime_s = 1 / freq_Hz;

            timer.Interval = 1 / freq_Hz * 1000;
            timer.Elapsed += Timer_Elapsed;
        }


        public void Set_TimerElapsedMethod(Action method)
        {
            timerElapsed = method;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerElapsed();
        }

        public void StartGenerator()
        {
            timer.Start();
        }

        public void StopGenerator()
        {
            timer.Stop();
        }







        public bool isEventNow(double t_s)
        {
            bool eventNow = false;

            if (t_s >= nextEventTime_s)
            {
                eventNow = true;
                nextEventTime_s = t_s + 1 / freq_Hz;
            }


            return eventNow;
        }



        public List<double> Get_allEventsTime_s()
        {
            return allEventsTime_s;
        }


        public void Set_minInterval_s(double min_interval_s)
        {
            minInterval_s = min_interval_s;
        }


        public bool Set_Frequency_Hz(double freq)
        {
            if (1 / freq >= minInterval_s)
            {
                freq_Hz = freq;
                timer.Interval = 1 / freq_Hz * 1000;
                return true;
            }
            else return false;
        }
    }
}
