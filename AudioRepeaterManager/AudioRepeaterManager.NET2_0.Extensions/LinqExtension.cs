using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace AudioRepeaterManager.NET2_0.Extensions
{
  public static class LinqExtension
  {
    /// <summary>
    /// Remove all elements that match the conditions defined by the specified
    /// predicate.
    /// </summary>
    /// <param name="list">The list</param>
    /// <param name="valueToMatch">The value to match</param>
    /// <returns>The number of elements removed from the list.</returns>
    public static int RemoveAll
    (
      ref IList list,
      object valueToMatch
    )
    {
      if
      (
        list == null
        || list.Count == 0
      )
      {
        return 0;
      }

      int count = 0;

      foreach(var item in list)
      {
        if (item == valueToMatch)
        {
          list.Remove(item);
          count++;
        }
      }

      return count;
    }

    /// <summary>
    /// Remove all elements that match the conditions defined by the specified
    /// predicate.
    /// </summary>
    /// <param name="list">The list</param>
    /// <param name="valueToMatch">The value to match</param>
    /// <param name="propertyName">The property name</param>
    /// <returns></returns>
    public static int RemoveAll
    (
      ref IList list,
      object valueToMatch,
      string propertyName
    )
    {
      if
      (
        list == null
        || list.Count == 0
      )
      {
        return 0;
      }

      int count = 0;

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(propertyName);

        object itemValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemValue == valueToMatch)
        {
          list.Remove(item);
          count++;
        }
      }

      return count;
    }

    /// <summary>
    /// Projects the element of a sequence into a new form.
    /// </summary>
    /// <param name="list">The list</param>
    /// <param name="valueToMatch">The value to match</param>
    /// <returns>
    /// A list whose elements are the result of invoking the transform
    /// function on each element of the source.
    /// </returns>
    public static List<object> Select
    (
      IList list,
      object valueToMatch
    )
    {
      if
      (
        list == null
        || list.Count == 0
      )
      {
        return null;
      }

      List<object> newList = null;

      foreach (var item in list)
      {
        if (item == valueToMatch)
        {
          newList.Add(item);
        }
      }

      return newList;
    }

    /// <summary>
    /// Projects the element of a sequence into a new form.
    /// </summary>
    /// <param name="list">The list</param>
    /// <param name="valueToMatch">The value to match</param>
    /// <param name="propertyName">The property name</param>
    /// <returns>
    /// A list whose elements are the result of invoking the transform
    /// function on each element of the source.
    /// </returns>
    public static List<object> Select
    (
      IList list,
      object valueToMatch,
      string propertyName
    )
    {
      if
      (
        list == null
        || list.Count == 0
      )
      {
        return null;
      }

      List<object> newList = null;

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(propertyName);

        object itemValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemValue == valueToMatch)
        {
          newList.Add(item);
        }
      }

      return newList;
    }

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