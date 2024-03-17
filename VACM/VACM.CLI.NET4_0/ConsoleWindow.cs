using log4net;
using System.Threading;
using System.Threading.Tasks;
using VACM.CLI.Views.NET4_0;

namespace VACM.CLI.NET4_0
{
    public class ConsoleWindow
    {
        /*
         * TODO:
         * -add logic to parse Program argument flags and params, and influence the
         *  constructor logic.
         * 
         */

        #region Parameters

        private static readonly ILog iLog = LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Task Task { get; private set; }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsoleWindow()
        {
            iLog.Info($"Preparing {nameof(ConsoleWindow)}...");

            PrepareTask();
            iLog.Info($"Starting task...");
            Task.Start();
        }

        /// <summary>
        /// Prepare the task.
        /// </summary>
        internal void PrepareTask()
        {
            iLog.Info($"Preparing task...");

            Task = new Task(() =>
            {
                new MainConsole();
            });
        }

        #endregion
    }
}
