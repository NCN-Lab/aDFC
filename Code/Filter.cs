using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mcs.Usb;

namespace OnlineSpikeDetection
{
    public class Filter
    {
        // Filters Data using the DSP [I GUESS], only works for USB-B, USB-A remains ulfiltered
        double HP_cut_Hz;

        public Filter()
        {
            HP_cut_Hz = 200;
        }

        public Filter(double HP_cut_freq_Hz)
        {
            HP_cut_Hz = HP_cut_freq_Hz;
        }

        public bool HP_Filter(CMeaUSBDeviceNet mea)
        {
            if (mea.IsConnected())
            {
                // Set Filter: HP 100 Hz
                double[] xcoeffs;
                double[] ycoeffs;
                mkfilterNet.mkfilter("Bu", 0, "Hp", 2, HP_cut_Hz / 50000.0, 0, out xcoeffs, out ycoeffs);
                mea.WriteRegister(0xc00, DoubleToFixedInt(1, 16, 30, xcoeffs[0])); // set b[0] fpr 100 Hz HP
                mea.WriteRegister(0xc02, DoubleToFixedInt(1, 15, 30, xcoeffs[1])); // set b[1] fpr 100 Hz HP
                mea.WriteRegister(0xc03, DoubleToFixedInt(1, 30, 30, ycoeffs[1])); // set a[1] fpr 100 Hz HP
                mea.WriteRegister(0xc04, DoubleToFixedInt(1, 16, 30, xcoeffs[2])); // set b[2] fpr 100 Hz HP
                mea.WriteRegister(0xc05, DoubleToFixedInt(1, 30, 30, ycoeffs[2])); // set a[2] fpr 100 Hz HP
                mea.WriteRegister(0xc07, 0x00000001); // enable

                mea.WriteRegister(0x880, 2); // Send data Filtered By DSP
                return true;
            }
            else
                return false; // mea NOT connected
        }


        public void Set_Freq_Cut_Hz(double HP_freq_cut, CMeaUSBDeviceNet mea)
        {
            HP_cut_Hz = HP_freq_cut;
        }


        public void Set_Freq_Cut_Hz(double HP_freq_cut)
        {
            HP_cut_Hz = HP_freq_cut;
        }


        public double Get_FreqCut_Hz()
        {
            return HP_cut_Hz;
        }

        uint DoubleToFixedInt(int vk, int nk, int commaPos, double valF)
        {
            valF *= 1 << nk;
            if (valF > 0)
            {
                valF += 0.5;
            }
            else
            {
                valF -= 0.5;
            }
            ulong mask = ((ulong)1 << (vk + nk + 1)) - 1;
            ulong val = (ulong)valF;
            uint value = (uint)(val & mask);
            if (commaPos > nk)
            {
                value = value << (commaPos - nk);
            }

            return value;
        }
    }
}
