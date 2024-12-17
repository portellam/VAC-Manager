using AudioRepeaterManager.NET8_0.GUI.Helpers;
using AudioRepeaterManager.NET8_0.Backend;

namespace AudioRepeaterManager.NET8_0.GUI
{
  public partial class MainForm : Form
  {
    #region Parameters

    private bool preferX64
    {
      get
      {
        return settingsPreferX64Application64bitToolStripMenuItem.Checked;
      }
      set
      {
        settingsPreferX64Application64bitToolStripMenuItem.Checked = value;
        settingsPreferX86Application32bitToolStripMenuItem.Checked = !value;
      }
    }

    private bool preferX86
    {
      get
      {
        return settingsPreferX86Application32bitToolStripMenuItem.Checked;
      }
      set
      {
        settingsPreferX86Application32bitToolStripMenuItem.Checked = value;
        settingsPreferX64Application64bitToolStripMenuItem.Checked = !value;
      }
    }

    private bool preferDarkTheme
    {
      get
      {
        return viewPreferDarkThemeToolStripMenuItem.Checked;
      }
      set
      {
        viewPreferDarkThemeToolStripMenuItem.Checked = value;
        viewPreferSystemThemeToolStripMenuItem.Checked = !value;
      }
    }

    private bool preferSystemTheme
    {
      get
      {
        return viewPreferSystemThemeToolStripMenuItem.Checked;
      }
      set
      {

        viewPreferSystemThemeToolStripMenuItem.Checked = value;
        viewPreferDarkThemeToolStripMenuItem.Checked = !value;
      }
    }

    #endregion

    public MainForm()
    {
      InitializeComponent();
      PostInitializeComponent();


      windowWindowToolStripDropDownButton.DropDownItems //note: this is a test.
        .Add
        (
          new ToolStripMenuItem()
          {
            Text = "1: Test Window"
          }
        );
    }

    #region Presentation logic

    private void PostInitializeComponent()
    {
      SetComponentsAbilityProperties();
      SetComponentsTextProperties();
    }

    private void SetComponentsAbilityProperties()
    {
      if (Environment.OSVersion.Version.Major < 6)
      {
        viewPreferSystemThemeToolStripMenuItem.Enabled = false;
      }

      if (!Environment.Is64BitOperatingSystem)
      {
        settingsPreferX64Application64bitToolStripMenuItem.Enabled = false;
        settingsPreferX86Application32bitToolStripMenuItem.Enabled = false;
        preferX86 = true;
      }
    }

    private void SetComponentsTextProperties()
    {
      Text = Global.ApplicationPartialAbbreviatedName;

      helpAboutToolStripMenuItem.Text = string.Format
        (
          "About {0}",
          Global.ApplicationPartialAbbreviatedName
        );

      helpApplicationWebsiteToolStripMenuItem.Text = string.Format
        (
          "{0} Website",
          Global.ReferencedApplicationName
        );


      helpWebsiteToolStripMenuItem.Text = string.Format
        (
          "{0} Website",
          Global.ApplicationPartialAbbreviatedName
        );

      string featureNotAvailableMessage = "N/A: ";

      if (!settingsPreferX64Application64bitToolStripMenuItem.Enabled)
      {
        settingsPreferX64Application64bitToolStripMenuItem.Text =
          featureNotAvailableMessage
          + settingsPreferX64Application64bitToolStripMenuItem;
      }

      if (!viewPreferSystemThemeToolStripMenuItem.Enabled)
      {
        viewPreferSystemThemeToolStripMenuItem.Text =
          featureNotAvailableMessage
          + viewPreferSystemThemeToolStripMenuItem;
      }
    }

    #endregion

    #region Main logic

    private void MainForm_Load
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region File logic

    private void fileCloseAllToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileCloseMultipleToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileCloseToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }


    private void fileExitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      // check if it is safe to exit.

      Environment.Exit(0);
    }

    private void fileNewToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileOpenToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      OpenFileDialog openFileDialog = new OpenFileDialog()
      {
        AddExtension = true,
        DefaultExt = ".vacarm",
        CheckFileExists = true,
        CheckPathExists = true,
        InitialDirectory = "C:\\",
        Multiselect = true,
        OkRequiresInteraction = true,
        ShowPreview = true,

      };

      openFileDialog.ShowDialog();

      string fileName = openFileDialog.FileName;
      //send to FileController?
      //file controller populates an instance of the repositories?

      openFileDialog.AddToRecent = true;
      openFileDialog.ShowPreview = true;
    }

    private void fileOpenContainingFolderToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileSaveToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileSaveAsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileSaveACopyAsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void fileSaveAllToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Device logic

    private void deviceExportToClipboardToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceExportToXMLToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceImportFromClipboardToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceImportFromXMLToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceRedoToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceDisableToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceEnableToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceRefreshToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSetAsDefaultToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllDisabledToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllDuplexToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllEnabledToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllInputsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectAllOutputsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectDefaultInputToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void deviceSelectDefaultOutputToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void undoToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Repeaters logic

    private void repeaterExportToClipboardToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterExportToScriptToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterExportToXMLToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterImportFromClipboardToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterImportFromScriptToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterImportFromXMLToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterRedoToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectAllToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterUndoToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterRestartToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectAllWithAbsentDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllWithDisabledDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllWithEnabledDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectAllWithPresentDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectInputDeviceToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterSelectOutputDeviceToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterStartToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void repeaterStopToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region View logic

    private void viewAlwaysOnTopToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }
    private void viewPreferSystemThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      if (sender is null)
      {
        return;
      }

      if (Environment.OSVersion.Version.Major < 6)
      {
        viewPreferSystemThemeToolStripMenuItem.Enabled = false;
      }

      preferSystemTheme = true;
    }

    private void viewPreferDarkThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void viewToggleFullScreenModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Settings logic

    private void settingsPreferX64Application64bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      if
      (
        !Environment.Is64BitOperatingSystem
        || sender is null
      )
      {
        return;
      }

      preferX64 = true;
    }

    private void settingsPreferX86Application32bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      if
      (
        !Environment.Is64BitOperatingSystem
        || sender is null
      )
      {
        return;
      }

      preferX86 = true;
    }

    private void settingsSetApplicationPathToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void settingsStartAllRepeatersOnLoadToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void settingsToggleBogusModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void settingsToggleSafeModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Help logic

    private void helpAboutToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      new AboutForm()
        .ShowDialog();
    }
    private void helpCommandLineArgumentsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void helpApplicationWebsiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      try
      {
        UrlRedirectHelper.GoToSite("https://vac.muzychenko.net");
      }
      catch
      { }
    }

    private void helpWebsiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      string projectName = "vac-audio-repeater-manager";

      try
      {
        UrlRedirectHelper
          .GoToSite
          (
            string.Format
            (
              "https://www.github.com/portellam/{0}",
              projectName
            )
          );

        return;
      }
      catch
      { }

      try
      {
        UrlRedirectHelper
          .GoToSite
          (
            string.Format
            (
              "https://www.codeberg.org/portellam/{0}",
              projectName
            )
          );

        return;
      }
      catch
      { }
    }

    #endregion

    #region Window logic

    private void windowSortByToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void windowWindowsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void windowToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion
  }
}