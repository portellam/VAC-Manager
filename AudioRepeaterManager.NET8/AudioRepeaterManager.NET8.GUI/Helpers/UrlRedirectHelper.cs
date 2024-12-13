using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AudioRepeaterManager.NET8.GUI.Helpers
{
  public class UrlRedirectHelper
  {
    /// <summary>
    /// Opens a URL in the default browser of the system.
    /// </summary>
    /// <param name="url">The URL</param>
    public static void GoToSite(string url)
    {
      if (string.IsNullOrWhiteSpace(url))
      {
        Debug.WriteLine("Failed open URL in browser. URL is null or whitespace.");
        return;
      }

      try
      {
        Process.Start(url);

        Debug.WriteLine
        (
          string.Format
          (
            "Trying to open URL in browser: '{1}'",
            url
          )
        );
      }

      catch
      {
        // hack because of this: https://github.com/dotnet/corefx/issues/10361
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
          url = url.Replace
            (
              "&",
              "^&"
            );

          Process.Start
            (
              new ProcessStartInfo(url)
              {
                UseShellExecute = true
              }
            );
        }

        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
          Process.Start
            (
              "xdg-open",
              url
            );
        }

        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
          Process.Start
            (
              "open",
              url
            );
        }

        else
        {
          Debug.WriteLine("Failed open URL in browser.");
          throw;
        }

        Debug.WriteLine("Opened URL in browser.");
      }
    }
  }
}