// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Collections.IPopsicleList`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Collections
{
  public interface IPopsicleList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
  {
    void Add(IEnumerable<T> collection);
  }
}
