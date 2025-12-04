// Decompiled with JetBrains decompiler
// Type: ImageTools.Helpers.Guard
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#nullable disable
namespace ImageTools.Helpers
{
  public static class Guard
  {
    public static void Between<TValue>(
      TValue target,
      TValue lower,
      TValue upper,
      string parameterName)
      where TValue : IComparable
    {
      if (!target.IsBetween<TValue>(lower, upper))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Value must be between {0} and {1}", new object[2]
        {
          (object) lower,
          (object) upper
        }), parameterName);
    }

    public static void Between<TValue>(
      TValue target,
      TValue lower,
      TValue upper,
      string parameterName,
      string message)
      where TValue : IComparable
    {
      if (!target.IsBetween<TValue>(lower, upper))
        throw new ArgumentException(message, parameterName);
    }

    public static void GreaterThan<TValue>(TValue target, TValue lower, string parameterName) where TValue : IComparable
    {
      if (target.CompareTo((object) lower) <= 0)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Value must be greater than {0}", new object[1]
        {
          (object) lower
        }), parameterName);
    }

    public static void GreaterThan<TValue>(
      TValue target,
      TValue lower,
      string parameterName,
      string message)
      where TValue : IComparable
    {
      if (target.CompareTo((object) lower) <= 0)
        throw new ArgumentException(message, parameterName);
    }

    public static void GreaterEquals<TValue>(TValue target, TValue lower, string parameterName) where TValue : IComparable
    {
      if (target.CompareTo((object) lower) < 0)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Value must be greater than {0}", new object[1]
        {
          (object) lower
        }), parameterName);
    }

    public static void GreaterEquals<TValue>(
      TValue target,
      TValue lower,
      string parameterName,
      string message)
      where TValue : IComparable
    {
      if (target.CompareTo((object) lower) < 0)
        throw new ArgumentException(message, parameterName);
    }

    public static void LessThan<TValue>(TValue target, TValue upper, string parameterName) where TValue : IComparable
    {
      if (target.CompareTo((object) upper) <= 0)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Value must be less than {0}", new object[1]
        {
          (object) upper
        }), parameterName);
    }

    public static void LessThan<TValue>(
      TValue target,
      TValue upper,
      string parameterName,
      string message)
      where TValue : IComparable
    {
      if (target.CompareTo((object) upper) <= 0)
        throw new ArgumentException(message, parameterName);
    }

    public static void LessEquals<TValue>(TValue target, TValue upper, string parameterName) where TValue : IComparable
    {
      if (target.CompareTo((object) upper) > 0)
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Value must be less than {0}", new object[1]
        {
          (object) upper
        }), parameterName);
    }

    public static void LessEquals<TValue>(
      TValue target,
      TValue upper,
      string parameterName,
      string message)
      where TValue : IComparable
    {
      if (target.CompareTo((object) upper) > 0)
        throw new ArgumentException(message, parameterName);
    }

    public static void NotEmpty<TType>(ICollection<TType> enumerable, string parameterName)
    {
      if (enumerable == null)
        throw new ArgumentNullException(nameof (enumerable));
      if (enumerable.Count == 0)
        throw new ArgumentException("Collection does not contain an item", parameterName);
    }

    public static void NotEmpty<TType>(
      ICollection<TType> enumerable,
      string parameterName,
      string message)
    {
      if (enumerable == null)
        throw new ArgumentNullException(nameof (enumerable));
      if (enumerable.Count == 0)
        throw new ArgumentException(message, parameterName);
    }

    public static void NotNull(object target, string parameterName)
    {
      if (target == null)
        throw new ArgumentNullException(parameterName);
    }

    public static void NotNull(object target, string parameterName, string message)
    {
      if (target == null)
        throw new ArgumentNullException(message, parameterName);
    }

    [SuppressMessage("Microsoft.Performance", "CA1820", Justification = "Make a difference between is null and is empty.")]
    public static void NotNullOrEmpty(string target, string parameterName)
    {
      if (target == null)
        throw new ArgumentNullException(parameterName);
      if (string.IsNullOrEmpty(target) || target.Trim().Equals(string.Empty))
        throw new ArgumentException("String parameter cannot be null or empty and cannot contain only blanks.", parameterName);
    }

    [SuppressMessage("Microsoft.Performance", "CA1820", Justification = "Make a difference between is null and is empty.")]
    public static void NotNullOrEmpty(string target, string parameterName, string message)
    {
      if (target == null)
        throw new ArgumentNullException(parameterName);
      if (string.IsNullOrEmpty(target) || target.Trim().Equals(string.Empty))
        throw new ArgumentException(message, parameterName);
    }
  }
}
