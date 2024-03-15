﻿using System.Threading;
using System.Windows.Forms;
using VACM.GUI.NET4_0.ViewModels;
using VACM.GUI.NET4_0.Views;

namespace VACM.GUI.NET4_0
{
    public class GraphicsWindow
    {
        #region Parameters

        private static bool isLightThemeEnabled;

        public static bool IsLightThemeEnabled
        {
            get
            {
                if (DoForceColorTheme)
                {
                    return Program.IsLightThemeEnabled;
                }

                return isLightThemeEnabled;
            }

            set
            {
                if (DoForceColorTheme)
                {
                    return;
                }

                isLightThemeEnabled = value;
            }
        }

        public static bool DoForceColorTheme
        {
            get
            {
                return Program.DoForceColorTheme;
            }
        }

        public static FormColorUpdater FormColorUpdater { get; private set; }
        public static LightThemeValidator LightThemeValidator { get; private set; }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public GraphicsWindow()
        {
            var thread = new Thread(() =>
            {
                if (!DoForceColorTheme)
                {
                    LightThemeValidator = new LightThemeValidator();
                }

                FormColorUpdater = new FormColorUpdater();
                Control.CheckForIllegalCrossThreadCalls = false;
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                Control.CheckForIllegalCrossThreadCalls = true;

                if (LightThemeValidator != null)
                {
                    LightThemeValidator.Dispose();
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion
    }
}
