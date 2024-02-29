using System;
using System.Linq;
using System.Windows.Forms;
using VACM.GUI.NET4_0.Views;

namespace VACM.GUI.NET4_0
{
    public class Program
    {
        #region Arguments

        /// <summary>
        /// The command line arguments.
        /// </summary>
        public static string[] Arguments { get; private set; }

        public static bool DoesArgumentForceColorTheme
        {
            get
            {
                return doForceDarkThemeAtStart.HasValue
                    || doForceLightThemeAtStart.HasValue;
            }
        }

        public static bool ForcedLightTheme
        {
            get
            {
                if (doForceLightThemeAtStart.HasValue)
                {
                    return doForceLightThemeAtStart.Value;
                }

                return false;
            }
        }

        private static bool? doForceDarkThemeAtStart;
        private static bool? doForceLightThemeAtStart;

        #endregion

        #region Logic

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="arguments">The command line arguments</param>
        [STAThread]
        internal static void Main(string[] arguments)
        {
            Arguments = arguments;
            ParseArguments();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Parse arguments passed by command line.
        /// </summary>
        internal static void ParseArguments()
        {
            if (Arguments.Count() == 0)
            {
                return;
            }

            Arguments.ToList().ForEach(argument =>
            {
                if (!argument.StartsWith("/"))
                {
                    return;
                }

                switch (argument)
                {
                    case "/forcedarkmode":
                        doForceDarkThemeAtStart = true;
                        break;

                    case "/forcelightmode":
                        doForceLightThemeAtStart = true;
                        break;

                    default:
                        break;
                }
            });
        }

        #endregion
    }
}
