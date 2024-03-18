using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using VACM.CLI.NET4_0.ViewModels;

namespace VACM.CLI.NET4_0.Views
{
    public class FileMenuView
    {
        #region Parameters

        private readonly Dictionary<string, Action>
            menuOptionAndMethodDictionary = new Dictionary<string, Action>
            {
                { "Open",   OpenFile },
                { "New",    CreateFile },
                { "Save",   SaveFile },
                { "Close",  CloseFile },
            };

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public FileMenuView()
        {
            iLog.Info($"Opening {nameof(FirstMenuView)}...");
            PrintFileMenu();
        }

        /// <summary>
        /// Print first menu.
        /// </summary>
        internal void PrintFileMenu()
        {
            iLog.Info($"Opening {nameof(PrintFileMenu)}...");
            Console.WriteLine();
            Console.WriteLine("File Menu");
            Console.WriteLine();

            PrintMenu.PrintAndInvokeSelectedAction
                (menuOptionAndMethodDictionary.ToList());
        }

        /// <summary>
        /// Close file.
        /// </summary>
        internal static void CloseFile()
        {
            iLog.Info($"Opening {nameof(CloseFile)}...");

            Console.WriteLine();
        }

        /// <summary>
        /// Create file.
        /// </summary>
        internal static void CreateFile()
        {
            iLog.Info($"Opening {nameof(CreateFile)}...");

            Console.WriteLine();
        }

        /// <summary>
        /// Open file.
        /// </summary>
        internal static void OpenFile()
        {
            iLog.Info($"Opening {nameof(OpenFile)}...");
    
            Console.WriteLine();
        }

        /// <summary>
        /// Save file.
        /// </summary>
        internal static void SaveFile()
        {
            iLog.Info($"Opening {nameof(SaveFile)}...");

            Console.WriteLine();
        }

        #endregion
    }
}
