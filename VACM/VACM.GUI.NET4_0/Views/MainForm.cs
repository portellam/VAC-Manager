using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0.Views
{
    public partial class MainForm : Form
    {
        #region Parameters

        public const string WaveInAsString = "Wave In";
        public const string WaveOutAsString = "Wave Out";

        #endregion

        #region Logic

        /// <summary>
        /// Main form view
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion
    }
}
