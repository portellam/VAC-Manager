﻿using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VACM.NET4_0.Models;
using VACM.NET4_0.ViewModels;
using VACM.NET4_0.ViewModels.Accessors;
using VACM.NET4_0.ViewModels.ColorTable;
using VACM.NET4_0.Extensions;
using VACM.NET4_0.Extensions.PropertyValueChanged;
using PropertyValueChangedEventArgs =
    VACM.NET4_0.Extensions.PropertyValueChanged.PropertyValueChangedEventArgs;

namespace VACM.NET4_0.Views
{
    public partial class MainForm : Form
    {
        #region Parameters

        //TODO: have master dict to contain all drop down items in device add and remove.

        private AboutForm aboutForm;

        private string darkModeText
        {
            get
            {
                string text = "Dark Mode";

                if (!viewToggleDarkModeToolStripMenuItem.Checked)
                {
                    return $"Enable {text}";
                }

                return $"Disable {text}";
            }
        }

        private bool DoForceColorTheme
        {
            get
            {
                return GraphicsWindow.DoForceColorTheme;
            }
        }

        private bool IsLightThemeEnabled
        {
            get
            {
                return GraphicsWindow.IsLightThemeEnabled;
            }
            set
            {
                GraphicsWindow.IsLightThemeEnabled = value;
                OnLightThemeIsEnabledValueChanged();
            }
        }

        private bool isCheckedDeviceAddNameListFull
        {
            get
            {
                return deviceAddSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .All(toolStripMenuItem => toolStripMenuItem.Checked)
                    || deviceAddSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .All(toolStripMenuItem => toolStripMenuItem.Checked);
            }
        }

        private bool isCheckedDeviceAddNameListNotEmpty
        {
            get
            {
                return deviceAddSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Any(toolStripMenuItem => toolStripMenuItem.Checked)
                    || deviceAddSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Any(toolStripMenuItem => toolStripMenuItem.Checked);
            }
        }

        private bool isCheckedDeviceRemoveNameListFull
        {
            get
            {
                return deviceRemoveSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .All(toolStripMenuItem => toolStripMenuItem.Checked)
                    || deviceRemoveSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .All(toolStripMenuItem => toolStripMenuItem.Checked);
            }
        }

        private bool isCheckedDeviceRemoveNameListNotEmpty
        {
            get
            {
                return deviceRemoveSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Any(toolStripMenuItem => toolStripMenuItem.Checked)
                    || deviceRemoveSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Any(toolStripMenuItem => toolStripMenuItem.Checked);
            }
        }

        private bool isSelectedDeviceListNotEmpty
        {
            get
            {
                if (deviceListModel is null)
                {
                    return false;
                }

                return (deviceListModel.SelectedWaveInNameList != null
                        && deviceListModel.SelectedWaveInNameList.Count > 0)
                    || (deviceListModel.SelectedWaveOutNameList != null
                        && deviceListModel.SelectedWaveOutNameList.Count > 0);
            }
        }

        private bool isUnselectedDeviceListNotEmpty
        {
            get
            {
                if (deviceListModel is null)
                {
                    return false;
                }

                return (deviceListModel.UnselectedWaveInNameList != null
                        && deviceListModel.UnselectedWaveInNameList.Count > 0)
                    || (deviceListModel.UnselectedWaveOutNameList != null
                        && deviceListModel.UnselectedWaveOutNameList.Count > 0);
            }
        }

        private string fileName;
        private DeviceListModel deviceListModel;
        private DeviceControl inputDeviceControl { get; set; }
        private DeviceControl outputDeviceControl { get; set; }
        private RepeaterDataModel repeaterDataModel { get; set; }
        private List<Control> controlList = new List<Control>();

        private List<string> checkedDeviceAddWaveInNameList
        {
            get
            {
                return deviceAddSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Where(toolStripMenuItem => toolStripMenuItem.Checked)
                    .Select(toolStripMenuItem => toolStripMenuItem.ToolTipText)
                    .ToList();
            }
        }

        private List<string> checkedDeviceAddWaveOutNameList
        {
            get
            {
                return deviceAddSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Where(toolStripMenuItem => toolStripMenuItem.Checked)
                    .Select(toolStripMenuItem => toolStripMenuItem.ToolTipText)
                    .ToList();
            }
        }

        private List<string> checkedDeviceRemoveWaveInNameList
        {
            get
            {
                return deviceRemoveSelectWaveInToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Where(toolStripMenuItem => toolStripMenuItem.Checked)
                    .Select(toolStripMenuItem => toolStripMenuItem.ToolTipText)
                    .ToList();
            }
        }

        private List<string> checkedDeviceRemoveWaveOutNameList
        {
            get
            {
                return deviceRemoveSelectWaveOutToolStripMenuItem.DropDownItems
                    .Cast<ToolStripMenuItem>()
                    .Where(toolStripMenuItem => toolStripMenuItem.Checked)
                    .Select(toolStripMenuItem => toolStripMenuItem.ToolTipText)
                    .ToList();
            }
        }

        private List<ToolStripItem> toolStripItemList = new List<ToolStripItem>();

        private const string deviceText = "Device";

        public const string WaveInAsString = "Wave In";
        public const string WaveOutAsString = "Wave Out";

        public event PropertyValueChangedDelegate IsLightThemeEnabledValueChanged;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        [ExcludeFromCodeCoverage]
        public MainForm()
        {
            SetDeviceList();
            InitializeComponent();
            PostInitializeComponent();
        }

        /// <summary>
        /// Set the device list.
        /// </summary>
        internal void SetDeviceList()
        {
            deviceListModel = new DeviceListModel();
        }

        #endregion

        #region Intialization logic

        /// <summary>
        /// Add all controls to list.
        /// </summary>
        internal void InitializeControlsList()                                          //NOTE: Append new control objects here!
        {
            controlList.Clear();
            controlList.Add(tabControl1);
            controlList.Add(graphTab);
            controlList.Add(gridTab);
        }

        /// <summary>
        /// Add all tool strip items to list.
        /// </summary>
        internal void InitializeToolStripItemList()                                     //NOTE: Append new tool strip item objects here!
        {
            toolStripItemList.Clear();
            toolStripItemList.Add(deviceAddConfirmToolStripMenuItem);
            toolStripItemList.Add(deviceAddSelectAllToolStripMenuItem);
            toolStripItemList.Add(deviceAddSelectToolStripMenuItem);
            toolStripItemList.Add(deviceAddSelectWaveInToolStripMenuItem);
            toolStripItemList.Add(deviceAddSelectWaveOutToolStripMenuItem);
            toolStripItemList.Add(deviceAddToolStripMenuItem);
            toolStripItemList.Add(deviceReloadAllToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveConfirmToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveSelectAllLinkedToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveSelectAllToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveSelectAllUnlinkedToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveSelectWaveInToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveSelectWaveOutToolStripMenuItem);
            toolStripItemList.Add(deviceToolStripSeparator1);
            toolStripItemList.Add(deviceToolStripSeparator2);
            toolStripItemList.Add(deviceToolStripSeparator2);
            toolStripItemList.Add(fileCloseToolStripMenuItem);
            toolStripItemList.Add(fileExitToolStripMenuItem);
            toolStripItemList.Add(fileNewToolStripMenuItem);
            toolStripItemList.Add(fileOpenToolStripMenuItem);
            toolStripItemList.Add(fileSaveACopyAsToolStripMenuItem);
            toolStripItemList.Add(fileSaveAsToolStripMenuItem);
            toolStripItemList.Add(fileSaveToolStripMenuItem);
            toolStripItemList.Add(fileToolStripMenuItem);
            toolStripItemList.Add(fileToolStripSeparator1);
            toolStripItemList.Add(helpAboutToolStripMenuItem);
            toolStripItemList.Add(helpToolStripMenuItem);
            toolStripItemList.Add(linkAddToolStripMenuItem);
            toolStripItemList.Add(linkAddWaveInToolStripMenuItem);
            toolStripItemList.Add(linkAddWaveOutToolStripMenuItem);
            toolStripItemList.Add(linkDefaultBitRateToolStripMenuItem);
            toolStripItemList.Add(linkDefaultBufferToolStripMenuItem);
            toolStripItemList.Add(linkDefaultChannelsToolStripMenuItem);
            toolStripItemList.Add(linkDefaultPrefillToolStripMenuItem);
            toolStripItemList.Add(linkDefaultResyncAtToolStripMenuItem);
            toolStripItemList.Add(linkDefaultSamplingRateToolStripMenuItem);
            toolStripItemList.Add(linkRemoveAllToolStripMenuItem);
            toolStripItemList.Add(linkRemoveToolStripMenuItem);
            toolStripItemList.Add(linkRemoveWaveInToolStripMenuItem);
            toolStripItemList.Add(linkRemoveWaveOutToolStripMenuItem);
            toolStripItemList.Add(linkToolStripMenuItem);
            toolStripItemList.Add(linkToolStripSeparator1);
            toolStripItemList.Add(linkToolStripSeparator2);
            toolStripItemList.Add(repeaterRestartAllToolStripMenuItem);
            toolStripItemList.Add(repeaterRestartToolStripMenuItem);
            toolStripItemList.Add(repeaterStartAllToolStripMenuItem);
            toolStripItemList.Add(repeaterStartToolStripMenuItem);
            toolStripItemList.Add(repeaterStopAllToolStripMenuItem);
            toolStripItemList.Add(repeaterStopToolStripMenuItem);
            toolStripItemList.Add(repeaterToolStripMenuItem);
            toolStripItemList.Add(repeaterToolStripSeparator1);
            toolStripItemList.Add(repeaterToolStripSeparator2);
            toolStripItemList.Add(viewToggleDarkModeToolStripMenuItem);
            toolStripItemList.Add(viewToolStripMenuItem);
        }

        /// <summary>
        /// Initialize the device tool strip menu item.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="toolStripMenuItemList">The tool strip menu item list</param>
        internal void InitializeDeviceItem(EventHandler eventHandler,
            MMDevice mMDevice, List<ToolStripMenuItem> toolStripMenuItemList)
        {
            //if (mMDevice.State == DeviceState.NotPresent)
            //{
            //	return;
            //}

            if (mMDevice is null || toolStripMenuItemList is null)
            {
                return;
            }

            bool deviceIsEnabled = mMDevice.State != DeviceState.Disabled;
            string text = $"{mMDevice.FriendlyName} ";

            if (deviceIsEnabled)
            {
                text += "(Enabled)";
            }
            else
            {
                text += "(Disabled)";
            }

            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem()
            {
                CheckState = CheckState.Unchecked,
                CheckOnClick = true,
                Text = text,
                ToolTipText = mMDevice.FriendlyName,                                    //NOTE: The ToolTipText property must contain the MMDevice.FriendlyName, so that the MenuItem as a sender object will be properly validated in DeviceList logic.
            };

            if (eventHandler != null)
            {
                toolStripMenuItem.Click += new EventHandler(eventHandler);
            }

            toolStripMenuItem.CheckOnClick = true;

            if (toolStripMenuItemList.Contains(toolStripMenuItem))
            {
                return;
            }

            toolStripMenuItemList.Add(toolStripMenuItem);
        }

        /// <summary>
        /// Initialize a device tool strip menu item collection by parsing the related
        /// device list.
        /// </summary>
        /// <param name="eventHandler">The event handler</param>
        /// <param name="parentToolStripMenuItem">The parent device tool strip menu item
        /// </param>
        /// <param name="mMDeviceList">The device list</param>
        internal void InitializeDeviceItemCollection(EventHandler eventHandler,
            ToolStripMenuItem parentToolStripMenuItem, List<MMDevice> mMDeviceList)
        {
            if (mMDeviceList is null || mMDeviceList.Count == 0)
            {
                return;
            }

            DataFlow dataFlow = mMDeviceList.FirstOrDefault().DataFlow;
            parentToolStripMenuItem.DropDownItems.Clear();

            List<ToolStripMenuItem> toolStripMenuItemList =
                new List<ToolStripMenuItem>();

            mMDeviceList.ForEach(mMDevice =>
                {
                    InitializeDeviceItem(eventHandler, mMDevice, toolStripMenuItemList);
                });

            toolStripMenuItemList.ForEach(toolStripMenuItem =>
                {
                    InitializeDeviceItemText(dataFlow, toolStripMenuItem);
                });

            parentToolStripMenuItem.DropDownItems
                .AddRange(toolStripMenuItemList.ToArray());

            FormColorUpdater.SetColorsOfToolStripItem(parentToolStripMenuItem);
            SetMousePropertiesOfToolStripMenuItemDropDown(parentToolStripMenuItem);

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (parentToolStripMenuItem);
        }

        /// <summary>
        /// Initialize the text of the device tool strip menu item.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="toolStripMenuItem">The device tool strip menu item</param>
        internal void InitializeDeviceItemText(DataFlow dataFlow,
            ToolStripMenuItem toolStripMenuItem)
        {
            int index = deviceListModel.GetIndexOfMMDevice(dataFlow,
                toolStripMenuItem.ToolTipText);

            index++;
            string prefix = $"{index.ToString()}. ";

            toolStripMenuItem.Text = string.Format("{0,4} {1}", prefix,
                toolStripMenuItem.Text);
        }

        /// <summary>
        /// Initialize device drop down collections.
        /// </summary>
        internal void InitializeDeviceDropDownCollections()
        {
            deviceAddSelectWaveInToolStripMenuItem.DropDownItems.Clear();
            deviceAddSelectWaveOutToolStripMenuItem.DropDownItems.Clear();
            deviceRemoveSelectWaveInToolStripMenuItem.DropDownItems.Clear();
            deviceRemoveSelectWaveOutToolStripMenuItem.DropDownItems.Clear();
            linkAddWaveInToolStripMenuItem.DropDownItems.Clear();
            linkAddWaveOutToolStripMenuItem.DropDownItems.Clear();
            linkRemoveWaveInToolStripMenuItem.DropDownItems.Clear();
            linkRemoveWaveOutToolStripMenuItem.DropDownItems.Clear();
            string text = deviceToolStripMenuItem.Text;
            deviceToolStripMenuItem.Text = "Loading...";
            deviceToolStripMenuItem.Enabled = false;
            Refresh();

            InitializeDeviceItemCollection
                (deviceAddConfirmToolStripMenuItemEnabled_Toggle,
                deviceAddSelectWaveInToolStripMenuItem,
                deviceListModel.UnselectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (deviceAddConfirmToolStripMenuItemEnabled_Toggle,
                deviceAddSelectWaveOutToolStripMenuItem,
                deviceListModel.UnselectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (deviceRemoveConfirmToolStripMenuItem_Toggle,
                deviceRemoveSelectWaveInToolStripMenuItem,
                deviceListModel.SelectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (deviceRemoveConfirmToolStripMenuItem_Toggle,
                deviceRemoveSelectWaveOutToolStripMenuItem,
                deviceListModel.SelectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (linkAddWaveInToolStripMenuItem_Click,
                linkAddWaveInToolStripMenuItem,
                deviceListModel.SelectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (linkAddWaveOutToolStripMenuItem_Click,
                linkAddWaveOutToolStripMenuItem,
                deviceListModel.SelectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (linkRemoveWaveInToolStripMenuItem_Click,
                linkRemoveWaveInToolStripMenuItem,
                repeaterDataModel.LinkWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (linkRemoveWaveOutToolStripMenuItem_Click,
                linkRemoveWaveOutToolStripMenuItem,
                repeaterDataModel.LinkWaveOutMMDeviceList);

            deviceToolStripMenuItem.Text = text;
            deviceToolStripMenuItem.Enabled = true;
            Refresh();
        }

        /// <summary>
        /// Initialize all lists.
        /// </summary>
        internal void InitializeLists()
        {
            InitializeControlsList();
            InitializeToolStripItemList();
            GC.Collect();
        }

        /// <summary>
        /// Logic to execute before InitializeLists.
        /// </summary>
        internal void ModifyListItemsBeforeInitialization()
        {
            InitializeDeviceDropDownCollections();
        }

        /// <summary>
        /// Code to run after generated code.
        /// </summary>
        internal void PostInitializeComponent()
        {
            SetPropertiesOfDeviceToolStripMenuItem();

            deviceAddSelectWaveInToolStripMenuItem.Text = WaveInAsString;
            deviceAddSelectWaveOutToolStripMenuItem.Text = WaveOutAsString;
            deviceRemoveSelectWaveInToolStripMenuItem.Text = WaveInAsString;
            deviceRemoveSelectWaveOutToolStripMenuItem.Text = WaveOutAsString;

            helpAboutToolStripMenuItem.Text =
                $"About {Common.ApplicationNameAsAbbreviation}";

            linkAddWaveInToolStripMenuItem.Text = WaveInAsString;
            linkAddWaveOutToolStripMenuItem.Text = WaveOutAsString;
            linkRemoveWaveInToolStripMenuItem.Text = WaveInAsString;
            linkRemoveWaveOutToolStripMenuItem.Text = WaveOutAsString;
            viewToggleDarkModeToolStripMenuItem.Enabled = !DoForceColorTheme;

            SetIsLightThemeEnabledValueChangedEventArgs();                              //FIXME: See SetColorTheme.

            SetRepeaterDataModel();

            ModifyListItemsBeforeInitialization();
            InitializeLists();

            SetInitialChanges();
            SetColorTheme();

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Save renderer to new parameter before making changes.
        /// </summary>
        internal void SaveInitialRenderer()
        {
            initialMenuStrip1Renderer = menuStrip1.Renderer;
        }

        /// <summary>
        /// Set color theme given dark mode is enabled or not.
        /// </summary>
        internal void SetColorTheme()
        {
            ToggleDarkModeRenderer();
            SetViewToggleDarkModeToolStripMenuItemProperties();
            FormColorUpdater.SetColorsOfConstructor(this);
            FormColorUpdater.SetColorsOfControlCollection(Controls);
            FormColorUpdater.SetColorsOfControlList(controlList);
            FormColorUpdater.SetColorsOfToolStripItemList(toolStripItemList);

            if (aboutForm != null)
            {
                aboutForm.SetColorTheme();
            }

            Invalidate();
        }

        /// <summary>
        /// Set initial changes to form and its children.
        /// </summary>
        internal void SetInitialChanges()
        {
            Text = AssemblyInformationAccessor.AssemblyTitle;
        }

        /// <summary>
        /// Set IsLightThemEnabledValueChanged event arguments.
        /// </summary>
        internal void SetIsLightThemeEnabledValueChangedEventArgs()
        {
            //GraphicsWindow.LightThemeValidator.IsLightThemeEnabledValueChanged +=       //NOTE: this will execute some of the code inside (inside SetColorTheme), but not all.
            //    (sender, propertyValueChangedEventArgs) =>
            //    {
            //        SetColorTheme();
            //    };

            IsLightThemeEnabledValueChanged +=
                (sender, propertyValueChangedEventArgs) =>
                {
                    SetColorTheme();                                                    //NOTE: this appears to execute all the code inside SetColorTheme.
                };
        }

        /// <summary>
        /// Set mouse properties of drop down tool strip menu item.
        /// </summary>
        /// <param name="toolStripMenuItem">The drop down tool strip menu item</param>
        internal void SetMousePropertiesOfToolStripMenuItemDropDown
            (ToolStripMenuItem toolStripMenuItem)
        {
            if (toolStripMenuItem is null)
            {
                return;
            }

            toolStripMenuItem.DropDown.MouseEnter += new EventHandler
                (SetAutoClosePropertyOfToolStripDropDown_MouseEnter);

            toolStripMenuItem.DropDown.MouseLeave += new EventHandler
                (SetAutoClosePropertyOfToolStripDropDown_MouseLeave);
        }

        /// <summary>
        /// Set viewToggleDarkModeToolStripMenuItem properties.
        /// </summary>
        internal void SetViewToggleDarkModeToolStripMenuItemProperties()
        {
            viewToggleDarkModeToolStripMenuItem.Checked = !IsLightThemeEnabled;
            viewToggleDarkModeToolStripMenuItem.Text = darkModeText;
        }

        /// <summary>
        /// Toggle the type of renderer given dark mode is enabled or not.
        /// </summary>
        internal void ToggleDarkModeRenderer()
        {
            if (IsLightThemeEnabled)
            {
                menuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                menuStrip1.Renderer = initialMenuStrip1Renderer;
            }
            else
            {
                menuStrip1.RenderMode = ToolStripRenderMode.Professional;
                menuStrip1.Renderer = new ToolStripProfessionalRenderer
                    (new DarkColorTable());

                //menuStrip1.Renderer = new ToolStripDarkRenderer();                    //NOTE: breaks context menu colors.
            }
        }

        #endregion

        #region Event handling

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

        #region ToolStrip helper logic

        /// <summary>
        /// Verify the following object's parent has a parent. If true, the object's
        /// parent is the child of the first parent (menuStrip1). If false, the current
        /// object is the child of the first parent.
        /// </summary>
        /// <param name="accessibleObject">The accessible object</param>
        /// <returns>The first parent's child object</returns>
        internal AccessibleObject GetChildOfFirstParentAccessibleObject
            (AccessibleObject accessibleObject)
        {
            if (accessibleObject is null)
            {
                return null;
            }

            if (string.Equals(accessibleObject.Parent.Name, menuStrip1.Name))           //NOTE: if parent is menuStrip1, return the object.
            {
                return accessibleObject;
            }

            AccessibleObject result = GetChildOfFirstParentAccessibleObject
                (accessibleObject.Parent);

            if (result is null)                                                         //NOTE: if parent and/or grandparent doesn't exist, return the object.
            {
                return accessibleObject;
            }

            return result;
        }

        /// <summary>
        /// Get the name of the tool strip menu item which is the child of the first
        /// parent object (menuStrip1).
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        /// <returns></returns>
        internal string GetNameOfChildToFirstParentAccessibleObject
            (ToolStripMenuItem toolStripMenuItem)
        {
            if (toolStripMenuItem is null)
            {
                return null;
            }

            return GetChildOfFirstParentAccessibleObject
                (toolStripMenuItem.AccessibilityObject).Name;
        }

        /// <summary>
        /// Move all checked tool strip menu items to new tool strip item collection.
        /// </summary>
        /// <param name="firstToolStripMenuItem">The first tool strip menu item</param>
        /// <param name="secondToolStripMenuItem">The second tool strip menu item
        /// </param>
        internal void MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
            (ToolStripMenuItem firstToolStripMenuItem,
            ToolStripMenuItem secondToolStripMenuItem)
        {
            if (firstToolStripMenuItem is null
                || firstToolStripMenuItem.DropDownItems.Count == 0
                || secondToolStripMenuItem is null)
            {
                return;
            }

            List<ToolStripMenuItem> toolStripMenuItemList = firstToolStripMenuItem
                .DropDownItems.Cast<ToolStripMenuItem>()
                .Where(toolStripMenuItem => toolStripMenuItem.Checked).ToList();

            toolStripMenuItemList.ForEach(toolStripMenuItem =>
                {
                    toolStripMenuItem.Checked = false;
                    firstToolStripMenuItem.DropDownItems.Remove(toolStripMenuItem);

                    if (!secondToolStripMenuItem.DropDownItems
                        .Contains(toolStripMenuItem))
                    {
                        secondToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                    }
                });

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (firstToolStripMenuItem);

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (secondToolStripMenuItem);

            //GC.Collect();
            SortToolStripMenuItemCollectionByName(secondToolStripMenuItem);
            //GC.Collect();                                                             //TODO: evaluate if GC Collect is necessary here.
        }

        internal void SortToolStripMenuItemCollectionByName
            (ToolStripMenuItem toolStripMenuItem)
        {
            if (toolStripMenuItem is null || toolStripMenuItem.DropDownItems.Count == 0)
            {
                return;
            }

            ToolStripMenuItem[] toolStripMenuItemArray = toolStripMenuItem
                .DropDownItems.Cast<ToolStripMenuItem>().OrderBy(x => x.Name)
                .ToArray();

            toolStripMenuItem.DropDownItems.Clear();
            toolStripMenuItem.DropDownItems.AddRange(toolStripMenuItemArray);
            //GC.Collect();
        }

        /// <summary>
        /// Recursively ShowDropDown for every parent of the current tool strip item.
        /// </summary>
        /// <param name="toolStripItem">The tool strip item</param>
        internal void RecursivelyShowDropDownForEveryParentToolStripItem
            (ToolStripItem toolStripItem)
        {
            if (toolStripItem is null)
            {
                return;
            }

            if (toolStripItem.OwnerItem != null)
            {
                RecursivelyShowDropDownForEveryParentToolStripItem
                    (toolStripItem.OwnerItem);
            }

            if (!(toolStripItem is ToolStripMenuItem))
            {
                return;
            }

            (toolStripItem as ToolStripMenuItem).ShowDropDown();
        }

        /// <summary>
        /// Recursively ShowDropDown for every parent of the current tool strip menu
        /// item.
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        internal void RecursivelyShowDropDownForEveryParentToolStripItem
            (ToolStripMenuItem toolStripMenuItem)
        {
            if (toolStripMenuItem is null)
            {
                return;
            }

            if (toolStripMenuItem.OwnerItem != null)
            {
                RecursivelyShowDropDownForEveryParentToolStripItem
                    (toolStripMenuItem.OwnerItem);
            }

            toolStripMenuItem.ShowDropDown();
        }

        /// <summary>
        /// Resets properties for selected nested tool strip item in tool strip menu
        /// item.
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="parentToolStripMenuItem">The referenced parent tool strip menu
        /// item</param>
        internal void ResetPropertiesForEachSelectedToolStripMenuItem(MMDevice mMDevice,
            ToolStripMenuItem parentToolStripMenuItem)
        {
            string isSelectedSuffix = " (Selected)";

            parentToolStripMenuItem.DropDownItems.Cast<ToolStripItem>().Where
                (toolStripItem => toolStripItem.ToolTipText != mMDevice.FriendlyName)
                .ToList().ForEach(toolStripItem =>
                    {
                        toolStripItem.Text = Regex.Replace(toolStripItem.Text,
                            isSelectedSuffix, string.Empty);
                    });
        }

        /// <summary>
        /// Set auto close property of tool strip drop down on mouse enter.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void SetAutoClosePropertyOfToolStripDropDown_MouseEnter(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripDropDown))
            {
                return;
            }

            (sender as ToolStripDropDown).AutoClose = false;
        }

        /// <summary>
        /// Set auto close property of tool strip drop down on mouse leave.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void SetAutoClosePropertyOfToolStripDropDown_MouseLeave(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripDropDown))
            {
                return;
            }

            (sender as ToolStripDropDown).AutoClose = true;
        }

        /// <summary>
        /// Set checked property of tool strip menu item.
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        /// <param name="isChecked">Is checked</param>
        internal void SetCheckedPropertyForEachToolStripMenuItem
            (ToolStripMenuItem toolStripMenuItem, bool isChecked)
        {
            if (toolStripMenuItem is null || toolStripMenuItem.DropDownItems.Count == 0)
            {
                return;
            }

            toolStripMenuItem.DropDownItems.Cast<ToolStripMenuItem>().ToList()
                .ForEach(thisToolStripMenuItem =>
                    {
                        thisToolStripMenuItem.Checked = isChecked;
                    });
        }

        internal void SortToolStripMenuItemDropDownCollection                           //TODO: remove refs?
            (ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.DropDownItems.Cast<ToolStripMenuItem>().ToList().Sort();
        }

        /// <summary>
        /// Set properties of tool strip menu item given tool strip item collection is
        /// empty or not.
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        internal void SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
            (ToolStripMenuItem toolStripMenuItem)
        {
            bool isNotEmpty = toolStripMenuItem.DropDownItems.Count > 0;
            toolStripMenuItem.Enabled = isNotEmpty;

            if (isNotEmpty)
            {
                toolStripMenuItem.ToolTipText = string.Empty;
                return;
            }

            string name = GetNameOfChildToFirstParentAccessibleObject
                (toolStripMenuItem);

            string items = "item(s)";

            if (!string.IsNullOrWhiteSpace(name))
            {
                items = $"{name.ToLower()}(s)";
            }

            toolStripMenuItem.ToolTipText = $"No {items} found.";
        }

        /// <summary>
        /// Set properties of every nested tool strip item. If the item matches the
        /// child tool strip menu item, append a substring and disable the item.
        /// If not, reverse the changes.
        /// </summary>
        /// <param name="parentToolStripMenuItem">The parent tool strip menu
        /// item</param>
        /// <param name="childToolStripMenuItem">The child tool strip menu item</param>
        internal void SetPropertiesOfSelectedToolStripMenuItem
            (ToolStripMenuItem parentToolStripMenuItem,
            ToolStripMenuItem childToolStripMenuItem)
        {
            if (!parentToolStripMenuItem.DropDownItems.Contains(childToolStripMenuItem))
            {
                return;
            }

            string isSelectedSuffix = " (Selected)";

            parentToolStripMenuItem.DropDownItems.Cast<ToolStripItem>().ToList()
                .ForEach(toolStripItem =>
                    {
                        if (toolStripItem != childToolStripMenuItem)
                        {
                            toolStripItem.Text = Regex.Replace(toolStripItem.Text,
                                isSelectedSuffix, string.Empty);
                        }
                        else
                        {
                            toolStripItem.Text += isSelectedSuffix;
                        }
                    });
        }

        #endregion

        #region 1. File menu logic

        /// <summary>
        /// Click event logic for fileOpenToolStripMenuItem.
        /// Get filename if dialog result is OK.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void fileOpenToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.CommonAppDataPath,
                Filter = $"{Common.ApplicationNameAsAbbreviation} files| " +
                    $"*{Common.FileExtension}*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            fileName = openFileDialog.FileName;
        }

        /// <summary>
        /// Click event logic for fileExitToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void fileExitToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            /*
             * TODO:
             *  -add logic to...
             *      -check if runtime data is saved to file.
             *      -warn user to save changes.
             *      -warn user that audio repeaters may exit at app shutdown.
             */

            Dispose();
            //Application.Exit();
        }

        /// <summary>
        /// Create new repeater data model. Called whenever a file is opened or closed.
        /// </summary>
        internal void SetRepeaterDataModel()
        {
            repeaterDataModel = new RepeaterDataModel();
        }

        #endregion

        #region 2. Device menu logic

        /// <summary>
        /// Click event logic for deviceAddConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddConfirmToolStripMenuItem_Click(object sender,            //TODO: make called methods async?
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            string text = deviceToolStripMenuItem.Text;
            deviceToolStripMenuItem.Enabled = false;
            deviceToolStripMenuItem.Text = "Loading...";
            Invalidate();

            deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Capture,        //NOTE: we can async the WaveIn and WaveOut list-parsing.
                checkedDeviceAddWaveInNameList);

            deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Render,
                checkedDeviceAddWaveOutNameList);

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection                //NOTE: is it possible to make both the model and UI logic async?
                (deviceAddSelectWaveInToolStripMenuItem,
                deviceRemoveSelectWaveInToolStripMenuItem);

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                (deviceAddSelectWaveOutToolStripMenuItem,
                 deviceRemoveSelectWaveOutToolStripMenuItem);

            deviceToolStripMenuItem.Enabled = true;
            deviceToolStripMenuItem.Text = text;
            Invalidate();

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Toggle enabled property event for deviceAddConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddConfirmToolStripMenuItemEnabled_Toggle(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Click event logic for deviceAddSelectAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddSelectAllToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            SetCheckedPropertyForEachToolStripMenuItem
                (deviceAddSelectWaveInToolStripMenuItem,
                deviceAddSelectAllToolStripMenuItem.Checked);

            SetCheckedPropertyForEachToolStripMenuItem
                (deviceAddSelectWaveOutToolStripMenuItem,
                deviceAddSelectAllToolStripMenuItem.Checked);

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();

            RecursivelyShowDropDownForEveryParentToolStripItem
                (deviceAddSelectAllToolStripMenuItem);
        }

        /// <summary>
        /// Click event logic for deviceReloadAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceReloadAllToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            SetDeviceList();
            InitializeLists();
            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Click event logic for deviceRemoveConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveConfirmToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                (deviceRemoveSelectWaveInToolStripMenuItem,
                deviceAddSelectWaveInToolStripMenuItem);

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                (deviceRemoveSelectWaveOutToolStripMenuItem,
                deviceAddSelectWaveOutToolStripMenuItem);

            deviceListModel.MoveMMDeviceNameListFromSelectedList(DataFlow.Capture,
                checkedDeviceRemoveWaveInNameList);

            deviceListModel.MoveMMDeviceNameListFromSelectedList(DataFlow.Render,
                checkedDeviceRemoveWaveOutNameList);

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Toggle enabled property event for deviceRemoveConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveConfirmToolStripMenuItem_Toggle(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
        }

        /// <summary>
        /// Click event logic for deviceRemoveSelectAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveSelectAllToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            //SetDeviceList();
            //InitializeLists();

            SetCheckedPropertyForEachToolStripMenuItem
                (deviceRemoveSelectWaveInToolStripMenuItem,
                deviceRemoveSelectAllToolStripMenuItem.Checked);

            SetCheckedPropertyForEachToolStripMenuItem
                (deviceRemoveSelectWaveOutToolStripMenuItem,
                deviceRemoveSelectAllToolStripMenuItem.Checked);

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();

            RecursivelyShowDropDownForEveryParentToolStripItem
                (deviceRemoveSelectAllToolStripMenuItem);
        }

        /// <summary>
        /// Set properties of deviceAddToolStripMenuItem drop downs.
        /// </summary>
        internal void SetPropertiesOfDeviceAddToolStripMenuItemDropDowns()
        {
            deviceAddConfirmToolStripMenuItem.Enabled =
                isCheckedDeviceAddNameListNotEmpty;

            deviceAddSelectAllToolStripMenuItem.Enabled =
                isUnselectedDeviceListNotEmpty;

            deviceAddSelectToolStripMenuItem.Enabled = isUnselectedDeviceListNotEmpty;
            deviceAddToolStripMenuItem.Enabled = isUnselectedDeviceListNotEmpty;

            deviceAddSelectAllToolStripMenuItem.Checked =
                isCheckedDeviceAddNameListFull && isUnselectedDeviceListNotEmpty;
        }

        /// <summary>
        /// Set properties of deviceRemoveToolStripMenuItem drop downs.
        /// </summary>
        internal void SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns()
        {
            deviceRemoveConfirmToolStripMenuItem.Enabled =
                isCheckedDeviceRemoveNameListNotEmpty;

            deviceRemoveSelectAllToolStripMenuItem.Enabled =
                isSelectedDeviceListNotEmpty;

            deviceRemoveSelectToolStripMenuItem.Enabled = isSelectedDeviceListNotEmpty;

            deviceRemoveToolStripMenuItem.Enabled = isSelectedDeviceListNotEmpty
                || deviceRemoveSelectAllLinkedToolStripMenuItem.Enabled
                || deviceRemoveSelectAllUnlinkedToolStripMenuItem.Enabled;

            deviceRemoveSelectAllToolStripMenuItem.Checked =
                isCheckedDeviceRemoveNameListFull && isSelectedDeviceListNotEmpty;

            //TODO: parse removeSelectAllLinked and Unlinked here.
        }

        #endregion

        #region 3. Link menu logic

        /// <summary>
        /// Add input and output device controls to repeater model.
        /// </summary>
        internal void AddToRepeaterModel()
        {
            if (inputDeviceControl is null || inputDeviceControl.MMDevice is null
                || outputDeviceControl is null || outputDeviceControl.MMDevice is null)
            {
                return;
            }

            repeaterDataModel.AddDictionary(inputDeviceControl, outputDeviceControl);
            inputDeviceControl = null;
            outputDeviceControl = null;
            InitializeLists();
        }

        /// <summary>
        /// Click event logic for linkAddWaveInToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkAddWaveInToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;

            MMDevice mMDevice = deviceListModel.GetMMDevice(DataFlow.Capture,
                toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            inputDeviceControl = new DeviceControl(mMDevice);

            SetPropertiesOfSelectedToolStripMenuItem(linkAddWaveInToolStripMenuItem,
                toolStripMenuItem);

            AddToRepeaterModel();
        }

        /// <summary>
        /// Click event logic for linkAddWaveOutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkAddWaveOutToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;

            MMDevice mMDevice = deviceListModel.GetMMDevice(DataFlow.Render,
                toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            outputDeviceControl = new DeviceControl(mMDevice);

            SetPropertiesOfSelectedToolStripMenuItem(linkAddWaveOutToolStripMenuItem,
                toolStripMenuItem);

            AddToRepeaterModel();
        }

        /// <summary>
        /// Remove input and output device controls to repeater model.
        /// </summary>
        internal void RemoveFromRepeaterModel()
        {
            if (inputDeviceControl is null || outputDeviceControl is null)
            {
                return;
            }

            repeaterDataModel.RemoveDictionary(inputDeviceControl, outputDeviceControl);
            ResetPropertiesForSelectedLinkAddToolStripMenuItem(inputDeviceControl);
            ResetPropertiesForSelectedLinkAddToolStripMenuItem(outputDeviceControl);
            inputDeviceControl = null;
            outputDeviceControl = null;
            InitializeLists();
        }

        /// <summary>
        /// Resets properties for selected linkAddWaveIn or linkAddWaveOut.
        /// </summary>
        /// <param name="deviceControl">The device control</param>
        internal void ResetPropertiesForSelectedLinkAddToolStripMenuItem
            (DeviceControl deviceControl)
        {
            if (deviceControl is null || deviceControl.MMDevice is null)
            {
                return;
            }

            if (deviceControl.MMDevice.DataFlow == DataFlow.Capture)
            {
                ResetPropertiesForEachSelectedToolStripMenuItem(deviceControl.MMDevice,
                    linkAddWaveInToolStripMenuItem);
            }
            else
            {
                ResetPropertiesForEachSelectedToolStripMenuItem(deviceControl.MMDevice,
                    linkAddWaveOutToolStripMenuItem);
            }
        }

        /// <summary>
        /// Click event logic for linkRemoveWaveInToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkRemoveWaveInToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;

            MMDevice mMDevice = deviceListModel.GetMMDevice(DataFlow.Capture,
                toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            inputDeviceControl = new DeviceControl(mMDevice);

            SetPropertiesOfSelectedToolStripMenuItem(linkRemoveWaveInToolStripMenuItem,
                toolStripMenuItem);

            RemoveFromRepeaterModel();
        }

        /// <summary>
        /// Click event logic for linkRemoveWaveOutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkRemoveWaveOutToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;

            MMDevice mMDevice = deviceListModel.GetMMDevice(DataFlow.Render,
                toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            outputDeviceControl = new DeviceControl(mMDevice);

            SetPropertiesOfSelectedToolStripMenuItem(linkRemoveWaveOutToolStripMenuItem,
                toolStripMenuItem);

            RemoveFromRepeaterModel();
        }

        #endregion

        #region 4. Repeater menu logic

        #endregion

        #region 5. View menu logic

        /// <summary>
        /// Click event logic for viewToggleDarkModeToolStripMenuItem.
        /// Set the ToggleDarkModeText.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void viewToggleDarkModeToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            IsLightThemeEnabled = !viewToggleDarkModeToolStripMenuItem.Checked;
        }

        #endregion

        #region 6. Help menu logic

        /// <summary>
        /// Click event logic for helpAboutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void helpAboutToolStripMenuItem_Click(object sender,
            EventArgs eventArgs)
        {
            if (Application.OpenForms.OfType<AboutForm>().Count() > 0)
            {
                Application.OpenForms.OfType<AboutForm>().ToList()
                    .ForEach(aboutForm => aboutForm.Close());
            }

            aboutForm = new AboutForm();
            aboutForm.Show();
        }

        #endregion

        #region 2. Device background logic

        /// <summary>
        /// Action logic for deviceAddConfirm background worker. If moving items in
        /// device list model raise exception, cancel and return 1. If moving checked
        /// items in item collection raise exception, cancel and return 2.
        /// Else, return 0.
        /// </summary>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        /// <returns>The return value</returns>
        internal int deviceAddConfirmBackgroundWorker_Action
            (DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Capture,
                    checkedDeviceAddWaveInNameList);

                deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Render,
                    checkedDeviceAddWaveOutNameList);
            }
            catch
            {
                doWorkEventArgs.Cancel = true;
                return 1;
            }

            try
            {
                MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                    (deviceAddSelectWaveInToolStripMenuItem,
                    deviceRemoveSelectWaveInToolStripMenuItem);

                MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                    (deviceAddSelectWaveOutToolStripMenuItem,
                     deviceRemoveSelectWaveOutToolStripMenuItem);
            }
            catch
            {
                doWorkEventArgs.Cancel = true;
                return 2;
            }

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
            return 0;
        }

        /// <summary>
        /// Work logic for deviceAddConfirm background worker.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        internal void deviceAddConfirmBackgroundWorker_DoWork(object sender,
            DoWorkEventArgs doWorkEventArgs)
        {
            if (sender is null || !(sender is BackgroundWorker))
            {
                return;
            }

            UnsetPropertiesOfDeviceToolStripMenuItem();

            doWorkEventArgs.Result = deviceAddConfirmBackgroundWorker_Action
                (doWorkEventArgs);
        }

        /// <summary>
        /// Action logic for deviceRemoveConfirm background worker. If moving items in
        /// device list model raise exception, cancel and return 1. If moving checked
        /// items in item collection raise exception, cancel and return 2.
        /// Else, return 0.
        /// </summary>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        /// <returns>The return value</returns>
        internal int deviceRemoveConfirmBackgroundWorker_Action
            (DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Capture,
                    checkedDeviceRemoveWaveInNameList);

                deviceListModel.MoveMMDeviceNameListToSelectedList(DataFlow.Render,
                    checkedDeviceRemoveWaveOutNameList);
            }
            catch
            {
                doWorkEventArgs.Cancel = true;
                return 1;
            }

            try
            {
                MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                    (deviceRemoveSelectWaveInToolStripMenuItem,
                    deviceAddSelectWaveInToolStripMenuItem);

                MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                    (deviceRemoveSelectWaveOutToolStripMenuItem,
                     deviceAddSelectWaveOutToolStripMenuItem);
            }
            catch
            {
                doWorkEventArgs.Cancel = true;
                return 2;
            }

            SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
            SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
            return 0;
        }

        /// <summary>
        /// Work logic for deviceRemoveConfirm background worker.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        internal void deviceRemoveConfirmBackgroundWorker_DoWork(object sender,
            DoWorkEventArgs doWorkEventArgs)
        {
            if (sender is null || !(sender is BackgroundWorker))
            {
                return;
            }

            UnsetPropertiesOfDeviceToolStripMenuItem();

            doWorkEventArgs.Result = deviceRemoveConfirmBackgroundWorker_Action
                (doWorkEventArgs);
        }

        /// <summary>
        /// Action logic for deviceReloadAllConfirm background worker. If moving items in
        /// device list model raise exception, cancel and return 1. If moving checked
        /// items in item collection raise exception, cancel and return 2.
        /// Else, return 0.
        /// </summary>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        /// <returns>The return value</returns>
        internal int deviceReloadAllBackgroundWorker_Action
            (DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                SetDeviceList();
                InitializeLists();
                SetPropertiesOfDeviceAddToolStripMenuItemDropDowns();
                SetPropertiesOfDeviceRemoveToolStripMenuItemDropDowns();
            }
            catch
            {
                doWorkEventArgs.Cancel = true;
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Work logic for deviceReloadAll background worker.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="doWorkEventArgs">The do work event arguments</param>
        internal void deviceReloadAllBackgroundWorker_DoWork(object sender,
            DoWorkEventArgs doWorkEventArgs)
        {
            if (sender is null || !(sender is BackgroundWorker))
            {
                return;
            }

            UnsetPropertiesOfDeviceToolStripMenuItem();

            doWorkEventArgs.Result = deviceReloadAllBackgroundWorker_Action
                (doWorkEventArgs);
        }

        /// <summary>
        /// On complete logic for device background worker(s).
        /// worker.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="runWorkerCompletedEventArgs">The run worker completed event
        /// arguments</param>
        internal void deviceBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (runWorkerCompletedEventArgs.Error != null)
            {
                MessageBoxWrapper.ShowError(runWorkerCompletedEventArgs.Error.Message);
                //NOTE: undo all changes here from previous callstack operation?
            }

            SetPropertiesOfDeviceToolStripMenuItem();
        }

        internal void SetPropertiesOfDeviceToolStripMenuItem()
        {
            deviceToolStripMenuItem.Enabled = true;
            deviceToolStripMenuItem.Text = deviceText;
        }

        internal void UnsetPropertiesOfDeviceToolStripMenuItem()
        {
            deviceToolStripMenuItem.Enabled = false;
            deviceToolStripMenuItem.Text = "Loading...";
        }

        #endregion
    }

    /*
    * TODO:
    * -import/export system MMEnumeration to file.
    * -repeaters > disable item of and start repeaters whose device(s) are disabled or not present.
    * -check for existing running repeaters (should this app exit).
    * -run task of starting repeaters in another thread.
    * -check for glitches in repeaters.
    * -make suggestions if audio glitches occur.
    * -allow for enabling/disabling devices.
    * -click event to open active audio repeater.
    */
}