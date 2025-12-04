// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ThrowHelper
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public static class ThrowHelper
  {
    public static void ThrowIfNull(object value, string name)
    {
      if (value == null)
        throw new ArgumentNullException(name);
    }

    public static void ThrowIfNull(object value)
    {
      if (value == null)
        throw new ArgumentNullException();
    }

    public static void ThrowIfAnyNull<T>(IEnumerable<T> sequence)
    {
      foreach (T obj in sequence)
      {
        if ((object) obj == null)
          throw new ArgumentNullException();
      }
    }
  }
}
