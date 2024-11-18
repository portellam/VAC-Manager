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
    private HashSet<DeviceModel> DeviceModelHashSet;

    /// <summary>
    /// The list of device IDs.
    /// </summary>
    private List<uint> IdList
    {
      get
      {
        List<uint> list =
          DeviceModelHashSet
            .Select(x => x.Id)
            .ToList();

        list.Sort();
        return list;
      }
    }

    /// <summary>
    /// The next valid repeater ID.
    /// </summary>
    private uint NextId
    {
      get
      {
        uint id = IdList.LastOrDefault();
        id++;
        return id;
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Logic

    /// <summary>
    /// Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    public DeviceRepository(List<MMDevice> mMDeviceList)
    {
      DeviceModelHashSet = new HashSet<DeviceModel>();
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

            DeviceModelHashSet
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

      DeviceModelHashSet
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
        || DeviceModelHashSet
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
        DeviceModelHashSet
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
        DeviceModelHashSet
          .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Get the device list.
    /// </summary>
    /// <returns>The device list.</returns>
    public List<DeviceModel> GetAll()
    {
      if (DeviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        DeviceModelHashSet
          .ToList();
    }

    /// <summary>
    /// Get the absent device list.
    /// </summary>
    /// <returns>The absent device list.</returns>
    public List<DeviceModel> GetAllAbsent()
    {
      if (DeviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        DeviceModelHashSet
          .Where(x => !x.IsPresent)
          .ToList();
    }

    /// <summary>
    /// Get the input device list.
    /// </summary>
    /// <returns>The input device list.</returns>
    public List<DeviceModel> GetAllInput()
    {
      if (DeviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        DeviceModelHashSet
          .Where(x => x.IsInput)
          .ToList();
    }

    /// <summary>
    /// Get the output device list.
    /// </summary>
    /// <returns>The output device list.</returns>
    public List<DeviceModel> GetAllOutput()
    {
      if (DeviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        DeviceModelHashSet
          .Where(x => x.IsOutput)
          .ToList();
    }

    /// <summary>
    /// Get the present device list.
    /// </summary>
    /// <returns>The present device list.</returns>
    public List<DeviceModel> GetAllPresent()
    {
      if (DeviceModelHashSet is null)
      {
        return new List<DeviceModel>();
      }

      return
        DeviceModelHashSet
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
        DeviceModelHashSet is null
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
        DeviceModelHashSet is null
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
      if (DeviceModelHashSet.Count() >= Global.MaxEndpointCount)
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

      DeviceModelHashSet
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

      DeviceModelHashSet
        .RemoveWhere(x => x.Id == id);
    }

    public void Remove(string actualId)
    {
      if (string.IsNullOrWhiteSpace(actualId))
      {
        return;
      }

      DeviceModelHashSet
        .RemoveWhere(x => x.ActualId == actualId);
    }

    /// <summary>
    /// Remove a list of repeaters.
    /// </summary>
    /// <param name="name">The device name</param>
    public void RemoveRange(string name)
    {
      if (string.IsNullOrWhiteSpace(name))
      {
        Debug.WriteLine
        (
          "Failed to remove device. " +
          "Device name is null or whitespace."
        );

        return;
      }

      int count = DeviceModelHashSet
        .RemoveWhere(x => x.Name == name);

      Debug.WriteLine
      (
        string.Format
        (
          "Removed devices\t=> Count: '{1}'" +
          count
        )
      );
    }

    /// <summary>
    /// Update a device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="actualId">The actual device ID</param>
    /// <param name="name">The actual device name</param>
    /// <param name="isInput">True/false is an input device</param>
    /// <param name="isOutput">True/false is an output device</param>
    /// <param name="isPresent">True/false is the device present</param>
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