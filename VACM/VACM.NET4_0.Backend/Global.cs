using System;

namespace VACM.NET4_0.Backend
{
  /*
   * TODO:
   * - add flags to toggle behavior.
   */

  public class Global
  {
    #region Parameters

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

        return VACMaxVirtualEndpointCount;
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
    public readonly static uint VACMaxVirtualEndpointCount = 256;

    /// <summary>
    /// Maximum amount of endpoints (audio devices) for Windows 5.x and older.
    /// </summary>
    public readonly static uint WindowsNT5MaxEndpointCount = 32;

    #endregion
  }
}
