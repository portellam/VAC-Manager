using System;
using System.Linq;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0
{
    public class Program
    {
        #region Arguments

        private static bool? doForceDarkTheme;
        private static bool? doForceLightTheme;

        public static bool DoesArgumentForceColorTheme
        {
            get
            {
                return doForceDarkTheme.HasValue
                    || doForceLightTheme.HasValue;
            }
        }

        public static bool IsLightThemeEnabled
        {
            get
            {
                if (doForceLightTheme.HasValue)
                {
                    return doForceLightTheme.Value;
                }

                return false;
            }
        }

        /// <summary>
        /// The command line arguments.
        /// </summary>
        public static string[] Arguments { get; private set; }

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
            new Window();
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

                switch (argument.ToLower())
                {
                    case "/forcedarkmode":
                        doForceDarkTheme = true;
                        break;

                    case "/forcelightmode":
                        doForceLightTheme = true;
                        break;

                    default:
                        break;
                }
            });
        }

        #endregion
    }
}