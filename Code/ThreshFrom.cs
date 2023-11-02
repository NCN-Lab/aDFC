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
using System.Windows.Forms.DataVisualization.Charting;



namespace OnlineSpikeDetection
{
    public partial class ThreshFrom : Form
    {
        // thresh_vector[2] --> G13
        // thresh_vector[85] --> A2

        // Nº Channels:
        const int nChannels = 256; //64;
        const int Checksum = 0; // whats this??  2 in github example
        const int TotalChannels = nChannels + Checksum;


        double std_thresh = 6;
        int[] data;
        double to_uV;

        int frames_read;
        

        // Sampling Rate:
        const int Samplerate = 10000; // 50000;
        const int nFrames = Samplerate/10; // reads 100ms of data

        Chart[] allCharts;
        List<labelStruct> electrodeLabels;

        // Electrode labels filename:
        string filename = AppDomain.CurrentDomain.BaseDirectory + @"\electrode_labels.txt"; // @"C:\Users\Asus\Desktop\Domingos\PDEEC\DSP\via dll and Matlab\Automated Protocol\electrode_labels.txt";

        // Initiatize Devices:
        CMeaUSBDeviceNet mea = new CMeaUSBDeviceNet();  // MEA

        // Connections/Devices Available:
        uint nUSBs = 0;
        CMcsUsbListNet UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB); // List of USB connections (A and/or B)

        public ThreshFrom()
        {
            electrodeLabels = organizeLabels(filename);
            InitializeComponent();
            RefreshDeviceList();
            nUSBs = UsbDeviceList.Count; // Nr of available USB ports / devices
            mea.ChannelDataEvent += new OnChannelData(mea_ChannelDataEvent);

            // Create Charts Array:
            int nLines = 16;
            int nCols = 16;
            int[] sides = new int[2] { 90, 50 };
            int X = 35;
            int Y = 80;
            allCharts = multipleCharts(nLines, nCols, sides, X, Y);

            main.thresholder = new Thresholder(std_thresh);

            txt_filter.Text = main.filter.Get_FreqCut_Hz().ToString();
            btn_set_filter.Enabled = false;
            txt_stds.Text = std_thresh.ToString();

            // Set Filter:
          //  mea.Connect((CMcsUsbListEntryNet)cbDeviceList.SelectedItem);
          //  main.filter.Set_Freq_Cut_Hz(double.Parse(txt_filter.Text), mea);
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
                
                data = mea.ChannelBlock_ReadFramesI32(0, nFrames, out frames_read);

                BeginInvoke(new Action(DisplayData));

                mea.StopDacq();
                mea.Disconnect();
            }
            else
            {
                // Activated in STOP - captures leftovers from buffers, I suppose
                data = mea.ChannelBlock_ReadFramesI32(0, numFrames, out frames_read);
            }
        }


        void DisplayData()
        {
            main.thresholder.Calc_AutoThresholds_and_Plot(data, allCharts);           
        }


        private void btn_startDacq_Click(object sender, EventArgs e)
        {
            uint status = mea.Connect((CMcsUsbListEntryNet)cbDeviceList.SelectedItem);

            int ana, digi, che, tim, block;
            mea.GetChannelLayout(out ana, out digi, out che, out tim, out block, 0); // AnalogChannels, DigitalChannels, ChecksumChannels, TimestampChannels, ChannelsInBlock, virtualDevice 

            std_thresh = double.Parse(txt_stds.Text);
            main.thresholder.Set_nSTDs_thresh(std_thresh);

            if (status == 0)
            {
                main.filter.HP_Filter(mea);

                int gain = mea.GetGain();  // milli Gain
                int range = mea.GetVoltageRangeInMilliVolt(); // +- range
                uint adc = mea.GetAdcDataFormat(0); //bit depth
                //CONVERT DATA VALUE TO uV
                //val_uV = data_int * (range*2) / (2^adc) / (0.001*gain) [* 1000]
                //                           |                 |
                //                           |                 L> milli to gain
                //                           L> because of +/- in the range     
                to_uV = 1000.0 * (range * 2) / Math.Pow(2, adc) / (0.001 * gain);

                // Hardcoded to_uV. If you are reading from Port-B you won't get gain, range and adc
                if (Double.IsNaN(to_uV))
                {
                    to_uV = 0.03070831298828125;
                }

                main.thresholder.Set_uV_conversion(to_uV);

                int ChannelsInBlock;

                mea.SetSamplerate(Samplerate, 1, 0);
                mea.SetNumberOfAnalogChannels(nChannels, 0, 0, 0, 0); // Read raw data

                mea.EnableChecksum(true, 0);
                mea.SetDataMode(DataModeEnumNet.Signed_32bit, 0);
                ChannelsInBlock = mea.GetChannelsInBlock(0);

                mea.SetSelectedData(TotalChannels, Samplerate * 10, nFrames, SampleSizeNet.SampleSize32Signed, ChannelsInBlock);

                mea.StartDacq();
            }
        }


        private Chart[] multipleCharts(int nLines, int nCols, int[] sides, int x_corner, int y_corner)
        {

            Chart[] allCharts = new Chart[nLines * nCols];

            int ind = 0;
            for (int col = 0; col < nCols; col++)
            {
                for (int line = 0; line < nLines; line++)
                {
                    Chart chart = new Chart();

                    chart.Left = col * sides[0] + x_corner;
                    chart.Top = line * sides[1] + y_corner;
                    chart.Width = sides[0];
                    chart.Height = sides[1];

                    chart.ChartAreas.Add("area1");
                    chart.ChartAreas[0].Position.X = 0;
                    chart.ChartAreas[0].Position.Y = 0;
                    chart.ChartAreas[0].Position.Height = 100;
                    chart.ChartAreas[0].Position.Width = 100;
                    chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
                    chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
                    chart.ChartAreas[0].AxisY.Maximum = 200;
                    chart.ChartAreas[0].AxisY.Minimum = -200;

                    chart.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                    chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                    chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart.Series.Add("series1");
                    chart.Series["series1"].ChartType = SeriesChartType.FastLine;
                    chart.Series["series1"].Color = Color.Red;

                    chart.Series.Add("series2");
                    chart.Series["series2"].ChartType = SeriesChartType.FastLine;
                    chart.Series["series2"].Color = Color.Blue;

                    chart.Series.Add("series3");
                    chart.Series["series3"].ChartType = SeriesChartType.FastLine;
                    chart.Series["series3"].Color = Color.Blue;

                    allCharts[ind] = chart;
                    Controls.Add(allCharts[ind]);
                    ind++;
                }
            }
            return allCharts;
        }



        private List<labelStruct> organizeLabels(string path)
        {
            var labelList = new List<labelStruct>();
            string[] lines = System.IO.File.ReadAllLines(path);
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            int i = 0;
            foreach (string raw_line in lines)
            {
                string line = raw_line.Substring(1, raw_line.Length - 2);
                Console.WriteLine("\t" + line);

                labelStruct label_elem = new labelStruct();
                label_elem.label = line;
                label_elem.letter = line[0];
                label_elem.number = Convert.ToInt32(line.Substring(1, line.Length - 1));
                label_elem.id = i + 2; // skip first two ids (grounds)
                labelList.Add(label_elem);
                i++;
            }

            List<labelStruct> sorted = labelList.OrderBy(x => x.letter)
                                   .ThenBy(x => x.number)
                                   .ToList();
            return sorted;
        }

        public struct labelStruct
        {
            public string label;
            public char letter;
            public int number;
            public int id;
        }

        private void btn_set_filter_Click(object sender, EventArgs e)
        {
            btn_set_filter.Enabled = false;
            main.filter.Set_Freq_Cut_Hz(double.Parse(txt_filter.Text), mea);
        }

        private void txt_filter_TextChanged(object sender, EventArgs e)
        {
            btn_set_filter.Enabled = true;
        }

        private void text_stds_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
