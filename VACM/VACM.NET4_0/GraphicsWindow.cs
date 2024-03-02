using System.Windows.Forms;
using VACM.NET4_0.ViewModels;
using VACM.NET4_0.Views;

namespace VACM.NET4_0
{
    public class GraphicsWindow
    {
        #region Parameters

        private static bool isLightThemeEnabled;
        private static MainForm mainForm;

        public static bool IsLightThemeEnabled
        {
            get
            {
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
                return Program.DoesArgumentForceColorTheme;
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
            if (!DoForceColorTheme)
            {
                LightThemeValidator = new LightThemeValidator();
            }

            FormColorUpdater = new FormColorUpdater();
            mainForm = new MainForm();
            Application.Run(mainForm);

            if (LightThemeValidator != null)
            {
                LightThemeValidator.Dispose();
            }
        }

        #endregion
    }
}
