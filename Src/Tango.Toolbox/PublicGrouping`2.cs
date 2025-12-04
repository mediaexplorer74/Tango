// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.PublicGrouping`2
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;

#nullable disable
namespace Tango.Toolbox
{
  public class PublicGrouping<TKey, TElement> : ObservableCollection<TElement>
  {
    private Visibility _visibility;

    public PublicGrouping(TKey name, IEnumerable<TElement> items)
    {
      this.Key = name;
      foreach (TElement element in items)
        this.Add(element);
    }

    public PublicGrouping(IGrouping<TKey, TElement> group)
    {
      this.Key = group.Key;
      foreach (TElement element in (IEnumerable<TElement>) group)
        this.Add(element);
    }

    public PublicGrouping(TKey name) => this.Key = name;

    public override int GetHashCode() => this.Key.GetHashCode();

    public bool HasItem => this.Count > 0;

    public override bool Equals(object obj)
    {
      return obj is PublicGrouping<TKey, TElement> publicGrouping && this.Key.Equals((object) publicGrouping.Key);
    }

    public TKey Key { get; set; }

    public Visibility Visibility
    {
      get => this._visibility;
      set
      {
        if (this._visibility == value)
          return;
        this._visibility = value;
        this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (Visibility)));
      }
    }
  }
}
