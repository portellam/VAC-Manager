using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VACM.GUI.NET4_0
{
    internal class Program
    {
        #region Arguments

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
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Parse arguments passed by command line.
        /// </summary>
        internal static void ParseArguments()
        {
            
        }

        #endregion
    }
}
