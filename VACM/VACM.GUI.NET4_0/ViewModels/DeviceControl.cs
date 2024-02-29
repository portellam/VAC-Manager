using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0.ViewModels
{
    public partial class DeviceControl : UserControl
    {
        #region Parameters

        public MMDevice MMDevice { get; private set; }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        public DeviceControl(MMDevice mMDevice)
        {
            MMDevice = mMDevice;
            InitializeComponent();
        }

        #endregion
    }
}
