using NAudio.CoreAudioApi;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using VACM.NET4_0.Backend.Structs;

namespace VACM.NET4_0.Backend.Models
{
  public class DeviceModel
  {
    #region Parameters

    private bool isInput;
    private bool isOutput;
    private bool isPresent;
    private bool isSelected;
    private string name;

    public string Id { get; private set; }

    public bool IsInput
    {
      get
      {
        return isInput;
      }
      set
      {
        isInput = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public bool IsOutput
    {
      get
      {
        return isOutput;
      }
      set
      {
        isOutput = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public bool IsPresent
    {
      get
      {
        return isPresent;
      }
      set
      {
        isPresent = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public bool IsSelected
    {
      get
      {
        return isSelected;
      }
      set
      {
        isSelected = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    /// <summary>
    /// The present device state.
    /// </summary>
    private DeviceState Present =
      DeviceState.Active
      | DeviceState.Unplugged
      | DeviceState.Disabled;

    #endregion

    #region Logic

    /// <summary>
    /// Abstract of the actual audio device.
    /// </summary>
    /// <param name="mMDevice">The actual device</param>
    /// <param name="isSelected">True/false is the device selected</param>
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
    /// Abstract of the actual audio device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="name">The device name</param>
    /// <param name="deviceState">The device state</param>
    /// <param name="dataFlow">The device dataflow</param>
    /// <param name="isSelected">True/false is the device selected</param>
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

    /// <summary>
    /// Logs event when property has changed.
    /// </summary>
    /// <param name="propertyName">The property name</param>
    private void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke
        (
          this, 
          new PropertyChangedEventArgs(propertyName)
        );
    }

    /// <summary>
    /// Set the device dataflow
    /// </summary>
    /// <param name="dataFlow">The device data flow</param>
    private void SetDataFlow(DataFlow dataFlow)
    {
      IsInput = DataFlow.Capture == dataFlow;
      IsOutput = DataFlow.Render == dataFlow;

      if (dataFlow != DataFlow.All)
      {
        return;
      }

      IsInput = true;
      IsOutput = true;
    }

    /// <summary>
    /// Toggle the device presence.
    /// </summary>
    public void ToggleIsPresent()
    {
      IsPresent = !IsPresent;
    }

    /// <summary>
    /// Toggle the device selection.
    /// </summary>
    public void ToggleIsSelected()
    {
      IsSelected = !IsSelected;
    }

    #endregion
  }
}