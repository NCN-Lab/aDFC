using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace OnlineSpikeDetection
{
    public partial class TestPoisson : Form
    {
        double k = 1;
        double min_Interval_s = 0.01;
        PoissonGenerator poissonGenerator;
        bool poisson_ON = false;
        TextWriter tw;
        TextWriter tw_stimProtocol;

        // Poisson Thread:
        Thread poissonThread;


        public TestPoisson()
        {
            InitializeComponent();
            poissonGenerator = new PoissonGenerator(k, min_Interval_s);

            txt_mean_rate.Text = k.ToString();
            txt_minInterStim_s.Text = min_Interval_s.ToString();
        }


        private void txt_mean_rate_TextChanged(object sender, EventArgs e){}
        private void txt_minInterStim_s_TextChanged(object sender, EventArgs e){}


        private void btn_set_Click(object sender, EventArgs e)
        {
            k = double.Parse(txt_mean_rate.Text);
            poissonGenerator.Set_Lambda(k);
        }


        private void btn_set_minInterStim_Click(object sender, EventArgs e)
        {
            min_Interval_s = double.Parse(txt_minInterStim_s.Text);
            poissonGenerator.Set_minInterval_s(min_Interval_s);
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            poisson_ON = true;

            btn_start.Enabled = false;
            btn_stop.Enabled = true;

            poissonThread = new Thread(PoissonThread);
            poissonThread.Start();
        }


        private void PoissonThread()
        {
            double start_s = Stopwatch.GetTimestamp() * 0.0000001;

            while (poisson_ON)
            {
                // Define t as a function of ticks!!
                // 1 tick = 0.0001ms = 0.0000001 s 
                double t = Stopwatch.GetTimestamp()*0.0000001 - start_s;
                poissonGenerator.isEventNow(t);

                /*
                if (poissonGenerator.isEventNow(t))
                {                    
                    //tw.WriteLine(t);
                    Console.WriteLine("---------------------------");
                }
                */
            }
        }


        private void btn_stop_Click(object sender, EventArgs e)
        {
            poisson_ON = false;
            btn_start.Enabled = true;
            btn_stop.Enabled = false;

            // Save Text Files
            String date = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            tw = new StreamWriter(date + "_StimTimes.txt");
            poissonGenerator.Get_allEventsTime_s().ForEach(tw.WriteLine);
            tw.Close();

            tw_stimProtocol = new StreamWriter(date + "_Protocol.txt");
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine("    Stim Protocol   ");
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine(" Poisson Lambda: " + k.ToString());
            tw_stimProtocol.WriteLine(" Min min_Interval [s]: " + min_Interval_s.ToString());
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.Close();
        }

    }
}
