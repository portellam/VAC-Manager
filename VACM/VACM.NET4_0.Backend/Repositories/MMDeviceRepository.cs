using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace VACM.NET4_0.Backend.Repositories
{
  public class MMDeviceRepository
  {
    #region Parameters

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
    public MMDeviceRepository()
    {
      mMDeviceEnumerator = new MMDeviceEnumerator();

      SetMMDeviceList();
    }

    /// <summary>
    /// Disable MMDevice.
    /// </summary>
    /// <param name="mMDevice">the MMDevice</param>
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
    /// Get MMDevice.
    /// </summary>
    /// <param name="id">the MMDevice ID to get</param>
    /// <returns>The MMDevice.</returns>
    public MMDevice GetMMDevice(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        return null;
      }

      return MMDeviceList
        .FirstOrDefault(x => x.ID == id);
    }

    /// <summary>
    /// Disable MMDevice.
    /// </summary>
    /// <param name="id">the MMDevice ID to disable</param>
    public void DisableDevice(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        return;
      }

      MMDevice mMDevice = GetMMDevice(id);
      DisableMMDevice(mMDevice);
    }

    /// <summary>
    /// Enable MMDevice.
    /// </summary>
    /// <param name="mMDevice">the MMDevice to enable</param>
    private void EnableMMDevice(MMDevice mMDevice)
    {
      if (
          mMDevice is null
          || mMDevice.State != DeviceState.Disabled
        )
      {
        return;
      }

      mMDevice
        .AudioClient
        .Start();

      mMDevice
        .AudioSessionManager
        .RefreshSessions();
    }

    /// <summary>
    /// Enable MMDevice.
    /// </summary>
    /// <param name="id">the MMDevice ID to enable</param>
    public void EnableDevice(string id)
    {
      if (string.IsNullOrEmpty(id))
      {
        return;
      }

      MMDevice mMDevice = GetMMDevice(id);
      EnableMMDevice(mMDevice);
    }

    /// <summary>
    /// Set the MMDevice list.
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