using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    public class FiringRater
    {
        List<double> spkTimes; 
        List<int> spkCounts;

        double dt;
        double window_dur_s;
        double[] kernel;
        int kernelsize;
        int nElecs;

        double FiringRate; // Normalized FR per Electrode

        public FiringRater()
        {
            spkTimes = new List<double>();
            spkCounts = new List<int>();
            dt = 0.0001; // assumes 10 kHz by default
            window_dur_s = 1;
            nElecs = 1;
            kernelsize = (int)Math.Round(window_dur_s / dt);
            kernel = new double[kernelsize];
            setSquareKernel();
        }

        public FiringRater(double dt_secs, double w_duration_secs, string kernelType, int nElectrodes)
        {
            spkTimes = new List<double>();
            spkCounts = new List<int>();
            dt = dt_secs;
            window_dur_s = w_duration_secs;
            kernelsize = (int)Math.Round(window_dur_s / dt);
            kernel = new double[kernelsize];

            if (String.Compare(kernelType, "square") == 0)
                setSquareKernel();
            else if (String.Compare(kernelType, "causal") == 0)
                setCausalKernel();
            else
                Console.WriteLine("Ups! Undifined Kernel type!");

            nElecs = nElectrodes;
        }


        // Calculates Instant Firing Rate at Time t using Kernel - Hardcoded for Square Window!!
        public double CalcFiringRate(double t)
        {
            double window_start = t - window_dur_s;
            int kernel_pos;
            int to_remove = 0;
            // FiringRate = 0;
            int total_spks = 0;

            for (int i = 0; i < spkTimes.Count; i++)
            {
                kernel_pos = (int)Math.Round( (spkTimes[i] - window_start) / dt )-1;

                if (kernel_pos < 0)
                    to_remove++;
                else
                    // FiringRate += kernel[kernel_pos] * spkCounts[i];  <--- do something like this for different kernels!
                    total_spks += spkCounts[i];  // HARDCODED for square kernel
            }

            spkTimes.RemoveRange(0, to_remove);
            spkCounts.RemoveRange(0, to_remove);

            FiringRate = (double)total_spks / window_dur_s / (double)nElecs;
            return FiringRate;
        }


        public void AddSpikes(int spkCount, double spkTime)
        {
            spkCounts.Add(spkCount);
            spkTimes.Add(spkTime);
        }


        // Define a square kernel of size kernelsize
        public void setSquareKernel()
        {
            for (int i = 0; i<kernelsize; i++)
            {
                kernel[i] = (double)1 / kernelsize;
            }
        }


        // Define Causal Kernel
        public void setCausalKernel()
        {
            Console.WriteLine("SetCausalKernel: Not Defined Yet!");
        }


        public void Set_dt(double dt_sec)
        {
            dt = dt_sec;
        }

        public void SetWindowDuration(double w_duration_sec)
        {
            window_dur_s = w_duration_sec; 
            kernelsize = (int)Math.Round(window_dur_s / dt);
            kernel = new double[kernelsize];
        }

        public void Set_nElecs(int nMonitoringElecs)
        {
            nElecs = nMonitoringElecs;
        }
    }
}
