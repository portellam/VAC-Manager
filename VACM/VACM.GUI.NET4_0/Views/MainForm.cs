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

        private bool toggleDeviceAddSelectAllToolStripMenuItem;
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
            toggleDeviceAddSelectAllToolStripMenuItem = false;
            SetDeviceList();
            InitializeComponent();
            PostInitializeComponent();
        }

        /// <summary>
        /// Set the device list.
        /// </summary>
        internal void SetDeviceList()
        {
            deviceListModel = new DeviceListModel();
        }

        #endregion

        #region 1. File menu logic



        #endregion

        #region 2. Device menu logic




        #endregion

        #region 3. Link menu logic




        #endregion

        #region 4. Repeater menu logic



        #endregion

        #region 5. View menu logic



        #endregion

        #region 6. Help menu logic



        #endregion
    }
}
