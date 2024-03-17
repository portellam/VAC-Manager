using log4net;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using File = System.IO.File;

namespace VACM.CLI.NET4_0
{
    public class Program
    {
        #region Arguments

        public static bool DisableAllDevices { get; private set; }
        public static bool EnableAllDevices { get; private set; }
        public static bool OutputVACMFileToBatchScriptFile { get; private set; }
        public static bool OutputVACMFileToWindowsTaskFile { get; private set; }
        public static bool OpenVACMFile { get; private set; }
        public static bool RestartAllCurrentRepeaters { get; private set; }
        public static bool StartAllRepeaters { get; private set; }
        public static bool StopAllCurrentRepeaters { get; private set; }
        public static string BatchScriptFilename { get; private set; }
        public static string VACMFilename { get; private set; }
        public static string WindowsTaskFilename { get; private set; }

        /// <summary>
        /// The command line arguments.
        /// </summary>
        private static string[] Arguments;

        #endregion

        #region Parameters

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Logic

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="arguments">The command line arguments</param>
        [STAThread]
        internal static int Main(string[] arguments)
        {
            iLog.Info("Application started...");
            Arguments = arguments;

            try
            {
                ParseArgumentsOrThrowException();
            }
            catch
            {
                return 2;
            }

            int resultCode;

            try
            {
                ConsoleWindow consoleWindow = new ConsoleWindow();
                iLog.Info($"Waiting on task completion...");
                consoleWindow.Task.Wait();
                resultCode = 0;
                Console.WriteLine();
            }
            catch (TaskCanceledException taskCanceledException)
            {
                iLog.Warn(taskCanceledException.Message);
                resultCode = 2;
            }
            catch (Exception exception)
            {
                iLog.Error(exception.Message);
                Console.WriteLine("An unexpected error has occurred.");
                resultCode = 1;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return resultCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static void ParseArgumentsOrThrowException()
        {
            string errorMessage =
                "One or more argument(s) and/or option(s) are not valid.";

            try
            {
                ParseArguments();
                ThrowExceptionIfAnyDependentArgumentIsNotValid();
            }
            catch (ArgumentException argumentException)
            {
                iLog.Info(argumentException.Message);
                Console.WriteLine(errorMessage);
                throw;
            }
            catch (NotSupportedException notSupportedException)
            {
                iLog.Info(notSupportedException.Message);
                Console.WriteLine(errorMessage);
                throw;
            }
            catch (Exception exception)
            {
                iLog.Info(exception.Message);
                Console.WriteLine("An unexpected error has occurred.");
                throw;
            }
        }

        /// <summary>
        /// Get formatted filename.
        /// </summary>
        internal static string GetFilename(string filename)
        {
            try
            {
                return GetFilenameOrThrowException(filename);
            }
            catch (Exception exception)
            {
                iLog.Error(exception.Message);
                throw;
            }
        }

        /// <summary>
        /// Throw exception if filename is not valid. Else, get formatted string of
        /// filename without quotations.
        /// </summary>
        /// <param name="filename">The filename with quotations.</param>
        /// <returns>The filename without quotations</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        internal static string GetFilenameOrThrowException(string filename)
        {
            if (filename.Contains(" ") &&
                (!filename.StartsWith("\"") || !filename.StartsWith("\"")))
            {
                throw new ArgumentException("Filename must be in quotations.");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (!File.Exists(filename))
            {
                throw new Exception(nameof(filename));
            }

            filename.TrimStart('"').TrimEnd('"');
            return filename;
        }

        /// <summary>
        /// Parse arguments passed by command line.
        /// </summary>
        internal static void ParseArguments()
        {
            iLog.Info("Parsing arguments...");

            if (Arguments.Count() == 0)
            {
                return;
            }

            Arguments.ToList().ForEach(argument =>
            {
                ParseThisArgument(argument);
            });
        }

        /// <summary>
        /// Parse this argument, and set the related argument flags.
        /// </summary>
        /// <param name="argument">The argument</param>
        internal static void ParseThisArgument(string argument)
        {
            if (!argument.StartsWith("/"))
            {
                return;
            }

            int index = Arguments.ToList().IndexOf(argument);

            string[] options = Arguments.Skip(index)
                .TakeWhile(x =>
                {
                    return !x.StartsWith("/");
                }).ToArray();

            switch (argument.ToLower())
            {
                case "/disableAllDevices":
                    DisableAllDevices = true;
                    break;

                case "/enableAllDevices":
                    EnableAllDevices = true;
                    break;

                case "/outputToBAT":
                    OutputVACMFileToBatchScriptFile = true;

                    try
                    {
                        ParseOptions(options, 1);
                        BatchScriptFilename = GetFilename(options[0]);
                    }
                    catch
                    {
                        Console.WriteLine("BAT filename is not valid.");
                        throw;
                    }

                    break;

                case "/outputToTask":
                    OutputVACMFileToWindowsTaskFile = true;

                    try
                    {
                        ParseOptions(options, 1);
                        WindowsTaskFilename = GetFilename(options[0]);
                    }
                    catch
                    {
                        Console.WriteLine("Windows Task filename is not valid.");
                        throw;
                    }

                    break;

                case "/file":
                    OpenVACMFile = true;

                    try
                    {
                        ParseOptions(options, 1);
                        VACMFilename = GetFilename(options[0]);
                    }
                    catch
                    {
                        Console.WriteLine("Filename is not valid.");
                        throw;
                    }

                    break;

                case "/restartAllCurrent":
                    RestartAllCurrentRepeaters = true;
                    break;

                case "/startAllNew":
                    StartAllRepeaters = true;
                    break;

                case "/stopAllCurrent":
                    StopAllCurrentRepeaters = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Parse options of passed by command line.
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="maxOptionsCount">The maximum options count</param>
        internal static void ParseOptions(string[] options, int maxOptionsCount)
        {
            iLog.Info("Parsing options...");

            try
            {
                ParseOptionsOrThrowException(options, maxOptionsCount);
            }
            catch (Exception exception)
            {
                iLog.Error(exception);
                throw;
            }
        }

        /// <summary>
        /// Throw an exception if an argument's option(s) are null, exceeds maximum
        /// count, or contains an another argument.
        /// </summary>
        /// <param name="options">The options</param>
        /// <param name="maxOptionsCount">The max options count</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal static void ParseOptionsOrThrowException
            (string[] options, int maxOptionsCount)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (maxOptionsCount < 0 || maxOptionsCount > byte.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxOptionsCount));
            }
            if (options.Length > maxOptionsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            if (options.ToList().Any(x => x.StartsWith("/")))
            {
                throw new ArgumentException("Options contain arguments.");
            }
        }

        /// <summary>
        /// Throw argument exception should any argument which depends on another be not
        /// valid.
        /// </summary>
        internal static void ThrowExceptionIfAnyDependentArgumentIsNotValid()
        {
            if (StartAllRepeaters && !OpenVACMFile)
            {
                iLog.Error
                    ($"{nameof(StartAllRepeaters)} requires {nameof(OpenVACMFile)}");

                Console.WriteLine("Filename is not valid.");
                throw new ArgumentException(nameof(OpenVACMFile));
            }

            if (OutputVACMFileToBatchScriptFile && !OpenVACMFile)
            {
                iLog.Error
                    ($"{nameof(OutputVACMFileToBatchScriptFile)} depends on " +
                    $"{nameof(OpenVACMFile)}");

                Console.WriteLine("Filename is not valid.");
                throw new ArgumentException(nameof(OpenVACMFile));
            }

            if (OutputVACMFileToWindowsTaskFile && !OpenVACMFile)
            {
                iLog.Error
                    ($"{nameof(OutputVACMFileToWindowsTaskFile)} depends on " +
                    $"{nameof(OpenVACMFile)}");

                Console.WriteLine("Filename is not valid.");
                throw new ArgumentException(nameof(OpenVACMFile));
            }
        }

        #endregion
    }
}