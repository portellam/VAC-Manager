namespace AudioRepeaterManager.NET8_0.GUI.Forms
{
  public partial class DeviceFindForm : Form
  {
    #region Parameters

    private bool areDeviceFindArrowButtonsEnabled
    {
      get
      {
        return deviceFindDirectionArrowCheckBox.Checked;
      }

      set
      {
        if ((bool?)value is null)
        {
          return;
        }

        deviceFindNextArrowButton.Visible = !value;
        deviceFindNextButton.Visible = value;
        deviceFindPreviousArrowButton.Visible = !value;
      }
    }

    #endregion

    #region Presentation Logic

    /// <summary>
    /// The constructor.
    /// </summary>
    public DeviceFindForm()
    {
      InitializeComponent();
      PostInitializeComponent();
    }

    private void PostInitializeComponent()
    {
      SetComponentsAbilityProperties();
      this.Refresh();
    }

    private void SetComponentsAbilityProperties()
    {
      areDeviceFindArrowButtonsEnabled = true;
    }

    #endregion

    #region Find logic

    private void deviceFindForm_Load(object sender, EventArgs e)
    {

    }

    private void deviceFindCloseButton_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void deviceFindComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindCountButton_Click(object sender, EventArgs e)
    {

    }

    private void deviceFindDirectionArrowCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      areDeviceFindArrowButtonsEnabled = !areDeviceFindArrowButtonsEnabled;
    }

    private void deviceFindEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindInputCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindNextArrowButton_Click(object sender, EventArgs e)
    {

    }

    private void deviceFindNextButton_Click(object sender, EventArgs e)
    {

    }

    private void deviceFindOutputCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindInSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindPresentCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void deviceFindPreviousArrowButton_Click(object sender, EventArgs e)
    {

    }

    #endregion
  }
}
