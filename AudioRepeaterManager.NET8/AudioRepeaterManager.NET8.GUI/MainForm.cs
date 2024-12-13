using AudioRepeaterManager.NET8.GUI.Helpers;

namespace AudioRepeaterManager.NET8.GUI
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    #region Main logic

    private void MainForm_Load
    (
      object sender,
      EventArgs e
    )
    {

    }

    #endregion

    #region File logic
    #endregion

    #region Device logic

    private void disableToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void enableToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void selectAllDuplexToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    #endregion

    #region Repeaters logic
    #endregion

    #region View logic

    private void alwaysOnTopToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void preferSystemThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void preferDarkThemeToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void toggleFullScreenModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    #endregion

    #region Settings logic

    private void preferX64Application64bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void preferX86Application32bitToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void setApplicationPathToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void startAllRepeatersOnLoadToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void toggleBogusModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void toggleSafeModeToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    #endregion

    #region Help logic

    private void aboutToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {
      new AboutForm()
        .ShowDialog();
    }
    private void commandLineArgumentsToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void vacWebsiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {
      string url = "https://vac.muzychenko.net";
      UrlRedirectHelper.GoToSite(url);
    }

    private void websiteToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
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
      EventArgs e
    )
    {

    }

    private void windowsToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    private void windowToolStripMenuItem_Click
    (
      object sender,
      EventArgs e
    )
    {

    }

    #endregion
  }
}
