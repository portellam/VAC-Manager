using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using VACM.NET4_0.Models;

namespace VACM.NET4_0.Repositories
{
  public class RepeaterRepository
  {
    #region Parameters
    /// <summary>
    /// The collection of repeaters.
    /// </summary>
    private HashSet<RepeaterModel> RepeaterModelHashSet;
    #endregion

    #region Logic
    /// <summary>
    /// Constructor
    /// </summary>
    [ExcludeFromCodeCoverage]
    public RepeaterRepository()
    {
      RepeaterModelHashSet = new HashSet<RepeaterModel>();
    }

    /// <summary>
    /// Add repeater.
    /// </summary>
    /// <param name="repeaterModel">The repeater to add</param>
    /// <returns>True/false if repeater is added</returns>
    public bool AddRepeater(RepeaterModel RepeaterModel)
    {
      if (RepeaterModel is null)
      {
        return false;
      }

      RepeaterModel actualRepeaterModel = GetRepeater(RepeaterModel.Id);

      if (
        actualRepeaterModel != null
        || ! RepeaterModelHashSet
          .Add(RepeaterModel)
        )
      {
        return false;
      }

      return true;
    }

    /// <summary>
    /// Delete repeater.
    /// </summary>
    /// <param name="repeaterModel">The repeater to delete</param>
    /// <returns>True/false delete a repeater</returns>
    public bool DeleteRepeater(RepeaterModel RepeaterModel)
    {
      if (RepeaterModel is null)
      {
        return false;
      }

      RepeaterModel actualRepeaterModel = GetRepeater(RepeaterModel.Id);

      if (
        actualRepeaterModel is null
        || ! RepeaterModelHashSet
          .Remove(actualRepeaterModel)
        )
      {
        return false;
      }

      return true;
    }

    /// <summary>
    /// Get repeater by ID.
    /// </summary>
    /// <param name="id">the repeater ID</param>
    /// <returns>The repeater.</returns>
    public RepeaterModel GetRepeater(int? id)
    {
      if (
        id is null
        || id < 0
      )
      {
        return null;
      }

      return RepeaterModelHashSet
        .FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Update repeater.
    /// </summary>
    /// <param name="repeaterModel">The repeater to update.</param>
    /// <returns>True/false if the repeater is updated.</returns>
    public bool UpdateRepeater(RepeaterModel RepeaterModel)
    {
      if (RepeaterModel is null)
      {
        return false;
      }

      RepeaterModel actualRepeaterModel = GetRepeater(RepeaterModel.Id);

      if (
        actualRepeaterModel is null
        || ! RepeaterModelHashSet
          .Remove(actualRepeaterModel)
        || ! RepeaterModelHashSet
          .Add(RepeaterModel)
        )
      {
        return false;
      }

      return true;
    }
    #endregion
  }
}