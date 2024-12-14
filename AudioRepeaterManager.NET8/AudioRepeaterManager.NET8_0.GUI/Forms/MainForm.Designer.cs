namespace AudioRepeaterManager.NET8_0.GUI
{
  partial class MainForm
  {
    #region Parameters

    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #endregion

    #region Logic

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

    #endregion

    #region Windows Form Designer generated logic

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      toolStrip1 = new ToolStrip();
      aboutToolStripMenuItem = new ToolStripMenuItem();
      alwaysOnTopToolStripMenuItem = new ToolStripMenuItem();
      closeAllToolStripMenuItem = new ToolStripMenuItem();
      closeMultipleToolStripMenuItem = new ToolStripMenuItem();
      closeToolStripMenuItem = new ToolStripMenuItem();
      helpToolStripDropDownButton = new ToolStripDropDownButton();
      commandLineArgumentsToolStripMenuItem = new ToolStripMenuItem();
      deviceExportToClipboardToolStripMenuItem = new ToolStripMenuItem();
      deviceExportToXMLToolStripMenuItem = new ToolStripMenuItem();
      deviceFindToolStripMenuItem = new ToolStripMenuItem();
      deviceImportFromClipboardToolStripMenuItem = new ToolStripMenuItem();
      deviceImportFromXMLToolStripMenuItem = new ToolStripMenuItem();
      deviceSelectAllToolStripMenuItem = new ToolStripMenuItem();
      deviceSelectToolStripMenuItem = new ToolStripMenuItem();
      deviceToolStripLabel = new ToolStripDropDownButton();
      deviceToolStripSeparator1 = new ToolStripSeparator();
      deviceToolStripSeparator2 = new ToolStripSeparator();
      deviceToolStripSeparator3 = new ToolStripSeparator();
      disableToolStripMenuItem = new ToolStripMenuItem();
      enableToolStripMenuItem = new ToolStripMenuItem();
      exitToolStripMenuItem = new ToolStripMenuItem();
      fileToolStripLabel = new ToolStripDropDownButton();
      fileToolStripSeparator1 = new ToolStripSeparator();
      helpToolStripSeparator1 = new ToolStripSeparator();
      helpToolStripSeparator2 = new ToolStripSeparator();
      newToolStripMenuItem = new ToolStripMenuItem();
      openContainingFolderToolStripMenuItem = new ToolStripMenuItem();
      openToolStripMenuItem = new ToolStripMenuItem();
      preferDarkThemeToolStripMenuItem = new ToolStripMenuItem();
      preferSystemThemeToolStripMenuItem = new ToolStripMenuItem();
      preferX64Application64bitToolStripMenuItem = new ToolStripMenuItem();
      preferX86Application32bitToolStripMenuItem = new ToolStripMenuItem();
      redoToolStripMenuItem = new ToolStripMenuItem();
      refreshToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToClipboardToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToScriptToolStripMenuItem = new ToolStripMenuItem();
      repeaterExportToXMLToolStripMenuItem = new ToolStripMenuItem();
      repeaterFindToolStripMenuItem = new ToolStripMenuItem();
      repeaterImportFromClipboardToolStripMenuItem = new ToolStripMenuItem();
      repeaterImportFromScriptToolStripMenuItem = new ToolStripMenuItem();
      repeaterImportFromXMLToolStripMenuItem = new ToolStripMenuItem();
      repeaterRedoToolStripMenuItem = new ToolStripMenuItem();
      repeaterSelectAllToolStripMenuItem = new ToolStripMenuItem();
      repeaterSelectToolStripMenuItem = new ToolStripMenuItem();
      repeaterToolStripDropDownButton = new ToolStripDropDownButton();
      repeaterToolStripSeparator1 = new ToolStripSeparator();
      repeaterToolStripSeparator2 = new ToolStripSeparator();
      repeaterToolStripSeparator3 = new ToolStripSeparator();
      repeaterToolStripSeparator4 = new ToolStripSeparator();
      repeaterUndoToolStripMenuItem = new ToolStripMenuItem();
      restartToolStripMenuItem = new ToolStripMenuItem();
      saveACopyAsToolStripMenuItem = new ToolStripMenuItem();
      saveAllToolStripMenuItem = new ToolStripMenuItem();
      saveAsToolStripMenuItem = new ToolStripMenuItem();
      saveToolStripMenuItem = new ToolStripMenuItem();
      selectAllDisabledToolStripMenuItem = new ToolStripMenuItem();
      selectAllDuplexToolStripMenuItem = new ToolStripMenuItem();
      selectAllEnabledToolStripMenuItem = new ToolStripMenuItem();
      selectAllInputsToolStripMenuItem = new ToolStripMenuItem();
      selectAllOutputsToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithAbsentDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithDisabledDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithEnabledDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectAllWithPresentDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectDefaultInputToolStripMenuItem = new ToolStripMenuItem();
      selectDefaultOutputToolStripMenuItem = new ToolStripMenuItem();
      selectDevicesToolStripMenuItem = new ToolStripMenuItem();
      selectInputDeviceToolStripMenuItem = new ToolStripMenuItem();
      selectOutputDeviceToolStripMenuItem = new ToolStripMenuItem();
      setApplicationPathToolStripMenuItem = new ToolStripMenuItem();
      setAsDefaultToolStripMenuItem = new ToolStripMenuItem();
      settingsToolStripButton = new ToolStripDropDownButton();
      settingsToolStripSeparator1 = new ToolStripSeparator();
      settingsToolStripSeparator2 = new ToolStripSeparator();
      sortByToolStripMenuItem = new ToolStripMenuItem();
      startAllRepeatersOnLoadToolStripMenuItem = new ToolStripMenuItem();
      startToolStripMenuItem = new ToolStripMenuItem();
      stopToolStripMenuItem = new ToolStripMenuItem();
      toggleBogusModeToolStripMenuItem = new ToolStripMenuItem();
      toggleFullScreenModeToolStripMenuItem = new ToolStripMenuItem();
      toggleSafeModeToolStripMenuItem = new ToolStripMenuItem();
      undoToolStripMenuItem = new ToolStripMenuItem();
      applicationWebsiteToolStripMenuItem = new ToolStripMenuItem();
      viewToolStripLabel = new ToolStripDropDownButton();
      viewToolStripSeparator1 = new ToolStripSeparator();
      websiteToolStripMenuItem = new ToolStripMenuItem();
      windowsToolStripMenuItem = new ToolStripMenuItem();
      windowToolStripDropDownButton = new ToolStripDropDownButton();
      windowToolStripSeparator1 = new ToolStripSeparator();

      toolStrip1.SuspendLayout();
      SuspendLayout();

      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange
        (
          new ToolStripItem[]
          {
            fileToolStripLabel,
            deviceToolStripLabel,
            repeaterToolStripDropDownButton,
            viewToolStripLabel,
            settingsToolStripButton,
            windowToolStripDropDownButton,
            helpToolStripDropDownButton
          });

      toolStrip1.Location = new Point(0, 0);
      toolStrip1.Name = nameof(toolStrip1);
      toolStrip1.Size = new Size(800, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      //
      // aboutToolStripMenuItem
      //
      aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
      aboutToolStripMenuItem.Name = nameof(aboutToolStripMenuItem);
      aboutToolStripMenuItem.Size = new Size(218, 22);
      aboutToolStripMenuItem.Text = "";
      //
      // alwaysOnTopToolStripMenuItem
      //
      alwaysOnTopToolStripMenuItem.CheckOnClick = true;
      alwaysOnTopToolStripMenuItem.Click += alwaysOnTopToolStripMenuItem_Click;
      alwaysOnTopToolStripMenuItem.Name = nameof(alwaysOnTopToolStripMenuItem);
      alwaysOnTopToolStripMenuItem.Size = new Size(203, 22);
      alwaysOnTopToolStripMenuItem.Text = "Always on Top";
      //
      // closeAllToolStripMenuItem
      //
      closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click;
      closeAllToolStripMenuItem.Name = nameof(closeAllToolStripMenuItem);
      closeAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
      closeAllToolStripMenuItem.Size = new Size(201, 22);
      closeAllToolStripMenuItem.Text = "Close All";
      //
      // closeMultipleToolStripMenuItem
      //
      closeMultipleToolStripMenuItem.Click += closeMultipleToolStripMenuItem_Click;
      closeMultipleToolStripMenuItem.Name = nameof(closeMultipleToolStripMenuItem);
      closeMultipleToolStripMenuItem.Size = new Size(201, 22);
      closeMultipleToolStripMenuItem.Text = "Close Multiple...";
      //
      // closeToolStripMenuItem
      //
      closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
      closeToolStripMenuItem.Name = nameof(closeToolStripMenuItem);
      closeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
      closeToolStripMenuItem.Size = new Size(201, 22);
      closeToolStripMenuItem.Text = "Close";
      //
      // helpToolStripDropDownButton
      //
      helpToolStripDropDownButton.AutoToolTip = false;
      helpToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      helpToolStripDropDownButton.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            commandLineArgumentsToolStripMenuItem,
            helpToolStripSeparator1,
            websiteToolStripMenuItem,
            applicationWebsiteToolStripMenuItem,
            helpToolStripSeparator2,
            aboutToolStripMenuItem
          }
        );

      helpToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
      helpToolStripDropDownButton.Name = nameof(helpToolStripDropDownButton);
      helpToolStripDropDownButton.Size = new Size(45, 22);
      helpToolStripDropDownButton.Text = "Help";
      //
      //
      //
      commandLineArgumentsToolStripMenuItem.Click += commandLineArgumentsToolStripMenuItem_Click;
      commandLineArgumentsToolStripMenuItem.Name = nameof(commandLineArgumentsToolStripMenuItem);
      commandLineArgumentsToolStripMenuItem.Size = new Size(218, 22);
      commandLineArgumentsToolStripMenuItem.Text = "Command Line Arguments";
      //
      // deviceExportToClipboardToolStripMenuItem
      //
      deviceExportToClipboardToolStripMenuItem.Click += deviceExportToClipboardToolStripMenuItem_Click;
      deviceExportToClipboardToolStripMenuItem.Name = nameof(deviceExportToClipboardToolStripMenuItem);
      deviceExportToClipboardToolStripMenuItem.Size = new Size(192, 22);
      deviceExportToClipboardToolStripMenuItem.Text = "Export to clipboard";
      //
      // deviceExportToXMLToolStripMenuItem
      //
      deviceExportToXMLToolStripMenuItem.Click += deviceExportToXMLToolStripMenuItem_Click;
      deviceExportToXMLToolStripMenuItem.Name = nameof(deviceExportToXMLToolStripMenuItem);
      deviceExportToXMLToolStripMenuItem.Size = new Size(192, 22);
      deviceExportToXMLToolStripMenuItem.Text = "Export to XML";
      //
      // deviceFindToolStripMenuItem
      //
      deviceFindToolStripMenuItem.Name = nameof(deviceFindToolStripMenuItem);
      deviceFindToolStripMenuItem.Size = new Size(192, 22);
      deviceFindToolStripMenuItem.Text = "Find...";
      //
      // deviceImportFromClipboardToolStripMenuItem
      //
      deviceImportFromClipboardToolStripMenuItem.Click += deviceImportFromClipboardToolStripMenuItem_Click;
      deviceImportFromClipboardToolStripMenuItem.Name = nameof(deviceImportFromClipboardToolStripMenuItem);
      deviceImportFromClipboardToolStripMenuItem.Size = new Size(192, 22);
      deviceImportFromClipboardToolStripMenuItem.Text = "Import from clipboard";
      //
      // deviceImportFromXMLToolStripMenuItem
      //
      deviceImportFromXMLToolStripMenuItem.Click += deviceImportFromXMLToolStripMenuItem_Click;
      deviceImportFromXMLToolStripMenuItem.Name = nameof(deviceImportFromXMLToolStripMenuItem);
      deviceImportFromXMLToolStripMenuItem.Size = new Size(192, 22);
      deviceImportFromXMLToolStripMenuItem.Text = "Import from XML";
      //
      // deviceSelectAllToolStripMenuItem
      //
      deviceSelectAllToolStripMenuItem.Click += deviceSelectAllToolStripMenuItem_Click;
      deviceSelectAllToolStripMenuItem.Name = nameof(deviceSelectAllToolStripMenuItem);
      deviceSelectAllToolStripMenuItem.Size = new Size(192, 22);
      deviceSelectAllToolStripMenuItem.Text = "Select All";
      //
      // deviceSelectToolStripMenuItem
      //
      deviceSelectToolStripMenuItem.Click += deviceSelectToolStripMenuItem_Click;
      deviceSelectToolStripMenuItem.Name = nameof(deviceSelectToolStripMenuItem);
      deviceSelectToolStripMenuItem.Size = new Size(192, 22);
      deviceSelectToolStripMenuItem.Text = "Select";
      //
      // deviceToolStripLabel
      //
      deviceToolStripLabel.AutoToolTip = false;
      deviceToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
      deviceToolStripLabel.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            undoToolStripMenuItem,
            redoToolStripMenuItem,
            deviceToolStripSeparator1,
            setAsDefaultToolStripMenuItem,
            refreshToolStripMenuItem,
            enableToolStripMenuItem,
            disableToolStripMenuItem,
            deviceToolStripSeparator2,
            deviceFindToolStripMenuItem,
            deviceSelectToolStripMenuItem,
            deviceSelectAllToolStripMenuItem,
            selectAllEnabledToolStripMenuItem,
            selectAllDisabledToolStripMenuItem,
            selectAllInputsToolStripMenuItem,
            selectAllOutputsToolStripMenuItem,
            selectAllDuplexToolStripMenuItem,
            selectDefaultInputToolStripMenuItem,
            selectDefaultOutputToolStripMenuItem,
            deviceToolStripSeparator3,
            deviceImportFromClipboardToolStripMenuItem,
            deviceImportFromXMLToolStripMenuItem,
            deviceExportToClipboardToolStripMenuItem,
            deviceExportToXMLToolStripMenuItem
          }
        );

      deviceToolStripLabel.Name = nameof(deviceToolStripLabel);
      deviceToolStripLabel.Size = new Size(55, 22);
      deviceToolStripLabel.Text = "Device";
      //
      // deviceToolStripSeparator1
      //
      deviceToolStripSeparator1.Name = nameof(deviceToolStripSeparator1);
      deviceToolStripSeparator1.Size = new Size(189, 6);
      //
      // deviceToolStripSeparator2
      //
      deviceToolStripSeparator2.Name = nameof(deviceToolStripSeparator2);
      deviceToolStripSeparator2.Size = new Size(189, 6);
      //
      // deviceToolStripSeparator3
      //
      deviceToolStripSeparator3.Name = nameof(deviceToolStripSeparator3);
      deviceToolStripSeparator3.Size = new Size(189, 6);
      //
      // disableToolStripMenuItem
      //
      disableToolStripMenuItem.Click += disableToolStripMenuItem_Click;
      disableToolStripMenuItem.Name = nameof(disableToolStripMenuItem);
      disableToolStripMenuItem.Size = new Size(192, 22);
      disableToolStripMenuItem.Text = "Disable";
      //
      // enableToolStripMenuItem
      //
      enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
      enableToolStripMenuItem.Name = nameof(enableToolStripMenuItem);
      enableToolStripMenuItem.Size = new Size(192, 22);
      enableToolStripMenuItem.Text = "Enable";
      //
      // exitToolStripMenuItem
      //
      exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
      exitToolStripMenuItem.Name = nameof(exitToolStripMenuItem);
      exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
      exitToolStripMenuItem.Size = new Size(201, 22);
      exitToolStripMenuItem.Text = "Exit";
      //
      // fileToolStripLabel
      //
      fileToolStripLabel.AutoToolTip = false;
      fileToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;

      fileToolStripLabel.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            newToolStripMenuItem,
            openToolStripMenuItem,
            openContainingFolderToolStripMenuItem,
            saveToolStripMenuItem,
            saveAsToolStripMenuItem,
            saveACopyAsToolStripMenuItem,
            saveAllToolStripMenuItem,
            closeToolStripMenuItem,
            closeAllToolStripMenuItem,
            closeMultipleToolStripMenuItem,
            fileToolStripSeparator1,
            exitToolStripMenuItem
          }
        );

      fileToolStripLabel.Name = nameof(fileToolStripLabel);
      fileToolStripLabel.Size = new Size(38, 22);
      fileToolStripLabel.Text = "File";
      //
      // fileToolStripSeparator1
      //
      fileToolStripSeparator1.Name = nameof(fileToolStripSeparator1);
      fileToolStripSeparator1.Size = new Size(198, 6);
      //
      // helpToolStripSeparator1
      //
      helpToolStripSeparator1.Name = nameof(helpToolStripSeparator1);
      helpToolStripSeparator1.Size = new Size(215, 6);
      helpToolStripSeparator2.Name = nameof(helpToolStripSeparator2);
      helpToolStripSeparator2.Size = new Size(215, 6);
      //
      // newToolStripMenuItem
      //
      newToolStripMenuItem.Click += newToolStripMenuItem_Click;
      newToolStripMenuItem.Name = nameof(newToolStripMenuItem);
      newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
      newToolStripMenuItem.Size = new Size(201, 22);
      newToolStripMenuItem.Text = "New";
      //
      // openContainingFolderToolStripMenuItem
      //
      openContainingFolderToolStripMenuItem.Click += openContainingFolderToolStripMenuItem_Click;
      openContainingFolderToolStripMenuItem.Name = nameof(openContainingFolderToolStripMenuItem);
      openContainingFolderToolStripMenuItem.Size = new Size(201, 22);
      openContainingFolderToolStripMenuItem.Text = "Open Containing Folder";
      //
      // openToolStripMenuItem
      //
      openToolStripMenuItem.Click += openToolStripMenuItem_Click;
      openToolStripMenuItem.Name = nameof(openToolStripMenuItem);
      openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
      openToolStripMenuItem.Size = new Size(201, 22);
      openToolStripMenuItem.Text = "Open...";
      //
      // preferDarkThemeToolStripMenuItem
      //
      preferDarkThemeToolStripMenuItem.CheckOnClick = true;
      preferDarkThemeToolStripMenuItem.Click += preferDarkThemeToolStripMenuItem_Click;
      preferDarkThemeToolStripMenuItem.Name = nameof(preferDarkThemeToolStripMenuItem);
      preferDarkThemeToolStripMenuItem.Size = new Size(203, 22);
      preferDarkThemeToolStripMenuItem.Text = "Prefer Dark Theme";
      //
      // preferSystemThemeToolStripMenuItem
      //
      preferSystemThemeToolStripMenuItem.CheckOnClick = true;
      preferSystemThemeToolStripMenuItem.Click += preferSystemThemeToolStripMenuItem_Click;
      preferSystemThemeToolStripMenuItem.Name = nameof(preferSystemThemeToolStripMenuItem);
      preferSystemThemeToolStripMenuItem.Size = new Size(203, 22);
      preferSystemThemeToolStripMenuItem.Text = "Prefer System Theme";
      //
      // preferX64Application64bitToolStripMenuItem
      //
      preferX64Application64bitToolStripMenuItem.CheckOnClick = true;
      preferX64Application64bitToolStripMenuItem.Click += preferX64Application64bitToolStripMenuItem_Click;
      preferX64Application64bitToolStripMenuItem.Name = nameof(preferX64Application64bitToolStripMenuItem);
      preferX64Application64bitToolStripMenuItem.Size = new Size(232, 22);
      preferX64Application64bitToolStripMenuItem.Text = "Prefer x64 Application (64-bit)";
      preferX86Application32bitToolStripMenuItem.CheckOnClick = true;
      //
      // preferX86Application32bitToolStripMenuItem
      //
      preferX86Application32bitToolStripMenuItem.Click += preferX86Application32bitToolStripMenuItem_Click;
      preferX86Application32bitToolStripMenuItem.Name = nameof(preferX86Application32bitToolStripMenuItem);
      preferX86Application32bitToolStripMenuItem.Size = new Size(232, 22);
      preferX86Application32bitToolStripMenuItem.Text = "Prefer x86 Application (32-bit)";
      //
      // redoToolStripMenuItem
      //
      redoToolStripMenuItem.Click += deviceRedoToolStripMenuItem_Click;
      redoToolStripMenuItem.Name = nameof(redoToolStripMenuItem);
      redoToolStripMenuItem.Size = new Size(192, 22);
      redoToolStripMenuItem.Text = "Redo";
      //
      // refreshToolStripMenuItem
      //
      refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
      refreshToolStripMenuItem.Name = nameof(refreshToolStripMenuItem);
      refreshToolStripMenuItem.Size = new Size(192, 22);
      refreshToolStripMenuItem.Text = "Refresh";
      //
      // repeaterExportToClipboardToolStripMenuItem
      //
      repeaterExportToClipboardToolStripMenuItem.Click += repeaterExportToClipboardToolStripMenuItem_Click;
      repeaterExportToClipboardToolStripMenuItem.Name = nameof(repeaterExportToClipboardToolStripMenuItem);
      repeaterExportToClipboardToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToClipboardToolStripMenuItem.Text = "Export to clipboard";
      //
      // repeaterExportToScriptToolStripMenuItem
      //
      repeaterExportToScriptToolStripMenuItem.Click += repeaterExportToScriptToolStripMenuItem_Click;
      repeaterExportToScriptToolStripMenuItem.Name = nameof(repeaterExportToScriptToolStripMenuItem);
      repeaterExportToScriptToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToScriptToolStripMenuItem.Text = "Export to script";
      //
      // repeaterExportToXMLToolStripMenuItem
      //
      repeaterExportToXMLToolStripMenuItem.Click += repeaterExportToXMLToolStripMenuItem_Click;
      repeaterExportToXMLToolStripMenuItem.Name = nameof(repeaterExportToXMLToolStripMenuItem);
      repeaterExportToXMLToolStripMenuItem.Size = new Size(239, 22);
      repeaterExportToXMLToolStripMenuItem.Text = "Export to XML";
      //
      // repeaterFindToolStripMenuItem
      //
      repeaterFindToolStripMenuItem.Name = nameof(repeaterFindToolStripMenuItem);
      repeaterFindToolStripMenuItem.Size = new Size(239, 22);
      repeaterFindToolStripMenuItem.Text = "Find...";
      //
      // repeaterImportFromClipboardToolStripMenuItem
      //
      repeaterImportFromClipboardToolStripMenuItem.Click += repeaterImportFromClipboardToolStripMenuItem_Click;
      repeaterImportFromClipboardToolStripMenuItem.Name = nameof(repeaterImportFromClipboardToolStripMenuItem);
      repeaterImportFromClipboardToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromClipboardToolStripMenuItem.Text = "Import from clipboard";
      //
      // repeaterImportFromScriptToolStripMenuItem
      //
      repeaterImportFromScriptToolStripMenuItem.Click += repeaterImportFromScriptToolStripMenuItem_Click;
      repeaterImportFromScriptToolStripMenuItem.Name = nameof(repeaterImportFromScriptToolStripMenuItem);
      repeaterImportFromScriptToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromScriptToolStripMenuItem.Text = "Import from script";
      //
      // repeaterImportFromXMLToolStripMenuItem
      //
      repeaterImportFromXMLToolStripMenuItem.Click += repeaterImportFromXMLToolStripMenuItem_Click;
      repeaterImportFromXMLToolStripMenuItem.Name = nameof(repeaterImportFromXMLToolStripMenuItem);
      repeaterImportFromXMLToolStripMenuItem.Size = new Size(239, 22);
      repeaterImportFromXMLToolStripMenuItem.Text = "Import from XML";
      //
      // repeaterRedoToolStripMenuItem
      //
      repeaterRedoToolStripMenuItem.Click += repeaterRedoToolStripMenuItem_Click;
      repeaterRedoToolStripMenuItem.Name = nameof(repeaterRedoToolStripMenuItem);
      repeaterRedoToolStripMenuItem.Size = new Size(239, 22);
      repeaterRedoToolStripMenuItem.Text = "Redo";
      //
      // repeaterSelectAllToolStripMenuItem
      //
      repeaterSelectAllToolStripMenuItem.Click += repeaterSelectAllToolStripMenuItem_Click;
      repeaterSelectAllToolStripMenuItem.Name = nameof(repeaterSelectAllToolStripMenuItem);
      repeaterSelectAllToolStripMenuItem.Size = new Size(239, 22);
      repeaterSelectAllToolStripMenuItem.Text = "Select All";
      //
      // repeaterSelectToolStripMenuItem
      //
      repeaterSelectToolStripMenuItem.Click += repeaterSelectToolStripMenuItem_Click;
      repeaterSelectToolStripMenuItem.Name = nameof(repeaterSelectToolStripMenuItem);
      repeaterSelectToolStripMenuItem.Size = new Size(239, 22);
      repeaterSelectToolStripMenuItem.Text = "Select";
      //
      // repeaterToolStripDropDownButton
      //
      repeaterToolStripDropDownButton.AutoToolTip = false;
      repeaterToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

      repeaterToolStripDropDownButton.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            repeaterUndoToolStripMenuItem,
            repeaterRedoToolStripMenuItem,
            repeaterToolStripSeparator1,
            repeaterFindToolStripMenuItem,
            repeaterSelectToolStripMenuItem,
            repeaterSelectAllToolStripMenuItem,
            selectAllWithEnabledDevicesToolStripMenuItem,
            selectAllWithDisabledDevicesToolStripMenuItem,
            selectAllWithPresentDevicesToolStripMenuItem,
            selectAllWithAbsentDevicesToolStripMenuItem,
            repeaterToolStripSeparator2,
            startToolStripMenuItem,
            stopToolStripMenuItem,
            restartToolStripMenuItem,
            repeaterToolStripSeparator3,
            selectDevicesToolStripMenuItem,
            selectInputDeviceToolStripMenuItem,
            selectOutputDeviceToolStripMenuItem,
            repeaterToolStripSeparator4,
            repeaterImportFromClipboardToolStripMenuItem,
            repeaterImportFromScriptToolStripMenuItem,
            repeaterImportFromXMLToolStripMenuItem,
            repeaterExportToClipboardToolStripMenuItem,
            repeaterExportToScriptToolStripMenuItem,
            repeaterExportToXMLToolStripMenuItem
          }
        );

      repeaterToolStripDropDownButton.Name = nameof(repeaterToolStripDropDownButton);
      repeaterToolStripDropDownButton.Size = new Size(66, 22);
      repeaterToolStripDropDownButton.Text = "Repeater";
      //
      // repeaterToolStripSeparator1
      //
      repeaterToolStripSeparator1.Name = nameof(repeaterToolStripSeparator1);
      repeaterToolStripSeparator1.Size = new Size(236, 6);
      //
      // repeaterToolStripSeparator2
      //
      repeaterToolStripSeparator2.Name = nameof(repeaterToolStripSeparator2);
      repeaterToolStripSeparator2.Size = new Size(236, 6);
      //
      // repeaterToolStripSeparator3
      //
      repeaterToolStripSeparator3.Name = nameof(repeaterToolStripSeparator3);
      repeaterToolStripSeparator3.Size = new Size(236, 6);
      //
      // repeaterToolStripSeparator4
      //
      repeaterToolStripSeparator4.Name = nameof(repeaterToolStripSeparator4);
      repeaterToolStripSeparator4.Size = new Size(236, 6);
      //
      // repeaterUndoToolStripMenuItem
      //
      repeaterUndoToolStripMenuItem.Click += repeaterUndoToolStripMenuItem_Click;
      repeaterUndoToolStripMenuItem.Name = nameof(repeaterUndoToolStripMenuItem);
      repeaterUndoToolStripMenuItem.Size = new Size(239, 22);
      repeaterUndoToolStripMenuItem.Text = "Undo";
      //
      // restartToolStripMenuItem
      //
      restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
      restartToolStripMenuItem.Name = nameof(restartToolStripMenuItem);
      restartToolStripMenuItem.Size = new Size(239, 22);
      restartToolStripMenuItem.Text = "Restart";
      //
      // saveACopyAsToolStripMenuItem
      //
      saveACopyAsToolStripMenuItem.Click += saveACopyAsToolStripMenuItem_Click;
      saveACopyAsToolStripMenuItem.Name = nameof(saveACopyAsToolStripMenuItem);
      saveACopyAsToolStripMenuItem.Size = new Size(201, 22);
      saveACopyAsToolStripMenuItem.Text = "Save a Copy As...";
      //
      // saveAllToolStripMenuItem
      //
      saveAllToolStripMenuItem.Click += saveAllToolStripMenuItem_Click;
      saveAllToolStripMenuItem.Name = nameof(saveAllToolStripMenuItem);
      saveAllToolStripMenuItem.Size = new Size(201, 22);
      saveAllToolStripMenuItem.Text = "Save All";
      //
      // saveAsToolStripMenuItem
      //
      saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
      saveAsToolStripMenuItem.Name = nameof(saveAsToolStripMenuItem);
      saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
      saveAsToolStripMenuItem.Size = new Size(201, 22);
      saveAsToolStripMenuItem.Text = "Save As...";
      //
      // saveToolStripMenuItem
      //
      saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
      saveToolStripMenuItem.Name = nameof(saveToolStripMenuItem);
      saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
      saveToolStripMenuItem.Size = new Size(201, 22);
      saveToolStripMenuItem.Text = "Save";
      //
      // selectAllDisabledToolStripMenuItem
      //
      selectAllDisabledToolStripMenuItem.Click += selectAllDisabledToolStripMenuItem_Click;
      selectAllDisabledToolStripMenuItem.Name = nameof(selectAllDisabledToolStripMenuItem);
      selectAllDisabledToolStripMenuItem.Size = new Size(192, 22);
      selectAllDisabledToolStripMenuItem.Text = "Select All Disabled";
      //
      // selectAllDuplexToolStripMenuItem
      //
      selectAllDuplexToolStripMenuItem.Click += selectAllDuplexToolStripMenuItem_Click;
      selectAllDuplexToolStripMenuItem.Name = nameof(selectAllDuplexToolStripMenuItem);
      selectAllDuplexToolStripMenuItem.Size = new Size(192, 22);
      selectAllDuplexToolStripMenuItem.Text = "Select All Duplex";
      //
      // selectAllEnabledToolStripMenuItem
      //
      selectAllEnabledToolStripMenuItem.Click += selectAllEnabledToolStripMenuItem_Click;
      selectAllEnabledToolStripMenuItem.Name = nameof(selectAllEnabledToolStripMenuItem);
      selectAllEnabledToolStripMenuItem.Size = new Size(192, 22);
      selectAllEnabledToolStripMenuItem.Text = "Select All Enabled";
      //
      // selectAllInputsToolStripMenuItem
      //
      selectAllInputsToolStripMenuItem.Click += selectAllInputsToolStripMenuItem_Click;
      selectAllInputsToolStripMenuItem.Name = nameof(selectAllInputsToolStripMenuItem);
      selectAllInputsToolStripMenuItem.Size = new Size(192, 22);
      selectAllInputsToolStripMenuItem.Text = "Select All Inputs";
      //
      // selectAllOutputsToolStripMenuItem
      //
      selectAllOutputsToolStripMenuItem.Click += selectAllOutputsToolStripMenuItem_Click;
      selectAllOutputsToolStripMenuItem.Name = nameof(selectAllOutputsToolStripMenuItem);
      selectAllOutputsToolStripMenuItem.Size = new Size(192, 22);
      selectAllOutputsToolStripMenuItem.Text = "Select All Outputs";
      //
      // selectAllWithAbsentDevicesToolStripMenuItem
      //
      selectAllWithAbsentDevicesToolStripMenuItem.Click += selectAllWithAbsentDevicesToolStripMenuItem_Click;
      selectAllWithAbsentDevicesToolStripMenuItem.Name = nameof(selectAllWithAbsentDevicesToolStripMenuItem);
      selectAllWithAbsentDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithAbsentDevicesToolStripMenuItem.Text = "Select All with Absent Devices";
      //
      // selectAllWithDisabledDevicesToolStripMenuItem
      //
      selectAllWithDisabledDevicesToolStripMenuItem.Click += selectAllWithDisabledDevicesToolStripMenuItem_Click;
      selectAllWithDisabledDevicesToolStripMenuItem.Name = nameof(selectAllWithDisabledDevicesToolStripMenuItem);
      selectAllWithDisabledDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithDisabledDevicesToolStripMenuItem.Text = "Select All with Disabled Devices";
      //
      // selectAllWithEnabledDevicesToolStripMenuItem
      //
      selectAllWithEnabledDevicesToolStripMenuItem.Click += selectAllWithEnabledDevicesToolStripMenuItem_Click;
      selectAllWithEnabledDevicesToolStripMenuItem.Name = nameof(selectAllWithEnabledDevicesToolStripMenuItem);
      selectAllWithEnabledDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithEnabledDevicesToolStripMenuItem.Text = "Select All with Enabled Devices";
      //
      // selectAllWithPresentDevicesToolStripMenuItem
      //
      selectAllWithPresentDevicesToolStripMenuItem.Click += selectAllWithPresentDevicesToolStripMenuItem_Click;
      selectAllWithPresentDevicesToolStripMenuItem.Name = nameof(selectAllWithPresentDevicesToolStripMenuItem);
      selectAllWithPresentDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectAllWithPresentDevicesToolStripMenuItem.Text = "Select All with Present Devices";
      //
      // selectDefaultInputToolStripMenuItem
      //
      selectDefaultInputToolStripMenuItem.Click += selectDefaultInputToolStripMenuItem_Click;
      selectDefaultInputToolStripMenuItem.Name = nameof(selectDefaultInputToolStripMenuItem);
      selectDefaultInputToolStripMenuItem.Size = new Size(192, 22);
      selectDefaultInputToolStripMenuItem.Text = "Select Default Input";
      //
      // selectDefaultOutputToolStripMenuItem
      //
      selectDefaultOutputToolStripMenuItem.Click += selectDefaultOutputToolStripMenuItem_Click;
      selectDefaultOutputToolStripMenuItem.Name = nameof(selectDefaultOutputToolStripMenuItem);
      selectDefaultOutputToolStripMenuItem.Size = new Size(192, 22);
      selectDefaultOutputToolStripMenuItem.Text = "Select Default Output";
      //
      // selectDevicesToolStripMenuItem
      //
      selectDevicesToolStripMenuItem.Click += selectDevicesToolStripMenuItem_Click;
      selectDevicesToolStripMenuItem.Name = nameof(selectDevicesToolStripMenuItem);
      selectDevicesToolStripMenuItem.Size = new Size(239, 22);
      selectDevicesToolStripMenuItem.Text = "Select Devices";
      //
      // selectInputDeviceToolStripMenuItem
      //
      selectInputDeviceToolStripMenuItem.Click += selectInputDeviceToolStripMenuItem_Click;
      selectInputDeviceToolStripMenuItem.Name = nameof(selectInputDeviceToolStripMenuItem);
      selectInputDeviceToolStripMenuItem.Size = new Size(239, 22);
      selectInputDeviceToolStripMenuItem.Text = "Select Input Device";
      //
      // selectOutputDeviceToolStripMenuItem
      //
      selectOutputDeviceToolStripMenuItem.Click += selectOutputDeviceToolStripMenuItem_Click;
      selectOutputDeviceToolStripMenuItem.Name = nameof(selectOutputDeviceToolStripMenuItem);
      selectOutputDeviceToolStripMenuItem.Size = new Size(239, 22);
      selectOutputDeviceToolStripMenuItem.Text = "Select Output Device";
      //
      // setApplicationPathToolStripMenuItem
      //
      setApplicationPathToolStripMenuItem.Click += setApplicationPathToolStripMenuItem_Click;
      setApplicationPathToolStripMenuItem.Name = nameof(setApplicationPathToolStripMenuItem);
      setApplicationPathToolStripMenuItem.Size = new Size(232, 22);
      setApplicationPathToolStripMenuItem.Text = "Set Application Path";
      //
      // setAsDefaultToolStripMenuItem
      //
      setAsDefaultToolStripMenuItem.Click += setAsDefaultToolStripMenuItem_Click;
      setAsDefaultToolStripMenuItem.Name = nameof(setAsDefaultToolStripMenuItem);
      setAsDefaultToolStripMenuItem.Size = new Size(192, 22);
      setAsDefaultToolStripMenuItem.Text = "Set As Default";
      //
      // settingsToolStripButton
      //
      settingsToolStripButton.AutoToolTip = false;
      settingsToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

      settingsToolStripButton.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            startAllRepeatersOnLoadToolStripMenuItem,
            settingsToolStripSeparator1,
            preferX86Application32bitToolStripMenuItem,
            preferX64Application64bitToolStripMenuItem,
            setApplicationPathToolStripMenuItem,
            settingsToolStripSeparator2,
            toggleBogusModeToolStripMenuItem,
            toggleSafeModeToolStripMenuItem
          }
        );

      settingsToolStripButton.ImageTransparentColor = Color.Magenta;
      settingsToolStripButton.Name = nameof(settingsToolStripButton);
      settingsToolStripButton.Size = new Size(62, 22);
      settingsToolStripButton.Text = "Settings";
      //
      // settingsToolStripSeparator1
      //
      settingsToolStripSeparator1.Name = nameof(settingsToolStripSeparator1);
      settingsToolStripSeparator1.Size = new Size(229, 6);
      //
      // settingsToolStripSeparator2
      //
      settingsToolStripSeparator2.Name = nameof(settingsToolStripSeparator2);
      settingsToolStripSeparator2.Size = new Size(229, 6);
      //
      // sortByToolStripMenuItem
      //
      sortByToolStripMenuItem.Click += sortByToolStripMenuItem_Click;
      sortByToolStripMenuItem.Name = nameof(sortByToolStripMenuItem);
      sortByToolStripMenuItem.Size = new Size(132, 22);
      sortByToolStripMenuItem.Text = "Sort By";
      //
      // startAllRepeatersOnLoadToolStripMenuItem
      //
      startAllRepeatersOnLoadToolStripMenuItem.CheckOnClick = true;
      startAllRepeatersOnLoadToolStripMenuItem.Click += startAllRepeatersOnLoadToolStripMenuItem_Click;
      startAllRepeatersOnLoadToolStripMenuItem.Name = nameof(startAllRepeatersOnLoadToolStripMenuItem);
      startAllRepeatersOnLoadToolStripMenuItem.Size = new Size(232, 22);
      startAllRepeatersOnLoadToolStripMenuItem.Text = "Start All Repeaters on Load";
      //
      // startToolStripMenuItem
      //
      startToolStripMenuItem.Click += startToolStripMenuItem_Click;
      startToolStripMenuItem.Name = nameof(startToolStripMenuItem);
      startToolStripMenuItem.Size = new Size(239, 22);
      startToolStripMenuItem.Text = "Start";
      //
      // stopToolStripMenuItem
      //
      stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
      stopToolStripMenuItem.Name = nameof(stopToolStripMenuItem);
      stopToolStripMenuItem.Size = new Size(239, 22);
      stopToolStripMenuItem.Text = "Stop";
      //
      // toggleBogusModeToolStripMenuItem
      //
      toggleBogusModeToolStripMenuItem.CheckOnClick = true;
      toggleBogusModeToolStripMenuItem.Click += toggleBogusModeToolStripMenuItem_Click;
      toggleBogusModeToolStripMenuItem.Name = nameof(toggleBogusModeToolStripMenuItem);
      toggleBogusModeToolStripMenuItem.Size = new Size(232, 22);
      toggleBogusModeToolStripMenuItem.Text = "Toggle Bogus Mode";
      //
      // toggleFullScreenModeToolStripMenuItem
      //
      toggleFullScreenModeToolStripMenuItem.CheckOnClick = true;
      toggleFullScreenModeToolStripMenuItem.Click += toggleFullScreenModeToolStripMenuItem_Click;
      toggleFullScreenModeToolStripMenuItem.Name = nameof(toggleFullScreenModeToolStripMenuItem);
      toggleFullScreenModeToolStripMenuItem.Size = new Size(203, 22);
      toggleFullScreenModeToolStripMenuItem.Text = "Toggle Full Screen Mode";
      //
      // toggleSafeModeToolStripMenuItem
      //
      toggleSafeModeToolStripMenuItem.Checked = true;
      toggleSafeModeToolStripMenuItem.CheckOnClick = true;
      toggleSafeModeToolStripMenuItem.CheckState = CheckState.Checked;
      toggleSafeModeToolStripMenuItem.Click += toggleSafeModeToolStripMenuItem_Click;
      toggleSafeModeToolStripMenuItem.Name = nameof(toggleSafeModeToolStripMenuItem);
      toggleSafeModeToolStripMenuItem.Size = new Size(232, 22);
      toggleSafeModeToolStripMenuItem.Text = "Toggle Safe Mode";
      //
      // undoToolStripMenuItem
      //
      undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
      undoToolStripMenuItem.Name = nameof(undoToolStripMenuItem);
      undoToolStripMenuItem.Size = new Size(192, 22);
      undoToolStripMenuItem.Text = "Undo";
      //
      // applicationWebsiteToolStripMenuItem
      //
      applicationWebsiteToolStripMenuItem.Click += applicationWebsiteToolStripMenuItem_Click;
      applicationWebsiteToolStripMenuItem.Name = nameof(applicationWebsiteToolStripMenuItem);
      applicationWebsiteToolStripMenuItem.Size = new Size(218, 22);
      applicationWebsiteToolStripMenuItem.Text = "";
      //
      // viewToolStripLabel
      //
      viewToolStripLabel.AutoToolTip = false;
      viewToolStripLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;

      viewToolStripLabel.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            alwaysOnTopToolStripMenuItem,
            toggleFullScreenModeToolStripMenuItem,
            viewToolStripSeparator1,
            preferDarkThemeToolStripMenuItem,
            preferSystemThemeToolStripMenuItem
          }
        );

      viewToolStripLabel.Name = nameof(viewToolStripLabel);
      viewToolStripLabel.Size = new Size(45, 22);
      viewToolStripLabel.Text = "View";
      //
      // viewToolStripSeparator1
      //
      viewToolStripSeparator1.Name = nameof(viewToolStripSeparator1);
      viewToolStripSeparator1.Size = new Size(200, 6);
      //
      // websiteToolStripMenuItem
      //
      websiteToolStripMenuItem.Click += websiteToolStripMenuItem_Click;
      websiteToolStripMenuItem.Name = nameof(websiteToolStripMenuItem);
      websiteToolStripMenuItem.Size = new Size(218, 22);
      websiteToolStripMenuItem.Text = "";
      //
      // windowsToolStripMenuItem
      //
      windowsToolStripMenuItem.Click += windowsToolStripMenuItem_Click;
      windowsToolStripMenuItem.Name = nameof(windowsToolStripMenuItem);
      windowsToolStripMenuItem.Size = new Size(132, 22);
      windowsToolStripMenuItem.Text = "Windows...";
      //
      // windowToolStripDropDownButton
      //
      windowToolStripDropDownButton.AutoToolTip = false;
      windowToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

      windowToolStripDropDownButton.DropDownItems.AddRange
        (
          new ToolStripItem[]
          {
            sortByToolStripMenuItem,
            windowsToolStripMenuItem,
            windowToolStripSeparator1
          }
        );

      windowToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
      windowToolStripDropDownButton.Name = nameof(windowToolStripDropDownButton);
      windowToolStripDropDownButton.Size = new Size(64, 22);
      windowToolStripDropDownButton.Text = "Window";
      windowToolStripSeparator1.Name = nameof(windowToolStripSeparator1);
      windowToolStripSeparator1.Size = new Size(129, 6);
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(toolStrip1);
      Name = nameof(MainForm);
      Text = "MainForm";
      Load += MainForm_Load;

      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();

      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    #region Windows Form Designer generated parameters

    private ToolStrip toolStrip1;
    private ToolStripDropDownButton helpToolStripDropDownButton;
    private ToolStripDropDownButton deviceToolStripLabel;
    private ToolStripDropDownButton fileToolStripLabel;
    private ToolStripDropDownButton repeaterToolStripDropDownButton;
    private ToolStripDropDownButton settingsToolStripButton;
    private ToolStripDropDownButton viewToolStripLabel;
    private ToolStripDropDownButton windowToolStripDropDownButton;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem alwaysOnTopToolStripMenuItem;
    private ToolStripMenuItem closeAllToolStripMenuItem;
    private ToolStripMenuItem closeMultipleToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    private ToolStripMenuItem deviceExportToClipboardToolStripMenuItem;
    private ToolStripMenuItem deviceExportToXMLToolStripMenuItem;
    private ToolStripMenuItem deviceFindToolStripMenuItem;
    private ToolStripMenuItem deviceImportFromClipboardToolStripMenuItem;
    private ToolStripMenuItem deviceImportFromXMLToolStripMenuItem;
    private ToolStripMenuItem deviceSelectAllToolStripMenuItem;
    private ToolStripMenuItem deviceSelectToolStripMenuItem;
    private ToolStripMenuItem disableToolStripMenuItem;
    private ToolStripMenuItem enableToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openContainingFolderToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem preferDarkThemeToolStripMenuItem;
    private ToolStripMenuItem preferSystemThemeToolStripMenuItem;
    private ToolStripMenuItem preferX64Application64bitToolStripMenuItem;
    private ToolStripMenuItem preferX86Application32bitToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripMenuItem refreshToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToClipboardToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToScriptToolStripMenuItem;
    private ToolStripMenuItem repeaterExportToXMLToolStripMenuItem;
    private ToolStripMenuItem repeaterFindToolStripMenuItem;
    private ToolStripMenuItem repeaterImportFromClipboardToolStripMenuItem;
    private ToolStripMenuItem repeaterImportFromScriptToolStripMenuItem;
    private ToolStripMenuItem repeaterImportFromXMLToolStripMenuItem;
    private ToolStripMenuItem repeaterRedoToolStripMenuItem;
    private ToolStripMenuItem repeaterSelectAllToolStripMenuItem;
    private ToolStripMenuItem repeaterSelectToolStripMenuItem;
    private ToolStripMenuItem repeaterUndoToolStripMenuItem;
    private ToolStripMenuItem restartToolStripMenuItem;
    private ToolStripMenuItem saveACopyAsToolStripMenuItem;
    private ToolStripMenuItem saveAllToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem selectAllDisabledToolStripMenuItem;
    private ToolStripMenuItem selectAllDuplexToolStripMenuItem;
    private ToolStripMenuItem selectAllEnabledToolStripMenuItem;
    private ToolStripMenuItem selectAllInputsToolStripMenuItem;
    private ToolStripMenuItem selectAllOutputsToolStripMenuItem;
    private ToolStripMenuItem selectAllWithAbsentDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithDisabledDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithEnabledDevicesToolStripMenuItem;
    private ToolStripMenuItem selectAllWithPresentDevicesToolStripMenuItem;
    private ToolStripMenuItem selectDefaultInputToolStripMenuItem;
    private ToolStripMenuItem selectDefaultOutputToolStripMenuItem;
    private ToolStripMenuItem selectDevicesToolStripMenuItem;
    private ToolStripMenuItem selectInputDeviceToolStripMenuItem;
    private ToolStripMenuItem selectOutputDeviceToolStripMenuItem;
    private ToolStripMenuItem setApplicationPathToolStripMenuItem;
    private ToolStripMenuItem setAsDefaultToolStripMenuItem;
    private ToolStripMenuItem sortByToolStripMenuItem;
    private ToolStripMenuItem startAllRepeatersOnLoadToolStripMenuItem;
    private ToolStripMenuItem startToolStripMenuItem;
    private ToolStripMenuItem stopToolStripMenuItem;
    private ToolStripMenuItem toggleBogusModeToolStripMenuItem;
    private ToolStripMenuItem toggleFullScreenModeToolStripMenuItem;
    private ToolStripMenuItem toggleSafeModeToolStripMenuItem;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem applicationWebsiteToolStripMenuItem;
    private ToolStripMenuItem websiteToolStripMenuItem;
    private ToolStripMenuItem windowsToolStripMenuItem;
    private ToolStripSeparator deviceToolStripSeparator1;
    private ToolStripSeparator deviceToolStripSeparator2;
    private ToolStripSeparator deviceToolStripSeparator3;
    private ToolStripSeparator fileToolStripSeparator1;
    private ToolStripSeparator helpToolStripSeparator1;
    private ToolStripSeparator helpToolStripSeparator2;
    private ToolStripSeparator repeaterToolStripSeparator1;
    private ToolStripSeparator repeaterToolStripSeparator2;
    private ToolStripSeparator repeaterToolStripSeparator3;
    private ToolStripSeparator repeaterToolStripSeparator4;
    private ToolStripSeparator settingsToolStripSeparator1;
    private ToolStripSeparator settingsToolStripSeparator2;
    private ToolStripSeparator viewToolStripSeparator1;
    private ToolStripSeparator windowToolStripSeparator1;
  }

  #endregion
}