using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.ComponentModel;
using AudioRepeaterManager.NET4_0.Backend.Models;

namespace AudioRepeaterManager.NET4_0.Backend.Repositories
{
  public interface IDeviceRepository
  {
    #region Parameters

    event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Logic

    DeviceModel Get(string actualId);
    DeviceModel Get(uint? id);
    List<DeviceModel> GetAll();
    List<DeviceModel> GetAllAbsent();
    List<DeviceModel> GetAllDuplex();
    List<DeviceModel> GetAllInput();
    List<DeviceModel> GetAllOutput();
    List<DeviceModel> GetAllPresent();
    List<DeviceModel> GetRange(List<string> actualIdList);
    List<DeviceModel> GetRange(List<uint?> idList);
    void Insert(DeviceModel deviceModel);
    void Insert(MMDevice mMDevice);

    void Insert
    (
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );

    void Remove(uint? Id);
    void Remove(string actualId);
    void RemoveRange(string name);
    void Update(DeviceModel deviceModel);

    void Update
    (
      uint id,
      MMDevice mMDevice
    );

    void Update
    (
      uint id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );

    #endregion
  }
}
