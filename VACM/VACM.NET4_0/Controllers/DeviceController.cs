using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VACM.NET4_0.Library.Models;

namespace VACM.NET4_0.Library.Controllers
{
  public class DeviceController
  {
    #region Parameters
    private DeviceModel DeviceModel;
    private DeviceViewModel DeviceViewModel;
    #endregion

    #region Logic
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="deviceModel">The device model</param>
    /// <param name="deviceModel">The device view model</param>
    [ExcludeFromCodeCoverage]
    public DeviceController(DeviceModel deviceModel, DeviceViewModel deviceViewModel)
    {
      DeviceModel = deviceModel;
      DeviceViewModel = deviceViewModel;
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
    public async Task<byte> DisableDevice()
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
    public async Task<byte> EnableDevice()
    {
      // try to enable device.
      // verify if device is enabled.
      // async?

      return 1;
    }

    /// <summary>
    /// Update the device.
    /// </summary>
    /// <param name="isPresent">True/False is device present</param>
    public void UpdateDevice(bool isPresent)
    {
      // update device in repository.
    }
    #endregion
  }
}