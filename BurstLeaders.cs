using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSpikeDetection
{
    public class BurstLeaders
    {
        int nElecs = 256;
        int nLeaders_per_burst = 5;
        double onsetWindowDuration_s = 0.1;
        List<int> onsetCandidates_elecsIDs = new List<int>();
        List<double> onsetCandidates_t_s = new List<double>();

        List<int[]> leaderIDs = new List<int[]>(); // List with array of electrode IDs (ID = 2 --> G13) for each burst
        List<int[]> leader_inds = new List<int[]>(); // List with array of electrode inds (ind = 0 --> A2) for each burst

        List<double[]> leaderSpks_t_s = new List<double[]>(); // List with times of onset spks for each burst

        int[] countElec_leaders_IDs; // Array storing th number of burst onsets per elec
        int nBursts = 0;

        AuxiliaryFunctions Aux = new AuxiliaryFunctions();

        public BurstLeaders()
        {            
            nLeaders_per_burst = 5;
            onsetWindowDuration_s = 0.1;

            nElecs = 256;
            countElec_leaders_IDs = new int[nElecs];
        }

        public BurstLeaders(int nLeaders, double onsetDuration_s)
        {
            nLeaders_per_burst = nLeaders;
            onsetWindowDuration_s = onsetDuration_s;

            nElecs = 256;
            countElec_leaders_IDs = new int[nElecs];
        }

        public BurstLeaders(int nLeaders, double onsetDuration_s, int nelecs)
        {
            nLeaders_per_burst = nLeaders;
            onsetWindowDuration_s = onsetDuration_s;

            nElecs = nelecs;
            countElec_leaders_IDs = new int[nElecs];
        }



        // Add electrode(s) that fired at time t to the list of candidates for burst Leaders
        public void AddSpks_leaderCandidates(List<int> elecs_ids, double t)
        {
            int nSpks = elecs_ids.Count();
            for (int spk = 0; spk < nSpks; spk++)
            {
                onsetCandidates_elecsIDs.Add(elecs_ids[spk]);
                onsetCandidates_t_s.Add(t);
            }
        }


        // Move Burst Window
        public void MoveBurstLeadersWindow(double t)
        {
            double window_start = t - onsetWindowDuration_s;

            if (onsetCandidates_t_s.Count > 0)
            {
              while (onsetCandidates_t_s[0] < window_start)
                {
                    onsetCandidates_t_s.RemoveAt(0);
                    onsetCandidates_elecsIDs.RemoveAt(0);

                    if (onsetCandidates_t_s.Count == 0)
                        break;
                }
            }

        }


        public void AddBurstLeaders()
        {
            nBursts++;

            int nCandidates = Math.Min(nLeaders_per_burst, onsetCandidates_elecsIDs.Count);
            int[] elecIDs = onsetCandidates_elecsIDs.GetRange(0, nCandidates).ToArray();
            leaderIDs.Add(elecIDs);


            double[] onsetSpks_t =  onsetCandidates_t_s.GetRange(0, nCandidates).ToArray();
            leaderSpks_t_s.Add(onsetSpks_t);

            // Add leader elecs to the burst leaders count
            for (int i = 0; i < nCandidates; i++)
            {
                int elec_ID = elecIDs[i];
                countElec_leaders_IDs[elec_ID]++;
            }
        }

        public void Reset_LeadersHistory()
        {
            countElec_leaders_IDs = new int[nElecs];
        }

        public List<int[]> GetBurstLeaders_IDs()
        {
            return leaderIDs;
        }

        public int[] GetBurstLeaders_IDs(int burst)
        {
            return leaderIDs[burst];
        }

        public void Set_nElecs(int nelecs)
        {
            nElecs = nelecs;
            countElec_leaders_IDs = new int[nElecs];
        }

        public void Set_nLeaders_per_burst(int nLeaders)
        {
            nLeaders_per_burst = nLeaders;
        }

        public void Set_onsetWindowDuration_s(double onsetWindow_s)
        {
            onsetWindowDuration_s = onsetWindow_s;
        }


        public int[] Get_BurstLeaders_IDs_Count_per_Elec()
        {
            return countElec_leaders_IDs;
        }


        public int[] Get_last_BurstLeaders_IDs()
        {
            if (nBursts > 0)
                return leaderIDs[nBursts - 1];
            else
                return new int[0];
        }

        public int[] Get_last_BurstLeaders_inds()
        {
            int[] lastLeaders_inds = Aux.from_IDs_to_inds(Get_last_BurstLeaders_IDs());
            return lastLeaders_inds;
        }

        public List<int> Get_OnsetCandidates_elecsIDs()
        {
            return onsetCandidates_elecsIDs;
        }

        public int Get_nBursts()
        {
            return nBursts;
        }

        public int Get_nLeaders_per_burst()
        {
            return nLeaders_per_burst;
        }

        public double Get_OnsetWindowDuration_s()
        {
            return onsetWindowDuration_s;
        }

    }

}
