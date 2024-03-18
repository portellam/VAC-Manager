using System;
using System.Collections.Generic;

namespace VACM.CLI.NET4_0.ViewModels
{
    public class PrintMenu
    {
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
                    break;
                }

                method.Invoke();
            }
        }

        #endregion
    }
}
