using log4net;
using System;
using System.Linq;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0
{
    public class Program
    {
        #region Arguments

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool DoForceColorTheme { get; private set; } = false;
        public static bool IsLightThemeEnabled { get; private set; } = false;

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
        internal static int Main(string[] arguments)
        {
            if (iLog is null)
            {
                return 1;
            }

            iLog.Info("Application started...");
            Arguments = arguments;
            ParseArguments();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new GraphicsWindow();

            return 0;
        }

        /// <summary>
        /// Parse arguments passed by command line.
        /// </summary>
        internal static void ParseArguments()
        {
            iLog.Info("Parsing arguments...");

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
                        DoForceColorTheme = true;
                        IsLightThemeEnabled = false;
                        break;

                    case "/forcelightmode":
                        DoForceColorTheme = true;
                        IsLightThemeEnabled = true;
                        break;

                    default:
                        break;
                }
            });
        }

        #endregion
    }
}