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
  public class DeviceRepository :
    IDeviceRepository,
    INotifyPropertyChanged
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
    /// The next valid device ID.
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
                x.ID,
                x.FriendlyName,
                x.DataFlow == DataFlow.Capture,
                x.DataFlow == DataFlow.Render,
                IsPresent(x.State)
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

    /// <summary>
    /// Construct a device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="mMDevice"></param>
    /// <returns></returns>
    private DeviceModel Construct
    (
      uint id,
      MMDevice mMDevice
    )
    {
      return new DeviceModel
      (
        id,
        x.ID,
        x.FriendlyName,
        x.DataFlow == DataFlow.Capture,
        x.DataFlow == DataFlow.Render,
        IsPresent(x.State)
      );
    }

    /// <summary>
    /// Is present.
    /// </summary>
    /// <param name="deviceState">The device state</param>
    /// <returns>True/false is the device present.</returns>
    private bool IsPresent(DeviceState deviceState)
    {
      return deviceState == DeviceState.Active
        || deviceState == DeviceState.Disabled
        || deviceState == DeviceState.Unplugged;
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
        Debug.WriteLine("Failed to update actual device. Device is null.");
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
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to insert device. Device already exists\t=> Id: '{1}'",
            deviceModel.Id
          )
        );

        return;
      }

      deviceModel = new DeviceModel
        (
          NextId,
          actualId,
          name,
          isInput,
          isOutput,
          isPresent
        );

      if (!DeviceModelHashSet.Add(deviceModel))
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to insert device\t=> Id: '{1}'",
            deviceModel.Id
          )
        );

        return;
      }

      Debug.WriteLine
        (
          string.Format
          (
            "Inserted device\t=> Id: '{1}'",
            deviceModel.Id
          )
        );
    }

    /// <summary>
    /// Remove a device.
    /// </summary>
    /// <param name="id">The device ID</param>
    public void Remove(uint? id)
    {
      if (id is null)
      {
        Debug.WriteLine("Failed to remove device. Device ID is null.");
        return;
      }

      int count = DeviceModelHashSet
        .RemoveWhere(x => x.Id == id);

      if (count == 0)
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to remove device. Device does not exist\t=> Id: '{1}'",
            id
          )
        );

        return;
      }

      Debug.WriteLine
      (
        string.Format
        (
          "Removed device\t=> Id: '{1}'",
          id
        )
      );
    }

    /// <summary>
    /// Remove device(s).
    /// </summary>
    /// <param name="actualId">The actual device ID</param>
    public void Remove(string actualId)
    {
      if (string.IsNullOrWhiteSpace(actualId))
      {
        Debug.WriteLine
        (
          "Failed to remove device. " +
          "Actual device ID is null or whitespace."
        );

        return;
      }

      int count = DeviceModelHashSet
        .RemoveWhere(x => x.ActualId == actualId);

      if (count == 0)
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to remove device. Device does not exist\t=> ActualId: '{1}'",
            actualId
          )
        );

        return;
      }

      Debug.WriteLine
      (
        string.Format
        (
          "Removed device(s)\t=> Count: '{1}'",
          count
        )
      );
    }

    /// <summary>
    /// Remove a list of devices.
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

      if (count == 0)
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to remove device. Name does not exist\t=> Name: '{1}'",
            name
          )
        );

        return;
      }

      Debug.WriteLine
      (
        string.Format
        (
          "Removed device(s)\t=> Count: '{1}'",
          count
        )
      );
    }

    /// <summary>
    /// Update a device.
    /// </summary>
    /// <param name="deviceModel">The device</param>
    public void Update(DeviceModel deviceModel)
    {
      if (deviceModel is null)
      {
        Debug.WriteLine("Failed to update device. Device is null.");
        return;
      }

      if
      (
        DeviceModelHashSet
          .RemoveWhere
          (x => x.Id == deviceModel.Id) == 0
      )
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to update device. Device does not exist\t=> Id: '{1}'",
            deviceModel.Id
          )
        );

        return;
      }

      if (!DeviceModelHashSet.Add(deviceModel))
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to update device\t=> Id: '{1}'",
            deviceModel.Id
          )
        );

        return;
      }

      Debug.WriteLine
      (
        string.Format
        (
          "Updated device\t=> Id: '{1}'",
          deviceModel.Id
        )
      );
    }

    /// <summary>
    /// Update a device.
    /// </summary>
    /// <param name="id">The device ID</param>
    /// <param name="mMDevice">The actual device</param>
    public void Update
    (
      uint id,
      MMDevice mMDevice
    )
    {
      if
      (
        mMDevice is null
      )
      {
        Debug.WriteLine
        (
          string.Format
          (
            "Failed to update device. Actual device is null\t=> Id: '{1}'",
            id
          )
        );
        return;
      }

      DeviceModel deviceModel = new DeviceModel
      (
        id,
        mMDevice.ID,
        mMDevice.FriendlyName,
        mMDevice.DataFlow == DataFlow.Capture,
        mMDevice.DataFlow == DataFlow.Render,
        IsPresent(mMDevice.State)
      );

      Update(deviceModel);
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
      uint id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    )
    {
      DeviceModel deviceModel = new DeviceModel
        (
          id,
          actualId,
          name,
          isInput,
          isOutput,
          isPresent
        );

      Update(deviceModel);
    }

    #endregion
  }
}