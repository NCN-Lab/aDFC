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

namespace OnlineSpikeDetection
{
    public partial class EfectiveStimElecsForm : Form
    {
        EffectiveStimFinder effectiveStimFinder;
                
        // Connections/Devices Available:
        CMcsUsbListNet UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB); // List of USB connections (A and/or B)

        public EfectiveStimElecsForm()
        {
            InitializeComponent();
            RefreshDeviceList();
        }

        private void EfectiveStimElecsForm_Load(object sender, EventArgs e)
        {
            int n_wells = 6;
            int[] stim_elecs_ids = new int[]       {  5,10,12,     50, 51, 52,     100, 101,105,      130,131, 132,      180, 181, 182,     220, 221, 222  };
            int[] monitoring_elecs_ids = new int[] {  6, 7, 8,     55, 56, 57,     110, 111, 112,     135, 136, 137,     185, 186, 187,     225, 226, 227  };
            int n_trials = 1;
            int inter_stim_interval_s = 3;

            effectiveStimFinder = new EffectiveStimFinder(n_wells, stim_elecs_ids, monitoring_elecs_ids, n_trials, inter_stim_interval_s);

        }


        private void btn_StartDacq_Click(object sender, EventArgs e)
        {
            btn_StopDacq.Enabled = true;
            btn_StartDacq.Enabled = false;

            effectiveStimFinder.Start( (CMcsUsbListEntryNet)cbDeviceList.SelectedItem, 10000);
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
    }
}
