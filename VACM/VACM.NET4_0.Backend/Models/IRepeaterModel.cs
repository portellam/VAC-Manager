using System.Collections.Generic;
using VACM.NET4_0.Backend.Structs;

namespace VACM.NET4_0.Backend.Models
{
  public interface IRepeaterModel
  {
    #region Parameters

    /// <summary>
    /// Primary key
    /// </summary>
    uint Id { get; set; }

    /// <summary>
    /// Foreign key
    /// </summary>
    uint InputDeviceId { get; set; }

    /// <summary>
    /// Foreign key
    /// </summary>
    uint OutputDeviceId { get; set; }

    byte BitsPerSample { get; set; }
    byte BufferAmount { get; set; }
    byte ChannelCount { get; }
    byte PrefillPercentage { get; set; }
    byte ResyncAtPercentage { get; set; }
    List<Channel> ChannelList { get; set; }
    string InputDeviceName { get; set; }
    string OutputDeviceName { get; set; }
    string PathName { get; set; }
    string WindowName { get; set; }
    uint ChannelMask { get; set; }
    uint SampleRateKHz { get; set; }
    ushort BufferDurationMs { get; set; }

    #endregion

    #region Logic

    void Deconstruct
    (
      out uint id,
      out uint inputDeviceId,
      out uint outputDeviceId,
      out byte bitsPerSample,
      out byte bufferAmount,
      out ushort bufferDurationMs,
      out List<Channel> channelList,
      out uint channelMask,
      out string pathName,
      out byte prefillPercentage,
      out List<string> propertyList,
      out byte resyncAtPercentage,
      out uint sampleRateKHz,
      out string windowName
    );

    string ToCommand();
    string ToString();
    void Set(List<string> infoList);

    #endregion
  }
}