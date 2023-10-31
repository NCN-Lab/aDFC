using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    class ActiveElecsManager
    {
        const int mea_total_elecs = 256;
        double FR_thresh_Hz = 0.1;
        double[] mean_FRs = new double[mea_total_elecs];
        List<int> activeElec_IDs;
        List<int> activeElec_inds;
        List<labelStruct> electrodeLabels;
        double t_start = 0;

        public void Calculate_Mean_FR(int[] elecSpkCounts, double t)
        {
            activeElec_IDs = new List<int>();
            activeElec_inds = new List<int>();

            for (int elec_i = 0; elec_i < main.ElecsPool_IDs.Count; elec_i++)
            {
                int elec_id = main.ElecsPool_IDs[elec_i];
                // elec_id = 2 --> G13
                mean_FRs[elec_id] = elecSpkCounts[elec_id] / (t-t_start);

                if (mean_FRs[elec_id] > FR_thresh_Hz)
                {
                    activeElec_IDs.Add(elec_id);
                    activeElec_inds.Add(main.ElecsPool_inds[elec_i]);
                }
            }
        }

        public List<int> Get_ActiveElec_IDs()
        {
            return activeElec_IDs;
        }

        public List<int> Get_ActiveElec_inds()
        {
            return activeElec_inds;
        }

        public double Get_FR_Thresh_Hz()
        {
            return FR_thresh_Hz;
        }

        public void Set_FR_Thresh_Hz(double thresh_Hz)
        {
            FR_thresh_Hz = thresh_Hz;
        }

        public double[] Get_mean_FRs()
        {
            return mean_FRs;
        }

        public void Set_monitoringElecs_ind(List<int> monitor_elecs_inds)
        {
            //monitoringElecs_ind = monitor_elecs_inds;
        }

        public void Set_Electrode_labels(List<labelStruct>  elecLabels)
        {
            electrodeLabels = elecLabels;
        }

        /*
        public struct labelStruct
        {
            public string label;
            public char letter;
            public int number;
            public int id;
        }
        */

        public void Reset_FR(double t)
        {
            mean_FRs = new double[mea_total_elecs];
            t_start = t;
        }
    }


}
