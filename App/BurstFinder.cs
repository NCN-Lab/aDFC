using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    class BurstFinder
    {
        double FR_thresh_Hz = 10;
        double FR_BurstEnd_thresh_Hz = 2;
        bool waitingBurst; // while FR is below FR_BurstEnd_thresh_Hz
        double minIBI_s = 1;

        double last_burst_s = 0;
        double last_FR_Hz = 0;

        int burstDetected = 0; 

        public BurstFinder(double FR_thresh, double minIBI)
        {
            FR_thresh_Hz = FR_thresh;
            minIBI_s = minIBI;
        }


        // Detects bursts and returns the Inter-Burst interval
        public double DetectBurst(double fireRate_Hz, double t)
        {
            double IBI = -1;
            burstDetected = 0;

            // Find Burst in Frequency Signal:

            if (waitingBurst && fireRate_Hz >= FR_thresh_Hz & last_FR_Hz < FR_thresh_Hz & t - last_burst_s > minIBI_s)
            {
                // Interburst Interval:
                IBI = t - last_burst_s;
                last_burst_s = t;
                burstDetected = 1;
                waitingBurst = false;
            }

            last_FR_Hz = fireRate_Hz;

            // Check if last burst already ended
            if (fireRate_Hz < FR_BurstEnd_thresh_Hz)
                waitingBurst = true; // last burst already ended

            return IBI;
        }


        public void Set_FR_thresh_Hz(double fr_thresh_Hz)
        {
            FR_thresh_Hz = fr_thresh_Hz;
        }

        public void Set_minIBI_s(double min_IBI_s)
        {
            minIBI_s = min_IBI_s;
        }

        public double Get_BurstThresh_Hz()
        {
            return FR_thresh_Hz;
        }

        public double Get_min_IBI_s()
        {
            return minIBI_s;
        }

        public int BurstDetected()
        {
            return burstDetected;
        }

        public void Restart()
        {
            last_burst_s = 0;
            last_FR_Hz = 0;
        }
    }
}
