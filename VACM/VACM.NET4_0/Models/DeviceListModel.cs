using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace VACM.NET4_0.Models
{
    public class DeviceListModel
    {
        #region Parameters

        public List<MMDevice> AllDeviceList { get; private set; }
        public List<MMDevice> AllWaveInDeviceList { get; private set; }
        public List<MMDevice> AllWaveOutDeviceList { get; private set; }

        public List<MMDevice> SelectedWaveInMMDeviceList { get; private set; }
        public List<MMDevice> SelectedWaveOutMMDeviceList { get; private set; }

        public List<MMDevice> UnselectedWaveInMMDeviceList { get; private set; }
        public List<MMDevice> UnselectedWaveOutMMDeviceList { get; private set; }

        public List<string> AllWaveInNameList { get; private set; }
        public List<string> AllWaveOutNameList { get; private set; }

        public List<string> SelectedWaveInNameList { get; private set; }
        public List<string> SelectedWaveOutNameList { get; private set; }

        public List<string> UnselectedWaveInNameList { get; private set; }
        public List<string> UnselectedWaveOutNameList { get; private set; }

        public static DeviceState Present =
            DeviceState.Active | DeviceState.Unplugged | DeviceState.Disabled;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        [ExcludeFromCodeCoverage]
        public DeviceListModel()
        {
            AllDeviceList = new MMDeviceEnumerator()
                .EnumerateAudioEndPoints(DataFlow.All, Present).Distinct().ToList();

            SetAndSortAllMMDeviceLists();
            GetUnselectedWaveInMMDeviceLists();
            GetUnselectedWaveOutMMDeviceLists();

            SelectedWaveInMMDeviceList = new List<MMDevice>();
            SelectedWaveInNameList = new List<string>();
            SelectedWaveOutMMDeviceList = new List<MMDevice>();
            SelectedWaveOutNameList = new List<string>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="allDeviceList">The MMDevice list</param>
        public DeviceListModel(List<MMDevice> allDeviceList)
        {
            AllDeviceList = allDeviceList.Where
                (mMDevice => mMDevice.State == Present).Distinct().ToList();

            SetAndSortAllMMDeviceLists();
            GetUnselectedWaveInMMDeviceLists();
            GetUnselectedWaveOutMMDeviceLists();

            SelectedWaveInMMDeviceList = new List<MMDevice>();
            SelectedWaveInNameList = new List<string>();
            SelectedWaveOutMMDeviceList = new List<MMDevice>();
            SelectedWaveOutNameList = new List<string>();
        }

        /// <summary>
        /// Does MMDevice list contain MMDevice.
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="mMDeviceList">The MMDevice list</param>
        /// <returns></returns>
        internal bool DoesListContainMMDevice
            (MMDevice mMDevice, List<MMDevice> mMDeviceList)
        {
            return mMDeviceList is null || mMDeviceList.Count == 0
                || !mMDeviceList.Contains(mMDevice);
        }

        /// <summary>
        /// Get list of MMDevice names, given MMDevice list.
        /// </summary>
        /// <param name="mMDeviceList">The MMDevice list</param>
        /// <returns></returns>
        internal List<string> GetNameListGivenMMDeviceList(List<MMDevice> mMDeviceList)
        {
            if (mMDeviceList is null || mMDeviceList.Count == 0)
            {
                return new List<string>();
            }

            return mMDeviceList.Select(mMDevice => mMDevice.FriendlyName).ToList();
        }

        /// <summary>
        /// Get MMDevice by friendly name and data flow.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="mMDeviceFriendlyName">The MMDevice friendly name</param>
        /// <returns>The MMDevice</returns>
        public MMDevice GetMMDevice(DataFlow dataFlow, string mMDeviceFriendlyName)
        {
            MMDevice mMDevice = null;

            if (dataFlow == DataFlow.Capture)
            {
                mMDevice = AllWaveInDeviceList
                    .Where(thisMMDevice =>
                        thisMMDevice.FriendlyName == mMDeviceFriendlyName)
                    .FirstOrDefault();
            }
            else
            {
                mMDevice = AllWaveOutDeviceList
                    .Where(thisMMDevice =>
                        thisMMDevice.FriendlyName == mMDeviceFriendlyName)
                    .FirstOrDefault();
            }

            return mMDevice;
        }

        /// <summary>
        /// Get index of MMDevice by friendly name.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="mMDeviceFriendlyName">The MMDevice friendly name</param>
        /// <returns>The index</returns>
        public int GetIndexOfMMDevice(DataFlow dataFlow, string mMDeviceFriendlyName)
        {
            if (mMDeviceFriendlyName is null)
            {
                return -1;
            }

            if (dataFlow == DataFlow.Capture)
            {
                return AllWaveInNameList.IndexOf(mMDeviceFriendlyName);
            }
            else if (AllWaveOutNameList.Contains(mMDeviceFriendlyName))
            {
                return AllWaveOutNameList.IndexOf(mMDeviceFriendlyName);
            }

            return -1;
        }

        /// <summary>
        /// Get unselected wave in MMDevice lists.
        /// </summary>
        internal void GetUnselectedWaveInMMDeviceLists()
        {
            if (SelectedWaveInMMDeviceList is null ||
                SelectedWaveInMMDeviceList.Count == 0)
            {
                UnselectedWaveInMMDeviceList = AllWaveInDeviceList;
            }
            else
            {
                UnselectedWaveInMMDeviceList = AllWaveInDeviceList
                    .Where(mMDevice =>
                        !DoesListContainMMDevice(mMDevice, SelectedWaveInMMDeviceList))
                    .ToList();
            }

            UnselectedWaveInNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveInMMDeviceList);
        }

        /// <summary>
        /// Get unselected wave out MMDevice lists.
        /// </summary>
        internal void GetUnselectedWaveOutMMDeviceLists()
        {
            if (SelectedWaveOutMMDeviceList is null ||
                SelectedWaveOutMMDeviceList.Count == 0)
            {
                UnselectedWaveOutMMDeviceList = AllWaveOutDeviceList;
            }
            else
            {
                UnselectedWaveOutMMDeviceList = AllWaveOutDeviceList
                    .Where(mMDevice =>
                        !DoesListContainMMDevice(mMDevice, SelectedWaveOutMMDeviceList))
                    .ToList();
            }

            UnselectedWaveOutNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveOutMMDeviceList);
        }

        /// <summary>
        /// Set and sort all MMDevice lists.
        /// </summary>
        internal void SetAndSortAllMMDeviceLists()
        {
            if (AllDeviceList is null)
            {
                return;
            }

            AllWaveInDeviceList = AllDeviceList.Where(mMDevice =>
                mMDevice.DataFlow == DataFlow.Capture).Distinct().ToList();

            AllWaveInDeviceList = AllWaveInDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            AllWaveInNameList = GetNameListGivenMMDeviceList(AllWaveInDeviceList);

            AllWaveOutDeviceList = AllDeviceList.Where(mMDevice =>
                mMDevice.DataFlow == DataFlow.Render).Distinct().ToList();

            AllWaveOutDeviceList = AllWaveOutDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            AllWaveOutNameList = GetNameListGivenMMDeviceList(AllWaveOutDeviceList);
        }

        /// <summary>
        /// Remove MMDevice(s) from selected lists if MMDevice does not currently exist
        /// or it is not present.
        /// </summary>
        internal void SetSelectedListsGivenNewMMDeviceState()
        {
            SelectedWaveInMMDeviceList.ForEach(mMDevice =>
            {
                if (!AllWaveInDeviceList.Contains(mMDevice)
                    || mMDevice.State != Present)
                {
                    SelectedWaveInMMDeviceList.Remove(mMDevice);
                }
            });

            SelectedWaveInNameList =
                GetNameListGivenMMDeviceList(SelectedWaveInMMDeviceList);

            SelectedWaveOutMMDeviceList.ForEach(mMDevice =>
            {
                if (!AllWaveOutDeviceList.Contains(mMDevice)
                    || mMDevice.State != Present)
                {
                    SelectedWaveOutMMDeviceList.Remove(mMDevice);
                }
            });

            SelectedWaveOutNameList =
                GetNameListGivenMMDeviceList(SelectedWaveOutMMDeviceList);
        }

        /// <summary>
        /// Sort selected MMDevice lists.
        /// </summary>
        internal void SortSelectedMMDeviceLists()
        {
            SelectedWaveInMMDeviceList = SelectedWaveInMMDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            SelectedWaveInNameList =
                GetNameListGivenMMDeviceList(SelectedWaveInMMDeviceList);

            SelectedWaveOutMMDeviceList = SelectedWaveOutMMDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            SelectedWaveOutNameList =
                GetNameListGivenMMDeviceList(SelectedWaveOutMMDeviceList);
        }

        /// <summary>
        /// Sort unselected MMDevice lists.
        /// </summary>
        internal void SortUnselectedMMDeviceLists()
        {
            UnselectedWaveInMMDeviceList = UnselectedWaveInMMDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            UnselectedWaveInNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveInMMDeviceList);

            UnselectedWaveOutMMDeviceList = UnselectedWaveOutMMDeviceList
                .OrderBy(mMDevice => mMDevice.FriendlyName).ToList()
                .OrderBy(mMDevice => mMDevice.DeviceFriendlyName).ToList();

            UnselectedWaveOutNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveOutMMDeviceList);
        }

        /// <summary>
        /// Move all unselected MMDevices to selected lists.
        /// </summary>
        public void MoveAllMMDevicesToSelectedLists()
        {
            SelectedWaveInMMDeviceList.AddRange(UnselectedWaveInMMDeviceList);
            UnselectedWaveInMMDeviceList = new List<MMDevice>();

            UnselectedWaveInNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveInMMDeviceList);

            SelectedWaveOutMMDeviceList.AddRange(UnselectedWaveOutMMDeviceList);
            UnselectedWaveOutMMDeviceList = new List<MMDevice>();

            UnselectedWaveOutNameList =
                GetNameListGivenMMDeviceList(UnselectedWaveOutMMDeviceList);

            SortSelectedMMDeviceLists();
        }

        /// <summary>
        /// Move MMDevice from selected list to related unselected list.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="mMDeviceName">The MMDevice name</param>
        public void MoveMMDeviceFromSelectedList(DataFlow dataFlow, string mMDeviceName)
        {
            if (string.IsNullOrWhiteSpace(mMDeviceName))
            {
                return;
            }

            MMDevice mMDevice = GetMMDevice(dataFlow, mMDeviceName);

            if (mMDevice is null)
            {
                return;
            }

            if (dataFlow == DataFlow.Capture)
            {
                SelectedWaveInMMDeviceList.Remove(mMDevice);

                SelectedWaveInNameList =
                    GetNameListGivenMMDeviceList(SelectedWaveInMMDeviceList);

                UnselectedWaveInMMDeviceList.Add(mMDevice);

                UnselectedWaveInNameList =
                    GetNameListGivenMMDeviceList(UnselectedWaveInMMDeviceList);
            }
            else
            {
                SelectedWaveOutMMDeviceList.Remove(mMDevice);

                SelectedWaveOutNameList =
                    GetNameListGivenMMDeviceList(SelectedWaveOutMMDeviceList);

                UnselectedWaveOutMMDeviceList.Add(mMDevice);

                UnselectedWaveOutNameList =
                    GetNameListGivenMMDeviceList(UnselectedWaveOutMMDeviceList);
            }

            SortUnselectedMMDeviceLists();
        }

        /// <summary>
        /// Move MMDevice from unselected list to related selected list.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="mMDeviceName">The MMDevice name</param>
        public void MoveMMDeviceToSelectedList(DataFlow dataFlow, string mMDeviceName)
        {
            if (string.IsNullOrWhiteSpace(mMDeviceName))
            {
                return;
            }

            MMDevice mMDevice = GetMMDevice(dataFlow, mMDeviceName);

            if (mMDevice is null)
            {
                return;
            }

            if (dataFlow == DataFlow.Capture)
            {
                UnselectedWaveInMMDeviceList.Remove(mMDevice);

                UnselectedWaveInNameList =
                    GetNameListGivenMMDeviceList(UnselectedWaveInMMDeviceList);

                SelectedWaveInMMDeviceList.Add(mMDevice);

                SelectedWaveInNameList =
                    GetNameListGivenMMDeviceList(SelectedWaveInMMDeviceList);
            }
            else
            {
                UnselectedWaveOutMMDeviceList.Remove(mMDevice);

                UnselectedWaveOutNameList =
                    GetNameListGivenMMDeviceList(UnselectedWaveOutMMDeviceList);

                SelectedWaveOutMMDeviceList.Add(mMDevice);

                SelectedWaveOutNameList =
                    GetNameListGivenMMDeviceList(SelectedWaveOutMMDeviceList);
            }

            SortSelectedMMDeviceLists();
        }

        /// <summary>
        /// Parse MMDevice name list and move each valid MMDevice to the relevant
        /// selected list.
        /// </summary>
        /// <param name="mMDeviceNameList">The MMDevice name list</param>
        public void MoveMMDeviceNameListFromSelectedList
            (DataFlow dataFlow, List<string> mMDeviceNameList)
        {
            if (dataFlow == DataFlow.All || mMDeviceNameList is null
                || mMDeviceNameList.Count == 0)
            {
                return;
            }

            mMDeviceNameList.ForEach(mMDeviceName =>
                MoveMMDeviceFromSelectedList(dataFlow, mMDeviceName));
        }

        /// <summary>
        /// Parse MMDevice name list and move each valid MMDevice to the relevant
        /// selected list.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="mMDeviceNameList">The MMDevice name list</param>
        public void MoveMMDeviceNameListToSelectedList
            (DataFlow dataFlow, List<string> mMDeviceNameList)
        {
            if (dataFlow == DataFlow.All || mMDeviceNameList is null
                || mMDeviceNameList.Count == 0)
            {
                return;
            }

            mMDeviceNameList.ForEach(mMDeviceName =>
                MoveMMDeviceToSelectedList(dataFlow, mMDeviceName));
        }

        #endregion
    }
}