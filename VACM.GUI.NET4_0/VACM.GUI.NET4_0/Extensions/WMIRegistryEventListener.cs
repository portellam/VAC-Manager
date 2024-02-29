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
    public class WMIRegistryEventListener : IDisposable
    {
        // TODO: add on value change event.
        // TODO: how to know when event signals a change, and to retrieve that value?


        // TODO: create new thread with async tasks, monitor for new event on registry
        //  key, and check for new value on event, and retrieve value.

        // TODO: add logic to watch for given sub key and its values.
        //  Track the values changed, or if it does change (boolean).



        #region Parameters

        private WindowsIdentity currentWindowsIdentity;

        private List<ManagementEventWatcher> managementEventWatcherList
        {
            get
            {
                return registryKeyPathAndValueNameAndManagementEventWatcherDictionary
                    .SelectMany(registryValueNameAndManagementEventWatcherDictionary =>
                        registryValueNameAndManagementEventWatcherDictionary.Value
                        .Select(managementEventWatcher => managementEventWatcher.Value))
                        .ToList();
            }
        }

        private Dictionary<string, Dictionary<string, ManagementEventWatcher>>
            registryKeyPathAndValueNameAndManagementEventWatcherDictionary;

        private Dictionary<RegistryHive, Dictionary<string, List<string>>>
            registryHiveAndKeyPathAndValueNameListDictionary;

        private Dictionary<RegistryHive, Dictionary<string, Dictionary<string, string>>>
            registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary;

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

            ConstructorHelper();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPathAndValueNameListDictionary">The registry key
        /// path and value name list dictionary</param>
        public WMIRegistryEventListener(RegistryHive registryHive,
            Dictionary<string, List<string>> registryKeyPathAndValueNameListDictionary)
        {
            this.registryHiveAndKeyPathAndValueNameListDictionary =
                new Dictionary<RegistryHive, Dictionary<string, List<string>>>()
                {
                    {
                        registryHive, registryKeyPathAndValueNameListDictionary
                    },
                };

            ConstructorHelper();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="registryHiveAndKeyPathAndValueNameListDictionary">The registry
        /// hive, key path, and value name list dictionary</param>
        public WMIRegistryEventListener
            (Dictionary<RegistryHive, Dictionary<string, List<string>>>
            registryHiveAndKeyPathAndValueNameListDictionary)
        {
            this.registryHiveAndKeyPathAndValueNameListDictionary =
                registryHiveAndKeyPathAndValueNameListDictionary;

            ConstructorHelper();
        }

        /// <summary>
        /// Constructor helper logic
        /// </summary>
        internal void ConstructorHelper()
        {
            if (registryHiveAndKeyPathAndValueNameListDictionary is null
                || registryHiveAndKeyPathAndValueNameListDictionary.Count == 0)
            {
                throw new ArgumentNullException();
            }

            registryKeyPathAndValueNameAndManagementEventWatcherDictionary =
                new Dictionary<string, Dictionary<string, ManagementEventWatcher>>();

            registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary =
                new Dictionary<RegistryHive, Dictionary
                    <string, Dictionary<string, string>>>();

            currentWindowsIdentity = WindowsIdentity.GetCurrent();
            ParseConstructorDictionaryAndSetDictionaries();
            StartAllManagementEventWatchers();

            Thread.Sleep(10000);
            StopAllManagementEventWatchers();
        }

        /// <summary>
        /// Get the management event watcher.
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The management event watcher</returns>
        internal ManagementEventWatcher GetManagementEventWatcher(string query)
        {
            ManagementEventWatcher managementEventWatcher =
                new ManagementEventWatcher(new EventQuery(query));

            int timeoutInSeconds = 5;

            managementEventWatcher.Options.Timeout =
                TimeSpan.FromSeconds(timeoutInSeconds);

            managementEventWatcher.EventArrived +=
                new EventArrivedEventHandler
                    (RegistryEventHandler_GetSubKeyValueOnRegistryValueChangeEvent);

            return managementEventWatcher;
        }

        /// <summary>
        /// Get the registry key from the valid hive.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <returns>The registry key</returns>
        internal RegistryKey GetRegistryKeyFromHive(RegistryHive registryHive)
        {
            if (!validRegistryHiveObjectAndValueDictionary.ContainsKey(registryHive))
            {
                return null;
            }

            switch (registryHive)
            {
                case RegistryHive.LocalMachine:
                    return Registry.LocalMachine;

                case RegistryHive.Users:
                    return Registry.CurrentUser;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Get the WQL query as a string.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        /// <returns>The WQL query</returns>
        internal string GetQuery(RegistryHive registryHive, string registryKeyPath,
            string registryValueName)
        {
            if (string.IsNullOrWhiteSpace(registryKeyPath)
                || string.IsNullOrWhiteSpace(registryValueName))
            {
                return string.Empty;
            }

            string registryHiveAsString =
                validRegistryHiveObjectAndValueDictionary[registryHive];

            if (registryHive == RegistryHive.Users)
            {
                registryKeyPath = string.Format("{0}\\{1}",
                    currentWindowsIdentity.User.Value, registryKeyPath);

                registryKeyPath = registryKeyPath.Replace("\\", "\\\\");
            }

            string table = "RegistryValueChangeEvent";

            return string.Format
                ("{0} {1} {2} {3} {4}",
                "SELECT *",
                $"FROM {table}",
                $"WHERE Hive = '{registryHiveAsString}'",
                $@"AND KeyPath = '{registryKeyPath}'",
                $"AND ValueName = '{registryValueName}'");
        }

        /// <summary>
        /// Parse constructor dictionary and set dictionaries.
        /// </summary>
        internal void ParseConstructorDictionaryAndSetDictionaries()
        {
            registryHiveAndKeyPathAndValueNameListDictionary.Keys.ToList().ForEach
                (registryHive => ParseRegistryHiveAndSetDictionaries(registryHive));
        }

        /// <summary>
        /// Parse registry hive and set dictionaries.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        internal void ParseRegistryHiveAndSetDictionaries(RegistryHive registryHive)
        {
            registryHiveAndKeyPathAndValueNameListDictionary[registryHive].Keys.ToList()
                .ForEach
                    (registryKeyPath => ParseRegistryHiveAndKeyPathAndSetDictionaries
                        (registryHive, registryKeyPath));
        }

        /// <summary>
        /// Parse registry hive and registry 
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        internal void ParseRegistryHiveAndKeyPathAndSetDictionaries
            (RegistryHive registryHive, string registryKeyPath)
        {
            registryHiveAndKeyPathAndValueNameListDictionary
                [registryHive][registryKeyPath].ForEach(registryValueName =>
                ParseRegistryHiveAndKeyPathAndValueNameAndSetDictionaries
                    (registryHive, registryKeyPath, registryValueName));
        }

        /// <summary>
        /// Parse registry key path and set dictionaries.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        internal void ParseRegistryHiveAndKeyPathAndValueNameAndSetDictionaries
            (RegistryHive registryHive, string registryKeyPath,
            string registryValueName)
        {
            if (string.IsNullOrWhiteSpace(registryValueName))
            {
                return;
            }

            if (!validRegistryHiveObjectAndValueDictionary
                .ContainsKey(registryHive))
            {
                string message = $"Registry Hive '{registryHive.ToString()} is not" +
                    "supported.'";

                throw new ArgumentException(message);
            }

            string query =
                GetQuery(registryHive, registryKeyPath, registryValueName);

            ManagementEventWatcher managementEventWatcher =
                GetManagementEventWatcher(query);

            if (!registryKeyPathAndValueNameAndManagementEventWatcherDictionary
                .ContainsKey(registryKeyPath))
            {
                registryKeyPathAndValueNameAndManagementEventWatcherDictionary.Add
                    (registryKeyPath,
                    new Dictionary<string, ManagementEventWatcher>()
                        {
                            { registryValueName, managementEventWatcher },
                        });
            }
            else
            {
                registryKeyPathAndValueNameAndManagementEventWatcherDictionary
                    [registryKeyPath].Add(registryValueName, managementEventWatcher);
            }

            SetSubKeyValueInDictionary
                (registryHive, registryKeyPath, registryValueName);
        }

        /// <summary>
        /// On RegistryValueChangeEvent, extract the WQL query fields related to the
        /// dictionary, and get the current sub key value.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArrivedEventArgs">The event arrived event arguments
        /// </param>
        internal void RegistryEventHandler_GetSubKeyValueOnRegistryValueChangeEvent
            (object sender, EventArrivedEventArgs eventArrivedEventArgs)
        {
            if (!(sender is ManagementEventWatcher))
            {
                return;
            }

            string registryHiveAsString = null;
            string registryKeyPath = null;
            string registryValueName = null;

            foreach (var propertyData in eventArrivedEventArgs.NewEvent.Properties)
            {
                switch (propertyData.Name)
                {
                    case "Hive":
                        registryHiveAsString = propertyData.Value.ToString();
                        continue;

                    case "KeyPath":
                        registryKeyPath = propertyData.Value.ToString();
                        continue;

                    case "ValueName":
                        registryValueName = propertyData.Value.ToString();
                        continue;

                    default:
                        continue;
                }
            }

            if (string.IsNullOrWhiteSpace(registryHiveAsString)
                || string.IsNullOrWhiteSpace(registryKeyPath)
                || string.IsNullOrWhiteSpace(registryValueName))
            {
                return;
            }

            RegistryHive registryHive = validRegistryHiveObjectAndValueDictionary
                .FirstOrDefault(x => x.Value == registryHiveAsString).Key;

            SetSubKeyValueInDictionary
                (registryHive, registryKeyPath, registryValueName);

            //TODO:
            /* 
             * -when the actual subkey value changes, how do I tell this class to
             * update the relevant boolean value in another class?
             * 
             */
        }

        /// <summary>
        /// Get sub key value in the dictionary.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        internal void SetSubKeyValueInDictionary(RegistryHive registryHive,
            string registryKeyPath, string registryValueName)
        {
            string subKeyValue = GetSubKeyValueOfRegistryKey
                (registryHive, registryKeyPath, registryValueName);

            if (!registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary
                .ContainsKey(registryHive))
            {
                registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary.Add
                    (registryHive,
                    new Dictionary<string, Dictionary<string, string>>()
                        {
                            { registryKeyPath, new Dictionary<string, string>()
                                {
                                    { registryValueName, subKeyValue },
                                }
                            }
                        });

                return;
            }
            else if (!registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary
                [registryHive][registryKeyPath][registryValueName]
                .Contains(subKeyValue))
            {
                registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary
                    [registryHive][registryKeyPath].Add(registryValueName, subKeyValue);
            }
            else
            {
                registryHiveAndKeyPathAndValueNameAndSubKeyValueDictionary
                    [registryHive][registryKeyPath][registryValueName] = subKeyValue;
            }
        }

        /// <summary>
        /// Start all management event watchers.
        /// </summary>
        internal void StartAllManagementEventWatchers()
        {
            if (managementEventWatcherList is null
                || managementEventWatcherList.Count == 0)
            {
                return;
            }

            managementEventWatcherList.ForEach(managementEventWatcher =>
                StartManagementEventWatcher(managementEventWatcher));
        }

        /// <summary>
        /// Start management event watcher.
        /// </summary>
        /// <param name="managementEventWatcher">The management event watcher</param>
        internal void StartManagementEventWatcher
            (ManagementEventWatcher managementEventWatcher)
        {
            if (managementEventWatcher is null)
            {
                return;
            }

            managementEventWatcher.Start();
            //TODO: add logger here. Check status (if started or not).
        }

        /// <summary>
        /// Stop all management event watchers.
        /// </summary>
        internal void StopAllManagementEventWatchers()
        {
            if (registryKeyPathAndValueNameAndManagementEventWatcherDictionary
                is null)
            {
                return;
            }

            if (registryKeyPathAndValueNameAndManagementEventWatcherDictionary is null
                || registryKeyPathAndValueNameAndManagementEventWatcherDictionary.Count == 0)
            {
                return;
            }

            managementEventWatcherList.ForEach(managementEventWatcher =>
                StopManagementEventWatcher(managementEventWatcher));
        }

        /// <summary>
        /// Stop management event watcher.
        /// </summary>
        /// <param name="managementEventWatcher">The management event watcher</param>
        internal void StopManagementEventWatcher
            (ManagementEventWatcher managementEventWatcher)
        {
            if (managementEventWatcher is null)
            {
                return;
            }

            managementEventWatcher.Stop();
            //TODO: add logger here. Check status (if stopped or not).
        }

        #endregion

        #region Logic

        /// <summary>
        /// Get sub key value of the registry key.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        public string GetSubKeyValueOfRegistryKey(RegistryHive registryHive,
            string registryKeyPath, string registryValueName)
        {
            RegistryKey registryKey = GetRegistryKeyFromHive(registryHive);

            if (registryKey is null)
            {
                return null;
            }

            registryKey.OpenSubKey(registryKeyPath);
            var subKeyValue = registryKey?.GetValue(registryValueName);

            if (subKeyValue is null)
            {
                return null;
            }

            return subKeyValue.ToString();
        }

        /// <summary>
        /// Dispose the constructor object.
        /// </summary>
        public void Dispose()
        {
            this.StopAllManagementEventWatchers();
        }

        #endregion
    }
}