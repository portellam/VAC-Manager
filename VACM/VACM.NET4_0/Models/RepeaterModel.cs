using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using VACM.NET4_0.Library.Structs;

namespace VACM.NET4_0.Library.Models
{
  public class RepeaterModel : INotifyPropertyChanged
  {
    /*
     * NEW TODO:
     * -remove DeviceControl references, use Device model.
     *  -why? To make this class independent of ViewModel logic.
     *  -idea is to reduce parsing of bloated objects and params.
     * 
     * OLD TODO:
     * -add logic to determine lesser property value between Input and output,
     *      and set max value to that.
     * -parse the VAC manual and reference it for this app README and popups.
     * -review the manual to create recommended values and new drop downs
     *      (process priority).
     * -as normal create graph file and data file. Also, create bat script and
     * task for windows task manager. Also update said task or remove it.
     *      Educate user.
     *      Create icon to save and run task or pause and delete it.
     * -fix audio crackle, recommended settings?
     * -allow repeaters to run without GUI or warn to leave open or close repeaters
     *      after exit of GUI.
     */

    #region Parameters
    public int Id { get; private set; }

    private byte bitsPerSample;
    private byte buffers;
    private byte prefill;
    private byte resyncAt;
    private ChannelConfig channelConfig;
    private string pathName;
    private string windowName;
    private uint samplingRate;
    private ushort bufferMs;

    public byte defaultBitsPerSample = BitsPerSampleOptions[2];
    public byte defaultBufferAmount = BufferOptions[2];
    public byte defaultPrefillPercentage = PrefillOptions[2];
    public byte defaultResyncAtPercentage = ResyncAtOptions[3];
    public string defaultPathName = Common.ExpectedExecutableFullPath;
    public string defaultWindowName = "{0} to {1}";
    public uint defaultSamplingRateKHz = SamplingRateOptions[5];
    public ushort defaultBufferDurationMs = BufferMsOptions[2];

    public ChannelConfig ChannelConfig
    {
      get
      {
        return channelConfig;
      }
      set
      {
        if (value != ChannelConfig.Custom)
        {
          ChannelMask = (uint)value;
        }

        channelConfig = value;

        OnPropertyChanged(nameof(ChannelConfig));
      }
    }

    public IEnumerable<ChannelConfig> ChannelConfigEnum
    {
      get
      {
        return Enum.GetValues(typeof(ChannelConfig))
            .Cast<ChannelConfig>();
      }
    }

    public DeviceModel InputDeviceModel { get; private set; }
    public DeviceModel OutputDeviceModel { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// The amount of bits per sample.
    /// </summary>
    public byte BitsPerSample
    {
      get
      {
        return bitsPerSample;
      }
      set
      {
        if (value >= 8
            && value <= 32)
        {
          bitsPerSample = value;
        }
        else
        {
          bitsPerSample = 16;
        }

        OnPropertyChanged(nameof(BitsPerSample));
      }
    }

    /// <summary>
    /// The amount of short-term data particles.
    /// </summary>
    public byte BufferAmount
    {
      get
      {
        return buffers;
      }
      set
      {
        if (value >= 1
            && value <= byte.MaxValue)
        {
          buffers = value;
        }
        else
        {
          buffers = 8;
        }

        OnPropertyChanged(nameof(BufferAmount));
      }
    }

    /// <summary>
    /// The amount of channels.
    /// </summary>
    public byte ChannelCount
    {
      get
      {
        if (ChannelList is null)
        {
          return 0;
        }

        return (byte)ChannelList.Count;
      }
    }

    /// <summary>
    /// The queue prefill percentage of a buffer size.
    /// Specify the amount of the queue to prefill the buffer.
    /// </summary>
    public byte PrefillPercentage
    {
      get
      {
        return prefill;
      }
      set
      {
        if (value >= PrefillOptions.FirstOrDefault()
            && value <= PrefillOptions.Last())
        {
          prefill = value;
        }
        else
        {
          prefill = 50;
        }

        OnPropertyChanged(nameof(PrefillPercentage));
      }
    }

    /// <summary>
    /// The resync at percentage of a buffer size.
    /// Specify the amount of the queue to resynchronize the buffer.
    /// </summary>
    public byte ResyncAtPercentage
    {
      get
      {
        return resyncAt;
      }
      set
      {
        if (value >= 0
            && value < prefill)
        {
          resyncAt = value;
        }
        else
        {
          resyncAt = (byte)Math.Round((double)(prefill / 2));
        }

        OnPropertyChanged(nameof(ResyncAtPercentage));
      }
    }

    /// <summary>
    /// The individual Channels available to the repeater, given the Channel layout.
    /// </summary>
    public List<Channel> ChannelList;

    /// <summary>
    /// The input devices's display name.
    /// </summary>
    public string Input
    {
      get
      {
        if (InputDeviceModel.Name.Length > 31)
        {
          return InputDeviceModel.Name.Substring(0, 31);
        }

        return InputDeviceModel.Name;
      }
    }

    /// <summary>
    /// The output device's display name.
    /// </summary>
    public string Output
    {
      get
      {
        if (InputDeviceModel.Name.Length > 31)
        {
          return InputDeviceModel.Name.Substring(0, 31);
        }

        return InputDeviceModel.Name;
      }
    }

    /// <summary>
    /// The file pathname.
    /// </summary>
    public string PathName
    {
      get
      {
        return pathName;
      }
      set
      {
        if (!File.Exists(value))
        {
          return;
        }

        pathName = value;
        OnPropertyChanged(nameof(PathName));
      }
    }

    /// <summary>
    /// The window name.
    /// </summary>
    public string WindowName
    {
      get
      {
        return windowName;
      }
      set
      {
        windowName = value.Replace("{0}", Input).Replace("{1}", Output);
        OnPropertyChanged(nameof(WindowName));
      }
    }

    /// <summary>
    /// The mask of the current configuration of Channels.
    /// </summary>
    public uint ChannelMask
    {
      get
      {
        uint sum = 0;

        ChannelList.ForEach(channel
            => sum += (uint)channel);

        return sum;
      }
      set
      {
        if (value < 0)
        {
          value = 0;
        }

        value &= 0x7FF;

        if (channelConfig != ChannelConfig.Custom)
        {
          channelConfig = ChannelConfig.Custom;
          OnPropertyChanged(nameof(ChannelConfig));
        }

        uint bit = 1;
        List<Channel> newChannels = new List<Channel>();

        while (value != 0)
        {
          uint digit = value & bit;

          if (digit > 0)
          {
            newChannels.Add(
                (Channel)digit);
          }

          value -= digit;
          bit <<= 1;
        }

        ChannelList = newChannels;
        OnPropertyChanged(nameof(ChannelMask));
      }
    }

    /// <summary>
    /// The sampling rate in KiloHertz.
    /// </summary>
    public uint SamplingRateKHz
    {
      get
      {
        return samplingRate;
      }
      set
      {
        if (value >= SamplingRateOptions.FirstOrDefault()
            && value <= SamplingRateOptions.Last())
        {
          samplingRate = value;
        }
        else
        {
          samplingRate = 48000;
        }

        OnPropertyChanged(nameof(SamplingRateKHz));
      }
    }

    /// <summary>
    /// The buffer time in milliseconds.
    /// </summary>
    public ushort BufferDurationMs
    {
      get
      {
        return bufferMs;
      }
      set
      {
        if (value >= 1
            && value <= ushort.MaxValue)
        {
          bufferMs = value;
        }
        else
        {
          bufferMs = 500;
        }

        OnPropertyChanged(nameof(BufferDurationMs));
      }
    }

    /// <summary>
    /// List of relevant properties.
    /// </summary>
    public readonly List<string> PropertyList = new List<string>()
      {
        nameof(BitsPerSample),
        nameof(BufferAmount),
        nameof(BufferDurationMs),
        nameof(ChannelConfig),
        nameof(ChannelMask),
        nameof(PrefillPercentage),
        nameof(ResyncAtPercentage),
        nameof(SamplingRateKHz)
      };

    /// <summary>
    /// Available choices for BitsPerSample.
    /// </summary>
    public static ReadOnlyCollection<byte> BitsPerSampleOptions =
      new ReadOnlyCollection<byte>
      (
        new byte[]
        {
          8,
          16,
          18,
          20,
          22,
          24,
          32
        }
      );

    /// <summary>
    /// Available choices for Buffer.
    /// </summary>
    public static ReadOnlyCollection<byte> BufferOptions =
      new ReadOnlyCollection<byte>
      (
        new byte[]
        {
          2,
          4,
          8,
          12,
          16,
          20,
          24,
          32
        }
      );

    /// <summary>
    /// Available choices for Prefill percentage.
    /// </summary>
    public static ReadOnlyCollection<byte> PrefillOptions =
      new ReadOnlyCollection<byte>
      (
        new byte[]
        {
          0,
          20,
          50,
          70,
          100
        }
      );

    /// <summary>
    /// Available choices for ResyncAt percentage.
    /// </summary>
    public static ReadOnlyCollection<byte> ResyncAtOptions =
      new ReadOnlyCollection<byte>(
        new byte[]
        {
          0,
          10,
          15,
          20,
          25,
          30,
          40,
          50
        }
      );

    /// <summary>
    /// Available choices for Sampling rate in KiloHertz.
    /// </summary>
    public static ReadOnlyCollection<uint> SamplingRateOptions =
      new ReadOnlyCollection<uint>(
        new uint[]
        {
          5000,
          8000,
          11025,
          22050,
          44100,
          48000,
          96000,
          192000
        }
      );

    /// <summary>
    /// Available choices for Buffer time in milliseconds.
    /// </summary>
    public static ReadOnlyCollection<ushort> BufferMsOptions =
      new ReadOnlyCollection<ushort>
      (
        new ushort[]
        {
          20,
          50,
          100,
          200,
          400,
          800,
          1000,
          2000,
          4000,
          8000
        }
      );

    #endregion

    #region Logic
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="inputDeviceModel">The input device model</param>
    /// <param name="outputDeviceModel">The output device model</param>
    [ExcludeFromCodeCoverage]
    public RepeaterModel
      (
        DeviceModel inputDeviceModel,
        DeviceModel outputDeviceModel
      )
    {
      BitsPerSample = defaultBitsPerSample;
      BufferDurationMs = defaultBufferDurationMs;
      BufferAmount = defaultBufferAmount;
      ChannelConfig = channelConfig;
      InputDeviceModel = inputDeviceModel;
      OutputDeviceModel = outputDeviceModel;
      PathName = defaultPathName;
      PrefillPercentage = defaultPrefillPercentage;
      ResyncAtPercentage = defaultResyncAtPercentage;
      SamplingRateKHz = defaultSamplingRateKHz;
      WindowName = defaultWindowName;
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

    /// <summary>
    /// Compiles a terminal command, to create and start an audio repeater.
    /// Also, use in batch script.
    /// </summary>
    /// <returns>The terminal command</returns>
    public string ToCommand()
    {
      return
        $"start " +
        $"/min \"audiorepeater\" \"{PathName}\" " +
        $"/Input:\"{Input}\" " +
        $"/Output:\"{Output}\" " +
        $"/SamplingRate:{SamplingRateKHz} " +
        $"/BitsPerSample:{BitsPerSample} " +
        $"/Channels:{ChannelList.Count} " +
        $"/ChanCfg:custom={ChannelMask} " +
        $"/BufferMs:{BufferDurationMs} " +
        $"/Prefill:{PrefillPercentage} " +
        $"/ResyncAt:{ResyncAtPercentage} " +
        $"/WindowName:\"{WindowName}\" " +
        $"/AutoStart";
    }

    /// <summary>
    /// Compiles output for a canvas graph file.
    /// </summary>
    /// <returns>The output</returns>
    public string ToSaveData()
    {
      return
        $"{SamplingRateKHz}\n" +
        $"{BitsPerSample}\n" +
        $"{ChannelMask}\n" +
        $"{(int)ChannelConfig}\n" +
        $"{BufferDurationMs}\n" +
        $"{BufferAmount}\n" +
        $"{PrefillPercentage}\n" +
        $"{ResyncAtPercentage}";
    }

    /// <summary>
    /// Sets the Constructor properties.
    /// </summary>
    /// <param name="infoList">The info list</param>
    public void SetConstructorProperties(List<string> infoList)
    {
      if (infoList is null)
      {
        return;
      }

      BitsPerSample = byte.Parse(infoList[1]);
      BufferAmount = byte.Parse(infoList[5]);
      BufferDurationMs = ushort.Parse(infoList[4]);
      ChannelConfig = (ChannelConfig)int.Parse(infoList[3]);
      ChannelMask = uint.Parse(infoList[2]);
      PrefillPercentage = byte.Parse(infoList[6]);
      ResyncAtPercentage = byte.Parse(infoList[7]);
      SamplingRateKHz = uint.Parse(infoList[0]);
    }
    #endregion
  }
}