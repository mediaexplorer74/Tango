// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.InviteListHeader
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System.ComponentModel;
using System.Windows;

#nullable disable
namespace WinPhoneTango
{
  public class InviteListHeader : INotifyPropertyChanged
  {
    private static InviteListHeader _smsInstance;
    private static InviteListHeader _emailInstance;
    private Visibility _selectAllVisible;
    private string _selectAllText = string.Empty;
    private bool _isSelectAllChecked;

    public event PropertyChangedEventHandler PropertyChanged;

    public static InviteListHeader SMSInstance
    {
      get
      {
        if (InviteListHeader._smsInstance == null)
          InviteListHeader._smsInstance = new InviteListHeader();
        return InviteListHeader._smsInstance;
      }
    }

    public static InviteListHeader EmailInstance
    {
      get
      {
        if (InviteListHeader._emailInstance == null)
          InviteListHeader._emailInstance = new InviteListHeader();
        return InviteListHeader._emailInstance;
      }
    }

    public Visibility SelectAllVisible
    {
      get => this._selectAllVisible;
      set
      {
        if (this._selectAllVisible == value)
          return;
        this._selectAllVisible = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (SelectAllVisible)));
      }
    }

    public string SelectAllText
    {
      get => this._selectAllText;
      set
      {
        if (!(this._selectAllText != value))
          return;
        this._selectAllText = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (SelectAllText)));
      }
    }

    public bool IsSelectAllChecked
    {
      get => this._isSelectAllChecked;
      set
      {
        if (this._isSelectAllChecked == value)
          return;
        this._isSelectAllChecked = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsSelectAllChecked)));
      }
    }
  }
}
