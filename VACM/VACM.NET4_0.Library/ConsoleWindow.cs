using System.Threading;
using VACM.NET4_0.Library.Consoles;

namespace VACM.NET4_0.Library
{
    public class ConsoleWindow
    {
        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public ConsoleWindow()
        {
            var thread = new Thread(() =>
            {
                var mainConsole = new MainConsole();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        #endregion
    }
}
