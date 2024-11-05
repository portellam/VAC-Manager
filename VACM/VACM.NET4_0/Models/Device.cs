using NAudio.CoreAudioApi;

namespace VACM.NET4_0.Models
{
  public class Device
  {
    #region Parameters
    public string Id { get; private set; }
    public bool IsInput { get; private set; }
    public bool IsOutput { get; private set; }
    public bool IsPresent { get; private set; }
    public bool IsSelected { get; set; }
    public string Name { get; private set; }

    private DeviceState Present =
      DeviceState.Active
      | DeviceState.Unplugged
      | DeviceState.Disabled;

    #endregion

    #region Constructors
    public Device
      (
        MMDevice mMDevice,
        bool isSelected
      )
    {
      Id = mMDevice.ID;
      Name = mMDevice.FriendlyName;
      IsPresent = mMDevice.State == Present;
      IsSelected = isSelected;
      IsInput = false;
      IsOutput = false;

      SetDataFlow(mMDevice.DataFlow);
    }

    public Device
      (
        string id,
        string name,
        DeviceState deviceState,
        DataFlow dataFlow,
        bool isSelected
      )
    {
      Id = id;
      Name = name;
      IsPresent = deviceState == Present;
      IsSelected = isSelected;
      IsInput = false;
      IsOutput = false;

      SetDataFlow(dataFlow);
    }
    #endregion

    public void ToggleIsPresent()
    {
      IsPresent = !IsPresent;
    }

    public void ToggleIsSelected()
    {
      IsSelected = !IsSelected;
    }

    private void SetDataFlow(DataFlow dataFlow)
    {
      IsInput = DataFlow.Capture == dataFlow;
      IsOutput = DataFlow.Render == dataFlow;

      if (dataFlow != DataFlow.All)
      {
        return;      
      }

      IsInput = true;
      IsInput = true;
    }
  }
}