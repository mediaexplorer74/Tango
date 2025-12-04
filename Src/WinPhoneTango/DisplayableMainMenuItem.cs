// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.DisplayableMainMenuItem
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

#nullable disable
namespace WinPhoneTango
{
  public class DisplayableMainMenuItem : INotifyPropertyChanged
  {
    private int _number;

    public event PropertyChangedEventHandler PropertyChanged;

    public ImageSource Icon { get; set; }

    public string Title { get; set; }

    public Visibility ShowNumber { get; set; }

    public Visibility Visibility { get; set; }

    public int Number
    {
      get => this._number;
      set
      {
        this._number = value;
        this.ShowNumber = this._number == 0 ? (Visibility) 1 : (Visibility) 0;
        if (this._number == value || this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Number)));
      }
    }
  }
}
