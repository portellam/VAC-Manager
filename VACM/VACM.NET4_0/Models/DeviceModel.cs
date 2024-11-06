using NAudio.CoreAudioApi;
using System.Diagnostics.CodeAnalysis;

namespace VACM.NET4_0.Models
{
  public class DeviceModel
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

    #region Logic

    /// <summary>
    /// Constructors
    /// </summary>
    /// <param name="mMDevice"></param>
    /// <param name="isSelected"></param>
    [ExcludeFromCodeCoverage]
    public DeviceModel
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

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="deviceState"></param>
    /// <param name="dataFlow"></param>
    /// <param name="isSelected"></param>
    [ExcludeFromCodeCoverage]
    public DeviceModel
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
    #endregion
  }
}