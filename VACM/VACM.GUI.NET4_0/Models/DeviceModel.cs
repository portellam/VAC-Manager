using NAudio.CoreAudioApi;

namespace VACM.GUI.NET4_0.Models
{
    public class DeviceModel
    {
        #region Parameters

        public bool IsChecked { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public MMDevice MMDevice { get; private set; }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        public DeviceModel(MMDevice mMDevice)
        {
            MMDevice = mMDevice;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="isSelected">Is selected</param>
        public DeviceModel(MMDevice mMDevice, bool isSelected)
        {
            MMDevice = mMDevice;
            IsChecked = isSelected;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="isSelected">Is selected</param>
        /// <param name="isChecked">Is checked</param>
        public DeviceModel(MMDevice mMDevice, bool isSelected, bool isChecked)
        {
            MMDevice = mMDevice;
            IsChecked = isSelected;
            IsChecked = isChecked;
        }

        #endregion
    }
}
