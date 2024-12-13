using AudioRepeaterManager.NET8.GUI.Helpers;
using System.Reflection;

namespace AudioRepeaterManager.NET8.GUI
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      Text = Assembly
        .GetEntryAssembly()
        .GetCustomAttribute<AssemblyTitleAttribute>()
        .Title;

      InitializeComponent();
    }

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

    private void closeAllToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void closeMultipleToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void closeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }


    private void exitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void newToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void openToolStripMenuItem_Click
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

    private void openContainingFolderToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void saveToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void saveAsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void saveACopyAsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void saveAllToolStripMenuItem_Click
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

    private void disableToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void enableToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void refreshToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void setAsDefaultToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllDisabledToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllDuplexToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllEnabledToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllInputsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllOutputsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectDefaultInputToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectDefaultOutputToolStripMenuItem_Click
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

    private void restartToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectAllWithAbsentDevicesToolStripMenuItem_Click
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

    private void selectAllWithPresentDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectDevicesToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectInputDeviceToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void selectOutputDeviceToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void startToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void stopToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region View logic

    private void alwaysOnTopToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void preferSystemThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void preferDarkThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void toggleFullScreenModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Settings logic

    private void preferX64Application64bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void preferX86Application32bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void setApplicationPathToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void startAllRepeatersOnLoadToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void toggleBogusModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void toggleSafeModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    #endregion

    #region Help logic

    private void aboutToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      new AboutForm()
        .ShowDialog();
    }
    private void commandLineArgumentsToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void vacWebsiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      string url = "https://vac.muzychenko.net";
      UrlRedirectHelper.GoToSite(url);
    }

    private void websiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {
      string url = "https://www.github.com/portellam/vac-audio-repeater-manager";
      UrlRedirectHelper.GoToSite(url);
    }

    #endregion

    #region Window logic

    private void sortByToolStripMenuItem_Click
    (
      object sender,
      EventArgs eventArgs
    )
    {

    }

    private void windowsToolStripMenuItem_Click
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