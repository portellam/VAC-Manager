using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VACM.NET4_0.Backend.Controllers
{
  public interface IDeviceController
  {

    void Insert(MMDevice mMDevice);

    void Insert
    (
      string actualId,
      string name,
      bool? isInput,
      bool? isOutput,
      bool? isPresent
    );
    void Remove(int? id);

    void Remove(string actualId);

    void Update
    (
      int? id,
      MMDevice mMDevice
    );
  }
}
