using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    class PoissonGenerator
    {
        double lambda;
        double minInterval_s;
        double nextEventTime_s;
        bool getNextTime = true;
        List<double> allEventsTime_s = new List<double>();

        public PoissonGenerator(double k)
        {
            lambda = k;
        }

        public PoissonGenerator(double k, double min_Interval_s)
        {
            lambda = k;
            minInterval_s = min_Interval_s;
        }

        public void Set_Lambda(double k)
        {
            lambda = k;
        }

        public bool isEventNow(double t_s)
        {
            bool eventNow = false;

            if( t_s >= nextEventTime_s)
            {
                getNextTime = true;
                eventNow = true;
                allEventsTime_s.Add(t_s);
            }

            if (getNextTime)
            {
                nextEventTime_s = NextEventTime_s(t_s);
                getNextTime = false;
            }

            return eventNow;
        }


        public double NextEventTime_s(double t_now_s)
        {
            double interval;
            do
            {
                double rand = new Random().NextDouble();
                interval = -Math.Log(1 - rand) / lambda;
            } while (interval < minInterval_s);

            nextEventTime_s = t_now_s + interval;
            return nextEventTime_s;
        }


        public List<double> Get_allEventsTime_s()
        {
            return allEventsTime_s;
        }


        public void Set_minInterval_s(double min_interval_s)
        {
            minInterval_s = min_interval_s;
        }
    }
}
