// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.ContactsFilter
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using Microsoft.Phone.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class ContactsFilter
  {
    private const int STOP_ON_HOW_MANY_CHANGES = 6;
    private ObservableCollection<PublicGrouping<string, DisplayableContact>> _groupResultHolder;
    private List<DisplayableContact> _listResultHolder;
    private LongListSelector _listSelector;
    private string _lastQuery;
    private DispatcherTimer _timerForFilter;
    private int _startGroupIndex;
    private int _startItemIndex;
    private int _visibleItemCountInPage = 3;
    private bool _isSearchingPaused;

    public bool HasResult { get; private set; }

    public bool HasUncheckedItem { get; private set; }

    public event ContactsFilter.OnFilterUpdateDelegate OnFilterUpdate;

    public ContactsFilter()
    {
      this._timerForFilter = new DispatcherTimer();
      this._timerForFilter.Interval = TimeSpan.FromMilliseconds(10.0);
      this._timerForFilter.Tick += new EventHandler(this.OnFilterTimer);
    }

    public bool IsSearching => this._timerForFilter.IsEnabled;

    public void PauseSearching()
    {
      if (!this.IsSearching)
        return;
      this._isSearchingPaused = true;
      this._timerForFilter.Stop();
    }

    public void ResumeSearching()
    {
      if (!this._isSearchingPaused)
        return;
      this._isSearchingPaused = false;
      this._timerForFilter.Start();
    }

    public void Init(
      ObservableCollection<PublicGrouping<string, DisplayableContact>> groupResultHolder,
      List<DisplayableContact> listResultHolder,
      LongListSelector listSelector)
    {
      this._groupResultHolder = groupResultHolder;
      this._listResultHolder = listResultHolder;
      this._listSelector = listSelector;
      this._listSelector.IsFlatList = true;
      this._listSelector.ItemsSource = (IEnumerable) this._listResultHolder;
      this.Reset();
    }

    private void Reset()
    {
      this._timerForFilter.Stop();
      this._isSearchingPaused = false;
      this.HasResult = false;
      this.HasUncheckedItem = false;
      if (this._groupResultHolder != null)
      {
        for (int index1 = 0; index1 < this._groupResultHolder.Count; ++index1)
        {
          PublicGrouping<string, DisplayableContact> publicGrouping = this._groupResultHolder[index1];
          for (int index2 = 0; index2 < publicGrouping.Count; ++index2)
          {
            publicGrouping[index2].Visibility = (Visibility) 0;
            publicGrouping[index2].Keyword = string.Empty;
            if (!this.HasUncheckedItem && !publicGrouping[index2].IsSelected)
              this.HasUncheckedItem = true;
          }
        }
        this.HasResult = this._groupResultHolder.Count > 0;
      }
      this._lastQuery = string.Empty;
      this.ResetListScroll();
    }

    private void ResetListScroll()
    {
      if (this._listSelector == null)
        return;
      ((UIElement) this._listSelector).UpdateLayout();
      if (this._groupResultHolder == null || this._groupResultHolder.Count <= 0 || this._groupResultHolder[0].Count <= 0)
        return;
      if (this._listSelector.ShowListHeader)
        this._listSelector.ScrollTo(this._listSelector.ListHeader);
      else
        this._listSelector.ScrollTo((object) this._groupResultHolder[0][0]);
    }

    public void ClearResult()
    {
      if (this._groupResultHolder != null && this._listSelector != null)
      {
        this._listSelector.IsFlatList = false;
        this._listSelector.ItemsSource = (IEnumerable) this._groupResultHolder;
      }
      this.Reset();
      this._groupResultHolder = (ObservableCollection<PublicGrouping<string, DisplayableContact>>) null;
      this._listSelector = (LongListSelector) null;
    }

    public void DoFilter(string query, int visibleItemCountInPage)
    {
      if (this._groupResultHolder == null || this._listResultHolder == null || query == null)
        return;
      if (string.IsNullOrEmpty(query))
      {
        this.Reset();
        this._listSelector.ItemsSource = (IEnumerable) this._listResultHolder;
        if (this.OnFilterUpdate == null)
          return;
        this.OnFilterUpdate(true, this.HasResult, this.HasUncheckedItem);
      }
      else
      {
        List<DisplayableContact> filteredList = new List<DisplayableContact>();
        query = query.ToLowerInvariant();
        if (this._lastQuery.Equals(query))
          return;
        this._visibleItemCountInPage = visibleItemCountInPage;
        this.ResetListScroll();
        this._isSearchingPaused = false;
        this._lastQuery = query;
        this._startGroupIndex = 0;
        this._startItemIndex = 0;
        this.HasResult = false;
        this.HasUncheckedItem = false;
        this.DoFilterImpl(filteredList);
        this._listSelector.ItemsSource = (IEnumerable) filteredList;
      }
    }

    public bool DoFilterImpl(List<DisplayableContact> filteredList)
    {
      Logger.Trace(string.Format("DoFilterImpl from group {0}, index {1}", (object) this._startGroupIndex, (object) this._startItemIndex));
      for (int startGroupIndex = this._startGroupIndex; startGroupIndex < this._groupResultHolder.Count; ++startGroupIndex)
      {
        PublicGrouping<string, DisplayableContact> publicGrouping = this._groupResultHolder[startGroupIndex];
        for (int startItemIndex = this._startItemIndex; startItemIndex < publicGrouping.Count; ++startItemIndex)
        {
          bool flag = HighlightTextBlock.CanHitKeyword(this._lastQuery, publicGrouping[startItemIndex].Name, true);
          if (flag)
            filteredList.Add(publicGrouping[startItemIndex]);
          if (!this.HasResult && flag)
          {
            this.HasResult = true;
            if (this.OnFilterUpdate != null)
              this.OnFilterUpdate(false, this.HasResult, this.HasUncheckedItem);
          }
          publicGrouping[startItemIndex].Keyword = this._lastQuery;
          if (!this.HasUncheckedItem && publicGrouping[startItemIndex].Visibility == null && !publicGrouping[startItemIndex].IsSelected)
            this.HasUncheckedItem = true;
        }
        this._startItemIndex = 0;
      }
      Logger.Trace("DoFilter finished");
      if (this.OnFilterUpdate != null)
        this.OnFilterUpdate(true, this.HasResult, this.HasUncheckedItem);
      return true;
    }

    private void OnFilterTimer(object sender, EventArgs e) => this._timerForFilter.Stop();

    public delegate void OnFilterUpdateDelegate(
      bool isFinished,
      bool hasResult,
      bool hasUncheckedItem);
  }
}
