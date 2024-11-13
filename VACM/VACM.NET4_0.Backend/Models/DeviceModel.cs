using NAudio.CoreAudioApi;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using VACM.NET4_0.Backend.Structs;

namespace VACM.NET4_0.Backend.Models
{
  public class DeviceModel : IDeviceModel, INotifyPropertyChanged
  {
    #region Parameters

    private uint id;
    private string actualId;
    private bool? isInput;
    private bool? isOutput;
    private bool? isPresent;
    private string name;

    /// <summary>
    /// Primary Key
    /// </summary>
    public uint Id
    {
      get
      {
        return id;
      }
      set
      {
        id = value;
        OnPropertyChanged(nameof(id));
      }
    }

    /// <summary>
    /// Foreign key
    /// </summary>
    public string ActualId
    {
      get
      {
        return actualId;
      }
      set
      {
        actualId = value;
        OnPropertyChanged(nameof(actualId));
      }
    }

    public bool IsDuplex
    {
      get
      {
        return IsInput == IsOutput;
      }
    }

    public bool IsInput
    {
      get
      {
        return isInput.Value;
      }
      set
      {
        if (isInput is null)
        {
          return;
        }

        isInput = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public bool IsOutput
    {
      get
      {
        return isOutput.Value;
      }
      set
      {
        if (isOutput is null)
        {
          return;
        }

        isOutput = value;
        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public bool IsPresent
    {
      get
      {
        return isPresent.Value;
      }
      set
      {
        if (isPresent is null)
        {
          return;
        }

        isPresent = value;
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

    #endregion

    #region Logic

    /// <summary>
    /// Abstract of the actual audio device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="mMDevice">The actual device</param>
    [ExcludeFromCodeCoverage]
    public DeviceModel
    (
      uint id,
      MMDevice mMDevice
    )
    {
      Id = id;
      ActualId = mMDevice.ID;
      Name = mMDevice.FriendlyName;
      IsInput = mMDevice.DataFlow == DataFlow.Capture;
      IsOutput =  mMDevice.DataFlow == DataFlow.Capture;
      IsPresent = IsNotAbsent(mMDevice.State);
    }

    /// <summary>
    /// Abstract of the actual audio device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="actualId">The actual device ID</param>
    /// <param name="name">The device name</param>
    /// <param name="isInput">True/false is an input device</param>
    /// <param name="isOutput">True/false is an output device</param>
    /// <param name="isPresent">True/false is the device present</param>
    [ExcludeFromCodeCoverage]
    public DeviceModel
    (
      uint id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    )
    {
      Id = id;
      ActualId = actualId;
      Name = name;
      IsInput = isInput.Value;
      IsOutput = isOutput.Value;
      IsPresent = isPresent.Value;
    }

    /// <summary>
    /// Is present.
    /// </summary>
    /// <param name="deviceState">The device state</param>
    /// <returns>True/false is the device present.</returns>
    private bool IsNotAbsent(DeviceState deviceState)
    {
      return
        deviceState == DeviceState.Active
        || deviceState == DeviceState.Disabled
        || deviceState == DeviceState.Unplugged;
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

    #endregion
  }
}