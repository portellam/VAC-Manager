using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace VACM.NET4.Extensions
{
    public class WMIRegistryEventListener
    {
        #region Parameters

        private Dictionary<string, Dictionary<string, ManagementEventWatcher>>
            registryKeyPathAndValueNameAndManagementEventWatcherDictionary;

        private Dictionary<RegistryHive, Dictionary<string, List<string>>>
            registryHiveAndKeyPathAndValueNameListDictionary;

        /// <summary>
        /// Valid hive objects and values for RegistryEvent class and derivatives.
        /// URL: https://learn.microsoft.com/en-us/previous-versions/windows/desktop/regprov/registrykeychangeevent
        /// </summary>
        private static Dictionary<RegistryHive, string>
            validRegistryHiveObjectAndValueDictionary =
            new Dictionary<RegistryHive, string>
            {
                {
                    RegistryHive.LocalMachine,      "HKEY_LOCAL_MACHINE"
                },
                {
                    RegistryHive.Users,             "HKEY_USERS"
                },
            };

        #endregion

        #region Constructor Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueNameList">The registry value name list</param>
        public WMIRegistryEventListener(RegistryHive registryHive,
            string registryKeyPath, List<string> registryValueNameList)
        {
            this.registryHiveAndKeyPathAndValueNameListDictionary =
                new Dictionary<RegistryHive, Dictionary<string, List<string>>>()
                {
                    {
                        registryHive, new Dictionary<string, List<string>>
                        {
                            { registryKeyPath, registryValueNameList }
                        }
                    },
                };

            //TODO: add constuctor helper here.
        }

        //TODO: add multiple constructors for ease of use.

        //TODO: add start and stop watcher methods.

        //TODO: add dispose.
        
        // TODO: add on value change event.


        #endregion
    }
}