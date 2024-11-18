using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
  public class DeviceRepository : IDeviceRepository, INotifyPropertyChanged
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
      uint id = 0;

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

            if (id == uint.MaxValue)
            {
              return;
            }

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

    private uint GetNewId()
    {
      uint id = 0;

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

    private uint GetNewId(uint? id)
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

      return (uint)id;
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

      Debug.WriteLine
      (
        string.Format
        (
          "PropertyChanged: '{1}'" +
          propertyName
        )
      );
    }

    /// <summary>
    /// Get the device.
    /// </summary>
    /// <param name="actualId">the actual device ID</param>
    /// <returns>The device to get.</returns>
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
    /// Get the device.
    /// </summary>
    /// <param name="id">the device ID</param>
    /// <returns>The device to get.</returns>
    public DeviceModel Get(uint? id)
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

    /// <summary>
    /// Get a device list.
    /// </summary>
    /// <param name="actualIdList">the list of actual device IDs</param>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetRange(List<string> actualIdList)
    {
      if
      (
        deviceModelHashSet is null
        || actualIdList is null
        || actualIdList.Count() == 0
      )
      {
        return new List<DeviceModel>();
      }

      List<DeviceModel> deviceModelList = new List<DeviceModel>();

      actualIdList
        .ForEach
        (
          x =>
          {
            DeviceModel deviceModel = Get(x);

            if (deviceModel != null)
            {
              deviceModelList
                .Add(deviceModel);
            }
          }
        );

      return deviceModelList;
    }

    /// <summary>
    /// Get a device list.
    /// </summary>
    /// <param name="idList">the list of device IDs</param>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetRange(List<uint?> idList)
    {
      if
      (
        deviceModelHashSet is null
        || idList is null
        || idList.Count() == 0
      )
      {
        return new List<DeviceModel>();
      }

      List<DeviceModel> deviceModelList = new List<DeviceModel>();

      idList
        .ForEach
        (
          x =>
          {
            DeviceModel deviceModel = Get(x);

            if (deviceModel != null)
            {
              deviceModelList
                .Add(deviceModel);
            }
          }
        );

      return deviceModelList;
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
      if (deviceModelHashSet.Count() >= Global.MaxEndpointCount)
      {
        Console.WriteLine
          (
            string.Format
            (
              "Cancelled device addition. " +
              "Device list amount will exceed maximum amount of {1}.",
              Global.MaxEndpointCount
            )
          );

        return;
      }

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

    public void Remove(uint? id)
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

    /// <summary>
    /// Update the device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="actualId">The actual device ID</param>
    /// <param name="name">The actual device name</param>
    /// <param name="isInput">True/false is the device</param>
    /// <param name="isOutput"></param>
    /// <param name="isPresent"></param>
    public void Update
    (
      uint? id,
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

    /// <summary>
    /// Update the device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="mMDevice">The actual device</param>
    public void Update
    (
      uint? id,
      MMDevice mMDevice
    )
    {
      if
      (
        mMDevice is null
      )
      {
        return;
      }

      Update
      (
        id,
        mMDevice.ID,
        mMDevice.FriendlyName,
        mMDevice.DataFlow == DataFlow.Capture,
        mMDevice.DataFlow == DataFlow.Render,
        IsPresent(mMDevice.State)
      );
    }

    #endregion
  }
}