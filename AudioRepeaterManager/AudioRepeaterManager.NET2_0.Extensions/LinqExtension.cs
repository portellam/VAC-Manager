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
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>The value at the last position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static TSource Last<TSource>(IEnumerable<TSource> source)
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (!(source is IList<TSource> list))
      {
        throw new NotImplementedException();
      }

      int count = list.Count;

      if (count == 0)
      {
        throw new InvalidOperationException();
      }

      count--;
      return list[count];
    }

    /// <summary>
    /// Return the last element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>
    /// <see langword="default"/>(TSource) if the source sequence is empty;
    /// otherwise, the last element in the
    /// <typeparamref name="IEnumerable"/>&lt;out <typeparamref name="TSource"/>&gt;.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static TSource LastOrDefault<TSource>(IEnumerable<TSource> source)
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (!(source is IList<TSource> list))
      {
        throw new NotImplementedException();
      }

      int count = list.Count;

      if (count == 0)
      {
        return default;
      }

      count--;
      return list[count];
    }

    /// <summary>
    /// Sorts the elements in sequence in ascending order according to a key.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="key">The key</param>
    /// <returns>
    /// A <typeparamref name="IEnumerable"/>&lt;<typeparamref name="TSource"/>&gt; 
    /// whose elements are sorted according to a key.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static IEnumerable<TSource> OrderBy<TSource, TKey>
    (
      IEnumerable<TSource> source,
      TKey key
    )
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (!(source is IList<TSource> list))
      {
        throw new NotImplementedException();
      }

      if (list.Count == 0)
      {
        return list;
      }

      List<TSource> valueList = new List<TSource>();

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(key.ToString());

        var itemValue = propertyInfo
          .GetValue
          (
            item,
            null
          );

        valueList.Add((TSource)itemValue);
      }

      valueList.Sort();
      var newList = list;

      for (int i = 0; i < valueList.Count; i++)
      {
        newList[i] = list[i];
      }

      return newList;
    }

    /// <summary>
    /// Sorts the elements in sequence in ascending order according to a key.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="key">The key</param>
    /// <returns>
    /// A <typeparamref name="List"/>&lt;<typeparamref name="TSource"/>&gt; 
    /// whose elements are sorted according to a key.
    /// </returns>
    public static List<TSource> OrderBy<TSource, TKey>
    (
      IList<TSource> source,
      TKey key
    )
    {
      return (List<TSource>)OrderBy
        (
          source as IEnumerable<TSource>,
          key
        );
    }
  }
}