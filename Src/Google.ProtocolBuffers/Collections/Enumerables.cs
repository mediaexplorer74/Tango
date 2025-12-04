// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.Enumerables
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public static class Enumerables
  {
    public static bool Equals(IEnumerable left, IEnumerable right)
    {
      IEnumerator enumerator = left.GetEnumerator();
      try
      {
        foreach (object objB in right)
        {
          if (!enumerator.MoveNext() || !object.Equals(enumerator.Current, objB))
            return false;
        }
        if (enumerator.MoveNext())
          return false;
      }
      finally
      {
        if (enumerator is IDisposable disposable)
          disposable.Dispose();
      }
      return true;
    }
  }
}
