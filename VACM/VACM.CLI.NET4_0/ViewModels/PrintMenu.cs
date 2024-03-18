using log4net;
using System;
using System.Collections.Generic;

namespace VACM.CLI.NET4_0.ViewModels
{
    public class PrintMenu
    {
        #region Parameters

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Logic

        /// <summary>
        /// Print names from list and invoke selected action.
        /// </summary>
        /// <param name="nameAndActionList">The name and action list</param>
        public static void PrintAndInvokeSelectedAction
            (List<KeyValuePair<string, Action>> nameAndActionList)
        {
            if (nameAndActionList is null || nameAndActionList.Count == 0)
            {
                return;
            }

            while (true)
            {
                nameAndActionList.ForEach(x =>
                {
                    int index = nameAndActionList.IndexOf(x) + 1;
                    string line = string.Format("{0}. {1}", index, x.Key);
                    Console.WriteLine(line);
                });

                Console.Write($"Enter [{1}-{nameAndActionList.Count}]:\t");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result)
                    || result < 1 || result > nameAndActionList.Count)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                result--;

                string option = nameAndActionList[result].Key;
                Action method = nameAndActionList[result].Value;

                if (string.IsNullOrWhiteSpace(option) || method is null)
                {
                    if (ReturnToThePreviousMenuIfYes())
                    {
                        break;
                    }

                    continue;
                }

                method.Invoke();
            }
        }

        /// <summary>
        /// Return to the previous menu if true.
        /// </summary>
        /// <returns>True/False</returns>
        internal static bool ReturnToThePreviousMenuIfYes()
        {
            Console.Write("Return to the previous menu? Enter [Y/n]:\t");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Y:
                    return true;

                case ConsoleKey.N:
                    return false;

                default:
                    iLog.Warn($"Invalid input \"{consoleKeyInfo.Key}\".");
                    Console.WriteLine($"Invalid input.");
                    return false;
            }
        }

        #endregion
    }
}
