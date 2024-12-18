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

    private readonly int maxHeight = 187;

    #endregion

    #region Presentation Logic

    /// <summary>
    /// The constructor.
    /// </summary>
    public DeviceFindForm()
    {
      PreInitializeComponent();
      InitializeComponent();
      PostInitializeComponent();
    }

    private void PostInitializeComponent()
    {
      SetComponentsAbilityProperties();
      this.Refresh();
    }
    private void PreInitializeComponent()
    {
      SetFormMaxSize();
    }

    private void SetComponentsAbilityProperties()
    {
      areDeviceFindArrowButtonsEnabled = true;
    }

    private void SetFormMaxSize()
    {
      this.MaximumSize = new Size(Int32.MaxValue, maxHeight);
    }

    #endregion

    #region Find logic

    private void deviceFindForm_Load(object sender, EventArgs eventArgsventArgs)
    {

    }

    private void deviceFindCloseButton_Click(object sender, EventArgs eventArgs)
    {
      Close();
    }

    private void deviceFindComboBox_SelectedIndexChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindCountButton_Click(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindDirectionArrowCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {
      areDeviceFindArrowButtonsEnabled = !areDeviceFindArrowButtonsEnabled;
    }

    private void deviceFindEnabledCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindInputCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindNextArrowButton_Click(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindNextButton_Click(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindOutputCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindInSelectionCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindPresentCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
    {

    }

    private void deviceFindPreviousArrowButton_Click(object sender, EventArgs eventArgs)
    {

    }

    #endregion
  }
}
