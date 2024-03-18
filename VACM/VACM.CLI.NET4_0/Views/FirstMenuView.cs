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

        private readonly Dictionary<string, Action>
            menuOptionAndMethodDictionary = new Dictionary<string, Action>
            {
                { "File",       PrintFileMenu },
                { "Devices",    PrintDeviceMenu },
                { "Links",      PrintLinkMenu },
                { "Repeaters",  PrintRepeaterMenu },
                { "Exit",       null },
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
        /// Print file menu.
        /// </summary>
        internal static void PrintFileMenu()
        {
            iLog.Info($"Opening {nameof(PrintFileMenu)}...");
            Console.WriteLine("File Menu");
            Console.WriteLine();
        }

        /// <summary>
        /// Print device menu.
        /// </summary>
        internal static void PrintDeviceMenu()
        {
            iLog.Info($"Opening {nameof(PrintDeviceMenu)}...");
            Console.WriteLine("Device Menu");
            Console.WriteLine();
        }

        /// <summary>
        /// Print link menu.
        /// </summary>
        internal static void PrintLinkMenu()
        {
            iLog.Info($"Opening {nameof(PrintLinkMenu)}...");
            Console.WriteLine("Link Menu");
            Console.WriteLine();
        }

        /// <summary>
        /// Print repeater menu.
        /// </summary>
        internal static void PrintRepeaterMenu()
        {
            iLog.Info($"Opening {nameof(PrintRepeaterMenu)}...");
            Console.WriteLine("Repeater Menu");
            Console.WriteLine();
        }

        /// <summary>
        /// Print first menu.
        /// </summary>
        internal void PrintFirstMenu()
        {
            iLog.Info($"Opening {nameof(PrintFirstMenu)}...");
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            PrintMenu.PrintAndInvokeSelectedAction
                (menuOptionAndMethodDictionary.ToList());
        }

        #endregion
    }
}
