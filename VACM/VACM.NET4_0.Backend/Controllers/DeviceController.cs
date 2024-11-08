using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using VACM.NET4_0.Backend.Repositories;

namespace VACM.NET4_0.Backend.Controllers
{
  public class DeviceController
  {
    #region Parameters

    private DeviceRepository DeviceRepository;

    #endregion

    #region Logic

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="deviceRepository">The device repository</param>
    [ExcludeFromCodeCoverage]
    public DeviceController(DeviceRepository deviceRepository)
    {
      DeviceRepository = deviceRepository;
    }

    /// <summary>
    /// Add the device.
    /// </summary>
    public void AddDevice(string id)
    {
      // add device to repository.
    }

    /// <summary>
    /// Delete the device.
    /// </summary>
    public void DeleteDevice(string id)
    {
      // delete device from repository.
    }

    /// <summary>
    /// Disable the device.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public async Task<byte> DisableDevice(string id)
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
    public async Task<byte> EnableDevice(string id)
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
    public void UpdateDevice(string id, bool isPresent)
    {
      // update device in repository.
    }

    #endregion
  }
}