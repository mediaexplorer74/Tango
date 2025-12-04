// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.ListComparator`1
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System.Collections.Generic;

#nullable disable
namespace Tango.Toolbox
{
  public class ListComparator<T>
  {
    private ListComparator()
    {
    }

    public static bool ListEqual(IList<T> list1, IList<T> list2)
    {
      if (list1 == null && list2 == null)
        return true;
      if (list1 == null || list2 == null || list1.Count != list2.Count)
        return false;
      for (int index = 0; index < list1.Count; ++index)
      {
        if (!list1[index].Equals((object) list2[index]))
          return false;
      }
      return true;
    }
  }
}
