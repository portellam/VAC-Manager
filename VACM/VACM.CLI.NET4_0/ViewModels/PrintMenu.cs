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
                int exitIndex = -1;
                int firstIndex = 0;

                nameAndActionList.ForEach(x =>
                {
                    int index = nameAndActionList.IndexOf(x) + 1;
                    string line = string.Format("{0}. {1}", index, x.Key);
                    Console.WriteLine(line);
                });

                Console.WriteLine(string.Format("{0}. {1}", firstIndex, "Return"));
                Console.WriteLine();
                Console.Write($"Enter [{firstIndex}-{nameAndActionList.Count}]: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result)
                    || result < firstIndex || result > nameAndActionList.Count)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                result--;

                if (result == exitIndex
                    || string.IsNullOrWhiteSpace(nameAndActionList[result].Key)
                    || nameAndActionList[result].Value is null)
                {
                    if (AskToReturnToPreviousMenu())
                    {
                        break;
                    }

                    continue;
                }

                Action method = nameAndActionList[result].Value;
                method.Invoke();
            }
        }

        /// <summary>
        /// Print names from list and invoke selected parameterless object.
        /// </summary>
        /// <param name="nameAndObjectTypeList">The name and object type list</param>
        public static void PrintAndInvokeSelectedObject
            (List<KeyValuePair<string, Type>> nameAndObjectTypeList)
        {
            if (nameAndObjectTypeList is null || nameAndObjectTypeList.Count == 0)
            {
                return;
            }

            while (true)
            {
                int exitIndex = -1;
                int firstIndex = 0;

                nameAndObjectTypeList.ForEach(x =>
                {
                    int index = nameAndObjectTypeList.IndexOf(x) + 1;
                    string line = string.Format("{0}. {1}", index, x.Key);
                    Console.WriteLine(line);
                });

                Console.WriteLine(string.Format("{0}. {1}", firstIndex, "Return"));
                Console.WriteLine();
                Console.Write($"Enter [{firstIndex}-{nameAndObjectTypeList.Count}]: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result)
                    || result < firstIndex || result > nameAndObjectTypeList.Count)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine();
                    continue;
                }

                result--;

                if (result == exitIndex
                    || string.IsNullOrWhiteSpace(nameAndObjectTypeList[result].Key)
                    || nameAndObjectTypeList[result].Value is null)
                {
                    if (AskToReturnToPreviousMenu())
                    {
                        break;
                    }

                    continue;
                }

                Type type = nameAndObjectTypeList[result].Value;

                try
                {
                    iLog.Info($"Creating instance of {nameof(type)}");
                    Activator.CreateInstance(type);
                }
                catch(Exception exception)
                {
                    iLog.Error(exception.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Ask to return to the previous menu if true.
        /// </summary>
        /// <returns>True/False</returns>
        internal static bool AskToReturnToPreviousMenu()
        {
            Console.Write("Return to the previous menu? Enter [Y/n]: ");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();                          //NOTE: Will jump to next line without 'Enter' pressed.
            Console.Write("");                                                          //NOTE: Padding.
            Console.Read();                                                             //NOTE: Two lines of Console.Read will allow 'Enter' to be pressed, as if ReadKey was ReadLine.
            Console.Read();
            Console.WriteLine();                                                        //NOTE: Padding.

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
