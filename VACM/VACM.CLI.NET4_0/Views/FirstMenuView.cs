using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

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
            PrintMenuOptionsAndInvokeMethod();
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
        /// Print menu options and invoke related method.
        /// </summary>
        internal void PrintMenuOptionsAndInvokeMethod()
        {
            iLog.Info($"Opening {nameof(PrintMenuOptionsAndInvokeMethod)}...");
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            while (true)
            {
                List<KeyValuePair<string, Action>> menuOptionAndMethodList =
                    menuOptionAndMethodDictionary.ToList();

                menuOptionAndMethodList.ForEach(x =>
                {
                    int index = menuOptionAndMethodList.IndexOf(x) + 1;
                    string line = string.Format("{0}. {1}", index, x.Key);
                    Console.WriteLine(line);
                });

                Console.Write($"Enter [{1}-{menuOptionAndMethodList.Count}]:\t");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result)
                    || result < 1 || result > menuOptionAndMethodList.Count)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                result--;

                string option = menuOptionAndMethodList[result].Key;
                Action method = menuOptionAndMethodList[result].Value;

                if (string.IsNullOrWhiteSpace(option) || method is null)
                {
                    break;
                }

                method.Invoke();
            }
        }

        #endregion
    }
}
