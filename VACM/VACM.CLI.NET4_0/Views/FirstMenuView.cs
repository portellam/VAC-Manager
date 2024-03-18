using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using VACM.CLI.NET4_0.ViewModels;

namespace VACM.CLI.NET4_0.Views
{
    public class FirstMenuView
    {
        #region Parameters

        private readonly Dictionary<string, Type>
            menuOptionAndMethodDictionary = new Dictionary<string, Type>
            {
                { "File",       typeof(FileMenuView) },
                //{ "Devices",    typeof(FileMenuView) },
                //{ "Links",      typeof(FileMenuView) },
                //{ "Repeaters",  typeof(FileMenuView) },
            };

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public FirstMenuView()
        {
            iLog.Info($"Opening {nameof(FirstMenuView)}...");
            PrintFirstMenu();
        }

        /// <summary>
        /// Print device menu.
        /// </summary>
        internal static void PrintDeviceMenu()
        {
            iLog.Info($"Opening {nameof(PrintDeviceMenu)}...");
            Console.WriteLine();
            Console.WriteLine("Device Menu");
            Console.WriteLine();

            //TODO: add code here.

        }

        /// <summary>
        /// Print first menu.
        /// </summary>
        internal void PrintFirstMenu()
        {
            iLog.Info($"Opening {nameof(PrintFirstMenu)}...");
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            PrintMenu.PrintAndInvokeSelectedObject
                (menuOptionAndMethodDictionary.ToList());
        }

        /// <summary>
        /// Print link menu.
        /// </summary>
        internal static void PrintLinkMenu()
        {
            iLog.Info($"Opening {nameof(PrintLinkMenu)}...");
            Console.WriteLine();
            Console.WriteLine("Link Menu");
            Console.WriteLine();

            //TODO: add code here.
        }

        /// <summary>
        /// Print repeater menu.
        /// </summary>
        internal static void PrintRepeaterMenu()
        {
            iLog.Info($"Opening {nameof(PrintRepeaterMenu)}...");
            Console.WriteLine();
            Console.WriteLine("Repeater Menu");
            Console.WriteLine();

            //TODO: add code here.
        }

        #endregion
    }
}
