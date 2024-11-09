using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using VACM.NET4_0.Backend.Structs;

namespace VACM.NET4_0.Backend.Models
{
  public class DeviceModel : IDeviceModel
  {
    #region Parameters

    private int id;
    private bool? isInput;
    private bool? isOutput;
    private bool? isPresent;
    private string actualId;
    private string name;

    public int Id
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
    /// <param name="actualId">The actual device ID</param>
    /// <param name="name">The device name</param>
    /// <param name="isInput">True/false is an input device</param>
    /// <param name="isOutput">True/false is an output device</param>
    /// <param name="isPresent">True/false is the device present</param>
    [ExcludeFromCodeCoverage]
    public DeviceModel
    (
      int id,
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