// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.CountrySelectorPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using System.Windows.Threading;

#nullable disable
namespace WinPhoneTango
{
  public partial class CountrySelectorPage : TangoEventPageBase
  {
    private const int LIST_ITEM_HEIGHT = 42;
    private const int LIST_LOAD_STEP = 10;
    private ObservableCollection<CountryCode> _countryList;
    private int _defaultCountryIndex = -1;
    private DispatcherTimer _timerForListLoad;
    private int _loadedListItemCount;
   

    public CountrySelectorPage()
    {
      this.InitializeComponent();
      this._countryList = new ObservableCollection<CountryCode>();
      ((ItemsControl) this.countryListBox).ItemsSource = (IEnumerable) this._countryList;
      this._timerForListLoad = new DispatcherTimer();
      this._timerForListLoad.Interval = TimeSpan.FromMilliseconds(40.0);
      this._timerForListLoad.Tick += new EventHandler(this.AsyncLoadCountryList);
      this._timerForListLoad.Start();
    }

    public void AsyncLoadCountryList(object sender, EventArgs e)
    {
      if (AppManager.Instance.DataManager.UserData == null)
        return;
      IList<CountryCode> countryCodeList = AppManager.Instance.DataManager.UserData.CountryCodeList;
      if (this._loadedListItemCount >= countryCodeList.Count)
      {
        this._timerForListLoad.Stop();
        ((UIElement) this.waitingBar).Visibility = (Visibility) 1;
        ((UIElement) this.countryListBox).Visibility = (Visibility) 0;
        this.SetCountryPickerData(this._defaultCountryIndex);
      }
      else
      {
        for (int loadedListItemCount = this._loadedListItemCount; loadedListItemCount < Math.Min(countryCodeList.Count, this._loadedListItemCount + 10); ++loadedListItemCount)
        {
          this._countryList.Add(countryCodeList[loadedListItemCount]);
          if (countryCodeList[loadedListItemCount].Countryid.Equals(AppManager.Instance.DataManager.SelectedCountryId))
            this._defaultCountryIndex = loadedListItemCount;
        }
        this._loadedListItemCount += 10;
      }
    }

    private void SetCountryPickerData(int index)
    {
      if (index < 0 || index >= this._countryList.Count)
        return;
      ((Selector) this.countryListBox).SelectedIndex = index;
      ((UIElement) this.countryListBox).UpdateLayout();
      int index1 = index + (int) (((FrameworkElement) this.countryListBox).Height / 42.0) / 2;
      if (index1 >= this._countryList.Count)
        index1 = this._countryList.Count - 1;
      this.countryListBox.ScrollIntoView((object) this._countryList[index1]);
    }

    private void countryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (((Selector) this.countryListBox).SelectedIndex < 0 || ((Selector) this.countryListBox).SelectedIndex == this._defaultCountryIndex)
        return;
      if (((Selector) this.countryListBox).SelectedIndex < this._countryList.Count)
        AppManager.Instance.DataManager.SelectedCountryId = this._countryList[((Selector) this.countryListBox).SelectedIndex].Countryid;
      this.GoBackToFormerPage();
    }

    
  }
}
