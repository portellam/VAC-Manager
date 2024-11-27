using System;
using System.Collections;

namespace AudioRepeaterManager.NET2_0.Backend
{
  public class LinqExtension
  {
    /// <summary>
    /// Returns the first element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <param name="type">The enumerable type argument to match</param>
    /// <returns>
    /// Throw exception if source is empty;
    /// otherwise, the first element in source
    /// </returns>
    public object First
    (
      IEnumerable enumerable,
      Type type
    )
    {
      if
      (
        enumerable == null
        || type == null
      )
      {
        throw new ArgumentNullException();
      }

      foreach (var item in enumerable)
      {
        if (item.GetType() != type)
        {
          throw new ArgumentNullException();
        }

        if (item != null)
        {
          return item;
        }
      }

      throw new InvalidOperationException();
    }

    /// <summary>
    /// Returns the first element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <param name="type">The enumerable type argument to match</param>
    /// <returns>
    /// Null if source is empty;
    /// otherwise, the first element in source
    /// </returns>
    public object FirstOrDefault
    (
      IEnumerable enumerable,
      Type type
    )
    {
      if
      (
        enumerable == null
        || type == null
      )
      {
        throw new ArgumentNullException();
      }

      foreach (var item in enumerable)
      {
        if (item.GetType() != type)
        {
          throw new ArgumentNullException();
        }

        if (item != null)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Returns the last element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <param name="type">The enumerable type argument to match</param>
    /// <returns>
    /// Throw exception if source is empty;
    /// otherwise, the last element in source
    /// </returns>
    public object Last
    (
      IEnumerable enumerable,
      Type type
    )
    {
      if
      (
        enumerable == null
        || type == null
      )
      {
        throw new ArgumentNullException();
      }

      int length = (enumerable as IList).Count + 1;

      for (int i = length; i >= 0; i--)
      {
        var item = (enumerable as IList)[i];

        if (item.GetType() != type)
        {
          throw new ArgumentNullException();
        }

        if (item != null)
        {
          return item;
        }
      }

      throw new InvalidOperationException();
    }

    /// <summary>
    /// Returns the last element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable</param>
    /// <param name="type">The enumerable type argument to match</param>
    /// <returns>
    /// Null if source is empty;
    /// otherwise, the last element in source
    /// </returns>
    public object LastOrDefault
    (
      IEnumerable enumerable,
      Type type
    )
    {
      if
      (
        enumerable == null
        || type == null
      )
      {
        throw new ArgumentNullException();
      }

      int length = (enumerable as IList).Count + 1;

      for (int i = length; i >= 0; i--)
      {
        var item = (enumerable as IList)[i];
        
        if (item.GetType() != type)
        {
          throw new ArgumentNullException();
        }

        if (item != null)
        {
          return item;
        }
      }

      return null;
    }
  }
}
