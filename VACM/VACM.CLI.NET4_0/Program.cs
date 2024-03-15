using System;
using System.Linq;

namespace VACM.CLI.NET4_0
{
    public class Program
    {
        #region Arguments

        /// <summary>
        /// The command line arguments.
        /// </summary>
        private static string[] Arguments;

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
            new ConsoleWindow();
        }

        /// <summary>
        /// Parse arguments passed by command line.
        /// </summary>
        internal static void ParseArguments()
        {
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
                    default:
                        break;
                }
            });
        }

        #endregion
    }
}