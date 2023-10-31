using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Drawing2D;

namespace OnlineSpikeDetection
{
    public partial class BurstLeadersForm : Form
    {
        static BurstLeaders burstLeaders = SpikeDetectionForm.burstLeaders;

        int nElecs = 256;
        Button[] allButtons;
        static ColorMap lastBurst_colormap;
        static ColorMap leadersHist_colormap;
        int nColors_hist = 10;
        public static ElecsButtonMatrix burstLeadersBtnMatrix;

        // Burst Leaders Parameters:
    //    int nLeaders;
    //    double onsetWindow_s;

        // Plot
        bool plotLastBurst = true;

        // Auto Update
        double update_interval_s = 1;
        int nBursts = 0;
        private System.Timers.Timer timer_updatePlot = new System.Timers.Timer();
       
        AuxiliaryFunctions Aux = new AuxiliaryFunctions();


        public BurstLeadersForm()
        {
            InitializeComponent();

            // Electrodes Matrix:
            int nLines = 16;
            int nCols = 16;
            int side = 36;
            int x_corner = 90;
            int y_corner = 90;
            burstLeadersBtnMatrix = new ElecsButtonMatrix(x_corner, y_corner, nLines, nCols, side, Btn_Click, Controls, Color.Transparent, Color.White);
            burstLeadersBtnMatrix.unlockSelectedButton(main.ElecsPool_inds);
            allButtons = burstLeadersBtnMatrix.Get_allButtons();

            // ColorMap:
            lastBurst_colormap = new ColorMap(burstLeaders.Get_nLeaders_per_burst()+1, "RedGreen");
            leadersHist_colormap = new ColorMap(nColors_hist, "WhiteBlack");

            // Auto Update
            txt_update_interval_s.Text = burstLeaders.Get_OnsetWindowDuration_s().ToString();
            txt_nLeaders.Text = burstLeaders.Get_nLeaders_per_burst().ToString();
            txt_onsetWindow_s.Text = burstLeaders.Get_OnsetWindowDuration_s().ToString();

            // Timer:
            timer_updatePlot.Interval = update_interval_s*1000;
            timer_updatePlot.Elapsed += Update_TimerPlot;

            // Colorbars:
            panel_lastLeaders.Paint += new PaintEventHandler(Paint_ColorbarLastLeaders);
            panel_lastLeaders.Refresh();
            panel_history.Paint += new PaintEventHandler(Paint_ColorbarHistory);
            panel_history.Refresh();

            txt_colorbar_nLeader.Text = "#" + burstLeaders.Get_nLeaders_per_burst().ToString();
        }


        private void Paint_ColorbarLastLeaders(object sender, PaintEventArgs e)
        {
            int hight = 500;
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(0, hight);

            Color firstColor = lastBurst_colormap.Get_RGB_Color(1);
            Color lastColor = lastBurst_colormap.Get_RGB_Color(burstLeaders.Get_nLeaders_per_burst());

            LinearGradientBrush lgb =
                new LinearGradientBrush(startPoint, endPoint, firstColor, lastColor);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, 0, 0, hight, hight);
        }


        private void Paint_ColorbarHistory(object sender, PaintEventArgs e)
        {
            int end = 500;
            Point startPoint = new Point(0, end);
            Point endPoint = new Point(0, 0);

            Color firstColor = leadersHist_colormap.Get_RGB_Color(1);
            Color lastColor = leadersHist_colormap.Get_RGB_Color(nColors_hist-1);

            LinearGradientBrush lgb =
                new LinearGradientBrush(startPoint, endPoint, firstColor, lastColor);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, 0, 0, end, end);
        }


        private void Update_TimerPlot(Object source, ElapsedEventArgs e)
        {
            int current_nBursts = SpikeDetectionForm.burstLeaders.Get_nBursts();
            if (nBursts < current_nBursts)
            {
                nBursts = current_nBursts;

                paintBurstLeadersHistory();
                if (plotLastBurst)
                    paintLastBurstLeaders();
            }
        }


        // Handler To Electrode Button Click:
        private void Btn_Click(object sender, EventArgs e)
        {
            /*
            Button btn = (Button)sender;
            if (btn.BackColor == Color.White)
            {
                btn.BackColor = Color.Transparent;
            }
            else
                btn.BackColor = Color.White;

            Btn_updateWarning();
            */
        }


        // Paint Rank of Last Burst in BlueRed colormap
        public static void paintLastBurstLeaders()
        {
            int[] last_leaders_inds = burstLeaders.Get_last_BurstLeaders_inds();

            for (int i = 0; i < last_leaders_inds.Length; i++)
                burstLeadersBtnMatrix.ChangeButtonColors(last_leaders_inds[i], lastBurst_colormap.Get_RGB_Color(i+1)); // first color is white!           
        }


        // Paint history of Burst Leaders in BlackWhite colormap
        public void paintBurstLeadersHistory()
        {
            int[] leaders_ID_countHistory = burstLeaders.Get_BurstLeaders_IDs_Count_per_Elec();
            double maxCount = leaders_ID_countHistory.Max();
            int color_ind;

            for (int i = 0; i < 252; i++)
            {
                int elec_ID = main.electrodeLabels[i].id;
                if (leaders_ID_countHistory[elec_ID] > 0)
                {
                    int elec_ind = Aux.from_ID_to_ind(elec_ID);
                    
                    color_ind = (int)Math.Floor(leaders_ID_countHistory[elec_ID] / maxCount * (nColors_hist-1)); // What happens if maxCount is 0?
                    burstLeadersBtnMatrix.ChangeButtonColors(elec_ind, leadersHist_colormap.Get_RGB_Color(color_ind));
                    
                    /*
                    //-------------   Debugging  -------------
                    Console.WriteLine("------------");
                    Console.WriteLine("i: " + i.ToString());
                    Console.WriteLine("Elec ind: " + elec_ind.ToString());
                    Console.WriteLine("Elec ID: " + elec_ID.ToString());
                    Console.WriteLine("Elec Label: " + main.electrodeLabels[i].label);
                    Console.WriteLine("Color Ind: " + color_ind.ToString());
                    Console.WriteLine("Leader Count: " + leaders_ID_countHistory[elec_ID]);
                    Console.WriteLine("Elec Max count: " + maxCount);
                    //-------------   Debugging  -------------
                    */

                }
            }
            Console.WriteLine("/////////////////");

            Set_nOnsets_Text(maxCount.ToString());
        }


        delegate void SetTextCallback(string text);

        private void Set_nOnsets_Text(string text)
        {
            if (txt_nOnsets.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Set_nOnsets_Text);
                txt_nOnsets.Invoke(d, new object[] { text });
            }
            else
            {
                txt_nOnsets.Text = text;
            }
        }


        private void btn_reset_Click(object sender, EventArgs e)
        {
            burstLeaders.Reset_LeadersHistory();
            txt_nOnsets.Text = "...";
            for (int i = 0; i < main.ElecsPool_inds.Count; i++)
            {
                burstLeadersBtnMatrix.ChangeButtonColors(main.ElecsPool_inds[i], burstLeadersBtnMatrix.Get_UnlockedColor());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btn_plot_leaders_Click(object sender, EventArgs e)
        {
            paintBurstLeadersHistory();

            if (plotLastBurst)
                paintLastBurstLeaders();
        }

        private void BurstLeadersForm_Load(object sender, EventArgs e)
        {

        }

        private void set_interval_Click(object sender, EventArgs e)
        {
            update_interval_s = double.Parse(txt_update_interval_s.Text);
            timer_updatePlot.Interval = update_interval_s*1000;
        }

        private void check_auto_plot_CheckedChanged(object sender, EventArgs e)
        {
            if (check_auto_plot.Checked)
                timer_updatePlot.Start();
            else
                timer_updatePlot.Stop();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_plotLastBurst.Checked)
                plotLastBurst = true;
            else
                plotLastBurst = false;
        }

        private void btn_set_nLeaders_Click(object sender, EventArgs e)
        {
          //  int nLeaders = int.Parse(txt_nLeaders.Text);
            burstLeaders.Set_nLeaders_per_burst(int.Parse(txt_nLeaders.Text));
        }

        private void btn_set_onsetWindow_Click(object sender, EventArgs e)
        {
           // double onsetWindow_s = double.Parse(txt_onsetWindow_s.Text);
            burstLeaders.Set_onsetWindowDuration_s(double.Parse(txt_onsetWindow_s.Text));
        }

        /*
        private void check_plotHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (check_plotHistory.Checked)
                plotHistory = true;
            else
                plotHistory = false;
        }
        */
    }
}
