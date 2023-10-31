using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Mcs.Usb;


namespace OnlineSpikeDetection
{
    class EffectiveStimFinder
    {
        // devices:
        CMeaUSBDeviceNet mea = new CMeaUSBDeviceNet();  // MEA
        Stimulator stimulator = new Stimulator();
        int nChannels = 256;
        int Samplerate = 10000;

        // Read Data Variables:
        int[] data;
        int frames_read;
        const int nFrames = 1;

        int[][] stimElecs_ids; // dimension # stim elec; dimension 2: well
        List<int>[] monitoringElecs_ids; // one array per well
        List<double>[] stimResponses_nElecs; // Avg number of responsive electrodes for each StimElec in each  well
        List<double>[] stimResponses_nSpikes; // Avg number of response spikes for each StimElec in each well
        int[] spkCountVector; // vector that stores the number of response spks of each electrode

        int nStimElecs_per_well; // all wells must have the same number of stim elecs!!
        int round = 0; // round --> 1:nStimElecs_per_well

        double response_window_s = 0.5; // duration of response after stimulus
        double clock_s = 0; // duration inside response window
        int clock = 0;
        double stim_artifact_s = 0.005; // time to ignore after stimulus

        int nWells;
        int nTrials;

        Timer timer = new Timer();
        
        Spike_Detector spkDetector = new Spike_Detector();


        public EffectiveStimFinder(int n_wells, int[] stim_elecs_ids, int[] monitoring_elecs_ids, int n_trials, int inter_stim_interval_s)
        {
            nWells = n_wells;
            int nStimElecs = stim_elecs_ids.Count();
            nStimElecs_per_well = nStimElecs / nWells;

            stimElecs_ids = new int[nStimElecs_per_well][];
            monitoringElecs_ids = new List<int>[nWells];
            stimResponses_nElecs = new List<double>[nWells];
            stimResponses_nSpikes = new List<double>[nWells];

            Set_StimElecs(stim_elecs_ids);
            Set_MonitoringElecs(monitoring_elecs_ids);

            nTrials = n_trials;
            timer.Interval = inter_stim_interval_s*1000;
            timer.Elapsed += Trigger_Stimulation;
            timer.AutoReset = true;

            mea.ChannelDataEvent += new OnChannelData(mea_ChannelDataEvent);
        }

        public void Start(CMcsUsbListEntryNet mea_device, int Samplerate)
        {
            // Connect to MEA device via USB-B:
            mea.Connect(mea_device); // 

            // Connect to Stimulator via USB-A:
            stimulator.Connect_USB_A();

            // Set Data Acquisition:
            int ChannelsInBlock;
            mea.SetSamplerate(Samplerate, 1, 0);
            mea.SetNumberOfAnalogChannels((uint)nChannels, 0, 0, 0, 0); // Read raw data
            mea.EnableChecksum(true, 0);
            mea.SetDataMode(DataModeEnumNet.Signed_32bit, 0);
            ChannelsInBlock = mea.GetChannelsInBlock(0);
            mea.SetSelectedData(nChannels, Samplerate, 1, SampleSizeNet.SampleSize32Signed, ChannelsInBlock);

            timer.Start();
        }


        private void Trigger_Stimulation(Object source, ElapsedEventArgs e)
        {
            // Start Dacq
            mea.StartDacq();

            // Set initial Stimulation Electrodes
            stimulator.Set_StimElecs_IDs(stimElecs_ids[round].ToList<int>());
            stimulator.Disable_and_UnSet_DacMux_Full_MEA();   // Deactivate everything just in case there are lost stim electrodes in hardware
            stimulator.Enable_all_StimElecs_and_Set_DacMux(); // Activate  only the electrodes you want

            stimulator.Stimulate();

            round++;

            if (round >= nStimElecs_per_well)
            {
                timer.AutoReset = false;
                timer.Stop();
                timer.Close();
            }
        }


        // Calculations are done here!
        void mea_ChannelDataEvent(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                if (clock_s < response_window_s)
                {
                    // Read Data:
                    data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                    // Advance clock:
                    clock++;
                    clock_s = (double)clock / Samplerate * nFrames;

                    // Spike Detection:
                    if (clock_s > stim_artifact_s)
                    {
                        List<int> spk_elec_IDs = spkDetector.Spike_count(data, clock_s, nFrames);

                        // Add spikes to the spike count vector:
                        for (int i = 0; i < spk_elec_IDs.Count(); i++)                  
                            spkCountVector[spk_elec_IDs[i]]++;  
                    }
                }
                else
                {
                    clock = 0;
                    clock_s = 0;
                    mea.StopDacq();


                    // 

                }
            }
        }


        private void Set_StimElecs(int[] stim_elecs_ids)
        {

                int elecs_per_well = 42; // 6 well by default
                int[] stimElec_aux_inds = new int[nWells];

                for (int stimElec_nr = 0; stimElec_nr < nStimElecs_per_well; stimElec_nr++)
                {
                    stimElecs_ids[stimElec_nr] = new int[nWells];
                }
                                

                for (int well = 0; well < nWells; well++)
                {
                    monitoringElecs_ids[well] = new List<int>();
                    stimResponses_nElecs[well] = new List<double>();
                    stimResponses_nSpikes[well] = new List<double>();
                }


                if (nWells == 9)
                    elecs_per_well = 26;

            // Add stimulation electrode of each well
            int nStimElecs = stim_elecs_ids.Count();
            for (int stimElec_i = 0; stimElec_i < nStimElecs; stimElec_i++)
                {
                    int well = Convert.ToInt32(Math.Floor(Convert.ToDouble(stim_elecs_ids[stimElec_i]) / elecs_per_well));
                    stimElecs_ids[stimElec_aux_inds[well]][well] = stim_elecs_ids[stimElec_i];
                    stimElec_aux_inds[well]++;
                }
        }

        private void Set_MonitoringElecs(int[] monitoring_elecs_ids)
        {
            if (nWells == 1)
            {
                monitoringElecs_ids[0] = monitoring_elecs_ids.ToList();
            }
            else
            {
                int nMonitoring_elecs = monitoring_elecs_ids.Count();
                int elecs_per_well = 42; // 6 well by default
               
                if (nWells == 9)
                    elecs_per_well = 26; 

                // Add monitoring electrode of each well
                for (int elec_i = 0; elec_i < nMonitoring_elecs; elec_i++)
                {
                    int well = Convert.ToInt32(Math.Floor(Convert.ToDouble(monitoring_elecs_ids[elec_i]) / elecs_per_well));
                    monitoringElecs_ids[well].Add(monitoring_elecs_ids[elec_i]);
                }
            }
        }

    }
}
