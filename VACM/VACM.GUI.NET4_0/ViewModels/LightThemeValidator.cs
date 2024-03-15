﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using VACM.GUI.NET4_0.Extensions;
using VACM.GUI.NET4_0.Extensions.PropertyValueChanged;

namespace VACM.GUI.NET4_0.ViewModels
{
    public class LightThemeValidator
    {
        #region Parameters

        private readonly string appsUseLightThemeRegistryValueName =
            "AppsUseLightTheme";

        private readonly string darkModeRegistryKeyPath =
            @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        private readonly string systemUsesLightThemeRegistryValueName =
            "SystemUsesLightTheme";

        private bool appsUseLightTheme
        {
            get
            {
                try
                {
                    var value = RegistryKeyPropertyGetter.GetRegistrySubKeyValue
                        (registryHive, darkModeRegistryKeyPath,
                        appsUseLightThemeRegistryValueName);

                    return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
                }
                catch (KeyNotFoundException keyNotFoundException)
                {
                    return true;
                }
            }
        }

        private bool isLightThemeEnabled;

        private bool systemUsesLightTheme
        {
            get
            {
                try
                {
                    var value = RegistryKeyPropertyGetter.GetRegistrySubKeyValue
                        (registryHive, darkModeRegistryKeyPath,
                        systemUsesLightThemeRegistryValueName);

                    return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
                }
                catch (KeyNotFoundException keyNotFoundException)
                {
                    return true;
                }
            }
        }

        private readonly RegistryHive registryHive = RegistryHive.CurrentUser;

        public bool IsLightThemeEnabled
        {
            get
            {
                return GraphicsWindow.IsLightThemeEnabled;
            }
            private set
            {
                GraphicsWindow.IsLightThemeEnabled = value;
                OnLightThemeIsEnabledValueChanged();
            }
        }

        public string WatchedPropertyIsLightThemeEnabledName
        {
            get
            {
                return nameof(IsLightThemeEnabled);
            }
        }

        public WMIRegistryEventListener WMIRegistryEventListener;
        public event PropertyValueChangedDelegate IsLightThemeEnabledValueChanged;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public LightThemeValidator()
        {
            if (GraphicsWindow.DoForceColorTheme)
            {
                return;
            }

            ConstructorHelperRunParallelTasks();
        }

        /// <summary>
        /// Constructor helper method to run tasks parallel.
        /// </summary>
        internal void ConstructorHelperRunParallelTasks()
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                SetIsLightThemeEnabledValueByRegistry();
            });

            Task task2 = Task.Factory.StartNew(() =>
            {
                InitializeWMIRegistryEventListenerAndEventArgs();
            });
        }

        /// <summary>
        /// Initialize WMIRegistryEventListener and event arguments.
        /// </summary>
        internal void InitializeWMIRegistryEventListenerAndEventArgs()
        {
            List<string> subKeyValueNameList = new List<string>()
            {
                appsUseLightThemeRegistryValueName,
                systemUsesLightThemeRegistryValueName,
            };

            WMIRegistryEventListener = new WMIRegistryEventListener
                (RegistryHive.CurrentUser, darkModeRegistryKeyPath, subKeyValueNameList);

            WMIRegistryEventListener.RegistrySubKeyChangedDelegate +=
                (sender, registrySubKeyChangedEventArgs) =>
                {
                    SetIsLightThemeEnabledValueByRegistry();
                };
        }

        /// <summary>
        /// Set is IsLightThemeEnabled value by registry.
        /// </summary>
        internal void SetIsLightThemeEnabledValueByRegistry()
        {
            //IsLightThemeEnabled = appsUseLightTheme || systemUsesLightTheme;          //NOTE: Is SystemUsesLightTheme even necessary?
            IsLightThemeEnabled = appsUseLightTheme;
        }

        /// <summary>
        /// Dispose the constructor object.
        /// </summary>
        public void Dispose()
        {
            WMIRegistryEventListener.Dispose();
        }

        /// <summary>
        /// Inform observers of LightThemeIsEnabled that its value has changed.
        /// </summary>
        internal void OnLightThemeIsEnabledValueChanged()
        {
            PropertyValueChangedEventArgs propertyValueChangedEventArgs =
                new PropertyValueChangedEventArgs(IsLightThemeEnabled);

            IsLightThemeEnabledValueChanged?.Invoke
                (this, propertyValueChangedEventArgs);
        }

        #endregion
    }
}