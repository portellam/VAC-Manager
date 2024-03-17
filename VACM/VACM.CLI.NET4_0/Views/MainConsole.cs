using log4net;
using System;
using VACM.GUI.NET4_0.ViewModels.Accessors;

namespace VACM.CLI.Views.NET4_0
{
    public class MainConsole
    {
        #region Parameters

        private string[] options = new string[]
        {
            "File",
            "Devices",
            "Links",
            "Repeaters",
            "About"
        };

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public MainConsole()
        {
            iLog.Info($"Opening {nameof(MainConsole)}...");
            FirstMenu();
            PrintAndParseOptions();
        }

        internal void FirstMenu()
        {
            Console.WriteLine(
                $"Welcome to {AssemblyInformationAccessor.AssemblyProduct}!"
            );
        }

        internal void PrintAndParseOptions()
        {
            iLog.Info($"Printing options...");
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            while (true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    string option = options[i];
                    int index = i + 1;
                    string line = string.Format("{0}. {1}", index, option);
                    Console.WriteLine(line);
                }

                Console.Write($"Enter [{1}-{options.Length}]:\t");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result)
                    || result < 1 || result > options.Length)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                result--;
                break;
            }
        }

        #endregion
    }
}