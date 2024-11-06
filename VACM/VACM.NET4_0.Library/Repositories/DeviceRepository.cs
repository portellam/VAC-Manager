using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using VACM.NET4_0.Backend.Models;

namespace VACM.NET4_0.Backend.Repositories
{
  public class DeviceRepository
  {
    #region Parameters
    /// <summary>
    /// The collection of devices.
    /// </summary>
    private HashSet<DeviceModel> deviceModelHashSet;

    /// <summary>
    /// The collection of actual devices.
    /// </summary>
    private List<MMDevice> MMDeviceList;
    #endregion

    #region Logic
    /// <summary>
    /// Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    public DeviceRepository()
    {
      deviceModelHashSet = new HashSet<DeviceModel>();
      MMDeviceList = new List<MMDevice>();

      SetMMDeviceList();
      SetDeviceModelHashSet();
    }

    /// <summary>
    /// Add device.
    /// </summary>
    /// <param name="deviceModel">The device to add</param>
    /// <returns>True/false if device is added</returns>
    public bool AddDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDeviceById(deviceModel.Id);

      if (
        actualDeviceModel != null
        || ! deviceModelHashSet
          .Add(deviceModel)
        )
      {
        return false;
      }

      return true;
    }

    /// <summary>
    /// Delete device.
    /// </summary>
    /// <param name="deviceModel">The device to delete</param>
    /// <returns>True/false delete a device</returns>
    public bool DeleteDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDeviceById(deviceModel.Id);

      if (
        actualDeviceModel is null
        || ! deviceModelHashSet
          .Remove(actualDeviceModel)
        )
      {
        return false;
      }

      return true;
    }

    /// <summary>
    /// Get the absent device list.
    /// </summary>
    /// <returns>The absent device list.</returns>
    public List<DeviceModel> GetAbsentDeviceList()
    {
      if (deviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .Where(x => ! x.IsPresent)
          .ToList();
    }

    /// <summary>
    /// Get device by name.
    /// </summary>
    /// <param name="name">the device name</param>
    /// <returns>The device.</returns>
    public DeviceModel GetDeviceByName(string name)
    {
      if (
        name is null
        || name == string.Empty
      )
      {
        return null;
      }

      return deviceModelHashSet
        .FirstOrDefault(x => x.Name == name);
    }

    /// <summary>
    /// Get device by ID.
    /// </summary>
    /// <param name="id">the device ID</param>
    /// <returns>The device.</returns>
    public DeviceModel GetDeviceById(string id)
    {
      if (
        id is null
        || id == string.Empty
      )
      {
        return null;
      }

      return deviceModelHashSet
        .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Get the device list.
    /// </summary>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetDeviceList()
    {
      if (deviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .ToList();
    }

    /// <summary>
    /// Get the device list by name.
    /// </summary>
    /// <param name="name">The device(s) name(s).</param>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetDeviceList(string name)
    {
      if (
        deviceModelHashSet is null
        || name is null
        || name == string.Empty
        )
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .Where(x => x.Name
            .ToLower()
            .Contains(name.ToLower()))
          .ToList();
    }

    /// <summary>
    /// Get the input device list.
    /// </summary>
    /// <returns>The input device list.</returns>
    public List<DeviceModel> GetInputDeviceList()
    {
      if (deviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .Where(x => x.IsInput)
          .ToList();
    }

    /// <summary>
    /// Get the output device list.
    /// </summary>
    /// <returns>The output device list.</returns>
    public List<DeviceModel> GetOutputDeviceList()
    {
      if (deviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .Where(x => x.IsOutput)
          .ToList();
    }

    /// <summary>
    /// Get the present device list.
    /// </summary>
    /// <returns>The present device list.</returns>
    public List<DeviceModel> GetPresentDeviceList()
    {
      if (deviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        deviceModelHashSet
          .Where(x => x.IsPresent)
          .ToList();
    }

    /// <summary>
    /// Update device.
    /// </summary>
    /// <param name="deviceModel">The device to update.</param>
    /// <returns>True/false if the device is updated.</returns>
    public bool UpdateDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDeviceById(deviceModel.Id);

      if (
        actualDeviceModel is null
        || ! deviceModelHashSet
          .Remove(actualDeviceModel)
        || ! deviceModelHashSet
          .Add(deviceModel)
        )
      {
        return false;
      }

      return true;
    }

    /// <summary>
    /// Set the device model hash set.
    /// </summary>
    public void SetDeviceModelHashSet()
    {
      if (MMDeviceList.Count == 0)
      {
        return;
      }

      bool isSelected = false;

      MMDeviceList
        .ForEach(x =>
          deviceModelHashSet
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

    /// <summary>
    /// Set the actual device list.
    /// </summary>
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