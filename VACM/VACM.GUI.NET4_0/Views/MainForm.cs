using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VACM.GUI.NET4_0.Models;
using VACM.GUI.NET4_0.ViewModels;
using VACM.NET4.Models;

namespace VACM.GUI.NET4_0.Views
{
    public partial class MainForm : Form
    {
        #region Parameters

        private string fileName;
        private DeviceListModel deviceListModel;
        private DeviceControl inputDeviceControl { get; set; }
        private DeviceControl outputDeviceControl { get; set; }
        private RepeaterDataModel repeaterDataModel { get; set; }

        public const string WaveInAsString = "Wave In";
        public const string WaveOutAsString = "Wave Out";

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        [ExcludeFromCodeCoverage]
        public MainForm()
        {
            InitializeComponent();
            PostInitializeComponent();
        }

        #endregion
    }
}
