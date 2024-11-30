using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace AudioRepeaterManager.NET2_0.Backend
{
  /// <summary>
  /// Global parameters
  /// </summary>
  public class Global
  {
    #region Parameters

    #region Application name

    public readonly static string ReferencedApplicationName = "Virtual Audio Cable";
    public readonly static string ReferencedFileExtension = ".vac";

    #endregion

    #region Executable path names

    /// <summary>
    /// The name of the executable.
    /// </summary>
    private readonly static string executableName = "audiorepeater.exe";

    /// <summary>
    /// Typically "C:\Program Files\Virtual Audio Cable\audiorepeater.exe".
    /// </summary>
    private static string executablePathNameForBitMatchedProcessAndSystem =
      $"{systemRootPathName}Program Files\\{firstParentPathNameForExecutable}";

    /// <summary>
    /// Typically "C:\Program Files (x86)\Virtual Audio Cable\audiorepeater.exe".
    /// </summary>
    private static string executablePathNameForBitUnmatchedProcessAndSystem =
      $"{systemRootPathName}Program Files (x86)\\{firstParentPathNameForExecutable}";

    /// <summary>
    /// Typically "Virtual Audio Cable\audiorepeater.exe".
    /// </summary>
    private readonly static string firstParentPathNameForExecutable =
      $"{ReferencedApplicationName}\\{executableName}";

    /// <summary>
    /// Typically "C:\".
    /// </summary>
    private static string systemRootPathName = Path.GetPathRoot
      (
        Environment.GetFolderPath
        (
          Environment.SpecialFolder.System
        )
      );

    private static bool doesProcessAndSystemBitMatch =
      is64BitProcess == is64BitOperatingSystem;

    /// <summary>
    /// The expected executable full path name.
    /// </summary>
    public static string ExpectedExecutableFullPathName
    {
      get
      {
        if (doesProcessAndSystemBitMatch)
        {
          return executablePathNameForBitMatchedProcessAndSystem;
        }

        return executablePathNameForBitUnmatchedProcessAndSystem;
      }
    }

    /// <summary>
    /// Does audio repeater executable exist.
    /// </summary>
    public static bool DoesExecutableExist
    {
      get
      {
        return File.Exists(ExpectedExecutableFullPathName);
      }
    }

    #endregion

    #region Limitations

    public static bool DoIgnoreSafeMaxRepeaterCount = false;

    /// <summary>
    /// Limit the maximum amount of endpoints (audio devices).
    /// Note: Windows NT 6.x and newer does not have a maximum amount of endpoints.
    /// </summary>
    public static uint MaxEndpointCount
    {
      get
      {
        if (Environment.OSVersion.Version.Major < 6)
        {
          return WindowsNT5MaxEndpointCount;
        }

        return AudioRepeaterManageraxVirtualEndpointCount;
      }
    }

    /// <summary>
    /// Limit the maximum amount of repeaters (pairs of audio devices).
    /// </summary>
    public static uint MaxRepeaterCount
    {
      get
      {
        if (DoIgnoreSafeMaxRepeaterCount)
        {
          return uint.MaxValue;
        }

        return SafeMaxRepeaterCount;
      }
    }

    /// <summary>
    /// Arbitrary maximum amount of repeaters.
    /// </summary>
    public readonly static uint SafeMaxRepeaterCount = 1024;

    /// <summary>
    /// Maximum amount of virtual endpoints (virtual audio cables) for VAC.
    /// </summary>
    public readonly static uint AudioRepeaterManageraxVirtualEndpointCount = 256;

    /// <summary>
    /// Maximum amount of endpoints (audio devices) for Windows 5.x and older.
    /// </summary>
    public readonly static uint WindowsNT5MaxEndpointCount = 32;

    #endregion

    #endregion

    #region Environment

    /// <summary>
    /// True/false is 64-bit operating system.
    /// </summary>
    private static bool is64BitOperatingSystem
    {
      get
      {
        return is64BitProcess
          || IsWoW64Application();
      }
    }

    /// <summary>
    /// True/false is 64-bit process.
    /// </summary>
    private static bool is64BitProcess
    {
      get
      {
        return IntPtr.Size == 8;
      }
    }

    /// <summary>
    /// Is application currently running on the Windows 32-bit on Windows 64-bit
    /// (WoW64) subsystem.
    /// </summary>
    /// <returns>True/false if application is running in WoW64.</returns>
    public static bool IsWoW64Application()
    {
      if
      (
        (
          Environment.OSVersion.Version.Major == 5
          && Environment.OSVersion.Version.Minor >= 1
        ) || Environment.OSVersion.Version.Major >= 6)
      {
        using (Process p = Process.GetCurrentProcess())
        {
          bool returnValue;

          if (
            !IsWoW64Process
            (
              p.Handle,
              out returnValue
            )
          )
          {
            return false;
          }

          return returnValue;
        }
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Is process currently runnning on the Windows 32-bit on Windows 64-bit
    /// (WoW64) subsystem.
    /// </summary>
    /// <param name="hProcess">The process handle</param>
    /// <param name="wow64Process">True/false is a WoW64 process</param>
    /// <returns></returns>
    [DllImport
      (
        "kernel32.dll",
        SetLastError = true,
        CallingConvention = CallingConvention.Winapi
      )
    ]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWoW64Process
    (
      [In] IntPtr hProcess,
      [Out] out bool wow64Process
    );

    #endregion
  }
}
