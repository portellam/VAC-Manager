using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using VACM.NET4_0.Backend.Models;

/*
 * TODO:
 * 
 * -organize methods by type, then name, then overrides.
 * -refactor comments
 * -device ability
 * -refer DeviceModel as abstract.
 * -refer MMDevice as actual.
 * 
 */

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
    /// The list of actual devices.
    /// </summary>
    private List<MMDevice> MMDeviceList;

    /// <summary>
    /// The collection of actual devices.
    /// </summary>
    private MMDeviceEnumerator mMDeviceEnumerator;

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
      mMDeviceEnumerator = new MMDeviceEnumerator();

      SetMMDeviceList();
      SetDeviceModelHashSet();
    }

    /// <summary>
    /// Get actual device by abstract device.
    /// </summary>
    /// <param name="deviceModel">the abstract device</param>
    /// <returns>The MMDevice.</returns>
    private MMDevice GetMMDevice(DeviceModel deviceModel)
    {
      DeviceModel actualDeviceModel = GetDeviceById(deviceModel.Id);

      if (actualDeviceModel is null)
      {
        return null;
      }

      return MMDeviceList
        .FirstOrDefault(x => x.ID == actualDeviceModel.Id);
    }

    /// <summary>
    /// Get actual device by ID.
    /// </summary>
    /// <param name="id">the actual device ID</param>
    /// <returns>The MMDevice.</returns>
    private MMDevice GetMMDevice(string id)
    {
      if (
        id is null
        || id == string.Empty
      )
      {
        return null;
      }

      return MMDeviceList
        .FirstOrDefault(x => x.ID == id);
    }

    /// <summary>
    /// Disable actual device.
    /// </summary>
    /// <param name="mMDevice">the actual device</param>
    private void DisableMMDevice(MMDevice mMDevice)
    {
      if (
          mMDevice is null
          || mMDevice.State == DeviceState.Disabled
        )
      {
        return;
      }

      mMDevice
        .AudioClient
        .Stop();

      mMDevice
      .AudioClient
      .Reset();

      mMDevice
        .AudioSessionManager
        .RefreshSessions();
    }

    /// <summary>
    /// Add device.
    /// </summary>
    /// <param name="deviceModel">The device to add</param>
    /// <returns>True/false if device is added.</returns>
    public bool AddDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDeviceById(deviceModel.Id);

      if (
        actualDeviceModel != null
        || !deviceModelHashSet
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
        || !deviceModelHashSet
          .Remove(actualDeviceModel)
        )
      {
        return false;
      }

      return true;
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
        || !deviceModelHashSet
          .Remove(actualDeviceModel)
        || !deviceModelHashSet
          .Add(deviceModel)
        )
      {
        return false;
      }

      return true;
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
          .Where(x => !x.IsPresent)
          .ToList();
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
    /// Disable the device.
    /// </summary>
    /// <param name="deviceModel">the device model</param>
    public void DisableDevice(DeviceModel deviceModel)
    {
      MMDevice mMDevice = GetMMDevice(deviceModel.Id);
      DisableMMDevice(mMDevice);
    }

    /// <summary>
    /// Disable the device.
    /// </summary>
    /// <param name="id">the device id</param>
    public void DisableDevice(string id)
    {
      if (
          id is null
          || id == string.Empty
        )
      {
        return;
      }

      MMDevice mMDevice = GetMMDevice(id);
      DisableMMDevice(mMDevice);
    }

    /// <summary>
    /// Enable the device.
    /// </summary>
    /// <param name="deviceModel">the device model</param>
    public void EnableDevice(DeviceModel deviceModel)
    {
      MMDevice mMDevice = GetMMDevice(deviceModel.Id);

      mMDevice
        .AudioClient
        .Start();

      mMDevice
        .AudioSessionManager
        .RefreshSessions();
    }

    /// <summary>
    /// Enable the device.
    /// </summary>
    /// <param name="deviceModel">the device model</param>
    public void EnableDevice(DeviceModel deviceModel)
    {
      MMDevice mMDevice = GetMMDevice(deviceModel.Id);

      mMDevice
        .AudioClient
        .Start();

      mMDevice
        .AudioSessionManager
        .RefreshSessions();
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
      MMDeviceList = mMDeviceEnumerator
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