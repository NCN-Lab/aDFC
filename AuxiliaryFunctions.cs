using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    class AuxiliaryFunctions
    {
        const int nelecs = 252;
        int[] inds_of_IDs = new int[nelecs];
        int[] IDs_of_inds = new int[nelecs];
        public static List<labelStruct> electrodeLabels;

        public AuxiliaryFunctions()
        {
            string labels_inds_path = AppDomain.CurrentDomain.BaseDirectory + @"\ind_of_IDs.txt";
            organizeIDs_by_column(labels_inds_path);

            string labels_path = AppDomain.CurrentDomain.BaseDirectory + @"\electrode_labels.txt"; // @"C:\Users\Asus\Desktop\Domingos\PDEEC\DSP\via dll and Matlab\Automated Protocol\electrode_labels.txt";
            electrodeLabels = organizeLabels(labels_path);
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

            for (int n = 0; n<nelecs; n++)
            {
                IDs_of_inds[n] = sorted[n].id;
            }

            return sorted;
        }


        public struct labelStruct
        {
            public string label;
            public char letter;
            public int number;
            public int id;
        }


        public List<labelStruct> Get_electrodeLabels()
        {
            return electrodeLabels;
        }


        private void organizeIDs_by_column(string path)
        {
            string[] IDs = System.IO.File.ReadAllLines(path);

            for (int i = 0; i<IDs.Length; i++)
            {
                inds_of_IDs[i] = int.Parse(IDs[i]);
            }
        }


        // Get the indexes (from A2-R14) of the IDs (from G13-G15)
        public int[] from_IDs_to_inds(int[] IDs)
        { 
            int nIDs = IDs.Length;
            int[] inds = new int[nIDs];

            for (int i = 0; i < nIDs; i++)
            {
                inds[i] = inds_of_IDs[IDs[i]-2];
            }
            return inds;
        }

        // Get the indexes (from A2-R14) of the IDs (from G13-G15)
        public List<int> from_IDs_to_inds(List<int> IDs)
        {
            int nIDs = IDs.Count;
            List<int> inds = new List<int>();

            for (int i = 0; i < nIDs; i++)
            {
                inds.Add(inds_of_IDs[IDs[i] - 2]);
            }
            return inds;
        }

        // Get the index (from A2-R14) of the ID (from G13-G15)
        public int from_ID_to_ind(int ID)
        {
            return inds_of_IDs[ID-2];
        }


        // Get the IDs (from G13-G15) of the inds (from A2-R14) 
        public int[] from_inds_to_IDs(int[] inds)
        {
            int ninds = inds.Length;
            int[] IDs = new int[ninds];

            for (int i = 0; i < ninds; i++)
            {
                IDs[i] = IDs_of_inds[inds[i]];
            }
            return inds;
        }

        // Get the ID (from G13-G15) of the ind (from A2-R14) 
        public int from_ind_to_ID(int ind)
        {
            return IDs_of_inds[ind];
        }

        public String from_ID_to_label(int ID)
        {
            int ind = from_ID_to_ind(ID);
            return electrodeLabels[ind].label;
        }

        public String[] from_IDs_to_labels(int[] IDs)
        {
            int nIDs = IDs.Length;
            String[] labels = new String[nIDs];
            for(int i=0; i< nIDs; i++)
            {
                int ind = from_ID_to_ind(IDs[i]);
                labels[i] = electrodeLabels[ind].label;
            }
            return labels;
        }

        public List<String> from_IDs_to_labels(List<int> IDs)
        {
            int nIDs = IDs.Count();
            List<String> labels = new List<string>();
            for (int i = 0; i < nIDs; i++)
            {
                int ind = from_ID_to_ind(IDs[i]);
                labels.Add(electrodeLabels[ind].label);
            }
            return labels;
        }


        public String[] from_inds_to_labels(int[] inds)
        {
            int ninds = inds.Length;
            String[] labels = new String[ninds];
            for (int i = 0; i < ninds; i++)
            {
                labels[i] = electrodeLabels[inds[i]].label;
            }
            return labels;
        }

        public List<String> from_inds_to_labels(List<int> inds)
        {
            int ninds = inds.Count();
            List<String> labels = new List<string>();
            for (int i = 0; i < ninds; i++)
            {
                labels.Add(electrodeLabels[inds[i]].label);
            }
            return labels;
        }

        public String from_ind_to_label(int ind)
        {
            return electrodeLabels[ind].label;
        }

    }
}
