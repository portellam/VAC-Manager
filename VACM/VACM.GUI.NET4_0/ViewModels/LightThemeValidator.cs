using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using VACM.GUI.NET4_0.Extensions;
using VACM.GUI.NET4_0.Extensions.RegistrySubKeyChanged;
using VACM.GUI.NET4_0.Extensions.PropertyValueChanged;
using VACM.NET4.Extensions;

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
                    var value = registrySubKeyNameAndPropertyDictionary?
                    [appsUseLightThemeRegistryValueName];

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
                    var value = registrySubKeyNameAndPropertyDictionary?
                        [systemUsesLightThemeRegistryValueName];

                    return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
                }
                catch (KeyNotFoundException keyNotFoundException)
                {
                    return true;
                }
            }
        }

        private Dictionary<string, object> registrySubKeyNameAndPropertyDictionary;
        private readonly RegistryHive registryHive = RegistryHive.CurrentUser;

        public bool IsLightThemeEnabled
        {
            get
            {
                if (Program.DoesArgumentForceColorTheme)
                {
                    return Program.IsLightThemeEnabled;
                }

                return isLightThemeEnabled;
            }
            set
            {
                isLightThemeEnabled = value;
                OnLightThemeIsEnabledValueChanged();
            }
        }

        public bool IsLightThemeEnabledInRegistry
        {
            get
            {
                return appsUseLightTheme;

                //return AppsUseLightTheme || SystemUsesLightTheme;
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
        public event PropertyValueChanged IsLightThemeEnabledValueChanged;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public LightThemeValidator(bool doForceColorTheme, bool isLightThemeEnforced)
        {
            if (doForceColorTheme)
            {
                IsLightThemeEnabled = isLightThemeEnforced;
                return;
            }

            registrySubKeyNameAndPropertyDictionary =
                new Dictionary<string, object>();

            SetIsLightThemeEnabledValueByRegistry();
            InitializeWMIRegistryEventListenerAndEventArgs();
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
                    SetRegistrySubKeyValueNameProperty
                        (registrySubKeyChangedEventArgs);

                    SetIsLightThemeEnabledValueByRegistry();
                };
        }

        /// <summary>
        /// Set is IsLightThemeEnabled value by registry.
        /// </summary>
        internal void SetIsLightThemeEnabledValueByRegistry()
        {
            var subKeyValue = RegistryKeyPropertyGetter.GetRegistrySubKeyValue
                (registryHive, darkModeRegistryKeyPath,
            systemUsesLightThemeRegistryValueName);

            SetRegistrySubKeyValueNameAndPropertyDictionary
                (appsUseLightThemeRegistryValueName, subKeyValue);

            subKeyValue = RegistryKeyPropertyGetter.GetRegistrySubKeyValue
                (registryHive, darkModeRegistryKeyPath,
                systemUsesLightThemeRegistryValueName);

            SetRegistrySubKeyValueNameAndPropertyDictionary
                (systemUsesLightThemeRegistryValueName, subKeyValue);

            IsLightThemeEnabled = IsLightThemeEnabledInRegistry;
        }

        /// <summary>
        /// Set the registry sub key value name and property dictionary.
        /// </summary>
        /// <param name="registrySubKeyValueName">The registry sub key value name
        /// </param>
        /// <param name="propertyValue">The property value</param>
        internal void SetRegistrySubKeyValueNameAndPropertyDictionary
            (string registrySubKeyValueName, string propertyValue)
        {
            if (registrySubKeyNameAndPropertyDictionary is null)
            {
                registrySubKeyNameAndPropertyDictionary =
                    new Dictionary<string, object>();
            }

            if (registrySubKeyNameAndPropertyDictionary.Count == 0
                || string.IsNullOrEmpty(registrySubKeyValueName))
            {
                return;
            }

            if (!registrySubKeyNameAndPropertyDictionary.ContainsKey
                (registrySubKeyValueName))
            {
                registrySubKeyNameAndPropertyDictionary.Add
                    (registrySubKeyValueName, propertyValue);

                return;
            }

            registrySubKeyNameAndPropertyDictionary[registrySubKeyValueName] =
                propertyValue;
        }

        /// <summary>
        /// Set the registry sub key value name property.
        /// </summary>
        /// <param name="registrySubKeyChangedEventArgs">The registry sub key changed
        /// event args</param>
        internal void SetRegistrySubKeyValueNameProperty
            (RegistrySubKeyChangedEventArgs registrySubKeyChangedEventArgs)
        {
            string registryValueName = registrySubKeyChangedEventArgs.RegistryValueName;

            var subKeyValue = RegistryKeyPropertyGetter.GetRegistrySubKeyValue
                (registrySubKeyChangedEventArgs.RegistryHive,
                registrySubKeyChangedEventArgs.RegistryKeyPath, registryValueName);

            SetRegistrySubKeyValueNameAndPropertyDictionary
                (registryValueName, subKeyValue);
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
                new PropertyValueChangedEventArgs(nameof(IsLightThemeEnabled));

            IsLightThemeEnabledValueChanged?.Invoke
                (this, propertyValueChangedEventArgs);
        }

        #endregion
    }
}