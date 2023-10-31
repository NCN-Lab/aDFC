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

namespace OnlineSpikeDetection
{
    public partial class StimulatorForm : Form
    {
        ElecsButtonMatrix elecsButtonMatrix;
        Stimulator stimulator = main.stimulator;

        // Poisson and Regular events are quite messy.....Poisson uses the uses clock_s while Regular uses a Timer...but they are both a bit bad 
        PoissonGenerator poissonGenerator; 
        RegularGenerator regularGenerator;

        // MeaLibStimulator stimulator;

        double freq_Hz = 1;
        double minInterStimInterval_s = 0.05; 
        TextWriter tw_stimTimes;
        TextWriter tw_stimProtocol;

        AuxiliaryFunctions Aux = new AuxiliaryFunctions();

        // Stimulator Thread:
        Thread stimulatorThread;

        public StimulatorForm()
        {
            InitializeComponent();

            int nLines = 16;
            int nCols = 16;
            int side = 36;
            int x_corner = 50;
            int y_corner = 140;

            // Electrodes Matrix:
            elecsButtonMatrix = new ElecsButtonMatrix(x_corner, y_corner, nLines, nCols, side, Btn_Click, Controls, Color.Transparent, Color.Green);
            elecsButtonMatrix.unlockSelectedButton(main.stimulator.Get_StimElecs_inds());

            elecsButtonMatrix.ChangeButtonsColors(main.ElecsPool_inds.ToArray(), Color.White);

            txt_mean_rate.Text = freq_Hz.ToString();
            txt_minInterStim_s.Text = minInterStimInterval_s.ToString();
            btn_set.Enabled = false;
            btn_set_minInterStim.Enabled = false;

            if (stimulator.Get_STG_ID() == 1)
            {
                radio_STG1.Checked = true;
                radio_STG2.Checked = false;
            }
            else if (stimulator.Get_STG_ID() == 2)
            {
                radio_STG1.Checked = false;
                radio_STG2.Checked = true;
            }

        }


        private void StimulatorForm_Load(object sender, EventArgs e)
        {
          //  stimulator = main.stimulator;
            poissonGenerator = new PoissonGenerator(freq_Hz, minInterStimInterval_s);
            
            regularGenerator = new RegularGenerator(freq_Hz, minInterStimInterval_s);
            regularGenerator.Set_TimerElapsedMethod(Stimulate);
        }


        private void PoissonThread()
        {
            //if (radio_poisson.Checked) 

                while (true)
                {
                if (poissonGenerator.isEventNow(SpikeDetectionForm.clock_s))
                    stimulator.Stimulate();
                }

          /*  else if (radio_regular.Checked) 
                while (true)
                {
                    if (regularGenerator.isEventNow(SpikeDetectionForm.clock_s))
                        stimulator.Stimulate();
                }
          */
                
        }


        // Handler To Electrode Button Click:
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == elecsButtonMatrix.Get_UnlockedColor())
            {
                btn.BackColor = elecsButtonMatrix.Get_LockedColor();
                stimulator.Remove_StimElec_ind(int.Parse(btn.Name));
            }
            else
            {
                btn.BackColor = elecsButtonMatrix.Get_UnlockedColor();
                int stimElec_ind = int.Parse(btn.Name);
                stimulator.Add_StimElec_ind(stimElec_ind);

                // If is monitoring Electrode, remove from monitoring electrodes
                if (main.ElecsPool_inds.Exists(x => x == stimElec_ind))
                {
                    main.ElecsPool_inds.Remove(stimElec_ind);
                    main.ElecsPool_IDs.Remove(Aux.from_ind_to_ID(stimElec_ind));
                }

            }
            Unlock_Set_StimElecs_Button();
        }


        private void btn_set_Click(object sender, EventArgs e)
        {
            freq_Hz = double.Parse(txt_mean_rate.Text);
            poissonGenerator.Set_Lambda(freq_Hz);
            regularGenerator.Set_Frequency_Hz(freq_Hz);
            btn_set.Enabled = false;
        }


        private void txt_mean_rate_TextChanged(object sender, EventArgs e)
        {
            btn_set.Enabled = true;
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            uint status = stimulator.Connect_USB_A();
            stimulator.Disable_and_UnSet_DacMux_Full_MEA();   // Deactivate everything just in case there are lost stim electrodes in hardware
            stimulator.Enable_all_StimElecs_and_Set_DacMux(); // Activate  only the electrodes you want

            Console.WriteLine(status);

            if (radio_poisson.Checked)
            {
                stimulatorThread = new Thread(PoissonThread);
                stimulatorThread.Start();
            }
            else if (radio_regular.Checked)
                regularGenerator.StartGenerator();

            btn_start.Enabled = false;
            btn_stop.Enabled = true;

            Lock_Set_StimElecs_Button();
        }


        public void Lock_Set_StimElecs_Button()
        {
            btn_set_stimElecs.ForeColor = Color.White;
            btn_set_stimElecs.BackColor = Color.Green;
            btn_set_stimElecs.Text = "Stim Elecs Saved";
            btn_set_stimElecs.Enabled = false;
        }


        public void Unlock_Set_StimElecs_Button()
        {
            btn_set_stimElecs.Enabled = true;
            btn_set_stimElecs.BackColor = Color.Yellow;
            btn_set_stimElecs.Text = "Save Stim Elecs";
            btn_set_stimElecs.ForeColor = Color.Black;
        }
 

        private void Stimulate()
        {
            stimulator.Stimulate();
        }
 

        private void btn_stop_Click(object sender, EventArgs e)
        {
            stimulator.Disable_all_StimElecs_and_UnSet_DacMux();
            stimulator.Disconnect();

            if (radio_poisson.Checked)
                stimulatorThread.Abort();
            else
                regularGenerator.StopGenerator();

            SaveTextFiles();

            btn_start.Enabled = true;
            btn_stop.Enabled = false;
        }


        private void SaveTextFiles()
        {
            // Save Text Files
            String date = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            tw_stimTimes = new StreamWriter(date + "_StimTimes.txt");

            tw_stimProtocol = new StreamWriter(date + "_Protocol.txt");
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine("  Stim Protocol  ");
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine(" Poisson Lambda: " + freq_Hz.ToString());
            tw_stimProtocol.WriteLine(" STG ID: " + stimulator.Get_STG_ID().ToString());
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine("Stimulation Electrodes Labels:");
            Aux.from_IDs_to_labels(stimulator.Get_StimElecs_IDs()).ForEach(tw_stimProtocol.WriteLine);
            tw_stimProtocol.WriteLine("--------------------");
            tw_stimProtocol.WriteLine("Stimulation Electrodes ID:");
            stimulator.Get_StimElecs_IDs().ForEach(tw_stimProtocol.WriteLine);
            tw_stimProtocol.Close();

            poissonGenerator.Get_allEventsTime_s().ForEach(tw_stimTimes.WriteLine);
            tw_stimTimes.Close();
        }

        
        private void txt_minInterStim_s_TextChanged(object sender, EventArgs e)
        {
            btn_set_minInterStim.Enabled = true;
        }


        private void btn_set_minInterStim_Click(object sender, EventArgs e)
        {
            btn_set_minInterStim.Enabled = false;

            minInterStimInterval_s = double.Parse(txt_minInterStim_s.Text);
            poissonGenerator.Set_minInterval_s(minInterStimInterval_s);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_STG1.Checked)
            {
                stimulator.Set_STG_ID(1);
                Unlock_Set_StimElecs_Button();
            }
        }
        private void radio_STG2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_STG2.Checked)
            {
                stimulator.Set_STG_ID(2);
                Unlock_Set_StimElecs_Button();
            }
        }

        private void btn_randStimElecs_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            var shuffled_monitoringElecs = main.ElecsPool_IDs.OrderBy(item => rnd.Next());

            int n = int.Parse(txt_N_stim_elecs.Text);
            List<int> stimElecs_IDs = shuffled_monitoringElecs.Take(n).ToList();

            main.stimulator.Remove_StimElecs();
            main.stimulator.Set_StimElecs_IDs(stimElecs_IDs);

            for (int i = 0; i < stimElecs_IDs.Count; i++)
            {
                main.ElecsPool_IDs.Remove(stimElecs_IDs[i]);
                main.ElecsPool_inds.Remove(Aux.from_ID_to_ind(stimElecs_IDs[i]));
            }

            elecsButtonMatrix.ChangeAllButtonsColors(elecsButtonMatrix.Get_LockedColor());
            elecsButtonMatrix.ChangeButtonsColors(main.ElecsPool_inds.ToArray(), Color.White);
            elecsButtonMatrix.unlockSelectedButton(main.stimulator.Get_StimElecs_inds());
        }

        private void txt_N_stim_elecs_TextChanged(object sender, EventArgs e)
        {
            btn_randStimElecs.Enabled = true;
        }

        private void set_stimElecs_Click(object sender, EventArgs e)
        {
            uint status = stimulator.Connect_USB_A();
            stimulator.Disable_and_UnSet_DacMux_Full_MEA();   // Deactivate everything just in case there are lost stim electrodes in hardware
            stimulator.Enable_all_StimElecs_and_Set_DacMux(); // Activate  only the electrodes you want

            Lock_Set_StimElecs_Button();
        }

        private void radio_regular_CheckedChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = true;
        }

        private void radio_poisson_CheckedChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = true;
        }

        private void radio_control_CheckedChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
        }
    }
}
