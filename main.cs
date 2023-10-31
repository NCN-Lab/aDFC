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
using System.IO;


namespace OnlineSpikeDetection
{
    public partial class main : Form
    {
        const int nChannels = 256;
        // public static double[] thresh_vector = new double[nChannels];
        // Pool of Electable Electrodes
        public static List<int> ElecsPool_inds = new List<int>();
        public static List<int> ElecsPool_IDs = new List<int>();
        public static List<labelStruct> electrodeLabels;
        public static string[] elecLabelsArray = new string[nChannels];

        public static int[] ids_9well; // Ids of wells from A to I - each well has 28 electrodes

        public static Stimulator stimulator = new Stimulator();
        public static Thresholder thresholder = new Thresholder();

        public static Filter filter = new Filter();

        // Save data Folder
        public static string folderName = Directory.GetCurrentDirectory();

        // Control Parameters:
        public static double burstThresh_Hz = 10;
        public static double minIBI_s = 0.2;
        public static double FR_window_s = 0.2;
        public static double stimGain = 0.5;
        public static double delay_frac = 0.5;
        public static double minSimFreq_Hz = 1;


        public main()
        {
            InitializeComponent();
            string labels_path = AppDomain.CurrentDomain.BaseDirectory + @"\electrode_labels.txt"; // @"C:\Users\Asus\Desktop\Domingos\PDEEC\DSP\via dll and Matlab\Automated Protocol\electrode_labels.txt";
            electrodeLabels = organizeLabels(labels_path);

            string ids_9well_path = AppDomain.CurrentDomain.BaseDirectory + @"\well9_id_by_well.txt";
            ids_9well = get_IDs_9well(ids_9well_path);

            // createElecLabelsArray(labels_path);
            // FormClosed += new FormClosedEventHandler(My_FormClosed);
        }


        private void btn_autoThresh_Click(object sender, EventArgs e)
        {
            ThreshFrom AutoThreshForm = new ThreshFrom();
            AutoThreshForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpikeDetectionForm spikeDetectionForm = new SpikeDetectionForm();
            spikeDetectionForm.Show();
        }

        private void bnt_chooseElecs_Click(object sender, EventArgs e)
        {
            chooseElectrodesForm ChooseElectrodesForm = new chooseElectrodesForm();
            ChooseElectrodesForm.Show();
        }

        private void bnt_dataViewer_Click(object sender, EventArgs e)
        {
            DataViewerForm dataViwerForm = new DataViewerForm();
            dataViwerForm.Show();
        }


        private List<labelStruct> organizeLabels(string path)
        {
            var labelList = new List<labelStruct>();
            string[] lines = System.IO.File.ReadAllLines(path);

            int i = 0;
            foreach (string raw_line in lines)
            {
                string line = raw_line.Substring(1, raw_line.Length - 2);

                labelStruct label_elem = new labelStruct();
                label_elem.label = line;
                label_elem.letter = line[0];
                label_elem.number = Convert.ToInt32(line.Substring(1, line.Length - 1));
                label_elem.id = i + 2; // skip first two ids (grounds): id = 0 --> G13
                labelList.Add(label_elem);
                i++;
            }

            List<labelStruct> sorted = labelList.OrderBy(x => x.letter)
                                   .ThenBy(x => x.number)
                                   .ToList();
            return sorted;
        }

        private int[] get_IDs_9well(string filename)
        {
            string[] ids_9_well = System.IO.File.ReadAllLines(filename); 
            return Array.ConvertAll(ids_9_well, int.Parse);
        }

        private void createElecLabelsArray(string path)
        {
            string[] labels = System.IO.File.ReadAllLines(path);
            elecLabelsArray[0] = "ground";
            elecLabelsArray[1] = "ground";
            for (int i = 0; i < 252; i++)
                elecLabelsArray[i + 2] = labels[i];
            elecLabelsArray[254] = "ground";
            elecLabelsArray[255] = "ground";
        }


        public struct labelStruct
        {
            public string label;
            public char letter;
            public int number;
            public int id;
        }


        void My_FormClosed(object sender, FormClosedEventArgs e)
        {
            //main.ElecsPool.Clear();
            Console.WriteLine("Closing!");
        }

        private void btn_poisson_stimulator_Click(object sender, EventArgs e)
        {
            StimulatorForm poissonStimulatorForm = new StimulatorForm();
            poissonStimulatorForm.Show();
        }

        private void btn_TestPoisson_Click(object sender, EventArgs e)
        {
            TestPoisson testPoisson = new TestPoisson();
            testPoisson.Show();
        }

        private void btn_effectiveStim_Click(object sender, EventArgs e)
        {
            EfectiveStimElecsForm effectiveStimElecForm = new EfectiveStimElecsForm();
            effectiveStimElecForm.Show();
        }
    }
}
