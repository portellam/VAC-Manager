using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using VACM.NET4_0.Models;

namespace VACM.NET4_0.Repositories
{
  public class RepeaterRepository
  {
    private HashSet<RepeaterModel> RepeaterModelHashSet;

    [ExcludeFromCodeCoverage]
    public RepeaterRepository()
    {
      RepeaterModelHashSet = new HashSet<RepeaterModel>();
    }

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
  }
}