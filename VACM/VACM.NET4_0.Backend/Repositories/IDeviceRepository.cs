using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.ComponentModel;
using VACM.NET4_0.Backend.Models;

namespace VACM.NET4_0.Backend.Repositories
{
  public interface IDeviceRepository
  {
    #region Parameters

    event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Logic

    DeviceModel Get(string actualId);
    DeviceModel Get(int? id);
    List<DeviceModel> GetAllAbsent();
    List<DeviceModel> GetAll();
    List<DeviceModel> GetAllInput();
    List<DeviceModel> GetAllOutput();
    List<DeviceModel> GetAllPresent();
    void Insert(MMDevice mMDevice);

    void Insert
    (
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );

    void Remove
    (
      int? Id
    );

    void Remove
    (
      string actualId
    );

    void Update
    (
      int? id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );

    #endregion
  }
}
