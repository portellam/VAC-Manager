using System.Diagnostics.CodeAnalysis;
using VACM.NET4_0.Models;
using VACM.NET4_0.ViewModels;

namespace VACM.NET4_0.Controllers
{
  public class RepeaterController
  {
    private RepeaterModel RepeaterModel;
    private RepeaterViewModel RepeaterViewModel;
    //TODO: add repeater repository?

    /// <summary>
    /// Controller
    /// </summary>
    /// <param name="repeaterModel"></param>
    /// <param name="repeaterViewModel"></param>
    [ExcludeFromCodeCoverage]
    public RepeaterController
      (
        RepeaterModel repeaterModel,
        RepeaterViewModel repeaterViewModel
      )
    {
      RepeaterModel = repeaterModel;
      RepeaterViewModel = repeaterViewModel;
    }

    /// <summary>
    /// Add the repeater.
    /// </summary>
    /// <param name="doStartRepeater">True/false start the repeater</param>
    public void AddRepeater(bool doStartRepeater)
    {
      // add repeater to repository
      // add repeater to view
      // start repeater
    }

    /// <summary>
    /// Delete the repeater.
    /// </summary>
    /// <param name="doStopRepeater">True/false stop the repeater</param>
    public void DeleteRepeater(bool doStopRepeater)
    {
      // stop repeater
      // remove repeater from view
      // remove repeater from repository
    }

    /// <summary>
    /// Restart the repeater.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public byte RestartRepeater()
    {
      if (this.StopRepeater() != 0
        || this.StartRepeater() != 0)
      {
        return 1;
      }

      return 0;
    }

    /// <summary>
    /// Start the repeater.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public byte StartRepeater()
    {
      // try to start repeater.
      // verify if repeater is started.
      // async?

      return 1;
    }

    /// <summary>
    /// Stop the repeater.
    /// </summary>
    /// <returns>0 if successful, 1 if failed.</returns>
    public byte StopRepeater()
    {
      // try to stop repeater.
      // verify if repeater is stopped.
      // async?

      return 1;
    }

    /// <summary>
    /// Update the repeater.
    /// </summary>
    /// <param name="doStopRepeater">True/false stop the repeater</param>
    public void UpdateRepeater(bool doStopRepeater)
    {
      // update repeater in repository
      // update repeater in view
      // restart repeater
    }
  }
}
