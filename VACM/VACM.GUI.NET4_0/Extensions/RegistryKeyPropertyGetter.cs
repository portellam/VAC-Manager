using Microsoft.Win32;

namespace VACM.GUI.NET4_0.Extensions
{
    public class RegistryKeyPropertyGetter
    {
        # region Logic

        /// <summary>
        /// Get the registry key from the registry hive.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <returns>The registry key</returns>
        public static RegistryKey GetRegistryKeyFromHive(RegistryHive registryHive)
        {
            switch (registryHive)
            {
                case RegistryHive.ClassesRoot:
                    return Registry.ClassesRoot;

                case RegistryHive.CurrentConfig:
                    return Registry.CurrentConfig;

                case RegistryHive.CurrentUser:
                    return Registry.CurrentUser;

                case RegistryHive.DynData:
                    return Registry.PerformanceData;                                            //NOTE: Changed due to CS0618.

                case RegistryHive.LocalMachine:
                    return Registry.LocalMachine;

                case RegistryHive.PerformanceData:
                    return Registry.PerformanceData;

                case RegistryHive.Users:
                    return Registry.Users;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Get the sub key value of a registry key.
        /// </summary>
        /// <param name="registryHive">The registry hive</param>
        /// <param name="registryKeyPath">The registry key path</param>
        /// <param name="registryValueName">The registry value name</param>
        public static string GetRegistrySubKeyValue(RegistryHive registryHive,
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

        #endregion
    }
}