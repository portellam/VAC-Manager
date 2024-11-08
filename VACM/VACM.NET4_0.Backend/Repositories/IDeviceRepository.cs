using NAudio.CoreAudioApi;
using System.Collections.Generic;
using System.ComponentModel;
using VACM.NET4_0.Backend.Models;

namespace VACM.NET4_0.Backend.Repositories
{
  public interface IDeviceRepository
  {
    bool InsertActual(DeviceModel deviceModel);
    bool RemoveActual(DeviceModel deviceModel);
    bool UpdateActual(DeviceModel deviceModel);
    DeviceModel Get(string actualId);
    DeviceModel Get(int deviceModelId);
    event PropertyChangedEventHandler PropertyChanged;
    IEnumerable<DeviceModel> DeviceModelIEnumerable { get; set; }
    IEnumerable<DeviceModel> GetAllAbsent();
    IEnumerable<DeviceModel> GetAll();
    IEnumerable<DeviceModel> GetAllInput();
    IEnumerable<DeviceModel> GetAllOutput();
    IEnumerable<DeviceModel> GetAllPresent();
    IEnumerable<DeviceModel> GetAllSelected();
    MMDevice GetActual(string actualId);
    IEnumerable<MMDevice> GetActualRange(List<string> actualIdList);
    void DisableActual(string actualId);
    void EnableActual(string actualId);
    
    void Insert
    (
      int Id,
      string actualId,
      string name,
      bool isInput,
      bool isOutput,
      bool? isPresent
    );

    void Remove
    (
      int Id
    );

    void Remove
    (
      string actualId
    );

    void Remove
    (
      int Id,
      string actualId
    );

    void Update
    (
      int Id,
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );
  }
}
