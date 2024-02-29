using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NAudio.CoreAudioApi;

namespace VACM.NET4.Models
{
    public class DeviceListModel
    {
        /*
         * -create constructor helper logic.    DONE
         * -set and sort device lists.          DONE
         * -set unselected lists.               DONE
         * -add interaction logic for form.
         * -???
         * 
         */

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

        #endregion
    }
}