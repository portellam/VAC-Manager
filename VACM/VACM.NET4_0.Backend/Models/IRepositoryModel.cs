using System.Collections.Generic;
using VACM.NET4_0.Backend.Structs;

namespace VACM.NET4_0.Backend.Models
{
  public interface IRepositoryModel
  {
    int Id { get; set; }
    byte BitsPerSample { get; set; }
    byte BufferAmount { get; set; }
    byte ChannelCount { get; set; }
    byte PrefillPercentage { get; set; }
    byte ResyncAtPercentage { get; set; }
    List<Channel> ChannelList { get; set; }
    List<string> PropertyList { get; set; }
    string InputDeviceName { get; set; }
    string OutputDeviceName { get; set; }
    string PathName { get; set; }
    string WindowName { get; set; }
    uint ChannelMask { get; set; }
    uint SampleRateKHz { get; set; }
    ushort BufferDurationMs { get; set; }
  }
}