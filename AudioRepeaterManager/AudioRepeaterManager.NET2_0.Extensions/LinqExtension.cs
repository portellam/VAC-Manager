using System;
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
    /// <param name="keyValue">The key value</param>
    /// <returns>The number of elements removed from the list.</returns>
    public static int RemoveAll
    (
      List<object> list,
      object keyValue
    )
    {
      if (list == null)
      {
        throw new NullReferenceException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int count = 0;

      if (list.Count == 0)
      {
        return count;
      }

      foreach (var item in list)
      {
        if (item == keyValue)
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
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns></returns>
    public static int RemoveAll
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list == null
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new NullReferenceException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int count = 0;

      if (list.Count == 0)
      {
        return count;
      }

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
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
    /// <param name="keyValue">The key value</param>
    /// <returns>
    /// A list whose elements are the result of invoking the transform
    /// function on each element of the source.
    /// </returns>
    public static List<object> Select
    (
      List<object> list,
      object keyValue
    )
    {
      if (list == null)
      {
        throw new NullReferenceException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      List<object> newList = null;

      if (list.Count == 0)
      {
        return newList;
      }

      foreach (var item in list)
      {
        if (item == keyValue)
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
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns>
    /// A list whose elements are the result of invoking the transform
    /// function on each element of the source.
    /// </returns>
    public static List<object> Select
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list == null
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new NullReferenceException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      List<object> newList = null;

      if (list.Count == 0)
      {
        return newList;
      }

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
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
    /// <returns>The value at thefirst position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object First(List<object> list)
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
    /// Return the first element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <returns>The value at thefirst position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object First
    (
      List<object> list,
      object keyValue
    )
    {
      if
      (
        list is null
        || list.Count == 0
      )
      {
        throw new ArgumentNullException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      foreach (var item in list)
      {
        if (item == keyValue)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Return the first element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns>The value at thefirst position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object First
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list is null
        || list.Count == 0
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new ArgumentNullException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Return the first element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the first element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object FirstOrDefault(List<object> list)
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
    /// Return the first element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the first element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object FirstOrDefault
    (
      List<object> list,
      object keyValue
    )
    {
      if (list is null)
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      foreach (var item in list)
      {
        if (item == keyValue)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Return the first element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the first element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object FirstOrDefault
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list is null
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
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
    /// <returns>The value at thelast position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object Last(List<object> list)
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
    /// Return the last element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <returns>The value at thelast position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object Last
    (
      List<object> list,
      object keyValue
    )
    {
      if
      (
        list is null
        || list.Count == 0
      )
      {
        throw new ArgumentNullException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int lastIndex = list.Count + 1;

      for (int i = lastIndex; i >= 0; i--)
      {
        var item = list[i];

        if (item == keyValue)
        {
          return item;
        }
      }

      throw new ArgumentNullException();
    }

    /// <summary>
    /// Return the last element of a sequence.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns>The value at thelast position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object Last
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list is null
        || list.Count == 0
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new ArgumentNullException();
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int lastIndex = list.Count + 1;

      for (int i = lastIndex; i >= 0; i--)
      {
        var item = list[i];

        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
        {
          return item;
        }
      }

      throw new ArgumentNullException();
    }

    /// <summary>
    /// Return the last element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the last element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static object LastOrDefault(List<object> list)
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

    /// <summary>
    /// Return the last element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the last element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object LastOrDefault
    (
      List<object> list,
      object keyValue
    )
    {
      if (list is null)
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int lastIndex = list.Count + 1;

      for (int i = lastIndex; i >= 0; i--)
      {
        var item = list[i];

        if (item == keyValue)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Return the last element of a sequence,
    /// or a default keyValue if the sequence contains no elements.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyValue">The key value</param>
    /// <param name="keyName">The key name</param>
    /// <returns>
    /// Null if the source sequence is empty;
    /// otherwise, the last element in the sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static object LastOrDefault
    (
      List<object> list,
      object keyValue,
      string keyName
    )
    {
      if
      (
        list is null
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return null;
      }

      if (list[0].GetType() != keyValue.GetType())
      {
        throw new InvalidOperationException
          ("List type does not match key type.");
      }

      int lastIndex = list.Count + 1;

      for (int i = lastIndex; i >= 0; i--)
      {
        var item = list[i];

        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if (itemkeyValue == keyValue)
        {
          return item;
        }
      }

      return null;
    }

    /// <summary>
    /// Sorts the elements in sequence in ascending order according to a key.
    /// </summary>
    /// <param name="list">The sequence</param>
    /// <param name="keyName">The key name</param>
    /// <returns>A list whose elements are sorted by a key.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static List<object> OrderBy
    (
      List<object> list,
      string keyName
    )
    {
      if
      (
        list is null
        || StringExtension.IsNullOrWhiteSpace(keyName)
      )
      {
        throw new ArgumentNullException();
      }

      if (list.Count == 0)
      {
        return list;
      }

      List<object> propertyList = new List<object>();

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(keyName);

        object itemkeyValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        propertyList.Add(itemkeyValue);
      }

      propertyList.Sort();
      var newList = list;

      for (int i = 0; i < propertyList.Count; i++)
      {
        newList[i] = list[i];
      }

      return newList;
    }
  }
}