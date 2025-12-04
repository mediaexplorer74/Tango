// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.Lists
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public static class Lists
  {
    public static IList<T> AsReadOnly<T>(IList<T> list) => Lists<T>.AsReadOnly(list);

    public static bool Equals<T>(IList<T> left, IList<T> right)
    {
      if (left == right)
        return true;
      if (left == null || right == null || left.Count != right.Count)
        return false;
      IEqualityComparer<T> equalityComparer = (IEqualityComparer<T>) EqualityComparer<T>.Default;
      for (int index = 0; index < left.Count; ++index)
      {
        if (!equalityComparer.Equals(left[index], right[index]))
          return false;
      }
      return true;
    }

    public static int GetHashCode<T>(IList<T> list)
    {
      int hashCode = 31;
      foreach (T obj in (IEnumerable<T>) list)
        hashCode = hashCode * 29 + obj.GetHashCode();
      return hashCode;
    }
  }
}
