using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using VACM.NET4.Extensions;

namespace VACM.GUI.NET4_0.ViewModels
{
    public class LightThemeValidator
    {
        //TODO: add event watcher
        //TODO: add on value change watcher here, which will watch for event watcher
        //  value change. Ditto in main form and about form.

        #region Parameters

        private readonly static string appsUseLightThemeRegistryValueName =
            "AppsUseLightTheme";

        private readonly static string darkModeRegistryKeyPath =
            @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        private readonly static string systemUsesLightThemeRegistryValueName =
            "SystemUsesLightTheme";

        private static bool AppsUseLightTheme
        {
            get
            {
                var result = Registry.CurrentUser?.OpenSubKey(darkModeRegistryKeyPath)
                    .GetValue(appsUseLightThemeRegistryValueName);

                return Convert.ToBoolean(result, CultureInfo.InvariantCulture);
            }
        }

        private static bool SystemUsesLightTheme
        {
            get
            {
                var result = Registry.CurrentUser?.OpenSubKey(darkModeRegistryKeyPath)
                    .GetValue(systemUsesLightThemeRegistryValueName);

                return Convert.ToBoolean(result, CultureInfo.InvariantCulture);
            }
        }

        private static bool isLightThemeEnabled = isLightThemeEnabledAtStart;

        private readonly static bool isLightThemeEnabledAtStart =
            IsLightThemeEnabledInRegistry;

        public static bool DoesLightThemeDifferFromRegistry
        {
            get
            {
                return IsLightThemeEnabled != IsLightThemeEnabledInRegistry;
            }
        }

        public static bool IsLightThemeEnabled
        {
            get
            {
                if (Program.DoesArgumentForceColorTheme)
                {
                    return Program.ForcedLightTheme;
                }

                return isLightThemeEnabled;
            }
            set
            {
                isLightThemeEnabled = value;
            }
        }

        public static bool IsLightThemeEnabledInRegistry
        {
            get
            {
                return AppsUseLightTheme
                    || SystemUsesLightTheme;
            }
        }

        public static WMIRegistryEventListener WMIRegistryEventListener;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public LightThemeValidator()
        {
            if (Program.DoesArgumentForceColorTheme)
            {
                return;
            }

            List<string> valueNameList = new List<string>()
            {
                appsUseLightThemeRegistryValueName,
                systemUsesLightThemeRegistryValueName,
            };

            WMIRegistryEventListener = new WMIRegistryEventListener
                (RegistryHive.Users, darkModeRegistryKeyPath, valueNameList);
        }

        /// <summary>
        /// Dispose the constructor object.
        /// </summary>
        public void Dispose()
        {
            WMIRegistryEventListener.Dispose();
        }

        #endregion
    }
}