using System.Reflection;

namespace AudioRepeaterManager.NET8.GUI
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="isDisposed">true if managed resources should be disposed;
    /// otherwise, false.</param>
    protected override void Dispose(bool isDisposed)
    {
      if
      (
        isDisposed
        && (components != null)
      )
      {
        components.Dispose();
      }

      base.Dispose(isDisposed);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      toolStrip1 = new ToolStrip();
      fileToolStripLabel = new ToolStripDropDownButton();
      newToolStripMenuItem = new ToolStripMenuItem();
      openToolStripMenuItem = new ToolStripMenuItem();
      openContainingFolderToolStripMenuItem = new ToolStripMenuItem();
      saveToolStripMenuItem = new ToolStripMenuItem();
      saveAsToolStripMenuItem = new ToolStripMenuItem();
      saveACopyAsToolStripMenuItem = new ToolStripMenuItem();
      saveAllToolStripMenuItem = new ToolStripMenuItem();
      closeToolStripMenuItem = new ToolStripMenuItem();
      closeAllToolStripMenuItem = new ToolStripMenuItem();
      closeMultipleToolStripMenuItem = new ToolStripMenuItem();
      fileToolStripSeparator1 = new ToolStripSeparator();
      exitToolStripMenuItem = new ToolStripMenuItem();
      deviceToolStripLabel = new ToolStripDropDownButton();
      undoToolStripMenuItem = new ToolStripMenuItem();
      redoToolStripMenuItem = new ToolStripMenuItem();
      deviceToolStripSeparator1 = new ToolStripSeparator();
      setAsDefaultToolStripMenuItem = new ToolStripMenuItem();
      refreshToolStripMenuItem = new ToolStripMenuItem();
      enableToolStripMenuItem = new ToolStripMenuItem();
      disableToolStripMenuItem = new ToolStripMenuItem();
      deviceToolStripSeparator2 = new ToolStripSeparator();
      deviceFindToolStripMenuItem = new ToolStripMenuItem();
      deviceSelectToolStripMenuItem = new ToolStripMenuItem();
      deviceSelectAllToolStripMenuItem = new ToolStripMenuItem();
      selectAllDisabledToolStripMenuItem = new ToolStripMenuItem();
      selectAllEnabledToolStripMenuItem = new ToolStripMenuItem();
      selectAllDuplexToolStripMenuItem = new ToolStripMenuItem();
      selectAllInputsToolStripMenuItem = new ToolStripMenuItem();
      selectAllOutputsToolStripMenuItem = new ToolStripMenuItem();
      selectDefaultInputToolStripMenuItem = new ToolStripMenuItem();
      selectDefaultOutputToolStripMenuItem = new ToolStripMenuItem();
      deviceToolStripSeparator3 = new ToolStripSeparator();
      deviceImportFromClipboardToolStripMenuItem = new ToolStripMenuItem();
      deviceImportFromXMLToolStripMenuItem = new ToolStripMenuItem();
      deviceExportToClipboardToolStripMenuItem = new ToolStripMenuItem();
      deviceExportToXMLToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripDropDownButton = new ToolStripDropDownButton();
      repeaterUndoToolStripMenuItem = new ToolStripMenuItem();
      repeaterRedoToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripSeparator1 = new ToolStripSeparator();
      repeaterFindToolStripMenuItem = new ToolStripMenuItem();
      repeaterSelectToolStripMenuItem = new ToolStripMenuItem();
      repeaterSelectAllToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithEnabledDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithDisabledDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithPresentDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithAbsentDevicesToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripSeparator2 = new ToolStripSeparator();
      startToolStripMenuItem = new ToolStripMenuItem();
      stopToolStripMenuItem = new ToolStripMenuItem();
      restartToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripSeparator3 = new ToolStripSeparator();
      selectDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectInputDeviceToolStripMenuItem = new ToolStripMenuItem();
      selectOutputDeviceToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripSeparator4 = new ToolStripSeparator();
      repeaterImportFromClipboardToolStripMenuItem = new ToolStripMenuItem();
      repeaterImportFromScriptToolStripMenuItem = new ToolStripMenuItem();
      repeaterImportFromXMLToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToClipboardToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToScriptToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToXMLToolStripMenuItem = new ToolStripMenuItem();
      viewToolStripLabel = new ToolStripDropDownButton();
      alwaysOnTopToolStripMenuItem = new ToolStripMenuItem();
      toggleFullScreenModeToolStripMenuItem = new ToolStripMenuItem();
      viewToolStripSeparator1 = new ToolStripSeparator();
      preferDarkThemeToolStripMenuItem = new ToolStripMenuItem();
      preferSystemThemeToolStripMenuItem = new ToolStripMenuItem();
      toolStripButton1 = new ToolStripDropDownButton();
      startAllRepeatersOnLoadToolStripMenuItem = new ToolStripMenuItem();
      settingsToolStripSeparator1 = new ToolStripSeparator();
      preferX86Application32bitToolStripMenuItem = new ToolStripMenuItem();
      preferX64Application64bitToolStripMenuItem = new ToolStripMenuItem();
      setApplicationPathToolStripMenuItem = new ToolStripMenuItem();
      settingsToolStripSeparator2 = new ToolStripSeparator();
      toggleBogusModeToolStripMenuItem = new ToolStripMenuItem();
      overrideSafeMaximumValuesToolStripMenuItem = new ToolStripMenuItem();
      toolStripDropDownButton2 = new ToolStripDropDownButton();
      sortByToolStripMenuItem = new ToolStripMenuItem();
      windowsToolStripMenuItem = new ToolStripMenuItem();
      windowToolStripSeparator1 = new ToolStripSeparator();
      toolStripDropDownButton1 = new ToolStripDropDownButton();
      commandLineArgumentsToolStripMenuItem = new ToolStripMenuItem();
      helpToolStripSeparator1 = new ToolStripSeparator();
      websiteToolStripMenuItem = new ToolStripMenuItem();
      vacWebsiteToolStripMenuItem = new ToolStripMenuItem();
      helpToolStripSeparator2 = new ToolStripSeparator();
      aboutToolStripMenuItem = new ToolStripMenuItem();
      toolStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripLabel, deviceToolStripLabel, repeaterToolStripDropDownButton, viewToolStripLabel, toolStripButton1, toolStripDropDownButton2, toolStripDropDownButton1 });
      toolStrip1.Location = new Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new Size(800, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // fileToolStripLabel
      // 
      fileToolStripLabel.AutoToolTip = false;
      fileToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
      fileToolStripLabel.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, openContainingFolderToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, saveACopyAsToolStripMenuItem, saveAllToolStripMenuItem, closeToolStripMenuItem, closeAllToolStripMenuItem, closeMultipleToolStripMenuItem, fileToolStripSeparator1, exitToolStripMenuItem });
      fileToolStripLabel.Name = "fileToolStripLabel";
      fileToolStripLabel.Size = new Size(38, 22);
      fileToolStripLabel.Text = "File";
      fileToolStripLabel.Click += toolStripLabel1_Click;
      // 
      // newToolStripMenuItem
      // 
      newToolStripMenuItem.Name = "newToolStripMenuItem";
      newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
      newToolStripMenuItem.Size = new Size(201, 22);
      newToolStripMenuItem.Text = "New";
      // 
      // openToolStripMenuItem
      // 
      openToolStripMenuItem.Name = "openToolStripMenuItem";
      openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
      openToolStripMenuItem.Size = new Size(201, 22);
      openToolStripMenuItem.Text = "Open...";
      // 
      // openContainingFolderToolStripMenuItem
      // 
      openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
      openContainingFolderToolStripMenuItem.Size = new Size(201, 22);
      openContainingFolderToolStripMenuItem.Text = "Open Containing Folder";
      // 
      // saveToolStripMenuItem
      // 
      saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
      saveToolStripMenuItem.Size = new Size(201, 22);
      saveToolStripMenuItem.Text = "Save";
      // 
      // saveAsToolStripMenuItem
      // 
      saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
      saveAsToolStripMenuItem.Size = new Size(201, 22);
      saveAsToolStripMenuItem.Text = "Save As...";
      // 
      // saveACopyAsToolStripMenuItem
      // 
      saveACopyAsToolStripMenuItem.Name = "saveACopyAsToolStripMenuItem";
      saveACopyAsToolStripMenuItem.Size = new Size(201, 22);
      saveACopyAsToolStripMenuItem.Text = "Save a Copy As...";
      // 
      // saveAllToolStripMenuItem
      // 
      saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
      saveAllToolStripMenuItem.Size = new Size(201, 22);
      saveAllToolStripMenuItem.Text = "Save All";
      // 
      // closeToolStripMenuItem
      // 
      closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      closeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
      closeToolStripMenuItem.Size = new Size(201, 22);
      closeToolStripMenuItem.Text = "Close";
      // 
      // closeAllToolStripMenuItem
      // 
      closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
      closeAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
      closeAllToolStripMenuItem.Size = new Size(201, 22);
      closeAllToolStripMenuItem.Text = "Close All";
      // 
      // closeMultipleToolStripMenuItem
      // 
      closeMultipleToolStripMenuItem.Name = "closeMultipleToolStripMenuItem";
      closeMultipleToolStripMenuItem.Size = new Size(201, 22);
      closeMultipleToolStripMenuItem.Text = "Close Multiple...";
      // 
      // fileToolStripSeparator1
      // 
      fileToolStripSeparator1.Name = "fileToolStripSeparator1";
      fileToolStripSeparator1.Size = new Size(198, 6);
      // 
      // exitToolStripMenuItem
      // 
      exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
      exitToolStripMenuItem.Size = new Size(201, 22);
      exitToolStripMenuItem.Text = "Exit";
      // 
      // deviceToolStripLabel
      // 
      deviceToolStripLabel.AutoToolTip = false;
      deviceToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
      deviceToolStripLabel.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, deviceToolStripSeparator1, setAsDefaultToolStripMenuItem, refreshToolStripMenuItem, enableToolStripMenuItem, disableToolStripMenuItem, deviceToolStripSeparator2, deviceFindToolStripMenuItem, deviceSelectToolStripMenuItem, deviceSelectAllToolStripMenuItem, selectAllDisabledToolStripMenuItem, selectAllEnabledToolStripMenuItem, selectAllDuplexToolStripMenuItem, selectAllInputsToolStripMenuItem, selectAllOutputsToolStripMenuItem, selectDefaultInputToolStripMenuItem, selectDefaultOutputToolStripMenuItem, deviceToolStripSeparator3, deviceImportFromClipboardToolStripMenuItem, deviceImportFromXMLToolStripMenuItem, deviceExportToClipboardToolStripMenuItem, deviceExportToXMLToolStripMenuItem });
      deviceToolStripLabel.Name = "deviceToolStripLabel";
      deviceToolStripLabel.Size = new Size(55, 22);
      deviceToolStripLabel.Text = "Device";
      deviceToolStripLabel.Click += deviceToolStripLabel_Click;
      // 
      // undoToolStripMenuItem
      // 
      undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      undoToolStripMenuItem.Size = new Size(192, 22);
      undoToolStripMenuItem.Text = "Undo";
      // 
      // redoToolStripMenuItem
      // 
      redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      redoToolStripMenuItem.Size = new Size(192, 22);
      redoToolStripMenuItem.Text = "Redo";
      // 
      // deviceToolStripSeparator1
      // 
      deviceToolStripSeparator1.Name = "deviceToolStripSeparator1";
      deviceToolStripSeparator1.Size = new Size(189, 6);
      // 
      // setAsDefaultToolStripMenuItem
      // 
      setAsDefaultToolStripMenuItem.Name = "setAsDefaultToolStripMenuItem";
      setAsDefaultToolStripMenuItem.Size = new Size(192, 22);
      setAsDefaultToolStripMenuItem.Text = "Set As Default";
      // 
      // refreshToolStripMenuItem
      // 
      refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
      refreshToolStripMenuItem.Size = new Size(192, 22);
      refreshToolStripMenuItem.Text = "Refresh";
      // 
      // enableToolStripMenuItem
      // 
      enableToolStripMenuItem.Name = "enableToolStripMenuItem";
      enableToolStripMenuItem.Size = new Size(192, 22);
      enableToolStripMenuItem.Text = "Enable";
      enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
      // 
      // disableToolStripMenuItem
      // 
      disableToolStripMenuItem.Name = "disableToolStripMenuItem";
      disableToolStripMenuItem.Size = new Size(192, 22);
      disableToolStripMenuItem.Text = "Disable";
      disableToolStripMenuItem.Click += disableToolStripMenuItem_Click;
      // 
      // deviceToolStripSeparator2
      // 
      deviceToolStripSeparator2.Name = "deviceToolStripSeparator2";
      deviceToolStripSeparator2.Size = new Size(189, 6);
      // 
      // deviceFindToolStripMenuItem
      // 
      deviceFindToolStripMenuItem.Name = "deviceFindToolStripMenuItem";
      deviceFindToolStripMenuItem.Size = new Size(192, 22);
      deviceFindToolStripMenuItem.Text = "Find...";
      // 
      // deviceSelectToolStripMenuItem
      // 
      deviceSelectToolStripMenuItem.Name = "deviceSelectToolStripMenuItem";
      deviceSelectToolStripMenuItem.Size = new Size(192, 22);
      deviceSelectToolStripMenuItem.Text = "Select";
      // 
      // deviceSelectAllToolStripMenuItem
      // 
      deviceSelectAllToolStripMenuItem.Name = "deviceSelectAllToolStripMenuItem";
      deviceSelectAllToolStripMenuItem.Size = new Size(192, 22);
      deviceSelectAllToolStripMenuItem.Text = "Select All";
      // 
      // selectAllDisabledToolStripMenuItem
      // 
      selectAllDisabledToolStripMenuItem.Name = "selectAllDisabledToolStripMenuItem";
      selectAllDisabledToolStripMenuItem.Size = new Size(192, 22);
      selectAllDisabledToolStripMenuItem.Text = "Select All Disabled";
      // 
      // selectAllEnabledToolStripMenuItem
      // 
      selectAllEnabledToolStripMenuItem.Name = "selectAllEnabledToolStripMenuItem";
      selectAllEnabledToolStripMenuItem.Size = new Size(192, 22);
      selectAllEnabledToolStripMenuItem.Text = "Select All Enabled";
      // 
      // selectAllDuplexToolStripMenuItem
      // 
      selectAllDuplexToolStripMenuItem.Name = "selectAllDuplexToolStripMenuItem";
      selectAllDuplexToolStripMenuItem.Size = new Size(192, 22);
      selectAllDuplexToolStripMenuItem.Text = "Select All Duplex";
      selectAllDuplexToolStripMenuItem.Click += selectAllDuplexToolStripMenuItem_Click;
      // 
      // selectAllInputsToolStripMenuItem
      // 
      selectAllInputsToolStripMenuItem.Name = "selectAllInputsToolStripMenuItem";
      selectAllInputsToolStripMenuItem.Size = new Size(192, 22);
      selectAllInputsToolStripMenuItem.Text = "Select All Inputs";
      // 
      // selectAllOutputsToolStripMenuItem
      // 
      selectAllOutputsToolStripMenuItem.Name = "selectAllOutputsToolStripMenuItem";
      selectAllOutputsToolStripMenuItem.Size = new Size(192, 22);
      selectAllOutputsToolStripMenuItem.Text = "Select All Outputs";
      // 
      // selectDefaultInputToolStripMenuItem
      // 
      selectDefaultInputToolStripMenuItem.Name = "selectDefaultInputToolStripMenuItem";
      selectDefaultInputToolStripMenuItem.Size = new Size(192, 22);
      selectDefaultInputToolStripMenuItem.Text = "Select Default Input";
      // 
      // selectDefaultOutputToolStripMenuItem
      // 
      selectDefaultOutputToolStripMenuItem.Name = "selectDefaultOutputToolStripMenuItem";
      selectDefaultOutputToolStripMenuItem.Size = new Size(192, 22);
      selectDefaultOutputToolStripMenuItem.Text = "Select Default Output";
      // 
      // deviceToolStripSeparator3
      // 
      deviceToolStripSeparator3.Name = "deviceToolStripSeparator3";
      deviceToolStripSeparator3.Size = new Size(189, 6);
      // 
      // deviceImportFromClipboardToolStripMenuItem
      // 
      deviceImportFromClipboardToolStripMenuItem.Name = "deviceImportFromClipboardToolStripMenuItem";
      deviceImportFromClipboardToolStripMenuItem.Size = new Size(192, 22);
      deviceImportFromClipboardToolStripMenuItem.Text = "Import from clipboard";
      // 
      // deviceImportFromXMLToolStripMenuItem
      // 
      deviceImportFromXMLToolStripMenuItem.Name = "deviceImportFromXMLToolStripMenuItem";
      deviceImportFromXMLToolStripMenuItem.Size = new Size(192, 22);
      deviceImportFromXMLToolStripMenuItem.Text = "Import from XML";
      // 
      // deviceExportToClipboardToolStripMenuItem
      // 
      deviceExportToClipboardToolStripMenuItem.Name = "deviceExportToClipboardToolStripMenuItem";
      deviceExportToClipboardToolStripMenuItem.Size = new Size(192, 22);
      deviceExportToClipboardToolStripMenuItem.Text = "Export to clipboard";
      // 
      // deviceExportToXMLToolStripMenuItem
      // 
      deviceExportToXMLToolStripMenuItem.Name = "deviceExportToXMLToolStripMenuItem";
      deviceExportToXMLToolStripMenuItem.Size = new Size(192, 22);
      deviceExportToXMLToolStripMenuItem.Text = "Export to XML";
      // 
      // repeaterToolStripDropDownButton
      // 
      repeaterToolStripDropDownButton.AutoToolTip = false;
      repeaterToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      repeaterToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { repeaterUndoToolStripMenuItem, repeaterRedoToolStripMenuItem, repeaterToolStripSeparator1, repeaterFindToolStripMenuItem, repeaterSelectToolStripMenuItem, repeaterSelectAllToolStripMenuItem, selectAllWithEnabledDevicesToolStripMenuItem, selectAllWithDisabledDevicesToolStripMenuItem, selectAllWithPresentDevicesToolStripMenuItem, selectAllWithAbsentDevicesToolStripMenuItem, repeaterToolStripSeparator2, startToolStripMenuItem, stopToolStripMenuItem, restartToolStripMenuItem, repeaterToolStripSeparator3, selectDevicesToolStripMenuItem, selectInputDeviceToolStripMenuItem, selectOutputDeviceToolStripMenuItem, repeaterToolStripSeparator4, repeaterImportFromClipboardToolStripMenuItem, repeaterImportFromScriptToolStripMenuItem, repeaterImportFromXMLToolStripMenuItem, repeaterExportToClipboardToolStripMenuItem, repeaterExportToScriptToolStripMenuItem, repeaterExportToXMLToolStripMenuItem });
      repeaterToolStripDropDownButton.Name = "repeaterToolStripDropDownButton";
      repeaterToolStripDropDownButton.Size = new Size(66, 22);
      repeaterToolStripDropDownButton.Text = "Repeater";
      // 
      // repeaterUndoToolStripMenuItem
      // 
      repeaterUndoToolStripMenuItem.Name = "repeaterUndoToolStripMenuItem";
      repeaterUndoToolStripMenuItem.Size = new Size(239, 22);
      repeaterUndoToolStripMenuItem.Text = "Undo";
      // 
      // repeaterRedoToolStripMenuItem
      // 
      repeaterRedoToolStripMenuItem.Name = "repeaterRedoToolStripMenuItem";
      repeaterRedoToolStripMenuItem.Size = new Size(239, 22);
      repeaterRedoToolStripMenuItem.Text = "Redo";
      // 
      // repeaterToolStripSeparator1
      // 
      repeaterToolStripSeparator1.Name = "repeaterToolStripSeparator1";
      repeaterToolStripSeparator1.Size = new Size(236, 6);
      // 
      // repeaterFindToolStripMenuItem
      // 
      repeaterFindToolStripMenuItem.Name = "repeaterFindToolStripMenuItem";
      repeaterFindToolStripMenuItem.Size = new Size(239, 22);
      repeaterFindToolStripMenuItem.Text = "Find...";
      // 
      // repeaterSelectToolStripMenuItem
      // 
      repeaterSelectToolStripMenuItem.Name = "repeaterSelectToolStripMenuItem";
      repeaterSelectToolStripMenuItem.Size = new Size(239, 22);
      repeaterSelectToolStripMenuItem.Text = "Select";
      // 
      // repeaterSelectAllToolStripMenuItem
      // 
      repeaterSelectAllToolStripMenuItem.Name = "repeaterSelectAllToolStripMenuItem";
      repeaterSelectAllToolStripMenuItem.Size = new Size(239, 22);
      repeaterSelectAllToolStripMenuItem.Text = "Select All";
      // 
      // selectAllWithEnabledDevicesToolStripMenuItem
      // 
      selectAllWithEnabledDevicesToolStripMenuItem.Name = "selectAllWithEnabledDevicesToolStripMenuItem";
      selectAllWithEnabledDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithEnabledDevicesToolStripMenuItem.Text = "Select All with Enabled Devices";
      // 
      // selectAllWithDisabledDevicesToolStripMenuItem
      // 
      selectAllWithDisabledDevicesToolStripMenuItem.Name = "selectAllWithDisabledDevicesToolStripMenuItem";
      selectAllWithDisabledDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithDisabledDevicesToolStripMenuItem.Text = "Select All with Disabled Devices";
      // 
      // selectAllWithPresentDevicesToolStripMenuItem
      // 
      selectAllWithPresentDevicesToolStripMenuItem.Name = "selectAllWithPresentDevicesToolStripMenuItem";
      selectAllWithPresentDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithPresentDevicesToolStripMenuItem.Text = "Select All with Present Devices";
      // 
      // selectAllWithAbsentDevicesToolStripMenuItem
      // 
      selectAllWithAbsentDevicesToolStripMenuItem.Name = "selectAllWithAbsentDevicesToolStripMenuItem";
      selectAllWithAbsentDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithAbsentDevicesToolStripMenuItem.Text = "Select All with Absent Devices";
      // 
      // repeaterToolStripSeparator2
      // 
      repeaterToolStripSeparator2.Name = "repeaterToolStripSeparator2";
      repeaterToolStripSeparator2.Size = new Size(236, 6);
      // 
      // startToolStripMenuItem
      // 
      startToolStripMenuItem.Name = "startToolStripMenuItem";
      startToolStripMenuItem.Size = new Size(239, 22);
      startToolStripMenuItem.Text = "Start";
      // 
      // stopToolStripMenuItem
      // 
      stopToolStripMenuItem.Name = "stopToolStripMenuItem";
      stopToolStripMenuItem.Size = new Size(239, 22);
      stopToolStripMenuItem.Text = "Stop";
      // 
      // restartToolStripMenuItem
      // 
      restartToolStripMenuItem.Name = "restartToolStripMenuItem";
      restartToolStripMenuItem.Size = new Size(239, 22);
      restartToolStripMenuItem.Text = "Restart";
      // 
      // repeaterToolStripSeparator3
      // 
      repeaterToolStripSeparator3.Name = "repeaterToolStripSeparator3";
      repeaterToolStripSeparator3.Size = new Size(236, 6);
      // 
      // selectDevicesToolStripMenuItem
      // 
      selectDevicesToolStripMenuItem.Name = "selectDevicesToolStripMenuItem";
      selectDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectDevicesToolStripMenuItem.Text = "Select Devices";
      // 
      // selectInputDeviceToolStripMenuItem
      // 
      selectInputDeviceToolStripMenuItem.Name = "selectInputDeviceToolStripMenuItem";
      selectInputDeviceToolStripMenuItem.Size = new Size(239, 22);
      selectInputDeviceToolStripMenuItem.Text = "Select Input Device";
      // 
      // selectOutputDeviceToolStripMenuItem
      // 
      selectOutputDeviceToolStripMenuItem.Name = "selectOutputDeviceToolStripMenuItem";
      selectOutputDeviceToolStripMenuItem.Size = new Size(239, 22);
      selectOutputDeviceToolStripMenuItem.Text = "Select Output Device";
      // 
      // repeaterToolStripSeparator4
      // 
      repeaterToolStripSeparator4.Name = "repeaterToolStripSeparator4";
      repeaterToolStripSeparator4.Size = new Size(236, 6);
      // 
      // repeaterImportFromClipboardToolStripMenuItem
      // 
      repeaterImportFromClipboardToolStripMenuItem.Name = "repeaterImportFromClipboardToolStripMenuItem";
      repeaterImportFromClipboardToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromClipboardToolStripMenuItem.Text = "Import from clipboard";
      // 
      // repeaterImportFromScriptToolStripMenuItem
      // 
      repeaterImportFromScriptToolStripMenuItem.Name = "repeaterImportFromScriptToolStripMenuItem";
      repeaterImportFromScriptToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromScriptToolStripMenuItem.Text = "Import from script";
      // 
      // repeaterImportFromXMLToolStripMenuItem
      // 
      repeaterImportFromXMLToolStripMenuItem.Name = "repeaterImportFromXMLToolStripMenuItem";
      repeaterImportFromXMLToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromXMLToolStripMenuItem.Text = "Import from XML";
      // 
      // repeaterExportToClipboardToolStripMenuItem
      // 
      repeaterExportToClipboardToolStripMenuItem.Name = "repeaterExportToClipboardToolStripMenuItem";
      repeaterExportToClipboardToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToClipboardToolStripMenuItem.Text = "Export to clipboard";
      // 
      // repeaterExportToScriptToolStripMenuItem
      // 
      repeaterExportToScriptToolStripMenuItem.Name = "repeaterExportToScriptToolStripMenuItem";
      repeaterExportToScriptToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToScriptToolStripMenuItem.Text = "Export to script";
      // 
      // repeaterExportToXMLToolStripMenuItem
      // 
      repeaterExportToXMLToolStripMenuItem.Name = "repeaterExportToXMLToolStripMenuItem";
      repeaterExportToXMLToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToXMLToolStripMenuItem.Text = "Export to XML";
      // 
      // viewToolStripLabel
      // 
      viewToolStripLabel.AutoToolTip = false;
      viewToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
      viewToolStripLabel.DropDownItems.AddRange(new ToolStripItem[] { alwaysOnTopToolStripMenuItem, toggleFullScreenModeToolStripMenuItem, viewToolStripSeparator1, preferDarkThemeToolStripMenuItem, preferSystemThemeToolStripMenuItem });
      viewToolStripLabel.Name = "viewToolStripLabel";
      viewToolStripLabel.Size = new Size(45, 22);
      viewToolStripLabel.Text = "View";
      viewToolStripLabel.Click += toolStripLabel4_Click;
      // 
      // alwaysOnTopToolStripMenuItem
      // 
      alwaysOnTopToolStripMenuItem.CheckOnClick = true;
      alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
      alwaysOnTopToolStripMenuItem.Size = new Size(203, 22);
      alwaysOnTopToolStripMenuItem.Text = "Always on Top";
      // 
      // toggleFullScreenModeToolStripMenuItem
      // 
      toggleFullScreenModeToolStripMenuItem.CheckOnClick = true;
      toggleFullScreenModeToolStripMenuItem.Name = "toggleFullScreenModeToolStripMenuItem";
      toggleFullScreenModeToolStripMenuItem.Size = new Size(203, 22);
      toggleFullScreenModeToolStripMenuItem.Text = "Toggle Full Screen Mode";
      // 
      // viewToolStripSeparator1
      // 
      viewToolStripSeparator1.Name = "viewToolStripSeparator1";
      viewToolStripSeparator1.Size = new Size(200, 6);
      // 
      // preferDarkThemeToolStripMenuItem
      // 
      preferDarkThemeToolStripMenuItem.CheckOnClick = true;
      preferDarkThemeToolStripMenuItem.Name = "preferDarkThemeToolStripMenuItem";
      preferDarkThemeToolStripMenuItem.Size = new Size(203, 22);
      preferDarkThemeToolStripMenuItem.Text = "Prefer Dark Theme";
      // 
      // preferSystemThemeToolStripMenuItem
      // 
      preferSystemThemeToolStripMenuItem.CheckOnClick = true;
      preferSystemThemeToolStripMenuItem.Name = "preferSystemThemeToolStripMenuItem";
      preferSystemThemeToolStripMenuItem.Size = new Size(203, 22);
      preferSystemThemeToolStripMenuItem.Text = "Prefer System Theme";
      // 
      // toolStripButton1
      // 
      toolStripButton1.AutoToolTip = false;
      toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
      toolStripButton1.DropDownItems.AddRange(new ToolStripItem[] { startAllRepeatersOnLoadToolStripMenuItem, settingsToolStripSeparator1, preferX86Application32bitToolStripMenuItem, preferX64Application64bitToolStripMenuItem, setApplicationPathToolStripMenuItem, settingsToolStripSeparator2, toggleBogusModeToolStripMenuItem, overrideSafeMaximumValuesToolStripMenuItem });
      toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
      toolStripButton1.ImageTransparentColor = Color.Magenta;
      toolStripButton1.Name = "toolStripButton1";
      toolStripButton1.Size = new Size(62, 22);
      toolStripButton1.Text = "Settings";
      // 
      // startAllRepeatersOnLoadToolStripMenuItem
      // 
      startAllRepeatersOnLoadToolStripMenuItem.CheckOnClick = true;
      startAllRepeatersOnLoadToolStripMenuItem.Name = "startAllRepeatersOnLoadToolStripMenuItem";
      startAllRepeatersOnLoadToolStripMenuItem.Size = new Size(232, 22);
      startAllRepeatersOnLoadToolStripMenuItem.Text = "Start All Repeaters on Load";
      // 
      // settingsToolStripSeparator1
      // 
      settingsToolStripSeparator1.Name = "settingsToolStripSeparator1";
      settingsToolStripSeparator1.Size = new Size(229, 6);
      // 
      // toolStripMenuItem1
      // 
      preferX86Application32bitToolStripMenuItem.CheckOnClick = true;
      preferX86Application32bitToolStripMenuItem.Name = "preferX86Application32bitToolStripMenuItem";
      preferX86Application32bitToolStripMenuItem.Size = new Size(232, 22);
      preferX86Application32bitToolStripMenuItem.Text = "Prefer x86 Application (32-bit)";
      preferX86Application32bitToolStripMenuItem.Click += preferX86Application32bitToolStripMenuItem_Click;
      // 
      // preferX64Application64bitToolStripMenuItem
      // 
      preferX64Application64bitToolStripMenuItem.CheckOnClick = true;
      preferX64Application64bitToolStripMenuItem.Name = "preferX64Application64bitToolStripMenuItem";
      preferX64Application64bitToolStripMenuItem.Size = new Size(232, 22);
      preferX64Application64bitToolStripMenuItem.Text = "Prefer x64 Application (64-bit)";
      // 
      // setApplicationPathToolStripMenuItem
      // 
      setApplicationPathToolStripMenuItem.Name = "setApplicationPathToolStripMenuItem";
      setApplicationPathToolStripMenuItem.Size = new Size(232, 22);
      setApplicationPathToolStripMenuItem.Text = "Set Application Path";
      // 
      // settingsToolStripSeparator2
      // 
      settingsToolStripSeparator2.Name = "settingsToolStripSeparator2";
      settingsToolStripSeparator2.Size = new Size(229, 6);
      // 
      // toggleBogusModeToolStripMenuItem
      // 
      toggleBogusModeToolStripMenuItem.CheckOnClick = true;
      toggleBogusModeToolStripMenuItem.Name = "toggleBogusModeToolStripMenuItem";
      toggleBogusModeToolStripMenuItem.Size = new Size(232, 22);
      toggleBogusModeToolStripMenuItem.Text = "Toggle Bogus Mode";
      // 
      // overrideSafeMaximumValuesToolStripMenuItem
      // 
      overrideSafeMaximumValuesToolStripMenuItem.Checked = true;
      overrideSafeMaximumValuesToolStripMenuItem.CheckOnClick = true;
      overrideSafeMaximumValuesToolStripMenuItem.CheckState = CheckState.Checked;
      overrideSafeMaximumValuesToolStripMenuItem.Name = "overrideSafeMaximumValuesToolStripMenuItem";
      overrideSafeMaximumValuesToolStripMenuItem.Size = new Size(232, 22);
      overrideSafeMaximumValuesToolStripMenuItem.Text = "Toggle Safe Mode";
      // 
      // toolStripDropDownButton2
      // 
      toolStripDropDownButton2.AutoToolTip = false;
      toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
      toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { sortByToolStripMenuItem, windowsToolStripMenuItem, windowToolStripSeparator1 });
      toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
      toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
      toolStripDropDownButton2.Name = "toolStripDropDownButton2";
      toolStripDropDownButton2.Size = new Size(64, 22);
      toolStripDropDownButton2.Text = "Window";
      toolStripDropDownButton2.Click += toolStripDropDownButton2_Click;
      // 
      // sortByToolStripMenuItem
      // 
      sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
      sortByToolStripMenuItem.Size = new Size(132, 22);
      sortByToolStripMenuItem.Text = "Sort By";
      // 
      // windowsToolStripMenuItem
      // 
      windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
      windowsToolStripMenuItem.Size = new Size(132, 22);
      windowsToolStripMenuItem.Text = "Windows...";
      // 
      // windowToolStripSeparator1
      // 
      windowToolStripSeparator1.Name = "windowToolStripSeparator1";
      windowToolStripSeparator1.Size = new Size(129, 6);
      // 
      // toolStripDropDownButton1
      // 
      toolStripDropDownButton1.AutoToolTip = false;
      toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
      toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { commandLineArgumentsToolStripMenuItem, helpToolStripSeparator1, websiteToolStripMenuItem, vacWebsiteToolStripMenuItem, helpToolStripSeparator2, aboutToolStripMenuItem });
      toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
      toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
      toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      toolStripDropDownButton1.Size = new Size(45, 22);
      toolStripDropDownButton1.Text = "Help";
      // 
      // commandLineArgumentsToolStripMenuItem
      // 
      commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
      commandLineArgumentsToolStripMenuItem.Size = new Size(218, 22);
      commandLineArgumentsToolStripMenuItem.Text = "Command Line Arguments";
      commandLineArgumentsToolStripMenuItem.Click += commandLineArgumentsToolStripMenuItem_Click;
      // 
      // helpToolStripSeparator1
      // 
      helpToolStripSeparator1.Name = "helpToolStripSeparator1";
      helpToolStripSeparator1.Size = new Size(215, 6);
      // 
      // websiteToolStripMenuItem
      // 
      websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
      websiteToolStripMenuItem.Size = new Size(218, 22);
      websiteToolStripMenuItem.Text = "VACARM Website";
      websiteToolStripMenuItem.Click += websiteToolStripMenuItem_Click;
      // 
      // vacWebsiteToolStripMenuItem
      // 
      vacWebsiteToolStripMenuItem.Name = "vacWebsiteToolStripMenuItem";
      vacWebsiteToolStripMenuItem.Size = new Size(218, 22);
      vacWebsiteToolStripMenuItem.Text = "VAC Website";
      vacWebsiteToolStripMenuItem.Click += vacWebsiteToolStripMenuItem_Click;
      // 
      // helpToolStripSeparator2
      // 
      helpToolStripSeparator2.Name = "helpToolStripSeparator2";
      helpToolStripSeparator2.Size = new Size(215, 6);
      // 
      // aboutToolStripMenuItem
      // 
      aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      aboutToolStripMenuItem.Size = new Size(218, 22);
      aboutToolStripMenuItem.Text = "About VACARM";
      aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(toolStrip1);
      Name = "MainForm";
      Text = "MainForm";
      Load += MainForm_Load;
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ToolStrip toolStrip1;
    private ToolStripDropDownButton fileToolStripLabel;
    private ToolStripDropDownButton deviceToolStripLabel;
    private ToolStripDropDownButton viewToolStripLabel;
    private ToolStripDropDownButton toolStripButton1;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem openContainingFolderToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem saveACopyAsToolStripMenuItem;
    private ToolStripMenuItem saveAllToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem closeAllToolStripMenuItem;
    private ToolStripMenuItem closeMultipleToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripSeparator fileToolStripSeparator1;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripDropDownButton repeaterToolStripDropDownButton;
    private ToolStripMenuItem repeaterUndoToolStripMenuItem;
    private ToolStripMenuItem repeaterRedoToolStripMenuItem;
    private ToolStripMenuItem refreshToolStripMenuItem;
    private ToolStripSeparator deviceToolStripSeparator1;
    private ToolStripMenuItem setAsDefaultToolStripMenuItem;
    private ToolStripMenuItem enableToolStripMenuItem;
    private ToolStripMenuItem disableToolStripMenuItem;
    private ToolStripSeparator deviceToolStripSeparator2;
    private ToolStripMenuItem deviceFindToolStripMenuItem;
    private ToolStripMenuItem deviceSelectToolStripMenuItem;
    private ToolStripMenuItem deviceSelectAllToolStripMenuItem;
    private ToolStripMenuItem selectAllDisabledToolStripMenuItem;
    private ToolStripMenuItem selectAllEnabledToolStripMenuItem;
    private ToolStripMenuItem selectAllInputsToolStripMenuItem;
    private ToolStripMenuItem selectAllOutputsToolStripMenuItem;
    private ToolStripMenuItem selectDefaultInputToolStripMenuItem;
    private ToolStripMenuItem selectDefaultOutputToolStripMenuItem;
    private ToolStripMenuItem selectAllDuplexToolStripMenuItem;
    private ToolStripSeparator repeaterToolStripSeparator1;
    private ToolStripSeparator repeaterToolStripSeparator2;
    private ToolStripMenuItem selectDevicesToolStripMenuItem;
    private ToolStripMenuItem selectInputDeviceToolStripMenuItem;
    private ToolStripMenuItem selectOutputDeviceToolStripMenuItem;
    private ToolStripSeparator repeaterToolStripSeparator3;
    private ToolStripMenuItem repeaterFindToolStripMenuItem;
    private ToolStripMenuItem repeaterSelectToolStripMenuItem;
    private ToolStripMenuItem repeaterSelectAllToolStripMenuItem;
    private ToolStripMenuItem alwaysOnTopToolStripMenuItem;
    private ToolStripMenuItem toggleFullScreenModeToolStripMenuItem;
    private ToolStripSeparator viewToolStripSeparator1;
    private ToolStripSeparator helpToolStripSeparator1;
    private ToolStripSeparator helpToolStripSeparator2;
    private ToolStripDropDownButton toolStripDropDownButton2;
    private ToolStripMenuItem sortByToolStripMenuItem;
    private ToolStripMenuItem windowsToolStripMenuItem;
    private ToolStripSeparator windowToolStripSeparator1;
    private ToolStripMenuItem selectAllWithEnabledDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithDisabledDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithPresentDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithAbsentDevicesToolStripMenuItem;
    private ToolStripMenuItem startToolStripMenuItem;
    private ToolStripMenuItem stopToolStripMenuItem;
    private ToolStripMenuItem restartToolStripMenuItem;
    private ToolStripSeparator repeaterToolStripSeparator4;
    private ToolStripMenuItem repeaterImportFromClipboardToolStripMenuItem;
    private ToolStripMenuItem repeaterImportFromScriptToolStripMenuItem;
    private ToolStripMenuItem repeaterImportFromXMLToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToClipboardToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToScriptToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToXMLToolStripMenuItem;
    private ToolStripSeparator deviceToolStripSeparator3;
    private ToolStripMenuItem deviceImportFromClipboardToolStripMenuItem;
    private ToolStripMenuItem deviceImportFromXMLToolStripMenuItem;
    private ToolStripMenuItem deviceExportToClipboardToolStripMenuItem;
    private ToolStripMenuItem deviceExportToXMLToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem websiteToolStripMenuItem;
    private ToolStripMenuItem vacWebsiteToolStripMenuItem;
    private ToolStripMenuItem preferX86Application32bitToolStripMenuItem;
    private ToolStripMenuItem preferX64Application64bitToolStripMenuItem;
    private ToolStripMenuItem overrideSafeMaximumValuesToolStripMenuItem;
    private ToolStripMenuItem startAllRepeatersOnLoadToolStripMenuItem;
    private ToolStripMenuItem setApplicationPathToolStripMenuItem;
    private ToolStripSeparator settingsToolStripSeparator1;
    private ToolStripSeparator settingsToolStripSeparator2;
    private ToolStripMenuItem toggleBogusModeToolStripMenuItem;
    private ToolStripMenuItem preferDarkThemeToolStripMenuItem;
    private ToolStripMenuItem preferSystemThemeToolStripMenuItem;
  }
}
