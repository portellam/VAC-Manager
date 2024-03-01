using System.Windows.Forms;
using VACM.GUI.NET4_0.ViewModels;
using VACM.GUI.NET4_0.Views;

namespace VACM.GUI.NET4_0
{
    public class GraphicsWindow
    {
        #region Parameters

        private static MainForm mainForm;

        public static FormColorUpdater FormColorUpdater { get; private set; }
        public static LightThemeValidator LightThemeValidator { get; private set; }

        #endregion

        #region Logic

        public GraphicsWindow()
        {
            LightThemeValidator = new LightThemeValidator
                (Program.DoesArgumentForceColorTheme, Program.IsLightThemeEnabled);

            FormColorUpdater = new FormColorUpdater();
            mainForm = new MainForm();

            Application.Run(mainForm);
        }

        #endregion
    }
}
