using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using VACM.NET4_0.Models;

namespace VACM.NET4_0.Repositories
{
  public class DeviceRepository
  {
    private HashSet<DeviceModel> deviceModelHashSet;

    [ExcludeFromCodeCoverage]
    public DeviceRepository()
    {
      deviceModelHashSet = new HashSet<DeviceModel>();
    }

    public bool AddDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDevice(deviceModel.Id);

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

    public bool DeleteDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDevice(deviceModel.Id);

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

    public DeviceModel GetDevice(string id)
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

    public List<DeviceModel> GetDeviceListByName(string name)
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

    public bool UpdateDevice(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        return false;
      }

      DeviceModel actualDeviceModel = GetDevice(deviceModel.Id);

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
  }
}
