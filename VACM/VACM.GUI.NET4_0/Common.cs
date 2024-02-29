using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VACM.GUI.NET4_0
{
    public class Common
    {
        #region Application name logic

        public readonly static string ApplicationNameAsAbbreviation = "VACM";

        public readonly static string FileExtension = "." +
            ApplicationNameAsAbbreviation.ToLower();

        public readonly static string ReferencedApplicationName = "Virtual Audio Cable";
        public readonly static string ReferencedFileExtension = ".vac";

        #endregion

        #region Application support logic

        /*
        * NOTES:
        * 
        * VAC Control Panel v4.70 documentation:
        * 
        * [1] https://vac.muzychenko.net/en/manual/features.htm
        * Up to 256 virtual cable devices (some systems limit number of MME devices).
        * 
        * [2] https://vac.muzychenko.net/en/manual/ctlpan.htm#Limitations
        * Windows XP/2003 limit number of MME devices to 32. So MME applications that
        * use waveIn/waveOut functions won't see more than 32 cable endpoints in
        * Windows XP/2003. To use more cables you need either to use DirectSound or
        * WDM/KS interfaces or switch to VAC 3 because it is a legacy MME driver.
        * 
        * Windows 6.x+ systems don't limit number of MME/DirectSound endpoints.
        * 
        * Moreover, creating too many (100 and more) virtual cables may even cause
        * other audio endpoints to disappear. Use this feature with care. 
        * 
        * Assumptions:
        * 
        * One (1) Audio Repeater has one Input and one Output device.
        * 
        * Given [1] a mamximum value of audio devices exist on Windows XP/2003, we will
        * limit the total Audio Repeaters to 32.
        * (32 devices / 2 types) * (2 types / 1 repeater) == 32
        * 
        * Given that a maximum of 256 Virtual Cables may exist, and that a Virtual
        * cable has one input and output, same as an Audio Repeater, we will limit
        * the total number of Audio Repeaters to 256.
        * 
        * Given that 100 or more Virtual Cables can cause slowdown, and that no
        * provided citations regard a limitation of actual audio cables, we will
        * warn the user if 100 or more Audio Repeaters exist.
        * 
        */

        public const byte AudioRepeaterMaxCountForWindowsNT5 = 32;
        public const byte AudioRepeaterMaxCountForWindowsNT6AndAbove = byte.MaxValue;
        public const ushort UserControlMaxCount = ushort.MaxValue;

        public static bool IsWindowsNT5
        {
            get
            {
                return IsWindowsNT && Environment.OSVersion.Version.Major == 5;
            }
        }

        public static bool IsWindowsNT6OrAbove
        {
            get
            {
                return IsWindowsNT && Environment.OSVersion.Version.Major >= 6;
            }
        }

        public static bool IsWindowsNT
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT;
            }
        }

        #endregion Application support logic

    }
}
