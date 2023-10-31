using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mcs.Usb;
using System.Collections;
using System.Threading;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace OnlineSpikeDetection
{
    public partial class SpikeDetectionForm : Form
    {
        // Choose Electrodes Vector:
        List<int> elec_idxs = main.ElecsPool_inds; // A2 = 0

        // Nº Channels:
        const int nChannels = 256; //64;
        const int Checksum = 0;   // whats this?? 2 in github example
        const int TotalChannels = nChannels + Checksum;

        // Sampling Rate:
        const int Samplerate = 10000; // 50000;
        const double dt = 1 / (double)Samplerate;
        const int nFrames = 1;
        
        // Read Data Variables:
        int[] data;
        int frames_read;
        int clock;
        public static double clock_s = 0;
        int nSpikes = 0;
        double chart_clock = 0;
        int chart_nSpikes = 0;

        bool detectingSpikes = false;
        int controlOn = 0;

        // Chart
        double past_window = 10; // sec
        double future_window = 2; // sec
        double max_y = 30;
        bool moveWindow = false;

        // Initiatize Devices:
        CMeaUSBDeviceNet mea = new CMeaUSBDeviceNet();  // MEA
        Stimulator stimulator;

        // Connections/Devices Available:
        CMcsUsbListNet UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB); // List of USB connections (A and/or B)

        // Spike Detector:
        public static Spike_Detector SpkDetector = new Spike_Detector();
        double deadtime_s = 0.003;  
        double spkThresh_uV = 50;

        // to remore stimulation artifact:
        bool remove_stim_artifact = true;
        double stim_artifact_s = 0.005; 
        double last_stim_s = 0;        

        // Firing Rate Object
        FiringRater FR;
        int nElecs;
        double fireRate_Hz = 0; // Hz 
        String kernelType = "square";

        // Burst Finder
        BurstFinder burstFinder;
        double IBI;

        // Burst Leaders
        bool withBurstLeader = false;
        int nLeaders_per_burst = 3;
        double onsetWindowDuration_s = 0.1;
        public static BurstLeaders burstLeaders;

        // Controller:
        bool adaptive = true;
        DelayedController Controller;     
        double osclt_T = 2;
        double maxFreq_Hz = 10; // Maximum stimulation frequency

        int stimulate; // 0: no stim; 1: stim now
        int chart_stimulate;
        int chart_burst;

        bool dualmode = false;

        // Mean Stimulation Freq:
        double start_control_t;
        int nStims = 0;
        double avg_Stim_Hz = 0;

        // Text Writer:
        // string folderName = Directory.GetCurrentDirectory();
        TextWriter tw; // control variables
        TextWriter tw_header; // header
        TextWriter tw_parameters;
        TextWriter tw_monitorElecs;
        TextWriter tw_burstLeaders;
        TextWriter tw_burstLeaders_counts;
        TextWriter tw_refChannel;

        TextWriter tw_timer;
        TextWriter tw_timer_parameters;
        long lastSamp_ticks = 0; // time of the last sampling
        double samplingInterval_ticks;

        // Save Data:
        bool saveData = true;

        public static readonly bool IsHighResolution;

        public SpikeDetectionForm()
        {
            InitializeComponent();
            RefreshDeviceList();
             mea.ChannelDataEvent += new OnChannelData(mea_ChannelDataEvent);
            //mea.ChannelDataEvent += new OnChannelData(mea_ChannelDataEvent_TestLatency_4);

            // Set Parameters Text box:
            if (main.thresholder.WithAutoThresholds())
                txt_thresh_uV.Text = "Auto";
            else
                txt_thresh_uV.Text = spkThresh_uV.ToString();

            txt_period.Text = osclt_T.ToString();
            txt_burstThresh.Text = main.burstThresh_Hz.ToString();
            txt_minIBI.Text = main.minIBI_s.ToString();
            txt_filter.Text = main.filter.Get_FreqCut_Hz().ToString();
            txt_delay_frac.Text = main.delay_frac.ToString();
            txt_stimGain.Text = main.stimGain.ToString();
            txt_past_window.Text = past_window.ToString();
            txt_future_window.Text = future_window.ToString();
            txt_FR_window.Text = main.FR_window_s.ToString();
            txt_max_y.Text = max_y.ToString();
            txt_min_stimFreq_thresh.Text = main.minSimFreq_Hz.ToString();

            btn_set_spk_thresh.Enabled = false;
            btn_fix_mode.Enabled = true;
            btn_set_BurstThresh.Enabled = false;
            btn_set_minIBI.Enabled = false;
            btn_set_delay_frac.Enabled = false;
            btn_set_stimGain.Enabled = false;
            btn_set_filter.Enabled = false;
            btn_set_past_window.Enabled = false;
            btn_set_future_window.Enabled = false;
            btn_set_FR_window.Enabled = false;
            btn_set_max_y.Enabled = false;
            btn_set_min_stimFreq_thresh.Enabled = false;

            btn_adaptive_mode.BackColor = Color.Green;

            txt_folder.Text = main.folderName;
            check_savaData.Checked = saveData;
        }

        private void RefreshDeviceList()
        {
            // UsbDeviceList.Initialize();
            cbDeviceList.Items.Clear(); // cbDeviceList is a combo list with showing th edevices available

            // Add the devices available to the combo list cbDeviceList
            for (uint i = 0; i < UsbDeviceList.Count; i++)
            {
                cbDeviceList.Items.Add(UsbDeviceList.GetUsbListEntry(i));
            }

            // If there is at least 1 device in list, select the first in the combo list:
            if (cbDeviceList.Items.Count > 0)
            {
                cbDeviceList.SelectedIndex = 0;
            }
        }

        private void SpikeDetectionForm_Load(object sender, EventArgs e)
        {
            //------------- Spike Detector ---------------
            // Set Detection Electrodes:
            SpkDetector.set_elecs_idx(elec_idxs.ToArray());

            if (main.thresholder.WithAutoThresholds())
                // Set Auto Thresholds:
                SpkDetector.set_thresholds(main.thresholder.Get_Thresholds_uV());
            else
                // Set Manual Thresholds:
                SpkDetector.set_thresholds(spkThresh_uV);

            // Set Deadtime:
            SpkDetector.set_deadtime(deadtime_s);
            //------------- Spike Detector ---------------


            // Initialize Firing Rate Calculator
            nElecs = elec_idxs.Count();
            FR = new FiringRater(dt,  main.FR_window_s, kernelType, nElecs);

            // Initialize Burst Finder:
            burstFinder = new BurstFinder(main.burstThresh_Hz, main.minIBI_s);

            // Initialize Burst Leaders Detector:
            burstLeaders = new BurstLeaders(nLeaders_per_burst, onsetWindowDuration_s, nChannels);

            // Initialize Controller:
            Controller = new DelayedController(osclt_T, main.delay_frac, main.stimGain, dt, maxFreq_Hz);

            //Stimulator:
            stimulator = main.stimulator;
        }


        // Calculations are done here!
        void mea_ChannelDataEvent(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                // Measure sampling Period:
                long new_samp_ticks = Stopwatch.GetTimestamp();
                samplingInterval_ticks = new_samp_ticks - lastSamp_ticks;
                lastSamp_ticks = new_samp_ticks;
                
                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // Advance clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;
                
                // Spike Detection:
                if (!remove_stim_artifact || (clock_s > last_stim_s + stim_artifact_s)) 
                {
                    List<int> spk_elec_IDs = SpkDetector.Spike_count(data, clock_s, nFrames);
                    nSpikes = spk_elec_IDs.Count();

                    if (nSpikes > 0)
                    {
                        // Add spike to Firing Rate Calculator:
                        FR.AddSpikes(nSpikes, clock_s);

                        // Add Spks to Burst Leaders Candidates
                        if (withBurstLeader)
                            burstLeaders.AddSpks_leaderCandidates(spk_elec_IDs, clock_s);

                        // For plots:
                        chart_clock = clock_s;
                        chart_nSpikes = nSpikes;
                    }                
                }

                // Calculate Instant Firing Rate:
                fireRate_Hz = FR.CalcFiringRate(clock_s);

                if (withBurstLeader)
                    // Move Window of Burst Leaders:
                    burstLeaders.MoveBurstLeadersWindow(clock_s);

                // Detect Burst:
                double IBI_temp = burstFinder.DetectBurst(fireRate_Hz, clock_s);

                if (burstFinder.BurstDetected() == 1)
                {
                    IBI = IBI_temp;

                    if (adaptive)
                        // Update Periodicity of Controller:
                        Controller.UpdatePeriodicty(IBI);
                    else
                        Controller.UpdatePeriodicty(Controller.Get_Period_s());

                    if (withBurstLeader)
                    {
                        // Add Burst Leaders to the list
                        burstLeaders.AddBurstLeaders();

                        // Write Burst Leaders in file
                        int[] last_burstLeaders = burstLeaders.Get_last_BurstLeaders_IDs();

                        for (int i = 0; i < last_burstLeaders.Count(); i++)
                        {
                            // CONVERT ID TO ELECTRODE LABELS
                            tw_burstLeaders.Write(main.elecLabelsArray[last_burstLeaders[i]]);
                            tw_burstLeaders.Write("\t");
                        }
                        tw_burstLeaders.WriteLine();
                    }

                    // For plots:
                    chart_burst = 1;      
                }

                stimulate = Controller.CalcDelayedFeedback(fireRate_Hz, clock_s);

                // Stimulation:
                if (stimulate == 1 && controlOn == 1)
                {
                    chart_stimulate = 1;
                    stimulator.Stimulate();

                    // If in dual Mode, alternate between STG 1 and STG 2 
                    if (dualmode) { 
                        if (stimulator.Get_STG_ID() == 1)
                            stimulator.Set_STG_ID(ElectrodeDacMuxEnumNet.Stg2);
                        else
                            stimulator.Set_STG_ID(ElectrodeDacMuxEnumNet.Stg1);
                    }

                    nStims++;
                    last_stim_s = clock_s;
                }
                
                if (saveData)
                {     // Write to File:
                    tw.WriteLine(fireRate_Hz + "\t" + Controller.Get_oscillator_value() + "\t" + Controller.Get_delayed_oscillator() + "\t" +
                    Controller.Get_FB_StimFreq_Hz() + "\t" + Controller.Get_Period_s() + "\t" + stimulate + "\t" + controlOn + "\t" + burstFinder.BurstDetected());
               
                    if (clock_s < 5) // save first 5 secs of reference channel to align with raw data from h5
                        tw_refChannel.WriteLine(clock_s + "\t" + data[2] * 0.0307);
               
                    long calculations_tick = Stopwatch.GetTimestamp() - new_samp_ticks;
                    tw_timer.WriteLine(samplingInterval_ticks + "\t" + calculations_tick);
                }

                // Check if window should move:
                Math.DivRem(clock, Samplerate * (int)future_window / 2, out int rest);
                if (rest == 0)
                    moveWindow = true;
            }
        }


        // ---------------------------------------- TESTS ------------------------------------------
        // Test Feedback Latency 1 -test latency of spike detection and stimulation
        void mea_ChannelDataEvent_TestLatency_1(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {/*
            if (numFrames >= nFrames)
            {
                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;

                // Spike Count:
                nSpikes = SpkDetector.Spike_count(data, clock_s, nFrames);

                if (nSpikes == nElecs)
                {
                    cStgDevice.SendStart(2); // Start Trigger 2 (associated with STG 2)
                }

                if (nSpikes > 0)
                {
                    // Debugging! //
                    Console.Write("Nr Spikes: ");
                    Console.WriteLine(nSpikes);
                    Console.Write("Clock: ");
                    Console.WriteLine(clock_s);
                    Console.WriteLine("----------");
                }
            }*/
        }

        // Test Feedback Latency 2 - test latency with all the Controller Code
        void mea_ChannelDataEvent_TestLatency_2(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {/*
            if (numFrames >= nFrames)
            {
                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;

                // Spike Count:
                nSpikes = SpkDetector.Spike_count(data, clock_s, nFrames);


                if (nSpikes == nElecs)
                {
                    chart_clock = clock_s;
                    chart_nSpikes = nSpikes;

                    // Add spike to Firing Rate Calculator:
                    FR.AddSpikes(nSpikes, clock_s);
                    cStgDevice.SendStart(2); // Start Trigger 2 (associated with STG 2)
                }

                // Calculate Instant Firing Rate:
                fireRate_Hz = FR.CalcFiringRate(clock_s);

                // Controller:
                stimulate = Controller.CalcDelayedFeedback(fireRate_Hz, clock_s);
                if (stimulate == 1)
                {
                    chart_stimulate = 1;                    
                }


                // Write to File:
                tw.WriteLine(fireRate_Hz + "\t" + Controller.Get_oscillator_value() + "\t" + Controller.Get_delayed_oscillator() + "\t" +
                    Controller.Get_FB_StimFreq_Hz() + "\t" + Controller.Get_Period_s() + "\t" + stimulate + "\t" + controlOn + "\t" + Controller.InBurst());

            }*/
        }

        // Test Start Latency of Auto Start by alignement of Raw Voltages - Test latency of sending stimulus
        void mea_ChannelDataEvent_TestLatency_3(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;

                // Spike Count:
                List<int> spk_elec_IDs = SpkDetector.Spike_count(data, clock_s, nFrames);
                nSpikes = spk_elec_IDs.Count();

                int spike = 0;
                if (nSpikes > 0)
                    spike = 1;

                if (clock_s % 1 == 0)
                {
                    //cStgDevice.SendStart(1);
                    stimulator.Stimulate();
                    stimulate = 1;
                }
                else
                    stimulate = 0;

                double V_data_uV = data[2] * 0.03070831298828125; // G13

                // Write to File:
                tw.WriteLine(V_data_uV + "\t" + spike + "\t" + stimulate );
            }
        }

        // Check duration of detecting spikes in all MEA. does it take less than 0.0001s? Kinda :D
        void mea_ChannelDataEvent_TestLatency_4(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                long start = Stopwatch.GetTimestamp();


                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // Advance clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;

                // Spike Detection:
                List<int> spk_elec_IDs = SpkDetector.Spike_count(data, clock_s, nFrames);
                nSpikes = spk_elec_IDs.Count();

                if (nSpikes > 0)
                {
                    // Add spike to Firing Rate Calculator:
                    FR.AddSpikes(nSpikes, clock_s);

                    // Add Spks to Burst Leaders Candidates
                    if (withBurstLeader)
                        burstLeaders.AddSpks_leaderCandidates(spk_elec_IDs, clock_s);

                    // For plots:
                    chart_clock = clock_s;
                    chart_nSpikes = nSpikes;
                }

                // Calculate Instant Firing Rate:
                fireRate_Hz = FR.CalcFiringRate(clock_s);

                if (withBurstLeader)
                    // Move Window of Burst Leaders:
                    burstLeaders.MoveBurstLeadersWindow(clock_s);

                // Detect Burst:
                double IBI_temp = burstFinder.DetectBurst(fireRate_Hz, clock_s);


                if (burstFinder.BurstDetected() == 1)
                {
                    IBI = IBI_temp;
                    // Update Periodicity of Controller:
                    Controller.UpdatePeriodicty(IBI);

                    if (withBurstLeader)
                        // Add Burst Leaders to the list
                        burstLeaders.AddBurstLeaders();

                    // For plots:
                    chart_burst = 1;

                    // Write Burst Leaders in file
                    int[] last_burstLeaders = burstLeaders.Get_last_BurstLeaders_IDs();

                    for (int i = 0; i < last_burstLeaders.Count(); i++)
                    {
                        // CONVERT ID TO ELECTRODE LABELS
                        tw_burstLeaders.Write(main.elecLabelsArray[last_burstLeaders[i]]);
                        tw_burstLeaders.Write("\t");
                    }
                    tw_burstLeaders.WriteLine();
                }

                stimulate = Controller.CalcDelayedFeedback(fireRate_Hz, clock_s);


                // Stimulation:
                if (stimulate == 1 && controlOn == 1)
                {
                    chart_stimulate = 1;

                    stimulator.Stimulate();

                    // If in dual Mode, alternate between STG 1 and STG 2 
                    if (dualmode)
                    {
                        if (stimulator.Get_STG_ID() == 1)
                            stimulator.Set_STG_ID(ElectrodeDacMuxEnumNet.Stg2);
                        else
                            stimulator.Set_STG_ID(ElectrodeDacMuxEnumNet.Stg1);
                    }

                    nStims++;
                }

                if (saveData)
                {     // Write to File:
                    tw.WriteLine(fireRate_Hz + "\t" + Controller.Get_oscillator_value() + "\t" + Controller.Get_delayed_oscillator() + "\t" +
                    Controller.Get_FB_StimFreq_Hz() + "\t" + Controller.Get_Period_s() + "\t" + stimulate + "\t" + controlOn + "\t" + burstFinder.BurstDetected());

                    if (clock_s < 10)
                        tw_refChannel.WriteLine(data[2] * 0.0307);
                }


                long end = Stopwatch.GetTimestamp();
                tw_timer.WriteLine(end - start);               
            }
        }

        // Check Sampling intervals
        void mea_ChannelDataEvent_TestSamplingIntervals(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                // Measure sampling Period:
                long new_samp_ticks = Stopwatch.GetTimestamp();
                samplingInterval_ticks = new_samp_ticks - lastSamp_ticks;
                lastSamp_ticks = new_samp_ticks;

                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // Advance clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;
               
                if (saveData)
                {  
                    if (clock_s < 10) // save first 5 secs of reference channel to align with raw data from h5
                        tw_refChannel.WriteLine(clock_s + "\t" + data[2] * 0.0307);

                    long calculations_tick = Stopwatch.GetTimestamp() - new_samp_ticks;
                    tw_timer.WriteLine(samplingInterval_ticks + "\t" + calculations_tick);
                }
            }
        }
        // ----------------------------------------- TESTS -----------------------------------------



        // "Start Spike Detection" Button       
        private void button1_Click(object sender, EventArgs e)
        {

            // Restart stuff:
            clock = 0;
            clock_s = 0;
            fireRate_Hz = 0;
            SpkDetector.Restart_Clock();
            burstFinder.Restart();


            btn_StopDacq.Enabled = true;
            btn_StartDacq.Enabled = false;
            detectingSpikes = true;

            
            // text Writer:
            String date = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            tw = new StreamWriter(main.folderName + "\\" + date + "_ControlVariables.txt");


            tw_header = new StreamWriter(main.folderName + "\\" + date + "_Header.txt");
            tw_header.WriteLine("FireRate[Hz]" + "\t" + "Oscillator" + "\t" + "Delayed Oscillator" + "\t" + "StimFreq [Hz]" + "\t" + "Osc Period [s]" + "\t" + "Stimulus" + "\t" + "Control ON/OFF" + "\t" + "Burst Detection");

            tw_parameters = new StreamWriter(main.folderName + "\\" + date + "_Parameters.txt");
            tw_parameters.WriteLine("--------------------");
            tw_parameters.WriteLine("Initial Parameters:");
            tw_parameters.WriteLine("--------------------");
            tw_parameters.WriteLine("HP Filter [Hz]: " + main.filter.Get_FreqCut_Hz());
            tw_parameters.WriteLine("Sampling Rate [Hz]: " + Samplerate);
            if (main.thresholder.WithAutoThresholds())
                tw_parameters.WriteLine("Auto Spike Threshold - n STDs: " + main.thresholder.Get_nSTDs_thresh().ToString());
            else
                tw_parameters.WriteLine("Manual Spike Threshold [uV]: " + spkThresh_uV.ToString());
            tw_parameters.WriteLine("Spike deadtime [s]: " + SpkDetector.Get_deadtime());
            tw_parameters.WriteLine("FR window duration [s]: " +  main.FR_window_s);
            tw_parameters.WriteLine("Burst Threshold [Hz]: " + burstFinder.Get_BurstThresh_Hz());
            tw_parameters.WriteLine("Min IBI [s]: " + burstFinder.Get_min_IBI_s());
            tw_parameters.WriteLine("Delay Fraction: " + Controller.Get_Delay_Fraction());
            tw_parameters.WriteLine("Stimulation Gain: " + Controller.Get_Stim_Gain());
            tw_parameters.WriteLine("Min Stimulation Freq Thresh [Hz]: " + Controller.Get_min_StimFreq_Hz().ToString());            
            tw_parameters.WriteLine("Monitoring Electrodes - order: 2 --> G13; 85 --> A2");


            tw_monitorElecs = new StreamWriter(main.folderName + "\\" + date + "_MonitorElecs.txt");
            tw_burstLeaders = new StreamWriter(main.folderName + "\\" + date + "_BurstLeaders.txt");
            tw_burstLeaders_counts =  new StreamWriter(main.folderName + "\\" + date + "_BurstLeaders_count_G13first.txt");
            tw_refChannel = new StreamWriter(main.folderName + "\\" + date + "_Ref_Data_G13.txt");
            SpkDetector.Get_elecs_IDs().ToList().ForEach(tw_monitorElecs.WriteLine);  // [2] --> G13; [85] --> A2

            
            tw_timer = new StreamWriter(main.folderName + "\\" + date + "_Running_Ticks.txt");
            tw_timer_parameters = new StreamWriter(main.folderName + "\\" + date + "_Running_Ticks_Parameters.txt");
            // Display the timer frequency and resolution.
            if (Stopwatch.IsHighResolution)
            {
                tw_timer_parameters.WriteLine("Operations timed using the system's high-resolution performance counter.");
            }
            else
            {
                tw_timer_parameters.WriteLine("Operations timed using the DateTime class.");
            }
            long frequency = Stopwatch.Frequency;
            tw_timer_parameters.WriteLine("  Timer frequency in ticks per second = {0}", frequency);
            long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
            tw_timer_parameters.WriteLine("  Timer is accurate within {0} nanoseconds", nanosecPerTick);
            tw_timer_parameters.WriteLine("");
            tw_timer_parameters.WriteLine("Sampling Perdiod [ticks]" + "\t" + "Calculations Duration [ticks]");


            // Connect to MEA device via USB-B:
            mea.Connect((CMcsUsbListEntryNet)cbDeviceList.SelectedItem);

            // Connect to Stimulator via USB-A:
            stimulator.Connect_USB_A();


            // Set Data Acquisition:
            int ChannelsInBlock;
            mea.SetSamplerate(Samplerate, 1, 0);
            mea.SetNumberOfAnalogChannels(nChannels, 0, 0, 0, 0); // Read raw data
            mea.EnableChecksum(true, 0);
            mea.SetDataMode(DataModeEnumNet.Signed_32bit, 0);
            ChannelsInBlock = mea.GetChannelsInBlock(0);
            mea.SetSelectedData(TotalChannels, Samplerate, nFrames, SampleSizeNet.SampleSize32Signed, ChannelsInBlock);
            mea.StartDacq();

            // Initiliae time count (in clock ticks)
            lastSamp_ticks = Stopwatch.GetTimestamp();

            Console.WriteLine("************************");
            Console.WriteLine(" Running Spike Detection");
            Console.WriteLine("************************");

            // Start Charts Thread:
            Thread chartsThread = new Thread(ChartsThread);
            chartsThread.Start();
                       
            if (radio_activate_rec_STG1.Checked)
                stimulator.Stimulate(1);  // Activate Recorder in Experimenter with triger 1 (STG 1)
            else if (radio_activate_rec_STG2.Checked)
                stimulator.Stimulate(2);  // Activate Recorder in Experimenter with triger 2 (STG 2)
        }


        private void UpdatePlot()
        {
            // PLOT
            if (spikeCount_chart.InvokeRequired)
            {
                spikeCount_chart.Invoke(new Action(() =>
                {
                    UpdatePlot();
                }
                ));
            }
            else
            {
                int nPoints = (int)Math.Round(past_window * Samplerate);

                if (check_spikeCount.Checked)
                {
                    spikeCount_chart.Series[0].Points.AddXY(chart_clock, chart_nSpikes);

                    if (spikeCount_chart.Series[0].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[0].Points.RemoveAt(0);
                }

                if (check_FR.Checked)
                {
                    spikeCount_chart.Series[1].Points.AddXY(clock_s, fireRate_Hz);
                    if (chart_burst == 1)
                    {
                        spikeCount_chart.Series[6].Points.AddXY(clock_s, fireRate_Hz);
                        txt_period.Text = Controller.Get_Period_s().ToString();
                    }

                    if (spikeCount_chart.Series[1].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[1].Points.RemoveAt(0);
                }


                if (check_oscillator.Checked)
                {
                    spikeCount_chart.Series[2].Points.AddXY(clock_s, Controller.Get_oscillator_value());

                    if (spikeCount_chart.Series[2].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[2].Points.RemoveAt(0);
                }

                if (check_controller.Checked)
                {
                    spikeCount_chart.Series[3].Points.AddXY(clock_s, Controller.Get_delayed_oscillator());

                    if (spikeCount_chart.Series[3].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[3].Points.RemoveAt(0);
                }

                if (check_stimFreq.Checked)
                {
                    spikeCount_chart.Series[4].Points.AddXY(clock_s, Controller.Get_FB_StimFreq_Hz());

                    if (spikeCount_chart.Series[4].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[4].Points.RemoveAt(0);
                }

                if (check_stimulus.Checked)
                {
                    spikeCount_chart.Series[5].Points.AddXY(clock_s, chart_stimulate * 10);

                    if (spikeCount_chart.Series[5].Points[0].XValue < clock_s - past_window && clock_s > past_window)
                        spikeCount_chart.Series[5].Points.RemoveAt(0);
                }
                chart_burst = 0;
                chart_stimulate = 0;
                chart_clock = clock_s;
                chart_nSpikes = nSpikes;

                // Move chart window forward:               
                if (moveWindow)
                {
                    moveWindow = false;
                    spikeCount_chart.ChartAreas[0].AxisX.Maximum = clock_s + future_window;
                    spikeCount_chart.ChartAreas[0].AxisX.Minimum = clock_s - past_window;
                }
            }
        }

        private void ChartsThread()
        {
            while (detectingSpikes)
            {
                UpdatePlot();
            }          
        }


        private void btn_StopDacq_Click(object sender, EventArgs e)
        {
            btn_StopDacq.Enabled = false;
            btn_StartDacq.Enabled = true;
            detectingSpikes = false;
            mea.StopDacq();
            mea.Disconnect();

            // Stop Recorder in Experimenter!
            stimulator.Disconnect();

            Console.WriteLine("************************");
            Console.WriteLine(" Stop Spike Detection");
            Console.WriteLine("************************");

            // Text Write:
            tw.Close();
            tw_header.Close();
            tw_parameters.Close();
            tw_monitorElecs.Close();
            tw_burstLeaders.Close();
            tw_refChannel.Close();
            
            // Write burst leaders count
            int[] burstLeadersCount = burstLeaders.Get_BurstLeaders_IDs_Count_per_Elec();
            for (int i = 2; i < burstLeadersCount.Length-2; i++) // Start in ID=2 --> G13
                tw_burstLeaders_counts.WriteLine(burstLeadersCount[i]);

            tw_burstLeaders_counts.Close();
            tw_timer.Close();
            tw_timer_parameters.Close();

            // Clear Chart Series:
            spikeCount_chart.Series[0].Points.Clear();
            spikeCount_chart.Series[1].Points.Clear();
            spikeCount_chart.Series[2].Points.Clear();
            spikeCount_chart.Series[3].Points.Clear();
            spikeCount_chart.Series[4].Points.Clear();
            spikeCount_chart.Series[5].Points.Clear();
            spikeCount_chart.Series[6].Points.Clear();
        }



        private void btn_stimulate_Click(object sender, EventArgs e)
        {
            stimulator.Connect_USB_A();
            stimulator.Stimulate();
            stimulator.Disconnect();
        }

        private void check_OnControl_CheckedChanged(object sender, EventArgs e)
        {
            if (check_OnControl.Checked)
            {
                controlOn = 1;
                start_control_t = clock_s;
            }
            else
            {
                controlOn = 0;
                double control_time = clock_s - start_control_t;
                avg_Stim_Hz = nStims / control_time;
                txt_avg_stim_freq.Text = (Math.Round(avg_Stim_Hz*10)/10).ToString();
            }
        }

        // Set Spike Threshold:
        private void txt_thresh_uV_TextChanged(object sender, EventArgs e)
        {
            btn_set_spk_thresh.Enabled = true;
        }

        private void btn_set_thresh_Click(object sender, EventArgs e)
        {
            double thresh = double.Parse(txt_thresh_uV.Text);
            SpkDetector.set_thresholds(thresh);
            btn_set_spk_thresh.Enabled = false;
            main.thresholder.Set_Manual_Thresholds(thresh);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Manual Spike Threshold [uV]: " + thresh);
            }
        }

        // Set Burst Threshold:
        private void txt_burstThresh_TextChanged(object sender, EventArgs e)
        {
            btn_set_BurstThresh.Enabled = true; 
        }

        private void btn_set_BurstThresh_Click(object sender, EventArgs e)
        {
            double new_burstThresh = double.Parse(txt_burstThresh.Text);
            
            btn_set_BurstThresh.Enabled = false;

            main.burstThresh_Hz = new_burstThresh;
            burstFinder.Set_FR_thresh_Hz(new_burstThresh);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Burst Threshold [Hz]: " + burstFinder.Get_BurstThresh_Hz());
            }
        }


        // Set Oscillator Period:
        private void txt_period_TextChanged(object sender, EventArgs e)
        {
            btn_fix_mode.Enabled = true;
        }

        private void btn_set_T_Click(object sender, EventArgs e)
        {
            adaptive = false;
            /*
            osclt_T = Convert.ToDouble(txt_period.Text); 
            Controller.Set_T(osclt_T);
            Controller.Reset_IBI_Batch();
            */

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Fixed Oscillator Period [s]: " + osclt_T.ToString());
            }

            btn_fix_mode.Enabled = false;
            btn_adaptive_mode.Enabled = true;
            btn_adaptive_mode.BackColor = Color.Gray;
            btn_fix_mode.BackColor = Color.Green;

        }


        // Set min IBI:
        private void txt_minIBI_TextChanged(object sender, EventArgs e)
        {
            btn_set_minIBI.Enabled = true;
        }


        private void btn_set_minIBI_Click(object sender, EventArgs e)
        {
            double new_minIBI = double.Parse(txt_minIBI.Text);
            btn_set_minIBI.Enabled = false;

            main.minIBI_s = new_minIBI;
            burstFinder.Set_minIBI_s(new_minIBI);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Min IBI [s]: " + burstFinder.Get_min_IBI_s());
            }
        }


        private void txt_filter_TextChanged(object sender, EventArgs e)
        {
            btn_set_filter.Enabled = true;
        }


        private void btn_set_filter_Click(object sender, EventArgs e)
        {
            btn_set_filter.Enabled = false;
           main.filter.Set_Freq_Cut_Hz(Convert.ToDouble(txt_filter.Text), mea);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("HP Filter [Hz]: " + main.filter.Get_FreqCut_Hz().ToString());
            }
        }

        private void txt_stimGain_TextChanged(object sender, EventArgs e)
        {
            btn_set_stimGain.Enabled = true;
        }

        private void btn_set_stimGain_Click(object sender, EventArgs e)
        {
            btn_set_stimGain.Enabled = false;
            main.stimGain = Convert.ToDouble(txt_stimGain.Text);
            Controller.Set_StimFreqGain(main.stimGain); 
            
            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Stimulation Gain: " + main.stimGain);
            }
        }

        private void txt_delay_frac_TextChanged(object sender, EventArgs e)
        {
            btn_set_delay_frac.Enabled = true;
        }

        private void btn_set_delay_frac_Click(object sender, EventArgs e)
        {
            btn_set_delay_frac.Enabled = false;
            main.delay_frac = Convert.ToDouble(txt_delay_frac.Text);
            Controller.Set_delayFrac(main.delay_frac);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Delay Fraction: " + main.delay_frac);
            }
        }

        private void txt_past_window_TextChanged(object sender, EventArgs e)
        {
            btn_set_past_window.Enabled = true;
        }

        private void btn_set_past_window_Click(object sender, EventArgs e)
        {
            btn_set_past_window.Enabled = false;
            past_window = Convert.ToDouble(txt_past_window.Text);
        }

        private void txt_future_window_TextChanged(object sender, EventArgs e)
        {
            btn_set_future_window.Enabled = true;
        }


        private void btn_set_future_window_Click(object sender, EventArgs e)
        {
            btn_set_future_window.Enabled = false;
            future_window = Convert.ToDouble(txt_future_window.Text);
        }


        private void btn_set_FR_window_Click(object sender, EventArgs e)
        {
                        
            btn_set_FR_window.Enabled = false;
            main.FR_window_s = Convert.ToDouble(txt_FR_window.Text);
            FR.SetWindowDuration( main.FR_window_s);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("FR window duration [s]: " +  main.FR_window_s);
            }
        }


        private void txt_min_stimFreq_TextChanged(object sender, EventArgs e)
        {
            btn_set_min_stimFreq_thresh.Enabled = true;
        }


        private void btn_set_min_stimFreq_Click(object sender, EventArgs e)
        {
            btn_set_min_stimFreq_thresh.Enabled = false;
            double min_stimFreq_Hz = double.Parse(txt_min_stimFreq_thresh.Text);
            main.minSimFreq_Hz = min_stimFreq_Hz;
            Controller.Set_min_StimFreq_Hz(min_stimFreq_Hz);

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Min Stimulation Freq Thresh[Hz]: " + min_stimFreq_Hz);
            }
        }


        private void txt_FR_window_TextChanged(object sender, EventArgs e)
        {
            btn_set_FR_window.Enabled = true;
        }

        private void btn_updateElecs_Click(object sender, EventArgs e)
        {
            elec_idxs = main.ElecsPool_inds;
            SpkDetector.set_elecs_idx(elec_idxs.ToArray());
            FR.Set_nElecs(elec_idxs.Count);

            tw_monitorElecs.WriteLine("--------------------");
            tw_monitorElecs.WriteLine("Time [s]: " + clock_s);
            SpkDetector.Get_elecs_IDs().ToList().ForEach(tw_monitorElecs.WriteLine);  // [2] --> G13; [85] --> A2
        }

        private void btn_set_max_y_Click(object sender, EventArgs e)
        {
            btn_set_max_y.Enabled = false;
            max_y = Convert.ToDouble(txt_max_y.Text);
            spikeCount_chart.ChartAreas[0].AxisY.Maximum = max_y;
            spikeCount_chart.ChartAreas[0].AxisY.Minimum = -max_y;
        }

        private void txt_max_y_TextChanged(object sender, EventArgs e)
        {
            btn_set_max_y.Enabled = true;
        }

        private void check_dualMode_CheckedChanged(object sender, EventArgs e)
        {
            if (dualmode)
                dualmode = false;
            else
                dualmode = true;
        }

        private void btn_BurstLeadersForm_Click(object sender, EventArgs e)
        {
            BurstLeadersForm burstLeadersForm = new BurstLeadersForm();
            burstLeadersForm.Show();
        }

        private void check_burstLeaders_CheckedChanged(object sender, EventArgs e)
        {
            if (check_burstLeaders.Checked)
            {
                btn_BurstLeadersForm.Enabled = true;
                withBurstLeader = true;
            }
            else
            {
                btn_BurstLeadersForm.Enabled = false;
                withBurstLeader = false;
            }
        }

        private void check_savaData_CheckedChanged(object sender, EventArgs e)
        {
            if (check_savaData.Checked)
                saveData = true;
            else
                saveData = false;
        }

        private void btn_chooseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    main.folderName = fbd.SelectedPath;
                }
            }
            txt_folder.Text = main.folderName;
        }

        private void txt_folder_TextChanged(object sender, EventArgs e)
        {
            btn_setFolder.Enabled = true;
        }

        private void btn_setFolder_Click(object sender, EventArgs e)
        {
            main.folderName = txt_folder.Text;
            Directory.CreateDirectory(main.folderName);
            btn_setFolder.Enabled = false;
        }

        private void check_activate_rec_STG2_CheckedChanged(object sender, EventArgs e){}
        private void cbDeviceList_SelectedIndexChanged(object sender, EventArgs e) {}
        private void spikeCount_chart_Click(object sender, EventArgs e) {}


        private void check_remove_stim_artifact_CheckedChanged(object sender, EventArgs e)
        {
            if (check_remove_stim_artifact.Checked)
                remove_stim_artifact = true;
            else
                remove_stim_artifact = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            adaptive = true;
            btn_adaptive_mode.Enabled = false;
            btn_fix_mode.Enabled = true;

            btn_adaptive_mode.BackColor = Color.Green;
            btn_fix_mode.BackColor = Color.Gray;

            if (detectingSpikes)
            {
                tw_parameters.WriteLine("--------------------");
                tw_parameters.WriteLine("Time [s]: " + clock_s);
                tw_parameters.WriteLine("Adaptive Oscillator ON - Period [s]: " + osclt_T.ToString());
            }
        }
    }
}