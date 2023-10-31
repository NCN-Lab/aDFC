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
    public partial class chooseElectrodesForm : Form
    {
        Button[] allButtons;
        CheckBox[] allChecks;
        bool all = false;
        bool toUpdate = false;

        // Choose Active Electrodes
        static ActiveElecsManager activeElecsManager = new ActiveElecsManager();
        private static System.Timers.Timer mean_FR_timer;
        int timer_interval = 5000;
        bool auto_mode = false;

        ColorMap colorMap;
        int nColors = 100;
        ElecsButtonMatrix elecsButtonMatrix; // Matrix of electrodes buttons
        AuxiliaryFunctions Aux = new AuxiliaryFunctions();

        public chooseElectrodesForm()
        {              
            int nLines = 16;
            int nCols = 16;
            int side = 36;
            int x_corner = 30;
            int y_corner = 90;
            
            InitializeComponent();

            // Electrodes Matrix:
            elecsButtonMatrix = new ElecsButtonMatrix(x_corner, y_corner, nLines, nCols, side, Btn_Click, Box_CheckedChanged, Controls, Color.Transparent, Color.White);
            elecsButtonMatrix.unlockSelectedButton(main.ElecsPool_inds);
            allButtons = elecsButtonMatrix.Get_allButtons();
            allChecks = elecsButtonMatrix.Get_allChecks();

            FormClosed += new FormClosedEventHandler(My_FormClosed);

            // ColorMap:
            colorMap = new ColorMap(nColors, "GreenRed");
            paint_electrodes();

            txt_FR_thresh.Text = activeElecsManager.Get_FR_Thresh_Hz().ToString();
            txt_update_s.Text = (timer_interval / 1000).ToString();
            txt_min_FR.Text = txt_FR_thresh.Text + " Hz";

            // Timer:
            mean_FR_timer = new System.Timers.Timer(timer_interval);
            mean_FR_timer.Elapsed += UpdateMeanFiringRate;
            mean_FR_timer.AutoReset = true;

            // Timer buttons:
            btn_set_auto_interval.Enabled = false;
            txt_update_s.Enabled = false;

            // Colorbar 
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Refresh();
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int hight = 500;
            Point startPoint = new Point(0, hight);
            Point endPoint = new Point(0, 0);

            LinearGradientBrush lgb =
                new LinearGradientBrush(startPoint, endPoint, colorMap.Get_RGB_Color(1), colorMap.Get_RGB_Color(nColors-1));
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, 0, 0, hight, hight);
        }
        

        // Handler To Electrode Button Click:
        private void Btn_Click(object sender, EventArgs e)
        {        
            Button btn = (Button)sender;
            if (btn.BackColor == elecsButtonMatrix.Get_UnlockedColor())
                btn.BackColor = elecsButtonMatrix.Get_LockedColor();
            else
                btn.BackColor = elecsButtonMatrix.Get_UnlockedColor();

            Btn_updateWarning();
        }

        // Handler To Electrode Line/Column CheckBox:
        private void Box_CheckedChanged(object sender, EventArgs e)
        {
            Btn_updateWarning();

            CheckBox box = ((CheckBox)sender);
            string name = box.Name;
            string type = name.Substring(0, 3);


            if (type == "num")
            {
                int number = int.Parse(name.Substring(4, 2));

                if (box.Checked)
                {
                    // Look for elec in
                    for (int i = 0; i < main.electrodeLabels.Count; i++)
                    {
                        if (number == main.electrodeLabels[i].number)
                        {
                            allButtons[i].BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    // Look for elec in
                    for (int i = 0; i < main.electrodeLabels.Count; i++)
                    {
                        if (number ==  main.electrodeLabels[i].number)
                        {
                            allButtons[i].BackColor = Color.Transparent;
                        }
                    }
                }
            }
            else
            {
                string letter = name.Substring(4, 1);

                if (box.Checked)
                {
                    // Look for elec in
                    for (int i = 0; i < main.electrodeLabels.Count; i++)
                    {
                        if (letter == main.electrodeLabels[i].letter.ToString())
                        {
                            allButtons[i].BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    // Look for elec in
                    for (int i = 0; i < main.electrodeLabels.Count; i++)
                    {
                        if (letter == main.electrodeLabels[i].letter.ToString())
                        {
                            allButtons[i].BackColor = Color.Transparent;
                        }
                    }
                }
            }
        }


        void My_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateMonitoringElecs();
        }

        private void UpdateMonitoringElecs()
        {
            main.ElecsPool_inds.Clear();
            main.ElecsPool_IDs.Clear();

            for (int i = 0; i < allButtons.Length; i++)
            {
                if (allButtons[i].BackColor != Color.Transparent)
                {
                    main.ElecsPool_inds.Add(i);
                    main.ElecsPool_IDs.Add(main.electrodeLabels[i].id);
                }
            }
        }

        private void check_all_CheckedChanged(object sender, EventArgs e)
        {        
            if (all)
            {
                all = false;
                for (int i = 0; i < allButtons.Length; i++)
                    allButtons[i].BackColor = Color.Transparent;    

                for (int i = 0; i < allChecks.Length; i++)
                    allChecks[i].Checked = false;
            }

            else
            {
                all = true;
                for (int i = 0; i < allButtons.Length; i++)
                    allButtons[i].BackColor = Color.White;

                for (int i = 0; i < allChecks.Length; i++)
                    allChecks[i].Checked = true;
            }
            Btn_updateWarning();
        }

        // Automatic Timer Update 
        private void UpdateMeanFiringRate(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Update!");
            UpdateActiveElecs();
        }


        private void check_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (auto_mode)
            {
                auto_mode = false;
                txt_update_s.Enabled = false;
                btn_set_auto_interval.Enabled = false;
                mean_FR_timer.Stop();
            }
            else
            {
                auto_mode = true;
                txt_update_s.Enabled = true;
                mean_FR_timer.Start();
            }
        }


        private void txt_update_s_TextChanged(object sender, EventArgs e)
        {
            btn_set_auto_interval.Enabled = true;
        }


        private void btn_getActiveElecs_Click(object sender, EventArgs e)
        {
            UpdateActiveElecs();
        }


        private void btn_set_auto_interval_Click(object sender, EventArgs e)
        {
            timer_interval = int.Parse(txt_update_s.Text) * 1000;
            mean_FR_timer.Interval = timer_interval;
            btn_set_auto_interval.Enabled = false;
        }


        private void paint_electrodes()
        {
            double[] mean_FRs = activeElecsManager.Get_mean_FRs();
            double mean_FR_i;
            double max_FR = mean_FRs.Max();

            double frac;
            Color RGB;
            if (max_FR > 0)
            {
                for (int i = 0; i < main.ElecsPool_inds.Count; i++)
                {
                    int elec_ID = main.ElecsPool_IDs[i];
                    mean_FR_i = mean_FRs[elec_ID];
                    if (mean_FR_i > activeElecsManager.Get_FR_Thresh_Hz())
                    {
                        frac = mean_FR_i / max_FR;
                        RGB = colorMap.Get_RGB_Color(frac);
                    }
                    else                    
                        RGB = colorMap.Get_RGB_Color(0);

                    allButtons[main.ElecsPool_inds[i]].BackColor = RGB;
                }
            }
        }


        private void UpdateActiveElecs()
        {
            int[] elecSpkCounts = SpikeDetectionForm.SpkDetector.Get_ElecSpkCounts();
            double t = SpikeDetectionForm.clock_s;
            activeElecsManager.Calculate_Mean_FR(elecSpkCounts, t);
            paint_electrodes();

            double max_FR = activeElecsManager.Get_mean_FRs().Max();

            double rounded_max_FR = Math.Round(max_FR * 10) / 10;
            Set_Max_FR_Text(rounded_max_FR.ToString() + " Hz");
        }

        delegate void SetTextCallback(string text);

        private void Set_Max_FR_Text(string text)
        {
            if (txt_max_FR.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Set_Max_FR_Text);
                txt_max_FR.Invoke(d, new object[] { text });
            }
            else
                txt_max_FR.Text = text;
        }


        private void bnt_reset_FRs_Click(object sender, EventArgs e)
        {
            SpikeDetectionForm.SpkDetector.Reset_Spk_Counts();
            activeElecsManager.Reset_FR(SpikeDetectionForm.clock_s);
        }

        private void txt_FR_thresh_TextChanged(object sender, EventArgs e)
        {
            btn_set_FR_thresh.Enabled = true;
        }

        private void btn_set_FR_thresh_Click(object sender, EventArgs e)
        {
            double thresh = double.Parse(txt_FR_thresh.Text);
            activeElecsManager.Set_FR_Thresh_Hz(thresh);
            btn_set_FR_thresh.Enabled = false;
            txt_min_FR.Text = txt_FR_thresh.Text + " Hz";
        }
        
        private void label2_Click(object sender, EventArgs e){}
        
        private void btn_setMoni_elecs_Click(object sender, EventArgs e)
        {
            toUpdate = false;
            btn_setMoni_elecs.Enabled = false;
            btn_setMoni_elecs.BackColor = Color.Green;
            btn_setMoni_elecs.Text = "All Good";
            btn_setMoni_elecs.ForeColor = Color.White;
            UpdateMonitoringElecs();
        }
        
        private void Btn_updateWarning()
        {
            toUpdate = true;
            btn_setMoni_elecs.Enabled = true;
            btn_setMoni_elecs.BackColor = Color.Yellow;
            btn_setMoni_elecs.Text = "Click Here!";
            btn_setMoni_elecs.ForeColor = Color.Black;
        }

        private void btn_chooseActive_Click(object sender, EventArgs e)
        {
            main.ElecsPool_inds = activeElecsManager.Get_ActiveElec_inds();
            main.ElecsPool_IDs  = activeElecsManager.Get_ActiveElec_IDs();

            for (int i = 0; i < allButtons.Length; i++)
            {
                allButtons[i].BackColor = Color.Transparent;
            }

            paint_electrodes();
        }

        private void txt_min_FR_Click(object sender, EventArgs e)
        {

        }

        private void check_well_A_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 2 * 42 + 2;
            int last_ID = 3 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_A.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void check_well_B_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 3 * 42 + 2;
            int last_ID = 4 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_B.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void check_well_C_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 4 * 42 + 2;
            int last_ID = 5 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_C.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void check_well_D_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 5 * 42 + 2;
            int last_ID = 6 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_D.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void check_well_E_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 0 * 42 + 2;
            int last_ID = 1 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_E.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void check_well_F_CheckedChanged(object sender, EventArgs e)
        {
            List<int> elec_IDs = new List<int>();
            int first_ID = 1 * 42 + 2;
            int last_ID = 2 * 42 + 2;
            for (int ID = first_ID; ID < last_ID; ID++)
                elec_IDs.Add(ID);

            if (check_well_F.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(elec_IDs));
        }

        private void check_well_A_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(0, check_well_A_9);
        }

        private void check_well_B_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26, check_well_B_9);
        }

        private void check_well_C_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26*2, check_well_C_9);
        }

        private void check_well_D_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26*3, check_well_D_9);
        }

        private void check_well_E_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26 * 4, check_well_E_9);
        }


        private void check_well_F_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26 * 5, check_well_F_9);
        }

        private void check_well_G_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26 * 6, check_well_G_9);
        }

        private void check_well_H_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26 * 7, check_well_H_9);
        }

        private void check_well_J_9_CheckedChanged(object sender, EventArgs e)
        {
            select_9_well(26 * 8, check_well_J_9);
        }

        private void select_9_well (int first_index, CheckBox check_well_9)
        {
            List<int> well_ids = new List<int>();
            for (int i = first_index; i < first_index + 26; i++)
                well_ids.Add(main.ids_9well[i] + 2);

            if (check_well_9.Checked)
                elecsButtonMatrix.unlockSelectedButton(Aux.from_IDs_to_inds(well_ids));
            else
                elecsButtonMatrix.lockSelectedButton(Aux.from_IDs_to_inds(well_ids));
        }
    }
}