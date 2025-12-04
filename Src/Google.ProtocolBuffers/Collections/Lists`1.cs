// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.Lists`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public static class Lists<T>
  {
    private static readonly ReadOnlyCollection<T> empty = new ReadOnlyCollection<T>((IList<T>) new T[0]);

    public static ReadOnlyCollection<T> Empty => Lists<T>.empty;

    public static IList<T> AsReadOnly(IList<T> list)
    {
      return !list.IsReadOnly ? (IList<T>) new ReadOnlyCollection<T>(list) : list;
    }
  }
}
