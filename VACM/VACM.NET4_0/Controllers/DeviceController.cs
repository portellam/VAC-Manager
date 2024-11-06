using System.Diagnostics.CodeAnalysis;
using VACM.NET4_0.Models;
using VACM.NET4_0.Repositories;

namespace VACM.NET4_0.Controllers
{
  public class DeviceController
  {
    private DeviceModel DeviceModel;
    private DeviceRepository DeviceRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deviceModel"></param>
    [ExcludeFromCodeCoverage]
    public DeviceController(DeviceModel deviceModel)
    {
      DeviceModel = deviceModel;
    }

    /// <summary>
    /// Add the device.
    /// </summary>
    public void AddDevice()
    {
      // add device to repository.
    }

    /// <summary>
    /// Delete the device.
    /// </summary>
    public void DeleteDevice()
    {
      // delete device from repository.
    }

    /// <summary>
    /// Disable the device.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public byte DisableDevice()
    {
      // try to disable device.
      // verify if device is disabled.
      // async?

      return 1;
    }

    /// <summary>
    /// Enable the device.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public byte EnableDevice()
    {
      // try to enable device.
      // verify if device is enabled.
      // async?

      return 1;
    }

    /// <summary>
    /// Update the device.
    /// </summary>
    public void UpdateDevice()
    {
      // update device in repository.
    }
  }
}
