// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.EnumerableExtensions
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace Tango.Toolbox
{
  public static class EnumerableExtensions
  {
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
    {
      ObservableCollection<T> observableCollection = new ObservableCollection<T>();
      foreach (T obj in collection)
        observableCollection.Add(obj);
      return observableCollection;
    }
  }
}
