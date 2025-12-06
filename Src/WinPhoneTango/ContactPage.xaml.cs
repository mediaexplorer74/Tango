// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.ContactPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.System.Threading;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public partial class ContactPage : TangoEventPageBase
  {
    private const int PIVOT_INDEX_ALL = 0;
    private const int PIVOT_INDEX_TANGO = 1;
    private const int PIVOT_COUNT = 2;
    private const int VISIBLE_ITEMS_IN_SEARCH_PAGE = 3;
    private ObservableCollection<PublicGrouping<string, DisplayableContact>> _allContactsByName;
    private ObservableCollection<PublicGrouping<string, DisplayableContact>> _tangoContactsByName;
    private ContactsFilter _contactFilter = new ContactsFilter();
    private List<DisplayableContact> _displayAllContacts;
    private List<DisplayableContact> _displayTangoContacts;
    private bool _isAllContactListOutOfDate = true;
    private bool _isTangoContactListOutOfDate = true;
    private object _saveContactTask; // Replaced WP7-specific SaveContactTask
    private object[] _pivotItems; // Replaced WP7-specific PivotItem
    private BitmapImage _defaultPhoto;
    private ThreadPoolTimer _timerForImageLoadingAll;
    private ThreadPoolTimer _timerForImageLoadingTango;
    private int _indexImageLoadingAll;
    private int _indexImageLoadingTango;
    private bool _isTimerForImageLoadingAllPausing;
    private bool _isTimerForImageLoadingTangoPausing;
   
    public ContactPage()
    {
      this._defaultPhoto = new BitmapImage(new Uri("ms-appx:///WinPhoneTango/Resources/small_avatar.png"));
      this._displayAllContacts = new List<DisplayableContact>();
      this._displayTangoContacts = new List<DisplayableContact>();
      this.IsGoBackable = true;
      this.InitializeComponent();
      this._pivotItems = new object[2]; // Placeholder for UWP PivotItem
      this._pivotItems[0] = this.pivotContactsType.Items[0];
      this._pivotItems[1] = this.pivotContactsType.Items[1];
      // For UWP, we'll handle this differently
      this.DisplayContactList();
    }

    protected override void OnInitialized()
    {
      // UIElementHelper.GetAbsoluteCoordinates is WP7-specific, removed for UWP
      this.ResetListHeight();
      this.ApplyThemeColorToResource(((FrameworkElement) this.listSelectorAll).Resources);
      this.ApplyThemeColorToResource(((FrameworkElement) this.listSelectorTango).Resources);
    }

    // Removed OnAppBarVisibilityChanged as ApplicationBar is WP7-specific

    private void ResetListHeight()
    {
      if (((FrameworkElement) this).ActualHeight <= 0.0)
        return;
      // ApplicationBar is WP7-specific, removed for UWP
      ((FrameworkElement) this.listSelectorTango).Height = ((FrameworkElement) this.listSelectorAll).Height = (double) ((int) (((FrameworkElement) this).ActualHeight - 0/*UIElementHelper.GetAbsoluteCoordinates((UIElement) this.listSelectorTango).Y*/));
    }

    private void OnImageLoadingTimerTango(object timer, TimerElapsedEventArgs args)
    {
      if (this._displayTangoContacts == null)
      {
        // timer.Stop() - not needed as ThreadPoolTimer handles this
      }
      else
      {
        while (this._indexImageLoadingTango < this._displayTangoContacts.Count)
        {
          DisplayableContact displayTangoContact = this._displayTangoContacts[this._indexImageLoadingTango++];
          if (displayTangoContact.Photo == this._defaultPhoto)
          {
            displayTangoContact.Photo = (ImageSource) DriversManager.Instance.ContactsDriver.GetPhotoByDeviceContactId(displayTangoContact.DeviceContactId, this._defaultPhoto);
            if (displayTangoContact.Photo != this._defaultPhoto)
              return;
          }
        }
        // timer.Stop() - not needed as ThreadPoolTimer handles this
        Logger.Trace("ImageLoading completed");
      }
    }

    private void OnImageLoadingTimerAll(object timer, TimerElapsedEventArgs args)
    {
      if (this._displayAllContacts == null)
      {
        // timer.Stop() - not needed as ThreadPoolTimer handles this
      }
      else
      {
        while (this._indexImageLoadingAll < this._displayAllContacts.Count)
        {
          DisplayableContact displayAllContact = this._displayAllContacts[this._indexImageLoadingAll++];
          if (displayAllContact.Photo == this._defaultPhoto)
          {
            displayAllContact.Photo = (ImageSource) DriversManager.Instance.ContactsDriver.GetPhotoByDeviceContactId(displayAllContact.DeviceContactId, this._defaultPhoto);
            if (displayAllContact.Photo != this._defaultPhoto)
              return;
          }
        }
        // timer.Stop() - not needed as ThreadPoolTimer handles this
        Logger.Trace("ImageLoading completed");
      }
    }

    public override void HandleTangoEvent(int messageId)
    {
      if (messageId != 35037)
        return;
      this.Assert((object) AppManager.Instance.DataManager.ContactList);
      if (DriversManager.Instance.ContactsDriver.IsContactsLoaded)
        this.StopLoadingProgress();
      this._isAllContactListOutOfDate = true;
      this._isTangoContactListOutOfDate = true;
      if (((UIElement) this.textBoxSearch).Visibility != Visibility.Collapsed)
        return;
      this.DisplayContactList();
      this.RefreshPagePrompt();
    }

    public override void HandleAppEvent(int messageId)
    {
      if (messageId != 1)
        return;
      this.StopLoadingProgress();
    }

    private void DisplayContactList()
    {
      if (AppManager.Instance.DataManager.ContactList != null)
      {
        this.UpdateContactList();
        if (!DriversManager.Instance.ContactsDriver.IsContactsLoaded)
          this.StartLoadingProgress(this.waitingBar);
      }
      else
      {
        ((FrameworkElement) this.waitingBar).VerticalAlignment = VerticalAlignment.Center;
        this.StartLoadingProgress(this.waitingBar);
      }
      this.RefreshPagePrompt();
    }

    private void UpdateContactList()
    {
      if (this.pivotContactsType.SelectedIndex == 0)
      {
        // _timerForImageLoadingTango.Stop() - not implemented in this conversion
        this.UpdateAllContactList();
      }
      else
      {
        // _timerForImageLoadingAll.Stop() - not implemented in this conversion
        this.UpdateTangoContactList();
      }
    }

    private void UpdateAllContactList()
    {
      if (this._isAllContactListOutOfDate && AppManager.Instance.DataManager.ContactList != null)
      {
        Logger.Trace(nameof (UpdateAllContactList));
        ContactsDriver contactsDriver = DriversManager.Instance.ContactsDriver;
        this._displayAllContacts.Clear();
        ContactsPayload contactList = AppManager.Instance.DataManager.ContactList;
        for (int index = 0; index < contactList.ContactsCount; ++index)
        {
          DisplayableContact displayableContact = new DisplayableContact();
          Contact contacts = contactList.ContactsList[index];
          displayableContact.ContactData = contacts;
          displayableContact.PutNameEx(contacts.Firstname, contacts.Lastname, contacts.PhoneNumber, contacts.Email);
          displayableContact.PutName(contactsDriver.GetDisplayNameByDeviceContactId(contacts.DeviceContactId, displayableContact.Name));
          displayableContact.DeviceContactId = contacts.DeviceContactId;
          displayableContact.TangoIconVisible = string.IsNullOrEmpty(contacts.Accountid) ? Visibility.Collapsed : Visibility.Visible;
          displayableContact.AccountId = contacts.Accountid;
          displayableContact.Photo = (ImageSource) this._defaultPhoto;
          this._displayAllContacts.Add(displayableContact);
        }
        this._isAllContactListOutOfDate = false;
        this.RenderAllContactsList();
        this.RefreshPagePrompt();
      }
      this._indexImageLoadingAll = 0;
      // Start timer for UWP - ThreadPoolTimer
      _timerForImageLoadingAll = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(OnImageLoadingTimerAll), TimeSpan.FromMilliseconds(10));
    }

    private void UpdateTangoContactList()
    {
      if (this._isTangoContactListOutOfDate && AppManager.Instance.DataManager.ContactList != null)
      {
        Logger.Trace(nameof (UpdateTangoContactList));
        ContactsDriver contactsDriver = DriversManager.Instance.ContactsDriver;
        this._displayTangoContacts.Clear();
        ContactsPayload contactList = AppManager.Instance.DataManager.ContactList;
        for (int index = 0; index < contactList.ContactsCount; ++index)
        {
          Contact contacts = contactList.ContactsList[index];
          if (!string.IsNullOrEmpty(contacts.Accountid))
          {
            DisplayableContact displayableContact = new DisplayableContact();
            displayableContact.ContactData = contacts;
            displayableContact.PutNameEx(contacts.Firstname, contacts.Lastname, contacts.PhoneNumber, contacts.Email);
            displayableContact.PutName(contactsDriver.GetDisplayNameByDeviceContactId(contacts.DeviceContactId, displayableContact.Name));
            displayableContact.DeviceContactId = contacts.DeviceContactId;
            displayableContact.TangoIconVisible = Visibility.Visible;
            displayableContact.AccountId = contacts.Accountid;
            displayableContact.Photo = (ImageSource) this._defaultPhoto;
            this._displayTangoContacts.Add(displayableContact);
          }
        }
        this._isTangoContactListOutOfDate = false;
        this.RenderTangoContactsList();
        this.RefreshPagePrompt();
      }
      this._indexImageLoadingTango = 0;
      // Start timer for UWP - ThreadPoolTimer
      _timerForImageLoadingTango = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(OnImageLoadingTimerTango), TimeSpan.FromMilliseconds(10));
    }

    private void RefreshPagePrompt()
    {
      if (this.pivotContactsType.SelectedIndex == 0)
      {
        ((UIElement) this.noContactText).Visibility = this._displayAllContacts == null || this._displayAllContacts.Count != 0 ? Visibility.Collapsed : Visibility.Visible;
        // AppBarController is WP7-specific, removed for UWP
      }
      else if (this.pivotContactsType.SelectedIndex == 1)
      {
        ((UIElement) this.noContactText).Visibility = this._displayTangoContacts == null || this._displayTangoContacts.Count != 0 ? Visibility.Collapsed : Visibility.Visible;
        // AppBarController is WP7-specific, removed for UWP
      }
      if (((UIElement) this.textBoxSearch).Visibility == Visibility.Visible)
      {
        // AppBarController is WP7-specific, removed for UWP
      }
      else
      {
        // AppBarController is WP7-specific, removed for UWP
      }
    }

    private void RenderAllContactsList()
    {
      if (this._displayAllContacts == null)
        return;
      this._allContactsByName = DisplayableContact.SortByName(this._displayAllContacts);
      this.listSelectorAll.ItemsSource = this._allContactsByName;
      ((UIElement) this.listSelectorAll).UpdateLayout();
    }

    private void RenderTangoContactsList()
    {
      if (this._displayTangoContacts == null)
        return;
      this._tangoContactsByName = DisplayableContact.SortByName(this._displayTangoContacts);
      this.listSelectorTango.ItemsSource = this._tangoContactsByName;
      ((UIElement) this.listSelectorTango).UpdateLayout();
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      this.listSelectorAll.SelectedItem = null;
      this.listSelectorTango.SelectedItem = null;
      base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      this.RefreshPagePrompt();
    }

    // Removed OnBackKeyPress as it's WP7-specific

    private void listSelectorAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.MakeCallOrInvite(this.listSelectorAll.SelectedItem as DisplayableContact);
    }

    private void listSelectorTango_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.MakeCallOrInvite(this.listSelectorTango.SelectedItem as DisplayableContact);
    }

    private void MakeCallOrInvite(DisplayableContact selectedContact)
    {
      if (selectedContact == null)
        return;
      this.ShowSearchBox(false);
      if (selectedContact.AccountId != null && selectedContact.AccountId.Length > 0)
      {
        MediaSessionPayload.Builder builder = MediaSessionPayload.CreateBuilder();
        builder.SetAccountId(selectedContact.AccountId);
        builder.SetDisplayname(selectedContact.Name);
        builder.SetDeviceContactId(selectedContact.DeviceContactId);
        builder.SetFromUi(true);
        MakeCallMessage message = new MakeCallMessage(TangoEventPageBase.GetNextSeqId(), builder);
        AppManager.Instance.DataManager.CallingData = (MediaSessionPayload) message.MsgPayload;
        TangoEventPageBase.SendMessage((ISendableMessage) message);
        Logger.Trace("Navigate by MakeCall from " + ((object) this).GetType().Name + " to dialing page");
        this.NavigateToPage("IncomingCallPage", IncomingCallPage.NAVIGATION_WAY_PARAM + "=" + IncomingCallPage.NAVIGATION_WAY_TYPE_SEND);
      }
      else
      {
        this.Assert((object) selectedContact.ContactData);
        if (selectedContact.ContactData == null || (selectedContact.ContactData.PhoneNumber == null || selectedContact.ContactData.PhoneNumber.SubscriberNumber == null || selectedContact.ContactData.PhoneNumber.SubscriberNumber.Length <= 0) && (selectedContact.ContactData.Email == null || selectedContact.ContactData.Email.Length <= 0))
        {
          // MessageBox is WP7-specific, replaced with UWP ContentDialog or MessageDialog
          // For now, just log the message
          Logger.Trace(ResourceLoader.GetForCurrentView("LangResource").GetString("contact_no_number_email_alert"));
        }
        else
        {
          ContactsPayload.Builder builder = ContactsPayload.CreateBuilder();
          builder.AddContacts(selectedContact.ContactData);
          TangoEventPageBase.SendMessage((ISendableMessage) new InviteContactMessage(TangoEventPageBase.GetNextSeqId(), builder));
        }
      }
    }

    private void ShowSearchBox(bool isToShow)
    {
      if (isToShow)
      {
        if (((UIElement) this.textBoxSearch).Visibility == Visibility.Visible)
          return;
        ((UIElement) this.PageTitle).Visibility = Visibility.Collapsed;
        this.textBoxSearch.Text = string.Empty;
        ((UIElement) this.textBoxSearch).Visibility = Visibility.Visible;
        this._contactFilter.OnFilterUpdate += new ContactsFilter.OnFilterUpdateDelegate(this.OnFilterUpdate);
        if (this.pivotContactsType.SelectedIndex == 0)
        {
          this._contactFilter.Init(this._allContactsByName, this._displayAllContacts, this.listSelectorAll);
          // Set header to empty string - not directly applicable in UWP
        }
        else
        {
          this._contactFilter.Init(this._tangoContactsByName, this._displayTangoContacts, this.listSelectorTango);
          // Set header to empty string - not directly applicable in UWP
        }
        // AppBarController is WP7-specific, removed for UWP
        ((Control) this.textBoxSearch).Focus();
      }
      else
      {
        if (((UIElement) this.textBoxSearch).Visibility == Visibility.Collapsed)
          return;
        ((UIElement) this.textBoxSearch).Visibility = Visibility.Collapsed;
        ((UIElement) this.PageTitle).Visibility = Visibility.Visible;
        // AppBarController is WP7-specific, removed for UWP
        this._contactFilter.ClearResult();
        this._contactFilter.OnFilterUpdate -= new ContactsFilter.OnFilterUpdateDelegate(this.OnFilterUpdate);
        ((UIElement) this.noSearchResultText).Visibility = Visibility.Collapsed;
        if (this._isAllContactListOutOfDate && this.pivotContactsType.SelectedIndex == 0 || this._isTangoContactListOutOfDate && this.pivotContactsType.SelectedIndex == 1)
        {
          this.textBoxSearch.Text = string.Empty;
          this.DisplayContactList();
        }
        this.textBoxSearch.Text = string.Empty;
        // Set headers back to original - not directly applicable in UWP
        this.RefreshPagePrompt();
      }
      this.ResetListHeight();
    }

    private void buttonSearch_Click(object sender, RoutedEventArgs e) => this.ShowSearchBox(true);

    private void buttonAdd_Click(object sender, RoutedEventArgs e)
    {
      // SaveContactTask is WP7-specific, replaced with UWP equivalent
      // For now, just log the action
      Logger.Trace("Add contact button clicked - UWP equivalent needed");
    }

    private void saveContactTask_Completed(object sender, object e) // Changed to object type
    {
      // Task handling is different in UWP
      // DriversManager.Instance.ContactsDriver.ClearContactsBuffer();
      // TangoEventPageBase.SendMessage((ISendableMessage) new RequestFilterContactMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      // ((FrameworkElement) this.waitingBar).VerticalAlignment = VerticalAlignment.Top;
      // this.StartLoadingProgress(this.waitingBar);
    }

    private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (this.textBoxSearch.Text.StartsWith("*debug"))
        AppManager.Instance.DataManager.IsEnableOnScreenLog = this.textBoxSearch.Text == "*debug1#";
      this._contactFilter.DoFilter(this.textBoxSearch.Text, 3);
    }

    private void OnFilterUpdate(bool isFinished, bool hasResult, bool hasUncheckedItem)
    {
      ((UIElement) this.noSearchResultText).Visibility = hasResult ? Visibility.Collapsed : Visibility.Visible;
      if (!isFinished)
        return;
      if (this.pivotContactsType.SelectedIndex == 0)
        ((UIElement) this.listSelectorAll).UpdateLayout();
      else
        ((UIElement) this.listSelectorTango).UpdateLayout();
    }

    private void textBoxSearch_LostFocus(object sender, RoutedEventArgs e)
    {
    }

    private void pivotContactsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.DisplayContactList();
      this.ShowSearchBox(false);
    }

    private int pivotContactsTypeSelection
    {
      get => this.pivotContactsType.SelectedIndex;
      set => this.pivotContactsType.SelectedIndex = value;
    }

    private void OnListScrollingStarted(object sender, object e) // Changed to object type
    {
      // Scrolling events are different in UWP
      this._contactFilter.PauseSearching();
      this.HideKeyboard();
    }

    private void OnListScrollingCompleted(object sender, object e) // Changed to object type
    {
      // Scrolling events are different in UWP
      this._contactFilter.ResumeSearching();
    }

    
 }
}
