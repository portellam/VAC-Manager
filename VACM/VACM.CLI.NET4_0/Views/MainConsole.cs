using log4net;
using System;
using VACM.CLI.NET4_0.Views;
using VACM.GUI.NET4_0.ViewModels.Accessors;

namespace VACM.CLI.Views.NET4_0
{
    public class MainConsole
    {
        #region Parameters

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
            new FirstMenuView();
        }

        #endregion
    }
}