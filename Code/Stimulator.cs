using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mcs.Usb;

namespace OnlineSpikeDetection
{
    public class Stimulator
    {
        CStg200xDownloadNet cStgDevice;
        CMcsUsbListNet UsbDeviceList;
        List<int> stimElecs_IDs;
        List<int> stimElecs_inds;
        ElectrodeDacMuxEnumNet STG_ID;
        uint trigger; // trigger 1 for STG 1; trigger 2 for STG 2

        int nElecs = 252;
        AuxiliaryFunctions Aux = new AuxiliaryFunctions();
                
        //=================================================================
        //                          Constructors:
        public Stimulator()
        {
            cStgDevice = new CStg200xDownloadNet();
            UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB);
            stimElecs_IDs = new List<int>();
            stimElecs_inds = new List<int>();

            STG_ID = ElectrodeDacMuxEnumNet.Stg1;
            trigger = 1;
        }


        public Stimulator(List<int> inds)
        {
            cStgDevice = new CStg200xDownloadNet();
            UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB);
            stimElecs_inds = new List<int>();
            int[] stimElecs_IDs_array = Aux.from_inds_to_IDs(inds.ToArray());
            stimElecs_IDs = stimElecs_IDs_array.ToList();

            STG_ID = ElectrodeDacMuxEnumNet.Stg1;
            trigger = 1;
        }


        public Stimulator(ElectrodeDacMuxEnumNet std_id)
        {
            cStgDevice = new CStg200xDownloadNet();
            UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB);
            stimElecs_IDs = new List<int>();
            stimElecs_inds = new List<int>();

            STG_ID = std_id;

            if (std_id == ElectrodeDacMuxEnumNet.Stg1)
                trigger = 1;
            else if (std_id == ElectrodeDacMuxEnumNet.Stg2)
                trigger = 2;
        }

        public Stimulator(ElectrodeDacMuxEnumNet std_id, List<int> inds)
        {
            cStgDevice = new CStg200xDownloadNet();
            UsbDeviceList = new CMcsUsbListNet(DeviceEnumNet.MCS_DEVICE_USB);
            stimElecs_inds = new List<int>();

            int[] stimElecs_IDs_array = Aux.from_inds_to_IDs(inds.ToArray());
            stimElecs_IDs = stimElecs_IDs_array.ToList();
            STG_ID = std_id;

            if (std_id == ElectrodeDacMuxEnumNet.Stg1)
                trigger = 1;
            else if (std_id == ElectrodeDacMuxEnumNet.Stg2)
                trigger = 2;
        }
        //                           Constructors
        //=================================================================


        // Stimulator needs to connect via USB-A
        public uint Connect_USB_A()
        {
            // Connect to Stimulator via USB-A:
            CMcsUsbListEntryNet[] entries = UsbDeviceList.GetUsbListEntries();
            int nEntries = entries.Length;

            uint USB_A = 0;
            if (entries[0].SerialNumber.Last() == 'B')
                USB_A = 1;

            uint status = cStgDevice.Connect(UsbDeviceList.GetUsbListEntry(USB_A), 0);
            return status;
        }


        public void Disconnect()
        {
            cStgDevice.Disconnect();
        }


        // Connect Stim Electrodes to STG DAC:
        // Can be done once for all available stim electrode. Then you can just enable/disable individual stim electrodes.
        public void Set_DacMux_StimElecs()
        {
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeDacMux((uint)stimElecs_IDs[i], 0, STG_ID); // --- FIX Side Band Signals (?)
            }
        }


        // Connect Stim Electrodes to STG DAC:
        // Disconnect the STG Mux for all stim electrodes. Useful when you change the full set of stim electrodes
        public void unSet_DacMux_StimElecs()
        {
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeDacMux((uint)stimElecs_IDs[i], 0, ElectrodeDacMuxEnumNet.Ground); // --- FIX Side Band Signals (?)
            }
        }


        // Enable Stim Electrodes:
        public void Enable_all_StimElecs()
        {            
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeEnable((uint)stimElecs_IDs[i], 0, true); // --- FIX Side Band Signals (?)
            }
        }



        // Connect Stim Electrodes to STG DAC and Enable:
        // Use this if you want to use all the stimulation electrodes for every stimulus
        public void Enable_all_StimElecs_and_Set_DacMux()
        {
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeDacMux((uint)stimElecs_IDs[i], 0, STG_ID); // --- FIX Side Band Signals (?)
                cStgDevice.SetElectrodeEnable((uint)stimElecs_IDs[i], 0, true);   // --- FIX Side Band Signals (?)
            }
        }


        // Disable all Stim Electrodes:
        public void Disable_all_StimElecs()
        {
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeEnable((uint)stimElecs_IDs[i], 0, false); // --- FIX Side Band Signals (?)
            }
        }

        // Disable all Stim Electrodes:
        public void Disable_Full_MEA()
        {
            for (uint i = 0; i < nElecs; i++)
            {
                cStgDevice.SetElectrodeEnable(i, 0, false); // --- FIX Side Band Signals (?)
            }
        }



        // Disable all Stim Electrodes:
        public void Disable_all_StimElecs_and_UnSet_DacMux()
        {
            for (int i = 0; i < stimElecs_IDs.Count(); i++)
            {
                cStgDevice.SetElectrodeDacMux((uint)stimElecs_IDs[i], 0, ElectrodeDacMuxEnumNet.Ground); // --- FIX Side Band Signals (?)
                cStgDevice.SetElectrodeEnable((uint)stimElecs_IDs[i], 0, false); // --- FIX Side Band Signals (?)
            }
        }


        // Disable all Stim Electrodes:
        public void Disable_and_UnSet_DacMux_Full_MEA()
        {
            for (uint i = 0; i < nElecs; i++)
            {
                cStgDevice.SetElectrodeDacMux(i, 0, ElectrodeDacMuxEnumNet.Ground); // --- FIX Side Band Signals (?)
                cStgDevice.SetElectrodeEnable(i, 0, false); // --- FIX Side Band Signals (?)
            }
        }


        // Enable individual Stim Electrode:
        public void Enable_StimElec_ID(uint elec_ID)
        {
            cStgDevice.SetElectrodeEnable(elec_ID, 0, true);
        }


        // Disable individual Stim Electrode:
        public void Disable_StimElec_ID(uint elec_ID)
        {
            cStgDevice.SetElectrodeEnable(elec_ID, 0, false);
        }


        public void Set_STG_ID(ElectrodeDacMuxEnumNet stg_id)
        {
            STG_ID = stg_id;
            if (stg_id == ElectrodeDacMuxEnumNet.Stg1)
                trigger = 1;
            else if (stg_id == ElectrodeDacMuxEnumNet.Stg2)
                trigger = 2;
        }


        public void Set_STG_ID(int id)
        {
            if (id == 1)
            {
                STG_ID = ElectrodeDacMuxEnumNet.Stg1;
                trigger = 1;
            }
            else if (id == 2) 
            { 
                STG_ID = ElectrodeDacMuxEnumNet.Stg2; 
                trigger = 2;
            }
    }

        public void Stimulate(uint trigger)
        {
            cStgDevice.SendStart(trigger);
        }

        public void Stimulate()
        {
            cStgDevice.SendStart(trigger);
        }

        public void Set_Trigger(uint trig)
        {
            trigger = trig;
        }

        public int Get_STG_ID()
        {
            if (STG_ID == ElectrodeDacMuxEnumNet.Stg1)
                return 1;
            else
                return 2;
        }


        public List<int> Get_StimElecs_IDs()
        {
            return stimElecs_IDs;
        }


        public List<int> Get_StimElecs_inds()
        {
            return stimElecs_inds;
        }


        //------------------------------------------
        //        Add Stimulation Electrodes:
        public void Set_StimElecs_IDs(List<int> IDs)
        {
            stimElecs_IDs = IDs;
            stimElecs_inds = Aux.from_IDs_to_inds(IDs);
        }


        public void Add_StimElec_ID(int ID)
        {
            stimElecs_IDs.Add(ID);
            int ind = Aux.from_ID_to_ind(ID);
            stimElecs_inds.Add(ind);
        }

        public void Add_StimElecs_IDs(int[] IDs)
        {
            int nIDs = IDs.Length;

            for (int i = 0; i < nIDs; i++)
            {
                stimElecs_IDs.Add(IDs[i]);
                int ind = Aux.from_ID_to_ind(IDs[i]);
                stimElecs_inds.Add(ind);
            }
        }

        public void Add_StimElec_ind(int ind)
        {
            stimElecs_inds.Add(ind);
            int ID = Aux.from_ind_to_ID(ind);
            stimElecs_IDs.Add(ID);
        }

        public void Add_StimElecs_inds(int[] inds)
        {
            int ninds = inds.Length;

            for (int i = 0; i < ninds; i++)
            {
                stimElecs_IDs.Add(inds[i]);
                int ID = Aux.from_ind_to_ID(inds[i]);
                stimElecs_IDs.Add(ID);
            }
        }
        //         Add Stimulation Electrodes
        //------------------------------------------

        public void Remove_StimElec_ID(int ID)
        {
            stimElecs_IDs.Remove(ID);
            stimElecs_inds.Remove(Aux.from_ID_to_ind(ID));
        }

        public void Remove_StimElec_ind(int ind)
        {
            stimElecs_IDs.Remove(Aux.from_ind_to_ID(ind));
            stimElecs_inds.Remove(ind);
        }

        public void Remove_StimElecs()
        {
            stimElecs_IDs = new List<int>();
            stimElecs_inds = new List<int>();
        }
    }
}
