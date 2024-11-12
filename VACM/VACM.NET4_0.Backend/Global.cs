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

    /// <summary>
    /// Limit the number of endpoints (audio devices).
    /// Note: Windows NT 6.x and newer does not have a maximum number of endpoints.
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
    /// Maximum amount of virtual endpoints (virtual audio cables) for VAC.
    /// </summary>
    public static uint VACMaxVirtualEndpointCount
    {
      get
      {
        return 256;
      }
    }

    /// <summary>
    /// Maximum amount of endpoints (audio devices) for Windows 5.x and older.
    /// </summary>
    public static uint WindowsNT5MaxEndpointCount
    {
      get
      {
        return 32;
      }
    }


    #endregion
  }
}
