using AudioSwitcher.AudioApi.CoreAudio;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace VACM.NET4_0.Backend.Repositories
{
  public class MMDeviceRepository :
    IMMDeviceRepository,
    INotifyPropertyChanged
  {
    #region Parameters

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// The list of actual devices.
    /// </summary>
    private List<MMDevice> MMDeviceList;

    /// <summary>
    /// The enumerator of actual devices.
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
      coreAudioController = new CoreAudioController();
      mMDeviceEnumerator = new MMDeviceEnumerator();
      Update();
    }

    /// <summary>
    /// Disable an actual device.
    /// </summary>
    /// <param name="mMDevice">the actual device</param>
    private void Disable(MMDevice mMDevice)
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

      Console
        .WriteLine
        (
          string
          .Format
          (
            "Audio '{1}' device disabled.",
            mMDevice.FriendlyName
          )
        );


      mMDevice
        .AudioClient
        .Reset();

      Console
        .WriteLine
        ("Reset audio devices.");

      mMDevice
        .AudioSessionManager
        .RefreshSessions();

      Console
        .WriteLine
        ("Refreshed audio devices.");
    }

    /// <summary>
    /// Enable an actual device.
    /// </summary>
    /// <param name="mMDevice">the actual device</param>
    private void Enable(MMDevice mMDevice)
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

      Console
        .WriteLine
        (
          string
          .Format
          (
            "Audio '{1}' device enabled.",
            mMDevice.FriendlyName
          )
        );

      mMDevice
        .AudioSessionManager
        .RefreshSessions();

      Console
        .WriteLine
        ("Refreshed audio devices.");
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

    /// <summary>
    /// Get an actual device.
    /// </summary>
    /// <param name="id">the actual device ID</param>
    /// <returns>The actual device.</returns>
    public MMDevice Get(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        return null;
      }

      return MMDeviceList
        .FirstOrDefault(x => x.ID == id);
    }

    /// <summary>
    /// Get the list of actual devices.
    /// </summary>
    /// <returns>The list of actual devices.</returns>
    public List<MMDevice> GetAll()
    {
      if
      (
        MMDeviceList is null
        || MMDeviceList.Count == 0
      )
      {
        return new List<MMDevice>();
      }

      return MMDeviceList;
    }

    /// <summary>
    /// Get a list of actual devices.
    /// </summary>
    /// <param name="idList">the actual device ID list</param>
    /// <returns>A list of actual devices.</returns>
    public List<MMDevice> GetRange(List<string> idList)
    {
      if
      (
        idList is null
        || idList.Count == 0
        || MMDeviceList is null
        || MMDeviceList.Count == 0
      )
      {
        return null;
      }

      List<MMDevice> mMDeviceList = new List<MMDevice>();

      idList
        .ForEach
        (
          id =>
          mMDeviceList
            .Add(Get(id))
        );

      return mMDeviceList;
    }

    /// <summary>
    /// Disable an actual device.
    /// </summary>
    /// <param name="id">the actual device ID</param>
    public void Disable(string id)
    {
      MMDevice mMDevice = Get(id);
      Disable(mMDevice);
    }

    /// <summary>
    /// Enable an actual device.
    /// </summary>
    /// <param name="id">the actual device ID</param>
    public void Enable(string id)
    {
      MMDevice mMDevice = Get(id);
      Enable(mMDevice);
    }

    /// <summary>
    /// Set the actual device as default (for its dataflow).
    /// </summary>
    /// <param name="id">the actual device ID</param>
    public void SetAsDefault(string id)   //TODO: implement!
    {
      MMDevice mMDevice = Get(id);

      if (mMDevice is null)
      {
        return;
      }

      CoreAudioDevice coreAudioDevice = coreAudioController
        .GetAudioDevice
        (
          Guid.Parse(id)
        );

      coreAudioDevice.SetAsDefault(); //TODO: make as async?
    }

    /// <summary>
    /// Set the actual device list.
    /// </summary>
    public void Update()
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

      Console
        .WriteLine
        ("Updated audio devices.");
    }

    #endregion
  }
}