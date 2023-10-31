using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OnlineSpikeDetection
{
    public class Spike_Detector
    {
        const int mea_total_channels = 256;

        double to_uV;
        double V_data_uV;
        double[] abs_prev_data; // [2] --> G13; [85] --> A2

        int[] elecs_ID;  // IDs of detection elecs from 2 to 252. elecs_id = 2 --> G13 (first channel)
        int[] elecs_idx; // ordered indexes of detection elecs from 0 to 250. elecs_id = 0 --> A2 (as ordered by chooseElectrodes Form)
        int nElecs;

        string lables_path;
        List<labelStruct> electrodeLabels;
        double[] thresholds_uV;
        double threshold_default_uV = 50;
        double deadtime_s;
        double deadtime_default_s = 0.003;
        int[] elecSpkCounts = new int[mea_total_channels];

        double[] last_spks_t_s; // stores the time of the last spike of each detection electrode to compare with deadtime


        // Class Constructor:
        public Spike_Detector()
        {
            lables_path = AppDomain.CurrentDomain.BaseDirectory + @"\electrode_labels.txt"; 

            // Coonsider having this in AuxiliaryFunctions!
            electrodeLabels = organizeLabels(lables_path);

            to_uV = 0.03070831298828125;
            nElecs = mea_total_channels;
            deadtime_s = deadtime_default_s;
 
            elecs_ID = new int[nElecs-4];  // [2] --> G13; [85] --> A2
            elecs_idx = new int[nElecs-4]; // [0] --> A2; [252] --> R14
            last_spks_t_s = new double[nElecs];  // [2] --> G13; [85] --> A2
            abs_prev_data = new double[nElecs];  // [2] --> G13; [85] --> A2

            thresholds_uV = new double[nElecs];  // [2] --> G13; [85] --> A2

            for (int i = 0; i < nElecs; i++)
            { 
                thresholds_uV[i] = threshold_default_uV;
                last_spks_t_s[i] = -1;
                abs_prev_data[i] = 0;
                // spike_stamps_s.Add(new double[nFrames]);
            }

            for (int i = 0; i < nElecs-4; i++) // iterate between 0 and 251
            {
                elecs_idx[i] = i;
            }
            set_elecs_idx(elecs_idx); // just to set elec IDs automatically...
        }

        // Use this when you choose the electrodes in choseElectrode Form
        // idx = 0 --> A2
        public void set_elecs_idx(int[] new_elecs_idx)
        {
            elecs_idx = new_elecs_idx;
            nElecs = new_elecs_idx.Length;
            elecs_ID = new int[nElecs];
            int idx;
            for (int i = 0; i < nElecs; i++)
            {
                idx = new_elecs_idx[i];
                elecs_ID[i] = electrodeLabels[idx].id;
            }
        }


        public void set_elecs_ID(int[] new_elecs_ID)
        {
            elecs_ID = new_elecs_ID;
            nElecs = new_elecs_ID.Length;

            for (int i = 0; i < nElecs; i++)
            {
                // elecs_idx[i] = idx of electrodeLabels with id equal to new_elecs_ID[i]
                last_spks_t_s[i] = -1;
                abs_prev_data[i] = 0;
            }
            // order elecs_ID and elec_idx by elec_idx
        }

        public void set_deadtime(double new_deadtime)
        {
            deadtime_s = new_deadtime;
        }

        public void set_thresholds(double[] new_thresholds)
        {
            thresholds_uV = new_thresholds; // new_thresholds[0] --> G13
        }


        public void set_thresholds(double new_threshold)
        {
            for (int i = 0; i< mea_total_channels; i++)
            {
                thresholds_uV[i] = new_threshold;
            }
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
                label_elem.id = i + 2; // skip first two ids (grounds)
                labelList.Add(label_elem);
                i++;
            }

            List<labelStruct> sorted = labelList.OrderBy(x => x.letter)
                                   .ThenBy(x => x.number)
                                   .ToList();
            return sorted;
        }
        
 
        // Counts the number of spikes in data
        //
        // Parameters:
        //   data:
        //     vector of MEA data with 1 frame per electrode     
        //   clock_s:
        //     current time stamp
        //
        // Returns:
        //     List of electrode IDs that fired (ID = 2 --> G13 )
        public List<int> Spike_count(int[] data, double clock_s, int numFrames)
        {
            // data: vector of MEA data with 1 frame per electrode           
            int elec_id; // elec_id = 0 --> G13
            List<int> elec_ids = new List<int>();

                for (int elec_i = 0; elec_i < nElecs; elec_i++)
                {
                    elec_id = elecs_ID[elec_i]; // elec_id = 2 --> G13
                    V_data_uV = Math.Abs(data[elec_id] * to_uV); // absolute value

                    // Detect spike in elec_i:
                    // thresh_vector[2] --> G13; [85] --> A2
                    // abs_prev_data[2] --> G13; [85] --> A2
                    // last_spks_t_s[2] --> G13; [85] --> A2
                    if ((V_data_uV > thresholds_uV[elec_id] & abs_prev_data[elec_id] < thresholds_uV[elec_id]) & clock_s > last_spks_t_s[elec_id] + deadtime_s)
                    {
                        elec_ids.Add(elec_id);
                        last_spks_t_s[elec_id] = clock_s;
                        elecSpkCounts[elec_id]++;
                        // Debugging:
                        // Console.WriteLine("Elec id: " + elec_id + " - Thresh: " + thresholds_uV[elec_id] + " - V: " + V_data_uV);
                    }
                    abs_prev_data[elec_id] = V_data_uV;
                }

            return elec_ids;
        }


        public int Spike_count_neg(int[] data, double clock_s, int numFrames)
        {
            // Detect Only Negative Spikes!!!

            // data: vactor of MEA data with 1 frame per electrode           
            int elec_id; // elec_id = 2 --> G13
            int nSpikes = 0;

            for (int elec_i = 0; elec_i < nElecs; elec_i++)
            {
                elec_id = elecs_ID[elec_i]; // elec_id = 0 --> G13
                                            //  V_data_uV = Math.Abs(data[frame * mea_total_channels + elec_id] * to_uV); // absolute value
                V_data_uV = data[elec_id] * to_uV; 

                // Detect spike in elec_i:
                // thresh_vector[0] --> G13
                // abs_prev_data[2] --> G13
                // last_spks_t_s[2] --> G13

                if ((V_data_uV < -thresholds_uV[elec_id] & abs_prev_data[elec_id] > -thresholds_uV[elec_id]) & clock_s > last_spks_t_s[elec_id] + deadtime_s)
                {
                    nSpikes++;
                    last_spks_t_s[elec_id] = clock_s;
                }
                abs_prev_data[elec_id] = V_data_uV;
            }
            return nSpikes;
        }


        public void Restart_Clock()
        {
            last_spks_t_s = new double[mea_total_channels];  // [2] --> G13; [85] --> A2
        }

        public double[] Get_SpkThresholds()
        {
            return thresholds_uV;
        }

        public int[] Get_elecs_IDs()
        {
            return elecs_ID; // 2 --> G13; 85 --> A2
        }


        public double Get_deadtime()
        {
            return deadtime_s;
        }

        public int[] Get_ElecSpkCounts()
        {
            return elecSpkCounts;
        }
        public void Reset_Spk_Counts()
        {
            elecSpkCounts = new int[mea_total_channels];
        }

    }

    public struct labelStruct
    {
        public string label;
        public char letter;
        public int number;
        public int id;
    }


}
