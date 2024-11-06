using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Linq;

namespace VACM.NET4_0.Models
{
  public class DeviceDictModel
  {
    #region Parameters
    private List<MMDevice> MMDeviceList { get; set; }

    public List<DeviceModel> DeviceList { get; private set; }

    public Dictionary<string, string> PresentWaveInDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsInput && x.IsPresent)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );

      }
    }

    public Dictionary<string, string> PresentWaveOutDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsOutput && x.IsPresent)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );

      }
    }

    public Dictionary<string, string> SelectedWaveInDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsInput && x.IsSelected)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );

      }
    }

    public Dictionary<string, string> SelectedWaveOutDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsOutput && x.IsSelected)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );

      }
    }

    public Dictionary<string, string> WaveInDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsInput)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );

      }
    }

    public Dictionary<string, string> WaveOutDeviceList
    {
      get
      {
        return DeviceList
          .Where(x => x.IsOutput)
          .ToDictionary
          (
            x => x.Id,
            x => x.Name
          );
      }
    }
    #endregion

    #region Logic
    public DeviceDictModel()
    {
      SetMMDeviceList();

      if(MMDeviceList.Count == 0)
      {
        return;
      }

      bool isSelected = false;
      DeviceList = new List<DeviceModel>();

      MMDeviceList
        .ForEach(x => DeviceList
          .Add
          (
            new DeviceModel
            (
              x,
              isSelected
            )
          )
        );
    }
    
    public void SetMMDeviceList()
    {
      MMDeviceList = new MMDeviceEnumerator()
        .EnumerateAudioEndPoints
        (
          DataFlow.All,
          DeviceState.All
        )
        .Distinct()
        .OrderBy(x => x.ID)
        .ToList();
    }
    #endregion
  }
}