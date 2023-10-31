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
using System.Threading;
using System.IO;

namespace OnlineSpikeDetection
{
    public partial class DataViewerForm : Form
    {
        bool plotting = false;

        // Nº Channels:
        const int nChannels = 256; //64;
        const int nGrounds = 4;
        const int Checksum = 0; // whats this??  2 in github example
        const int TotalChannels = nChannels + Checksum;

        // Sampling Rate:
        const int Samplerate = 10000; // 50000;
        const double dt = 1 / (double)Samplerate;
        const int nFrames = 1;

        // Read Data Variables:
        int[] data;
        int frames_read;
        int clock;
        double clock_s = 0;
        double chart_clock_s;
        double to_uV = 0.03070831298828125;
        double V_data_uV;
        double chart_V;

        int elec_id = 2; // G13


        // Initiatize Devices:
        CMeaUSBDeviceNet mea = new CMeaUSBDeviceNet();  // MEA
        CStg200xDownloadNet cStgDevice = new CStg200xDownloadNet();

        // Connections/Devices Available:
        CMcsUsbListNet UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB); // List of USB connections (A and/or B)

        TextWriter tw; // control variables


        public DataViewerForm()
        {
            InitializeComponent();
            RefreshDeviceList();
            mea.ChannelDataEvent += new OnChannelData(mea_ChannelDataEvent);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = false;
            btn_stop.Enabled = true;

            plotting = true;
            // Connect to MEA device via USB-B:
            mea.Connect((CMcsUsbListEntryNet)cbDeviceList.SelectedItem);


            // Set Data Acquisition:
            int ChannelsInBlock;
            mea.SetSamplerate(Samplerate, 1, 0);
            mea.SetNumberOfAnalogChannels(nChannels, 0, 0, 0, 0); // Read raw data
            mea.EnableChecksum(true, 0);
            mea.SetDataMode(DataModeEnumNet.Signed_32bit, 0);
            ChannelsInBlock = mea.GetChannelsInBlock(0);
            mea.SetSelectedData(TotalChannels, Samplerate, nFrames, SampleSizeNet.SampleSize32Signed, ChannelsInBlock);
            mea.StartDacq();

            Console.WriteLine("************************");
            Console.WriteLine(" Running Spike Detection");
            Console.WriteLine("************************");


            String date = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            tw = new StreamWriter(date + "_G13_Data.txt");


            // Start Charts Thread:
            Thread chartsThread = new Thread(ChartsThread);
            //  chartsThread.Start();


            // Connect to Stimulator via USB-A:
            uint USB_A = 0;
            if (cbDeviceList.SelectedIndex == 0)
                USB_A = 1;
            cStgDevice.Connect(UsbDeviceList.GetUsbListEntry(USB_A), 2);

            // Activate Recorder in Experimenter!
            cStgDevice.SendStart(1);
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

        void mea_ChannelDataEvent(CMcsUsbDacqNet dacq, int CbHandle, int numFrames)
        {
            if (numFrames >= nFrames)
            {
                // Read Data:
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                // clock:
                clock++;
                clock_s = (double)clock / Samplerate * nFrames;

                //elec_id = elecs_ID[0]; // elec_id = 2 --> G13
                V_data_uV = data[elec_id] * to_uV; 

                tw.WriteLine(V_data_uV);
            }
        }

        private void ChartsThread()
        {
            while (plotting)
            {
                UpdatePlot();
            }
        }


        private void UpdatePlot()
        {
            // PLOT
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(() =>
                {
                    UpdatePlot();
                }
                ));
            }
            else
            {
                
                chart1.Series[0].Points.AddXY(clock_s, V_data_uV);
              //  chart_clock = 0;
              //  chart_V = 0;

            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            plotting = false;
            mea.StopDacq();
            mea.Disconnect();
            tw.Close();

            Console.WriteLine("************************");
            Console.WriteLine(" Stop Plotting");
            Console.WriteLine("************************");

        }

        private void DataViewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
