// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.CallHistoryPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tango.Messages;
using Tango.Toolbox;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public partial class CallHistoryPage : TangoEventPageBase
 {
    private const int PIVOT_ITEM_ALL = 0;
    private const int PIVOT_ITEM_MISSED = 1;
    private bool _isCallLogUpdated;
    

    public CallHistoryPage()
    {
      this.IsGoBackable = true;
      this.InitializeComponent();
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnLoaded);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e) => base.OnNavigatedTo(e);

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      this.listSelectorAll.SelectedItem = null;
      this.listSelectorMissed.SelectedItem = null;
      base.OnNavigatedFrom(e);
    }

    private void OnLoaded(object sender, RoutedEventArgs e) => this.LoadHistoryList();

    private void LoadHistoryList()
    {
      List<DisplayableContact> source1 = new List<DisplayableContact>();
      if (AppManager.Instance.DataManager.CallLogData != null)
      {
        this.StopLoadingProgress();
        this.UpdateApplicationBarVisibility();
        CallEntriesPayload callLogData = AppManager.Instance.DataManager.CallLogData;
        for (int index = 0; index < callLogData.EntriesCount; ++index)
        {
          DisplayableContact displayableContact = new DisplayableContact();
          CallEntry entries = callLogData.EntriesList[index];
          displayableContact.PutNameEx(entries.FirstName, entries.LastName, entries.PhoneNumber, entries.Email);
          displayableContact.PutCall(entries.CallType, entries.StartTime, entries.Duration);
          displayableContact.AccountId = entries.AccountId;
          displayableContact.DeviceContactId = entries.DeviceContactId;
          displayableContact.BindedCallEntry = entries;
          source1.Add(displayableContact);
        }
        ((UIElement) this.noCallText).Visibility = source1.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        this.listSelectorAll.ItemsSource = source1.OrderByDescending<DisplayableContact, ulong>((Func<DisplayableContact, ulong>) (call => call.LastCallStartTime));
        ((UIElement) this.listSelectorAll).UpdateLayout();
        List<DisplayableContact> source2 = new List<DisplayableContact>();
        for (int index = 0; index < source1.Count; ++index)
        {
          if (source1[index].IsLastCallMissed)
            source2.Add(source1[index]);
        }
        this.listSelectorMissed.ItemsSource = source2.OrderByDescending<DisplayableContact, ulong>((Func<DisplayableContact, ulong>) (call => call.LastCallStartTime));
        ((UIElement) this.listSelectorMissed).UpdateLayout();
        ((UIElement) this.noMissedCallText).Visibility = source2.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
      }
      if (AppManager.Instance.DataManager.CallLogData == null)
      {
          // ApplicationBar is WP7-specific, removed for UWP
      }
      if (this._isCallLogUpdated || AppManager.Instance.DataManager.CallLogData != null && AppManager.Instance.DataManager.IsCallLogUpdatedFromServer)
        return;
      this.StartLoadingProgress(this.waitingBar);
    }

    public override void HandleTangoEvent(int messageId)
    {
      if (messageId != 35093 && messageId != 35092)
        return;
      if (AppManager.Instance.DataManager.IsCallLogUpdatedFromServer)
        this._isCallLogUpdated = true;
      this.StopLoadingProgress();
      this.LoadHistoryList();
    }

    public override void HandleAppEvent(int messageId)
    {
      if (messageId != 2 || !AppManager.Instance.DataManager.IsCallLogUpdatedFromServer)
        return;
      Logger.Trace("Get updated call log from server, stop the loading progress bar.");
      this._isCallLogUpdated = true;
      this.StopLoadingProgress();
    }

    private void listSelectorAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.MakeCall(this.listSelectorAll.SelectedItem as DisplayableContact);
    }

    private void listSelectorMissed_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.MakeCall(this.listSelectorMissed.SelectedItem as DisplayableContact);
    }

    private void MakeCall(DisplayableContact selectedContact)
    {
      if (selectedContact == null || selectedContact.AccountId == null || selectedContact.AccountId.Length <= 0)
        return;
      MediaSessionPayload.Builder builder = MediaSessionPayload.CreateBuilder();
      builder.SetAccountId(selectedContact.AccountId);
      builder.SetDisplayname(selectedContact.Name);
      builder.SetFromUi(true);
      builder.SetDeviceContactId(selectedContact.DeviceContactId);
      MakeCallMessage message = new MakeCallMessage(TangoEventPageBase.GetNextSeqId(), builder);
      AppManager.Instance.DataManager.CallingData = (MediaSessionPayload) message.MsgPayload;
      TangoEventPageBase.SendMessage((ISendableMessage) message);
      Logger.Trace("Navigate by MakeCall from " + ((object) this).GetType().Name + " to dialing page");
      this.NavigateToPage("IncomingCallPage", IncomingCallPage.NAVIGATION_WAY_PARAM + "=" + IncomingCallPage.NAVIGATION_WAY_TYPE_SEND);
    }

    private void ApplicationBarIconButton_Click(object sender, RoutedEventArgs e)
    {
      // MessageBox is WP7-specific, removed for UWP
      // For UWP, we would use ContentDialog or MessageDialog
    }

    private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.UpdateApplicationBarVisibility();
    }

    private void UpdateApplicationBarVisibility()
    {
      int selectedIndex = this.pivotCallLog.SelectedIndex;
      switch (selectedIndex)
      {
        case 0:
          if (AppManager.Instance.DataManager.CallLogData != null && AppManager.Instance.DataManager.CallLogData.EntriesCount > 0)
          {
            // ApplicationBar is WP7-specific, removed for UWP
            break;
          }
          // ApplicationBar is WP7-specific, removed for UWP
          break;
        case 1:
          // ApplicationBar is WP7-specific, removed for UWP
          break;
        default:
          Logger.Trace("CallHistoryPage got wrong pivot index selected, index = " + (object) selectedIndex);
          // ApplicationBar is WP7-specific, removed for UWP
          break;
      }
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      // ContextMenu is WP7-specific, removed for UWP
    }

    private void DeleteSelectedItem(DisplayableContact contact)
    {
      if (contact == null)
        Logger.Trace("[CallHistoryPage::DeleteSelectedItem] no selected contact found");
      else if (contact.BindedCallEntry == null)
      {
        Logger.Trace("[CallHistoryPage::DeleteSelectedItem] selected contact is not binded to a call entry");
      }
      else
      {
        DeleteCallEntriesPayload.Builder builder = DeleteCallEntriesPayload.CreateBuilder();
        builder.AddEntries(contact.BindedCallEntry);
        TangoEventPageBase.SendMessage((ISendableMessage) new DeleteCallLogMessage(TangoEventPageBase.GetNextSeqId(), builder));
        this.StartLoadingProgress(this.waitingBar);
      }
    }

    private void ContextMenu_Closed(object sender, RoutedEventArgs e)
    {
      // ContextMenu is WP7-specific, removed for UWP
    }

    private void ContextMenu_Opened(object sender, RoutedEventArgs e)
    {
      // ContextMenu is WP7-specific, removed for UWP
    }

    
  }
}
