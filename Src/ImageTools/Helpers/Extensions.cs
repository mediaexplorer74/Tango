// Decompiled with JetBrains decompiler
// Type: ImageTools.Helpers.Extensions
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
//using System.Windows;
//using System.Windows.Resources;
using Windows.Foundation;
using Windows.ApplicationModel;

#nullable disable
namespace ImageTools.Helpers
{
  public static class Extensions
  {
    public static readonly Rect ZeroRect = new Rect(0.0, 0.0, 0.0, 0.0);

    public static Stream GetLocalResourceStream(Uri uri)
    {
      Contract.Requires<ArgumentNullException>(uri != (Uri) null, "Uri cannot be null.");
      return null; // Stub for UWP
    }

    public static Rectangle Multiply(Rectangle rectangle, double factor)
    {
      rectangle.X = (int) ((double) rectangle.X * factor);
      rectangle.Y = (int) ((double) rectangle.Y * factor);
      rectangle.Width = (int) ((double) rectangle.Width * factor);
      rectangle.Height = (int) ((double) rectangle.Height * factor);
      return rectangle;
    }

    public static Rect Multiply(Rect rectangle, double factor)
    {
      rectangle.X *= factor;
      rectangle.Y *= factor;
      rectangle.Width *= factor;
      rectangle.Height *= factor;
      return rectangle;
    }

    public static bool IsNumber(this double value)
    {
      return !double.IsInfinity(value) && !double.IsNaN(value);
    }

    public static bool IsNumber(this float value)
    {
      return !float.IsInfinity(value) && !float.IsNaN(value);
    }

    public static void Foreach<T>(this IEnumerable<T> items, Action<T> action)
    {
      Contract.Requires<ArgumentNullException>(items != null, "Items cannot be null");
      Contract.Requires<ArgumentNullException>(action != null, "Action cannot be null.");
      foreach (T obj in items)
      {
        if ((object) obj != null)
          action(obj);
      }
    }

    public static void Foreach(this IEnumerable items, Action<object> action)
    {
      Contract.Requires<ArgumentNullException>(items != null, "Items cannot be null");
      Contract.Requires<ArgumentNullException>(action != null, "Action cannot be null.");
      foreach (object obj in items)
      {
        if (obj != null)
          action(obj);
      }
    }

    public static void AddRange<TItem>(
      this ObservableCollection<TItem> target,
      IEnumerable<TItem> elements)
    {
      Contract.Requires<ArgumentNullException>(target != null, "Target cannot be null");
      Contract.Requires<ArgumentNullException>(elements != null, "Elements cannot be null.");
      foreach (TItem element in elements)
        target.Add(element);
    }

    public static void AddRange<TItem>(this Collection<TItem> target, IEnumerable<TItem> elements)
    {
      Contract.Requires<ArgumentNullException>(target != null, "Target cannot be null");
      Contract.Requires<ArgumentNullException>(elements != null, "Elements cannot be null.");
      foreach (TItem element in elements)
        target.Add(element);
    }

    public static bool IsBetween<TValue>(this TValue value, TValue low, TValue high) where TValue : IComparable
    {
      return Comparer<TValue>.Default.Compare(low, value) <= 0 && Comparer<TValue>.Default.Compare(high, value) >= 0;
    }

    public static TValue RemainBetween<TValue>(this TValue value, TValue low, TValue high) where TValue : IComparable
    {
      TValue obj = value;
      if (Comparer<TValue>.Default.Compare(high, low) < 0)
        obj = low;
      else if (Comparer<TValue>.Default.Compare(value, low) <= 0)
        obj = low;
      else if (Comparer<TValue>.Default.Compare(value, high) >= 0)
        obj = high;
      return obj;
    }

    [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
    public static void Swap<TRef>(ref TRef lhs, ref TRef rhs) where TRef : class
    {
      TRef @ref = lhs;
      lhs = rhs;
      rhs = @ref;
    }
  }
}
