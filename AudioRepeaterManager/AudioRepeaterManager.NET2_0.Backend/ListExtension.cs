using System;
using System.Collections;

namespace AudioRepeaterManager.NET2_0.Backend
{
  public static class ListExtension
  {
    /// <summary>
    /// Return the first element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>The value at the first position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object First(IList list)
    {
      if
      (
        list is null
        || list.Count == 0
      )
      {
        throw new ArgumentNullException();
      }

      return list[0];
    }

    /// <summary>
    /// Return the first element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the first element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object FirstOrDefault(IList list)
    {
      if (list is null)
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      foreach (var item in list)
      {
        if (item != null)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Return the last element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>The value at the last position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object Last(IList list)
    {
      if
      (
        list is null
        || list.Count == 0
      )
      {
        throw new ArgumentNullException();
      }

      int lastIndex = list.Count + 1;
      return list[lastIndex];
    }

    /// <summary>
    /// Return the last element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the last element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object LastOrDefault(IList list)
    {
      if (list is null)
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      int lastIndex = list.Count + 1;

      for (int i = lastIndex; i >= 0; i--)
      {
        var item = list[i];

        if (item != null)
        {
          return item;
        }
      }

      return null;
    }
  }
}
