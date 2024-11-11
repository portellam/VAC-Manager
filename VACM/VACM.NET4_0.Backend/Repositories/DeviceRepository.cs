using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.ComponentModel;
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
  public class DeviceRepository : IDeviceRepository
  {
    #region Parameters

    /// <summary>
    /// The collection of devices.
    /// </summary>
    private HashSet<DeviceModel> deviceModelHashSet;

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Logic

    /// <summary>
    /// Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    public DeviceRepository(List<MMDevice> mMDeviceList)
    {
      deviceModelHashSet = new HashSet<DeviceModel>();
      int id = 0;

      mMDeviceList
        .ForEach
        (
          x =>
          {
            DeviceModel deviceModel =
              new DeviceModel
              (
                id,
                x
              );

            deviceModelHashSet
              .Add(deviceModel);

            id++;
          }
        );
    }

    private bool IsPresent(DeviceState deviceState)
    {
      return
        deviceState == DeviceState.Active
        || deviceState == DeviceState.Disabled
        || deviceState == DeviceState.Unplugged;
    }

    private int GetNewId()
    {
      int id = 0;

      deviceModelHashSet
        .ToList()
        .ForEach
        (
          x =>
          {
            if (x.Id > id)
            {
              id = x.Id;
            }
          }
        );

      id++;
      return id;
    }

    private int GetNewId(int? id)
    {
      if
      (
        id is null
        || id < 0
        || deviceModelHashSet
          .Any(x => x.Id == id)
      )
      {
        return GetNewId();
      }

      return (int)id;
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
    public DeviceModel Get(int? id)
    {
      if
      (
        id is null
        || id < 0
      )
      {
        return null;
      }

      return
        deviceModelHashSet
          .FirstOrDefault(x => x.Id == id);
    }
    public DeviceModel Get(string actualId)
    {
      if (string.IsNullOrWhiteSpace(actualId))
      {
        return null;
      }

      return
        deviceModelHashSet
          .FirstOrDefault(x => x.ActualId == actualId);
    }

    /// <summary>
    /// Get the device list.
    /// </summary>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetAll()
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
    /// Get the absent device list.
    /// </summary>
    /// <returns>The absent device list.</returns>
    public List<DeviceModel> GetAllAbsent()
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
    /// Get the input device list.
    /// </summary>
    /// <returns>The input device list.</returns>
    public List<DeviceModel> GetAllInput()
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
    public List<DeviceModel> GetAllOutput()
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
    public List<DeviceModel> GetAllPresent()
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

    public void Insert(MMDevice mMDevice)
    {
      if (mMDevice is null)
      {
        return;
      }

      Insert
      (
        mMDevice.ID,
        mMDevice.FriendlyName,
        mMDevice.DataFlow == DataFlow.Capture,
        mMDevice.DataFlow == DataFlow.Render,
        IsPresent(mMDevice.State)
      );
    }

    public void Insert
    (
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    )
    {
      DeviceModel deviceModel = Get(actualId);

      if (deviceModel != null)
      {
        return;
      }

      deviceModel = new DeviceModel
        (
          GetNewId(),
          actualId,
          name,
          isInput,
          isOutput,
          isPresent
        );

      deviceModelHashSet
        .Add(deviceModel);
    }

    public void Remove(int? id)
    {
      if
      (
        id is null
        || id < 0
      )
      {
        return;
      }

      deviceModelHashSet
        .RemoveWhere(x => x.Id == id);
    }

    public void Remove(string actualId)
    {
      if (string.IsNullOrWhiteSpace(actualId))
      {
        return;
      }

      deviceModelHashSet
        .RemoveWhere(x => x.ActualId == actualId);
    }

    public void Update
    (
      int? id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    )
    {
      DeviceModel deviceModel = Get(actualId);

      if (deviceModel is null)
      {
        return;
      }

      deviceModel = new DeviceModel
        (
          GetNewId(id),
          actualId,
          name,
          isInput,
          isOutput,
          isPresent
        );
    }

    #endregion
  }
}