﻿using Microsoft.Win32;

namespace VACM.GUI.NET4_0.Extensions.RegistrySubKeyChanged
{
    public class RegistrySubKeyChangedEventArgs : System.EventArgs
    {
        #region Parameters

        private RegistryHive registryHive;
        private string registryKeyPath;
        private string registryValueName;

        public RegistryHive RegistryHive
        {
            get
            {
                return registryHive;
            }
        }

        public string RegistryKeyPath
        {
            get
            {
                return registryKeyPath;
            }
        }

        public string RegistryValueName
        {
            get
            {
                return registryValueName;
            }
        }

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="registryHive">The registry key</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        public RegistrySubKeyChangedEventArgs(RegistryHive registryHive,
            string registryKeyPath, string registryValueName)
        {
            this.registryHive = registryHive;
            this.registryKeyPath = registryKeyPath;
            this.registryValueName = registryValueName; 
        }

        #endregion
    }
}
