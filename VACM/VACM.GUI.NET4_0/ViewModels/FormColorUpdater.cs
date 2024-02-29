using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0.ViewModels
{
    public class FormColorUpdater
    {
        #region Parameters

        private readonly static Color darkBackColor = Color.FromArgb(60, 63, 65);
        private readonly static Color darkTextColor = Color.White;
        private readonly static Color lightBackColor = Color.White;
        private readonly static Color lightTextColor = Color.Black;

        public static Color BackColor
        {
            get
            {
                if (!LightThemeValidator.IsLightThemeEnabled)
                {
                    return darkBackColor;
                }
                else
                {
                    return lightBackColor;
                }
            }
        }

        public static Color ForeColor
        {
            get
            {
                if (!LightThemeValidator.IsLightThemeEnabled)
                {
                    return darkTextColor;
                }
                else
                {
                    return lightTextColor;
                }
            }
        }

        #endregion
    }
}
