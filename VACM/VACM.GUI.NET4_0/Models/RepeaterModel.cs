using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using VACM.GUI.NET4_0.Structs;
using VACM.GUI.NET4_0.ViewModels;

namespace VACM.GUI.NET4_0.Models
{
    public class RepeaterModel : INotifyPropertyChanged
    {
        /*
         * TODO:
         * -add constructor, logic.
         * -add params.
         * -add getter logic.
         * 
         */

        #region Parameters

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
        public byte defaultBuffers = BufferOptions[2];
        public byte defaultPrefill = PrefillOptions[2];
        public byte defaultResyncAt = ResyncAtOptions[3];
        public string defaultPathName = Common.ExpectedExecutableFullPath;
        public string defaultWindowName = "{0} to {1}";
        public uint defaultSamplingRate = SamplingRateOptions[5];
        public ushort defaultBufferMs = BufferMsOptions[2];

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

        public DeviceControl InputDeviceControl;
        public DeviceControl OutputDeviceControl;
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
        public byte Buffers
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

                OnPropertyChanged(nameof(Buffers));
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
        public byte Prefill
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

                OnPropertyChanged(nameof(Prefill));
            }
        }

        /// <summary>
        /// The resync at percentage of a buffer size.
        /// Specify the amount of the queue to resynchronize the buffer.
        /// </summary>
        public byte ResyncAt
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

                OnPropertyChanged(nameof(ResyncAt));
            }
        }

        /// <summary>
        /// The UI element representing a link between the Input and Output device.
        /// </summary>
        public Line Link { get; }

        /// <summary>
        /// The individual Channels available to the repeater, given the Channel layout.
        /// </summary>
        public List<Channel> ChannelList;

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
        public uint SamplingRate
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

                OnPropertyChanged(nameof(SamplingRate));
            }
        }

        /// <summary>
        /// The buffer time in milliseconds.
        /// </summary>
        public ushort BufferMs
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

                OnPropertyChanged(nameof(BufferMs));
            }
        }

        /// <summary>
        /// List of relevant properties.
        /// </summary>
        public readonly List<string> PropertyList = new List<string>()
        {
            nameof(BitsPerSample),
            nameof(Buffers),
            nameof(BufferMs),
            nameof(ChannelConfig),
            nameof(ChannelMask),
            nameof(Prefill),
            nameof(ResyncAt),
            nameof(SamplingRate)
        };

        /// <summary>
        /// Available choices for BitsPerSample.
        /// </summary>
        public static ReadOnlyCollection<byte> BitsPerSampleOptions =
            new ReadOnlyCollection<byte>(new byte[] { 8, 16, 18, 20, 22, 24, 32 });

        /// <summary>
        /// Available choices for Buffer.
        /// </summary>
        public static ReadOnlyCollection<byte> BufferOptions =
            new ReadOnlyCollection<byte>(new byte[] { 2, 4, 8, 12, 16, 20, 24, 32 });

        /// <summary>
        /// Available choices for Prefill percentage.
        /// </summary>
        public static ReadOnlyCollection<byte> PrefillOptions =
            new ReadOnlyCollection<byte>(new byte[] { 0, 20, 50, 70, 100 });

        /// <summary>
        /// Available choices for ResyncAt percentage.
        /// </summary>
        public static ReadOnlyCollection<byte> ResyncAtOptions =
            new ReadOnlyCollection<byte>(new byte[] { 0, 10, 15, 20, 25, 30, 40, 50 });

        /// <summary>
        /// Available choices for Sampling rate in KiloHertz.
        /// </summary>
        public static ReadOnlyCollection<uint> SamplingRateOptions =
            new ReadOnlyCollection<uint>(
                new uint[] { 5000, 8000, 11025, 22050, 44100, 48000, 96000, 192000 });

        /// <summary>
        /// Available choices for Buffer time in milliseconds.
        /// </summary>
        public static ReadOnlyCollection<ushort> BufferMsOptions =
            new ReadOnlyCollection<ushort>(
                new ushort[] { 20, 50, 100, 200, 400, 800, 1000, 2000, 4000, 8000 });

        #endregion

        #region Logic

        /// <summary>
		/// Logs event when property has changed.
		/// </summary>
		/// <param name="propertyName">The property name</param>
        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}