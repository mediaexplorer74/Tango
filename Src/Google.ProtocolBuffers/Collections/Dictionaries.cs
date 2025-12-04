// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.Dictionaries
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public static class Dictionaries
  {
    public static bool Equals<TKey, TValue>(
      IDictionary<TKey, TValue> left,
      IDictionary<TKey, TValue> right)
    {
      if (left.Count != right.Count)
        return false;
      foreach (KeyValuePair<TKey, TValue> keyValuePair in (IEnumerable<KeyValuePair<TKey, TValue>>) left)
      {
        TValue objB;
        if (!right.TryGetValue(keyValuePair.Key, out objB))
          return false;
        IEnumerable left1 = (object) keyValuePair.Value as IEnumerable;
        IEnumerable right1 = (object) objB as IEnumerable;
        if (left1 == null || right1 == null)
        {
          if (!object.Equals((object) keyValuePair.Value, (object) objB))
            return false;
        }
        else if (!Enumerables.Equals(left1, right1))
          return false;
      }
      return true;
    }

    public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(
      IDictionary<TKey, TValue> dictionary)
    {
      return !dictionary.IsReadOnly ? (IDictionary<TKey, TValue>) new ReadOnlyDictionary<TKey, TValue>(dictionary) : dictionary;
    }

    public static int GetHashCode<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
    {
      int hashCode = 31;
      foreach (KeyValuePair<TKey, TValue> keyValuePair in (IEnumerable<KeyValuePair<TKey, TValue>>) dictionary)
      {
        int num = keyValuePair.Key.GetHashCode() ^ Dictionaries.GetDeepHashCode((object) keyValuePair.Value);
        hashCode ^= num;
      }
      return hashCode;
    }

    private static int GetDeepHashCode(object value)
    {
      if (!(value is IEnumerable enumerable))
        return value.GetHashCode();
      int deepHashCode = 29;
      foreach (object obj in enumerable)
        deepHashCode = deepHashCode * 37 + obj.GetHashCode();
      return deepHashCode;
    }
  }
}
