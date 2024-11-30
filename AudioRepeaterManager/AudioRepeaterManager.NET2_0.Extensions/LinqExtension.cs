using System;
using System.Collections.Generic;
using System.Reflection;

namespace AudioRepeaterManager.NET2_0.Extensions
{
  public static class LinqExtension
  {
    // TODO: make sure all input params and summaries match actual methods!

    /// <summary>
    /// Removes all elements that match the conditions defined by the specified
    /// predicate from a
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="match">The predicate</param>
    /// <returns>
    /// The number of elements that were removed from the
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// collection.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static int RemoveWhere<TSource, TKey>
    (
      ref IEnumerable<TSource> source,
      Predicate<TKey> match
    )
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (match is null)
      {
        throw new ArgumentNullException(nameof(match));
      }

      if (!(source is IList<TSource> list))
      {
        throw new NotImplementedException();
      }

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(match.ToString());

        object value = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if
        (
          value is null
          || !(value is TSource key)
          || !list.Contains(key)
        )
        {
          continue;
        }

        list.Remove(key);
      }

      source = list;
      return list.Count;
    }

    /// <summary>
    /// Removes all elements that match the conditions defined by the specified
    /// predicate from a
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="match">The predicate</param>
    /// <returns>
    /// The number of elements that were removed from the
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// collection.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static int RemoveWhere<TSource, TKey>
    (
      ref IList<TSource> source,
      Predicate<TKey> match
    )
    {
      IEnumerable<TSource> enumerable = source;

      int count = RemoveWhere
        (
          ref enumerable,
          match
        );

      source = (IList<TSource>)enumerable;
      return count;
    }

    /// <summary>
    /// Projects the element of a sequence into a new form.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="result">The result</param>
    /// <returns>
    /// An <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// whose elements are the result of the property on each element of the source.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static IEnumerable<TResult> Select<TSource, TResult>
    (
      IEnumerable<TSource> source,
      TResult result
    )
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (result == null)
      {
        throw new ArgumentNullException(nameof(result));
      }

      if (!(source is IList<TSource> list))
      {
        throw new NotImplementedException();
      }

      List<TResult> newList = new List<TResult>();

      foreach (var item in list)
      {
        PropertyInfo propertyInfo = item
         .GetType()
         .GetProperty(result.ToString());

        object value = propertyInfo
          .GetValue
          (
            item,
            null
          );

        if
        (
          value is null
          || !(value is TResult newResult)
          || newList.Contains(newResult)
        )
        {
          continue;
        }

        newList.Add(newResult);
      }

      return newList;
    }

    /// <summary>
    /// Projects the element of a sequence into a new form.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="source">The sequence</param>
    /// <param name="result">The result</param>
    /// <returns>
    /// A <typeparamref name="List"/>&lt;<typeparamref name="T"/>&gt;
    /// whose elements are the result of the property on each element of the source.
    /// </returns>    
    public static List<TResult> Select<TSource, TResult>
    (
      IList<TSource> source,
      TResult result
    )
    {
      return (List<TResult>)Select
        (
          source as IEnumerable<TSource>,
          result
        );
    }

    /// <summary>
    /// Returns distinct elements from a sequence.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>
    /// An <typeparamref name="IEnumerable"/>&lt;<typeparamref name="T"/>&gt;
    /// that contains distinct elements from the source sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static IEnumerable<T> Distinct<T>(IEnumerable<T> source)
    {
      if (source is null)
      {
        throw new ArgumentNullException(nameof(source));
      }

      if (!(source is List<T> list))
      {
        throw new NotImplementedException();
      }

      if (list.Count == 0)
      {
        return list;
      }

      List<T> newList = new List<T>();

      foreach (var item in list)
      {
        if (newList.Contains(item))
        {
          continue;
        }

        newList.Add(item);
      }

      return newList;
    }

    /// <summary>
    /// Returns distinct elements from a sequence.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>
    /// An <typeparamref name="List"/>&lt;<typeparamref name="T"/>&gt;
    /// that contains distinct elements from the source sequence.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static List<T> Distinct<T>(List<T> source)
    {
      return (List<T>)Distinct(source as IEnumerable<T>);
    }

    /// <summary>
    /// Return the first element of a sequence.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>The value at the first position in the source sequence.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static TSource First<TSource>(IEnumerable<TSource> source)
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

      return list[0];
    }

    /// <summary>
    /// Return the first element of a sequence,
    /// or a default value if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source">The sequence</param>
    /// <returns>
    /// <see langword="default"/>(TSource) if the source sequence is empty;
    /// otherwise, the first element in the
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="TSource"/>&gt;.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public static TSource FirstOrDefault<TSource>(IEnumerable<TSource> source)
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

      return list[0];
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
    /// <typeparamref name="IEnumerable"/>&lt;<typeparamref name="TSource"/>&gt;.
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

      if (key == null)
      {
        throw new ArgumentNullException(nameof(key));
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