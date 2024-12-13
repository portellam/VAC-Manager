using AudioRepeaterManager.NET8.GUI.Helpers;

namespace AudioRepeaterManager.NET8.GUI
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {

    }

    private void toolStripLabel4_Click(object sender, EventArgs e)
    {

    }

    private void deviceToolStripLabel_Click(object sender, EventArgs e)
    {

    }

    private void disableToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void enableToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void selectAllDuplexToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void disableDevicsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void toolStripDropDownButton2_Click(object sender, EventArgs e)
    {

    }

    private void exportToClipboarToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void preferX86Application32bitToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    #region Help view logic

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      new AboutForm()
        .ShowDialog();
    }
    private void commandLineArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void vacWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string url = "https://vac.muzychenko.net";
      UrlRedirectHelper.GoToSite(url);
    }

    private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string url = "https://www.github.com/portellam/vac-audio-repeater-manager";
      UrlRedirectHelper.GoToSite(url);
    }

    #endregion
  }
}
