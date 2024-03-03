using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VACM.NET4_0.Models;
using VACM.NET4_0.ViewModels;
using VACM.NET4.Models;
using VACM.NET4_0.ViewModels.Accessors;
using VACM.NET4_0.ViewModels.ColorTable;

namespace VACM.NET4_0.Views
{
    public partial class MainForm : Form
    {
        #region Parameters

        private AboutForm aboutForm;

        private bool doAddSelectedWaveInOrWaveOutContainCheckedMenuItem
        {
            get
            {
                return DoesToolStripItemCollectionContainCheckedMenuItem
                    (deviceAddSelectWaveInToolStripMenuItem.DropDownItems)
                    || DoesToolStripItemCollectionContainCheckedMenuItem
                    (deviceAddSelectWaveOutToolStripMenuItem.DropDownItems);
            }
        }

        private bool DoForceColorTheme
        {
            get
            {
                return GraphicsWindow.DoForceColorTheme;
            }
        }

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

        private bool IsLightThemeEnabled
        {
            get
            {
                return GraphicsWindow.IsLightThemeEnabled;
            }
            set
            {
                GraphicsWindow.IsLightThemeEnabled = value;
            }
        }

        private bool toggleDeviceAddSelectAllToolStripMenuItem;
        private string fileName;
        private DeviceListModel deviceListModel;
        private DeviceControl inputDeviceControl { get; set; }
        private DeviceControl outputDeviceControl { get; set; }
        private RepeaterDataModel repeaterDataModel { get; set; }
        private List<Control> controlList = new List<Control>();
        private List<ToolStripItem> toolStripItemList = new List<ToolStripItem>();

        public const string WaveInAsString = "Wave In";
        public const string WaveOutAsString = "Wave Out";

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        [ExcludeFromCodeCoverage]
        public MainForm()
        {
            toggleDeviceAddSelectAllToolStripMenuItem = false;
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

        #region Windows Form Designer custom code

        /// <summary>
        /// Set the ability of the DeviceAdd and DeviceAddAll menu items.
        /// </summary>
        internal void DeviceAddMenuItemAbility()
        {
            bool isEnabled = deviceAddSelectWaveInToolStripMenuItem.Enabled
                || deviceAddSelectWaveOutToolStripMenuItem.Enabled;
            deviceAddSelectToolStripMenuItem.Enabled = isEnabled;
            deviceAddSelectAllToolStripMenuItem.Enabled = isEnabled;
        }

        /// <summary>
        /// Set the ability of the DeviceRemove and DeviceRemoveAll menu items.
        /// </summary>
        internal void DeviceRemoveMenuItemAbility()
        {
            bool isEnabled = deviceRemoveWaveInToolStripMenuItem.Enabled
                || deviceRemoveWaveOutToolStripMenuItem.Enabled;
            deviceRemoveToolStripMenuItem.Enabled = isEnabled;
            deviceRemoveAllToolStripMenuItem.Enabled = isEnabled;
        }

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
            toolStripItemList.Add(deviceRemoveAllLinkedToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveAllToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveAllUnlinkedToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveWaveInToolStripMenuItem);
            toolStripItemList.Add(deviceRemoveWaveOutToolStripMenuItem);
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
            MMDevice mMDevice, ref List<ToolStripMenuItem> toolStripMenuItemList)
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
                ToolTipText = mMDevice.FriendlyName,                                //NOTE: The ToolTipText property must contain the MMDevice.FriendlyName, so that the MenuItem as a sender object will be properly validated in DeviceList logic.
            };

            if (eventHandler != null)
            {
                toolStripMenuItem.Click += new System.EventHandler(eventHandler);
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
            ref ToolStripMenuItem parentToolStripMenuItem, List<MMDevice> mMDeviceList)
        {
            if (mMDeviceList is null || mMDeviceList.Count == 0)
            {
                return;
            }

            DataFlow dataFlow = mMDeviceList.FirstOrDefault().DataFlow;
            parentToolStripMenuItem.DropDownItems.Clear();

            List<ToolStripMenuItem> toolStripMenuItemList =
                new List<ToolStripMenuItem>();

            foreach (MMDevice mMDevice in mMDeviceList.ToList())
            {
                InitializeDeviceItem(eventHandler, mMDevice, ref toolStripMenuItemList);
            }

            toolStripMenuItemList.ForEach(toolStripMenuItem =>
            {
                InitializeDeviceItemText(dataFlow, ref toolStripMenuItem);
            });

            parentToolStripMenuItem.DropDownItems.AddRange
                (toolStripMenuItemList.ToArray());

            FormColorUpdater.SetColorsOfToolStripItem(parentToolStripMenuItem);

            SetMousePropertiesOfToolStripMenuItemDropDown
                (ref parentToolStripMenuItem);

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (ref parentToolStripMenuItem);
        }

        /// <summary>
        /// Initialize the text of the device tool strip menu item.
        /// </summary>
        /// <param name="dataFlow">The data flow</param>
        /// <param name="toolStripMenuItem">The device tool strip menu item</param>
        internal void InitializeDeviceItemText
            (DataFlow dataFlow, ref ToolStripMenuItem toolStripMenuItem)
        {
            int index = deviceListModel.GetIndexOfMMDevice
                (dataFlow, toolStripMenuItem.ToolTipText);

            index++;
            string prefix = $"{index.ToString()}. ";

            toolStripMenuItem.Text = string.Format
                ("{0,4} {1}", prefix, toolStripMenuItem.Text);
        }

        /// <summary>
        /// Initialize device drop down collections.
        /// </summary>
        internal void InitializeDeviceDropDownCollections()
        {
            deviceAddSelectWaveInToolStripMenuItem.DropDownItems.Clear();
            deviceAddSelectWaveOutToolStripMenuItem.DropDownItems.Clear();
            deviceRemoveWaveInToolStripMenuItem.DropDownItems.Clear();
            deviceRemoveWaveOutToolStripMenuItem.DropDownItems.Clear();
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
                ref deviceAddSelectWaveInToolStripMenuItem,
                deviceListModel.UnselectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (deviceAddConfirmToolStripMenuItemEnabled_Toggle,
                ref deviceAddSelectWaveOutToolStripMenuItem,
                deviceListModel.UnselectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (deviceRemoveWaveInToolStripMenuItemDropDown_Click,
                ref deviceRemoveWaveInToolStripMenuItem,
                deviceListModel.SelectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (deviceRemoveWaveOutToolStripMenuItemDropDown_Click,
                ref deviceRemoveWaveOutToolStripMenuItem,
                deviceListModel.SelectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (linkAddWaveInToolStripMenuItem_Click,
                ref linkAddWaveInToolStripMenuItem,
                deviceListModel.SelectedWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (linkAddWaveOutToolStripMenuItem_Click,
                ref linkAddWaveOutToolStripMenuItem,
                deviceListModel.SelectedWaveOutMMDeviceList);

            InitializeDeviceItemCollection
                (linkRemoveWaveInToolStripMenuItem_Click,
                ref linkRemoveWaveInToolStripMenuItem,
                repeaterDataModel.LinkWaveInMMDeviceList);

            InitializeDeviceItemCollection
                (linkRemoveWaveOutToolStripMenuItem_Click,
                ref linkRemoveWaveOutToolStripMenuItem,
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
            DeviceAddMenuItemAbility();
            DeviceRemoveMenuItemAbility();
        }

        /// <summary>
        /// Code to run after generated code.
        /// </summary>
        internal void PostInitializeComponent()
        {
            deviceAddConfirmToolStripMenuItem.Enabled =
                doAddSelectedWaveInOrWaveOutContainCheckedMenuItem;

            deviceAddSelectWaveInToolStripMenuItem.Text = WaveInAsString;
            deviceAddSelectWaveOutToolStripMenuItem.Text = WaveOutAsString;
            deviceRemoveWaveInToolStripMenuItem.Text = WaveInAsString;
            deviceRemoveWaveOutToolStripMenuItem.Text = WaveOutAsString;

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
        internal void SetColorTheme()                                                   //NOTE: while debugging when the event is handled for IsLightThemeEnabled.*
        {
            ToggleDarkModeRenderer();                                                   //NOTE: this will break.*
            SetViewToggleDarkModeToolStripMenuItemProperties();

            FormColorUpdater.SetColorsOfConstructor(this);                              //NOTE: this will NOT break.*
            FormColorUpdater.SetColorsOfControlCollection(Controls);                    //NOTE: this will NOT break.*
            FormColorUpdater.SetColorsOfControlList(controlList);                       //NOTE: this will NOT break.*
            FormColorUpdater.SetColorsOfToolStripItemList(toolStripItemList);           //NOTE: this will NOT break.*

            if (aboutForm != null)                                                      //NOTE: this will NOT break.*
            {
                aboutForm.SetColorTheme();                                              //NOTE: this will NOT break.*
            }

            Invalidate();                                                               //NOTE: this will NOT break.*
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
            if (GraphicsWindow.LightThemeValidator is null)
            {
                return;
            }

            GraphicsWindow.LightThemeValidator.IsLightThemeEnabledValueChanged +=
                (sender, propertyValueChangedEventArgs) =>
                {

                    SetColorTheme();
                };
        }

        /// <summary>
        /// Set mouse properties of drop down tool strip menu item.
        /// </summary>
        /// <param name="toolStripMenuItem">The drop down tool strip menu item</param>
        internal void SetMousePropertiesOfToolStripMenuItemDropDown
            (ref ToolStripMenuItem toolStripMenuItem)
        {
            if (toolStripMenuItem is null)
            {
                return;
            }

            toolStripMenuItem.DropDown.MouseEnter += new System.EventHandler
                (this.SetAutoClosePropertyOfToolStripDropDown_MouseEnter);

            toolStripMenuItem.DropDown.MouseLeave += new System.EventHandler
                (this.SetAutoClosePropertyOfToolStripDropDown_MouseLeave);
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

        #region 1. File menu logic

        /// <summary>
        /// Click event logic for fileOpenToolStripMenuItem.
        /// Get filename if dialog result is OK.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void fileOpenToolStripMenuItem_Click(object sender, EventArgs eventArgs)
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
        internal void fileExitToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            /*
             * TODO:
             *  -add logic to...
             *      -check if runtime data is saved to file.
             *      -warn user to save changes.
             *      -warn user that audio repeaters may exit at app shutdown.
             */

            Application.Exit();
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
        /// Click event logic for deviceAddSelectAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddSelectAllToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            ToggleDeviceAddSelectAllToolStripMenuItem();

            SetCheckedPropertyForEachToolStripMenuItem
                (ref deviceAddSelectWaveInToolStripMenuItem,
                toggleDeviceAddSelectAllToolStripMenuItem);

            SetCheckedPropertyForEachToolStripMenuItem
                (ref deviceAddSelectWaveOutToolStripMenuItem,
                toggleDeviceAddSelectAllToolStripMenuItem);

            SetEnabledPropertyOfDeviceAddConfirmToolStripMenuItem();
        }

        /// <summary>
        /// Click event logic for deviceAddConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddConfirmToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                (ref deviceAddSelectWaveInToolStripMenuItem,
                ref deviceRemoveWaveInToolStripMenuItem);

            MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
                (ref deviceAddSelectWaveOutToolStripMenuItem,
                ref deviceRemoveWaveOutToolStripMenuItem);

            //deviceListModel.MoveMMDeviceToSelectedList()                              //FIXME

            SetEnabledPropertyOfDeviceAddConfirmToolStripMenuItem();
            SetEnabledPropertyOfDeviceAddSelectAllToolStripMenuItem();
            SetEnabledPropertyOfDeviceAddSelectToolStripMenuItem();
            SetEnabledPropertyOfDeviceAddToolStripMenuItem();
        }

        /// <summary>
        /// Toggle enabled property event for deviceAddConfirmToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceAddConfirmToolStripMenuItemEnabled_Toggle
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || !(sender is ToolStripMenuItem))
            {
                return;
            }

            SetEnabledPropertyOfDeviceAddConfirmToolStripMenuItem();
        }

        /// <summary>
        /// Click event logic for deviceReloadAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceReloadAllToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            SetDeviceList();
            InitializeLists();
            SetEnabledPropertyOfDeviceAddConfirmToolStripMenuItem();
        }

        /// <summary>
        /// Click event logic for deviceRemoveAllToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveAllToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            SetDeviceList();
            InitializeLists();
        }

        /// <summary>
        /// Click event logic for deviceRemoveWaveInToolStripMenuItemDropDown.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveWaveInToolStripMenuItemDropDown_Click
            (object sender, EventArgs eventArgs)
        {
            if (!(sender is ToolStripMenuItem))
            {
                return;
            }

            deviceListModel.MoveMMDeviceFromSelectedList
                (DataFlow.Capture, (sender as ToolStripMenuItem).ToolTipText);
            InitializeLists();
        }

        /// <summary>
        /// Click event logic for deviceRemoveWaveOutToolStripMenuItemDropDown.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void deviceRemoveWaveOutToolStripMenuItemDropDown_Click
            (object sender, EventArgs eventArgs)
        {
            if (!(sender is ToolStripMenuItem))
            {
                return;
            }

            deviceListModel.MoveMMDeviceFromSelectedList
                (DataFlow.Render, (sender as ToolStripMenuItem).ToolTipText);
            InitializeLists();
        }

        /// <summary>
        /// Set Enable property of deviceAddConfirmToolStripMenuItem.
        /// </summary>
        internal void SetEnabledPropertyOfDeviceAddConfirmToolStripMenuItem()
        {
            deviceAddConfirmToolStripMenuItem.Enabled =
                doAddSelectedWaveInOrWaveOutContainCheckedMenuItem;
        }

        /// <summary>
        /// Set Enable property of deviceAddSelectAllToolStripMenuItem.
        /// </summary>
        internal void SetEnabledPropertyOfDeviceAddSelectAllToolStripMenuItem()
        {
            deviceAddSelectAllToolStripMenuItem.Enabled =
                doAddSelectedWaveInOrWaveOutContainCheckedMenuItem;
        }

        /// <summary>
        /// Set Enable property of deviceAddSelectToolStripMenuItem.
        /// </summary>
        internal void SetEnabledPropertyOfDeviceAddSelectToolStripMenuItem()
        {
            deviceAddSelectToolStripMenuItem.Enabled =
                doAddSelectedWaveInOrWaveOutContainCheckedMenuItem;
        }

        /// <summary>
        /// Set Enable property of deviceAddToolStripMenuItem.
        /// </summary>
        internal void SetEnabledPropertyOfDeviceAddToolStripMenuItem()
        {
            deviceAddToolStripMenuItem.Enabled =
                doAddSelectedWaveInOrWaveOutContainCheckedMenuItem;
        }

        /// <summary>
        /// Toggle bool value, call deviceAddSelectAllToolStripMenuItem is clicked.
        /// </summary>
        internal void ToggleDeviceAddSelectAllToolStripMenuItem()
        {
            toggleDeviceAddSelectAllToolStripMenuItem =
                !toggleDeviceAddSelectAllToolStripMenuItem;
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
        internal void linkAddWaveInToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            MMDevice mMDevice = deviceListModel.GetMMDevice
                (DataFlow.Capture, toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            inputDeviceControl = new DeviceControl(mMDevice);
            SetPropertiesOfSelectedToolStripMenuItem
                (ref linkAddWaveInToolStripMenuItem, toolStripMenuItem);
            AddToRepeaterModel();
        }

        /// <summary>
        /// Click event logic for linkAddWaveOutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkAddWaveOutToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            MMDevice mMDevice = deviceListModel.GetMMDevice
                (DataFlow.Render, toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            outputDeviceControl = new DeviceControl(mMDevice);
            SetPropertiesOfSelectedToolStripMenuItem
                (ref linkAddWaveOutToolStripMenuItem, toolStripMenuItem);
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
                ResetPropertiesForEachSelectedToolStripMenuItem
                    (deviceControl.MMDevice, ref linkAddWaveInToolStripMenuItem);
            }
            else
            {
                ResetPropertiesForEachSelectedToolStripMenuItem
                    (deviceControl.MMDevice, ref linkAddWaveOutToolStripMenuItem);
            }
        }

        /// <summary>
        /// Click event logic for linkRemoveWaveInToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkRemoveWaveInToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            MMDevice mMDevice = deviceListModel.GetMMDevice
                (DataFlow.Capture, toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            inputDeviceControl = new DeviceControl(mMDevice);
            SetPropertiesOfSelectedToolStripMenuItem
                (ref linkRemoveWaveInToolStripMenuItem, toolStripMenuItem);
            RemoveFromRepeaterModel();
        }

        /// <summary>
        /// Click event logic for linkRemoveWaveOutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void linkRemoveWaveOutToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (sender is null || sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            MMDevice mMDevice = deviceListModel.GetMMDevice
                (DataFlow.Render, toolStripMenuItem.ToolTipText);

            if (mMDevice is null)
            {
                return;
            }

            outputDeviceControl = new DeviceControl(mMDevice);
            SetPropertiesOfSelectedToolStripMenuItem
                (ref linkRemoveWaveOutToolStripMenuItem, toolStripMenuItem);
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
        internal void viewToggleDarkModeToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            IsLightThemeEnabled = !viewToggleDarkModeToolStripMenuItem.Checked;
            SetColorTheme();
        }

        #endregion

        #region 6. Help menu logic

        /// <summary>
        /// Click event logic for helpAboutToolStripMenuItem.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void helpAboutToolStripMenuItem_Click
            (object sender, EventArgs eventArgs)
        {
            if (Application.OpenForms.OfType<AboutForm>().Count() > 0)
            {
                Application.OpenForms.OfType<AboutForm>().ToList().ForEach
                    (x => x.Close());
            }

            aboutForm = new AboutForm();
            aboutForm.Show();
        }

        #endregion

        #region ToolStrip helper logic

        /// <summary>
        /// Does tool strip item collection contain any checked tool strip menu item(s).
        /// </summary>
        /// <param name="toolStripItemCollection">The tool strip item collection</param>
        /// <returns>True/False</returns>
        internal bool DoesToolStripItemCollectionContainCheckedMenuItem
            (ToolStripItemCollection toolStripItemCollection)
        {
            if (toolStripItemCollection is null || toolStripItemCollection.Count == 0)
            {
                return false;
            }

            foreach (var item in toolStripItemCollection)
            {
                if (!(item is ToolStripMenuItem))
                {
                    continue;
                }

                if ((item as ToolStripMenuItem).Checked)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Move all checked tool strip menu items to new tool strip item collection.
        /// </summary>
        /// <param name="firstToolStripMenuItem">The first tool strip menu item</param>
        /// <param name="secondToolStripMenuItem">The second tool strip menu item
        /// </param>
        internal void MoveAllCheckedToolStripMenuItemsToNewToolStripItemCollection
            (ref ToolStripMenuItem firstToolStripMenuItem,
            ref ToolStripMenuItem secondToolStripMenuItem)
        {
            if (firstToolStripMenuItem is null
                || firstToolStripMenuItem.DropDownItems.Count == 0
                || secondToolStripMenuItem is null)
            {
                return;
            }

            List<ToolStripMenuItem> tempToolStripMenuItemList =
                new List<ToolStripMenuItem>();

            foreach (var item in firstToolStripMenuItem.DropDownItems)
            {
                if (item is null || !(item is ToolStripMenuItem))
                {
                    continue;
                }

                tempToolStripMenuItemList.Add(item as ToolStripMenuItem);
            }

            foreach (ToolStripMenuItem toolStripMenuItem in tempToolStripMenuItemList)
            {
                if (!toolStripMenuItem.Checked)
                {
                    continue;
                }

                firstToolStripMenuItem.DropDownItems.Remove(toolStripMenuItem);

                if (secondToolStripMenuItem.DropDownItems.Contains(toolStripMenuItem))
                {
                    continue;
                }

                secondToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            }

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (ref firstToolStripMenuItem);

            SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
                (ref secondToolStripMenuItem);

            GC.Collect();
        }

        /// <summary>
        /// Resets properties for selected nested tool strip item in tool strip menu
        /// item.
        /// </summary>
        /// <param name="mMDevice">The MMDevice</param>
        /// <param name="parentToolStripMenuItem">The referenced parent tool strip menu
        /// item</param>
        internal void ResetPropertiesForEachSelectedToolStripMenuItem
            (MMDevice mMDevice, ref ToolStripMenuItem parentToolStripMenuItem)
        {
            string isSelectedSuffix = " (Selected)";

            foreach (ToolStripItem toolStripItem in
                parentToolStripMenuItem.DropDownItems)
            {
                if (toolStripItem.ToolTipText != mMDevice.FriendlyName)
                {
                    continue;
                }

                toolStripItem.Text = Regex.Replace
                    (toolStripItem.Text, isSelectedSuffix, string.Empty);
            }
        }

        /// <summary>
        /// Set auto close property of tool strip drop down on mouse enter.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="eventArgs">The event arguments</param>
        internal void SetAutoClosePropertyOfToolStripDropDown_MouseEnter
            (object sender, EventArgs eventArgs)
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
        internal void SetAutoClosePropertyOfToolStripDropDown_MouseLeave
            (object sender, EventArgs eventArgs)
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
            (ref ToolStripMenuItem toolStripMenuItem, bool isChecked)
        {
            if (toolStripMenuItem is null || toolStripMenuItem.DropDownItems.Count == 0)
            {
                return;
            }

            foreach (var item in toolStripMenuItem.DropDownItems)
            {
                if (item is null || !(item is ToolStripMenuItem))
                {
                    continue;
                }

                (item as ToolStripMenuItem).Checked = isChecked;
            }
        }

        /// <summary>
        /// Set properties of tool strip menu item given tool strip item collection is
        /// empty or not.
        /// </summary>
        /// <param name="toolStripMenuItem">The tool strip menu item</param>
        internal void SetPropertiesOfToolStripMenuItemGivenItemCollectionIsEmptyOrNot
            (ref ToolStripMenuItem toolStripMenuItem)
        {
            bool isNotEmpty = toolStripMenuItem.DropDownItems.Count != 0;
            toolStripMenuItem.Enabled = isNotEmpty;

            if (isNotEmpty)
            {
                toolStripMenuItem.ToolTipText = string.Empty;
            }
            else
            {
                toolStripMenuItem.ToolTipText = "No items found.";
            }
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
            (ref ToolStripMenuItem parentToolStripMenuItem,
            ToolStripMenuItem childToolStripMenuItem)
        {
            if (!parentToolStripMenuItem.DropDownItems.Contains(childToolStripMenuItem))
            {
                return;
            }

            string isSelectedSuffix = " (Selected)";

            foreach
                (ToolStripItem toolStripItem in parentToolStripMenuItem.DropDownItems)
            {
                if (toolStripItem != childToolStripMenuItem)
                {
                    toolStripItem.Text = Regex.Replace
                        (toolStripItem.Text, isSelectedSuffix, string.Empty);
                }
                else
                {
                    toolStripItem.Text += isSelectedSuffix;
                }
            }
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