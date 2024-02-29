using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using VACM.GUI.NET4_0.ViewModels.Accessors;

namespace VACM.GUI.NET4_0.Views
{
    partial class AboutForm : Form
    {
        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();

            this.Text = String.Format
                ("About {0}", AssemblyInformationAccessor.AssemblyTitle);

            this.labelProductName.Text =
                AssemblyInformationAccessor.AssemblyProduct;

            this.labelVersion.Text = String.Format("Version {0}",
                AssemblyInformationAccessor.AssemblyVersion);

            this.labelCopyright.Text =
                AssemblyInformationAccessor.AssemblyCopyright;

            this.labelCompanyName.Text =
                AssemblyInformationAccessor.AssemblyCompany;

            this.textBoxDescription.Text =
                AssemblyInformationAccessor.AssemblyDescription;
        }

        #endregion
    }
}
