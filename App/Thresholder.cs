using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace OnlineSpikeDetection
{
    public class Thresholder
    {   
        // thresh_vector[2] --> G13
        // thresh_vector[85] --> A2
        
        int nElecs = 256;
        double to_uV;
        int nFrames;    // number of frames to read
        int frames_read; // number of frames actually read (needed?)
        double std_thresh;
        double[] V_data_uV;
        double[] thresholds_uv;
        int sampleRate = 10000;
        bool withAutoThresh = false;
        AuxiliaryFunctions Aux = new AuxiliaryFunctions();

        public Thresholder()
        {
            to_uV =  0.03070831298828125;
            std_thresh = 5;
            thresholds_uv = new double[nElecs];

            nFrames = sampleRate / 10; // reads 100ms of data
            V_data_uV = new double[nFrames];
        }


        public Thresholder(double nStds)
        {
            std_thresh = nStds;
            to_uV = 0.03070831298828125;
            thresholds_uv = new double[nElecs];

            nFrames = sampleRate / 10; // reads 100ms of data            
            V_data_uV = new double[nFrames];
        }

        public Thresholder(double nStds, double to_uv)
        {
            std_thresh = nStds;
            to_uV = to_uv;
            thresholds_uv = new double[nElecs];

            nFrames = sampleRate / 10; // reads 100ms of data            
            V_data_uV = new double[nFrames];
        }

        public Thresholder(int nframes)
        {
            to_uV = 0.03070831298828125;
            std_thresh = 5;
            thresholds_uv = new double[nElecs];

            nFrames = nframes;
            V_data_uV = new double[nFrames];
        }

        public Thresholder(double nStds, double to_uv, int nframes)
        {
            std_thresh = nStds;
            to_uV = to_uv;
            thresholds_uv = new double[nElecs];
                        
            nFrames = nframes;             
            V_data_uV = new double[nFrames];
        }


        public double[] Calc_AutoThresholds(double[] data_uV)
        {
            for (int elec_ID = 2; elec_ID < nElecs-2; elec_ID++)
            {
                // Extract electrode data:
                for (int i = 0; i < nFrames; i += 1)
                    V_data_uV[i] = data_uV[i * nElecs + elec_ID] * to_uV;

                // Threshold:            
                thresholds_uv[elec_ID] = Calc_AutoThreshold(V_data_uV);
            }
            withAutoThresh = true;

            return thresholds_uv;
        }


        public double[] Calc_AutoThresholds_and_Plot(int[] data_uV, Chart[] allCharts)
        {
            double[] time = new double[nFrames];
            for (int i = 0; i < nFrames; i++)
                time[i] = (double)i / sampleRate;

            int elec_ind = 0;
            int elec_ID;
            for (int chart = 1; chart < nElecs - 1; chart++)
            {
                if (chart != 15 && chart != 240)
                {
                    elec_ID = Aux.from_ind_to_ID(elec_ind);

                    // Extract electrode data:
                    for (int i = 0; i < nFrames; i++)
                        V_data_uV[i] = data_uV[i * nElecs + elec_ID] * to_uV;                                      

                    // Threshold:            
                    thresholds_uv[elec_ID] = Calc_AutoThreshold(V_data_uV);

                    allCharts[chart].Series[0].Points.DataBindXY(time, V_data_uV);
                    double[] xx = { 0, time[nFrames - 1] };

                    double[] thr_plus = { thresholds_uv[elec_ID], thresholds_uv[elec_ID] };
                    double[] thr_neg = { -thresholds_uv[elec_ID], -thresholds_uv[elec_ID] };

                    allCharts[chart].Series[1].Points.DataBindXY(xx, thr_plus);
                    allCharts[chart].Series[2].Points.DataBindXY(xx, thr_neg);

                    elec_ind++;
                }
            }
            withAutoThresh = true;
            return thresholds_uv;
        }


        public double Calc_AutoThreshold(double[] elec_data_uV)
        {
            // Threshold:
            double avg = elec_data_uV.Average();
            double sumOfSquaresOfDifferences = elec_data_uV.Select(val => (val - avg) * (val - avg)).Sum();
            double std = Math.Sqrt(sumOfSquaresOfDifferences / elec_data_uV.Length);

            return std_thresh * std;
        }

        public void Set_SampleRate(int samplerate)
        {
            sampleRate = samplerate;
        }

        public void Set_nSTDs_thresh(double nStds)
        {
            std_thresh = nStds;
        }

        public void Set_uV_conversion(double to_uv)
        {
            to_uV = to_uv;
        }

        public void Set_Manual_elec_ID_threshold_uV(int elecID, double thresh_uV)
        {
            thresholds_uv[elecID] = thresh_uV;
            withAutoThresh = false;
        }

        public void Set_Manual_elec_ind_threshold_uV(int elec_ind, double thresh_uV)
        {
            thresholds_uv[Aux.from_ind_to_ID(elec_ind)] = thresh_uV;
            withAutoThresh = false;
        }

        public void Set_Manual_Thresholds(double thresh_uV)
        {
            for (int i = 0; i < nElecs; i++)
                thresholds_uv[i] = thresh_uV;

            withAutoThresh = false;
        }

        public double[] Get_Thresholds_uV()
        {
            return thresholds_uv;
        }
        
        public double Get_nSTDs_thresh()
        {
            return std_thresh;
        }

        public bool WithAutoThresholds()
        {
            return withAutoThresh;
        }
    }
}
