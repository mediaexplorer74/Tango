// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.InvitePage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

//using Microsoft.Phone.Controls;
//using Microsoft.Phone.Shell;
using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

#nullable disable
namespace WinPhoneTango
{
  public partial class InvitePage : TangoEventPageBase
  {
    private const int PIVOT_INDEX_SMS = 0;
    private const int PIVOT_INDEX_EMAIL = 1;
    private const int PIVOT_COUNT = 2;
    private const int VISIBLE_ITEMS_IN_SEARCH_PAGE = 3;
    private ObservableCollection<PublicGrouping<string, DisplayableContact>> _smsContactsByName;
    private ObservableCollection<PublicGrouping<string, DisplayableContact>> _emailContactsByName;
    private ContactsFilter _contactFilter = new ContactsFilter();
    private List<DisplayableContact> _displaySmsContacts;
    private List<DisplayableContact> _displayEmailContacts;
    private int _selectedSmsCount;
    private int _selectedEmailCount;
    private bool _isWaitingForAppBack;
    private bool _isWaitingForEngineResult;
    private PivotItem[] _pivotItems;
    private bool _isSmsListInGroupView;
    private bool _isEmailListInGroupView;
    
    public InvitePage()
    {
      this.IsGoBackable = true;
      this.InitializeComponent();
      this._pivotItems = new PivotItem[2];
      this._pivotItems[0] = ((PresentationFrameworkCollection<object>) this.pivotInviteType.Items)[0] as PivotItem;
      this._pivotItems[1] = ((PresentationFrameworkCollection<object>) this.pivotInviteType.Items)[1] as PivotItem;
      TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSelectionMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      this.buttonPreview = this.ApplicationBar.Buttons[0] as ApplicationBarIconButton;
      this.buttonPreview.Text = ResourceLoader.GetForCurrentView("LangResource").GetString("preview_button");
      this.buttonSearch = this.ApplicationBar.Buttons[1] as ApplicationBarIconButton;
      this.buttonSearch.Text = ResourceLoader.GetForCurrentView("LangResource").GetString("menuitem_search");
      this.buttonCancel = this.ApplicationBar.Buttons[2] as ApplicationBarIconButton;
      this.buttonCancel.Text = ResourceLoader.GetForCurrentView("LangResource").GetString("cancel_button");
      this.InitAppBarController();
    }

    protected override void OnAppBarVisibilityChanged(object sender, EventArgs e)
    {
      base.OnAppBarVisibilityChanged(sender, e);
      this.ResetListHeight();
    }

    protected override void OnInitialized()
    {
      this.InitState();
      this.ApplyThemeColorToResource(((FrameworkElement) this.listSelectorEmail).Resources);
      this.ApplyThemeColorToResource(((FrameworkElement) this.listSelectorSms).Resources);
    }

    private void InitState()
    {
      this._selectedSmsCount = 0;
      this._selectedEmailCount = 0;
      InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
      InviteListHeader.SMSInstance.IsSelectAllChecked = false;
      InviteListHeader.SMSInstance.SelectAllVisible = (Visibility) 1;
      InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
      InviteListHeader.EmailInstance.IsSelectAllChecked = false;
      InviteListHeader.EmailInstance.SelectAllVisible = (Visibility) 1;
      this.LoadSmsContactList();
      this.LoadEmailContactList();
      if (this.pivotInviteType.SelectedIndex == 0)
        ((UIElement) this.listSelectorSms).UpdateLayout();
      else if (this.pivotInviteType.SelectedIndex == 1)
        ((UIElement) this.listSelectorEmail).UpdateLayout();
      this.ResetListHeight();
    }

    private void ResetListHeight()
    {
      if (((FrameworkElement) this).ActualHeight <= 0.0)
        return;
      ((FrameworkElement) this.listSelectorEmail).Height = ((FrameworkElement) this.listSelectorSms).Height = (double) ((int) (((FrameworkElement) this).ActualHeight - UIElementHelper.GetAbsoluteCoordinates((UIElement) this.listSelectorSms).Y) - (this.ApplicationBar == null || !this.ApplicationBar.IsVisible ? 0 : (int) this.ApplicationBar.DefaultSize));
    }

    public override void HandleTangoEvent(int messageId)
    {
      switch (messageId)
      {
        case 35039:
          if (!this._isWaitingForEngineResult)
            break;
          this._isWaitingForEngineResult = false;
          AppManager.Instance.DataManager.SmsContactList = (ContactsPayload) null;
          AppManager.Instance.DataManager.EmailContactList = (InviteEmailSelectionPayload) null;
          this.InitState();
          if (this.pivotInviteType.SelectedIndex == 0)
          {
            TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSelectionMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
            break;
          }
          if (this.pivotInviteType.SelectedIndex != 1)
            break;
          TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailSelectionMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 35041:
          this.StopLoadingProgress();
          this.LoadEmailContactList();
          break;
        case 35057:
          if (this._isWaitingForAppBack)
          {
            this._isWaitingForAppBack = false;
            this._isWaitingForEngineResult = true;
            InviteSendPayload.Builder builder = InviteSendPayload.CreateBuilder();
            builder.SetSuccess(true);
            TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailSendMessage(TangoEventPageBase.GetNextSeqId(), builder));
            break;
          }
          this.Assert((object) AppManager.Instance.DataManager.EmailInfo);
          this._isWaitingForAppBack = true;
          InviteComposer.InviteByEmail(AppManager.Instance.DataManager.EmailInfo.InviteeList);
          break;
        case 35059:
          this.StopLoadingProgress();
          this.LoadSmsContactList();
          break;
        case 35061:
          if (this._isWaitingForAppBack)
          {
            this._isWaitingForAppBack = false;
            this._isWaitingForEngineResult = true;
            InviteSendPayload.Builder builder = InviteSendPayload.CreateBuilder();
            builder.SetSuccess(true);
            TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSendMessage(TangoEventPageBase.GetNextSeqId(), builder));
            break;
          }
          this.Assert((object) AppManager.Instance.DataManager.SmsInfo);
          this._isWaitingForAppBack = true;
          InviteComposer.InviteBySms(AppManager.Instance.DataManager.SmsInfo.ContactList);
          break;
      }
    }

    private void RefreshInvitePrompt(bool isWithMessage)
    {
      if (isWithMessage)
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteDisplayMainMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        if (isWithMessage)
          TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSelectionMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
        if (AppManager.Instance.DataManager.SmsContactList != null)
        {
          ((UIElement) this.PageTitle).Visibility = (Visibility) 0;
          this.PageTitle.Text = AppManager.Instance.DataManager.SmsContactList.ContactsCount == 0 ? ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_empty_prompt") : ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_prompt");
          if (AppManager.Instance.DataManager.SmsContactList.ContactsCount == 0)
            this.AppBarController.DisableButton(this.buttonSearch);
          else
            this.AppBarController.EnableButton(this.buttonSearch);
          if (AppManager.Instance.DataManager.SmsContactList.ContactsCount > 0 || DriversManager.Instance.ContactsDriver.IsContactsLoaded)
            this.StopLoadingProgress();
          else
            this.StartLoadingProgress(this.waitingBar, timeout: 30);
        }
        else
        {
          this.PageTitle.Text = ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_empty_prompt");
          this.AppBarController.DisableButton(this.buttonSearch);
          this.StartLoadingProgress(this.waitingBar, timeout: 30);
        }
        this.ShowPreviewPanel(this._selectedSmsCount > 0);
      }
      else
      {
        if (this.pivotInviteType.SelectedIndex != 1)
          return;
        if (isWithMessage)
          TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailSelectionMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
        if (AppManager.Instance.DataManager.EmailContactList != null)
        {
          ((UIElement) this.PageTitle).Visibility = (Visibility) 0;
          this.PageTitle.Text = AppManager.Instance.DataManager.EmailContactList.ContactCount == 0 ? ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_empty_prompt") : ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_prompt");
          if (AppManager.Instance.DataManager.EmailContactList.ContactCount == 0)
            this.AppBarController.DisableButton(this.buttonSearch);
          else
            this.AppBarController.EnableButton(this.buttonSearch);
          if (AppManager.Instance.DataManager.EmailContactList.ContactCount > 0 || DriversManager.Instance.ContactsDriver.IsContactsLoaded)
            this.StopLoadingProgress();
          else
            this.StartLoadingProgress(this.waitingBar, timeout: 30);
        }
        else
        {
          this.PageTitle.Text = ResourceLoader.GetForCurrentView("LangResource").GetString("invite_contact_empty_prompt");
          this.AppBarController.DisableButton(this.buttonSearch);
          this.StartLoadingProgress(this.waitingBar, timeout: 30);
        }
        this.ShowPreviewPanel(this._selectedEmailCount > 0);
      }
    }

    private bool CurrentInSearchMode() => ((UIElement) this.textBoxSearch).Visibility == 0;

    private void ShowSearchBox(bool isToShow, int renderListIndex)
    {
      if (isToShow)
      {
        if (((UIElement) this.textBoxSearch).Visibility == null)
          return;
        ((UIElement) this.PageTitle).Visibility = (Visibility) 1;
        this.textBoxSearch.Text = string.Empty;
        ((UIElement) this.textBoxSearch).Visibility = (Visibility) 0;
        this._contactFilter.OnFilterUpdate += new ContactsFilter.OnFilterUpdateDelegate(this.OnFilterUpdate);
        if (renderListIndex == 0)
        {
          this._contactFilter.Init(this._smsContactsByName, this._displaySmsContacts, this.listSelectorSms);
          this._pivotItems[1].Header = (object) string.Empty;
          InviteListHeader.SMSInstance.SelectAllVisible = (Visibility) 1;
        }
        else
        {
          this._contactFilter.Init(this._emailContactsByName, this._displayEmailContacts, this.listSelectorEmail);
          this._pivotItems[0].Header = (object) string.Empty;
          InviteListHeader.EmailInstance.SelectAllVisible = (Visibility) 1;
        }
        this.AppBarController.DisableButton(this.buttonSearch);
        ((Control) this.textBoxSearch).Focus();
      }
      else
      {
        if (((UIElement) this.textBoxSearch).Visibility == 1)
          return;
        ((UIElement) this.textBoxSearch).Visibility = (Visibility) 1;
        ((UIElement) this.PageTitle).Visibility = (Visibility) 0;
        ((UIElement) this.noSearchResultText).Visibility = (Visibility) 1;
        this._contactFilter.ClearResult();
        this._contactFilter.OnFilterUpdate -= new ContactsFilter.OnFilterUpdateDelegate(this.OnFilterUpdate);
        this.textBoxSearch.Text = string.Empty;
        this._pivotItems[0].Header = (object) ResourceLoader.GetForCurrentView("LangResource").GetString("invite_sms");
        this._pivotItems[1].Header = (object) ResourceLoader.GetForCurrentView("LangResource").GetString("invite_email");
        switch (renderListIndex)
        {
          case 0:
            this.SelectAllSmsContacts(false);
            InviteListHeader.SMSInstance.SelectAllVisible = (Visibility) 0;
            break;
          case 1:
            this.SelectAllEmailContacts(false);
            InviteListHeader.EmailInstance.SelectAllVisible = (Visibility) 0;
            break;
        }
      }
      this.ResetListHeight();
    }

    private void LoadSmsContactList()
    {
      if (!this.IsLoaded)
        return;
      if (AppManager.Instance.DataManager.SmsContactList != null)
      {
        ContactsDriver contactsDriver = DriversManager.Instance.ContactsDriver;
        this._displaySmsContacts = new List<DisplayableContact>();
        IList<Contact> contactsList = AppManager.Instance.DataManager.SmsContactList.ContactsList;
        for (int index = 0; index < contactsList.Count; ++index)
        {
          DisplayableContact displayableContact = new DisplayableContact();
          Contact contact = contactsList[index];
          displayableContact.ContactData = contact;
          displayableContact.PutNameEx(contact.Firstname, contact.Lastname, contact.PhoneNumber, contact.Email);
          displayableContact.PutName(contactsDriver.GetDisplayNameByDeviceContactId(contact.DeviceContactId, displayableContact.Name));
          displayableContact.AccountId = contact.Accountid;
          displayableContact.IsSelected = false;
          if (contact.PhoneNumber != null && contact.PhoneNumber.SubscriberNumber != null)
            displayableContact.InviteeInfo = contact.PhoneNumber.SubscriberNumber;
          this._displaySmsContacts.Add(displayableContact);
        }
        InviteListHeader.SMSInstance.SelectAllVisible = contactsList.Count == 0 ? (Visibility) 1 : (Visibility) 0;
        this._selectedSmsCount = 0;
        this.RenderSmsContactsList();
      }
      this.RefreshInvitePrompt(false);
    }

    private void LoadEmailContactList()
    {
      if (!this.IsLoaded)
        return;
      if (AppManager.Instance.DataManager.EmailContactList != null)
      {
        ContactsDriver contactsDriver = DriversManager.Instance.ContactsDriver;
        this._displayEmailContacts = new List<DisplayableContact>();
        IList<Contact> contactList = AppManager.Instance.DataManager.EmailContactList.ContactList;
        IList<bool> selectedList = AppManager.Instance.DataManager.EmailContactList.SelectedList;
        this._selectedEmailCount = 0;
        for (int index = 0; index < contactList.Count; ++index)
        {
          DisplayableContact displayableContact = new DisplayableContact();
          Contact contact = contactList[index];
          displayableContact.ContactData = contact;
          displayableContact.PutNameEx(contact.Firstname, contact.Lastname, contact.PhoneNumber, contact.Email);
          displayableContact.PutName(contactsDriver.GetDisplayNameByDeviceContactId(contact.DeviceContactId, displayableContact.Name));
          displayableContact.AccountId = contact.Accountid;
          displayableContact.IsSelected = selectedList[index];
          if (contact.Email != null)
            displayableContact.InviteeInfo = contact.Email;
          this._displayEmailContacts.Add(displayableContact);
          if (selectedList[index])
            ++this._selectedEmailCount;
        }
        InviteListHeader.EmailInstance.SelectAllVisible = contactList.Count == 0 ? (Visibility) 1 : (Visibility) 0;
        this.RenderEmailContactsList();
      }
      this.RefreshInvitePrompt(false);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      this.listSelectorSms.SelectedItem = (object) null;
      this.listSelectorEmail.SelectedItem = (object) null;
      base.OnNavigatedFrom(e);
    }

    private void pivotInviteType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      int selectedPivotIndex = this.GetPreviousSelectedPivotIndex();
      this.ShowSearchBox(false, selectedPivotIndex);
      this.buttonPreview.IconUri = selectedPivotIndex != 1 
                ? new Uri("/Assets/Resources/icon_send_email.png", UriKind.Relative) 
                : new Uri("/Assets/Resources/icon_send_sms.png", UriKind.Relative);
      this.RefreshInvitePrompt(true);
    }

    private int GetPreviousSelectedPivotIndex() => 1 - this.pivotInviteType.SelectedIndex;

    private void RenderSmsContactsList()
    {
      this._smsContactsByName = DisplayableContact.SortByName(this._displaySmsContacts);
      if (((UIElement) this.textBoxSearch).Visibility == null)
        this.listSelectorSms.ItemsSource = (IEnumerable) this._displaySmsContacts;
      else
        this.listSelectorSms.ItemsSource = (IEnumerable) this._smsContactsByName;
    }

    private void RenderEmailContactsList()
    {
      this._emailContactsByName = DisplayableContact.SortByName(this._displayEmailContacts);
      if (((UIElement) this.textBoxSearch).Visibility == null)
        this.listSelectorEmail.ItemsSource = (IEnumerable) this._displayEmailContacts;
      else
        this.listSelectorEmail.ItemsSource = (IEnumerable) this._emailContactsByName;
    }

    private void SelectAllSmsContacts(bool IsToSelect)
    {
      if (IsToSelect)
      {
        InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
        InviteListHeader.SMSInstance.IsSelectAllChecked = true;
        this._selectedSmsCount = 0;
        for (int index = 0; index < this._displaySmsContacts.Count; ++index)
        {
          if (this._displaySmsContacts[index].Visibility == null)
          {
            if (!this._displaySmsContacts[index].IsSelected)
              this._displaySmsContacts[index].IsSelected = true;
            else
              ++this._selectedSmsCount;
          }
        }
      }
      else
      {
        InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        InviteListHeader.SMSInstance.IsSelectAllChecked = false;
        for (int index = 0; index < this._displaySmsContacts.Count; ++index)
        {
          if (this._displaySmsContacts[index].Visibility == null)
            this._displaySmsContacts[index].IsSelected = false;
        }
        this._selectedSmsCount = 0;
      }
      this.ShowPreviewPanel(IsToSelect);
    }

    private void checkBoxSmsHeader_Checked(object sender, RoutedEventArgs e)
    {
      if (InviteListHeader.SMSInstance.IsSelectAllChecked)
        return;
      this.SelectAllSmsContacts(true);
    }

    private void checkBoxSmsHeader_Unchecked(object sender, RoutedEventArgs e)
    {
      if (!InviteListHeader.SMSInstance.IsSelectAllChecked)
        return;
      this.SelectAllSmsContacts(false);
    }

    private void SelectAllEmailContacts(bool IsToSelect)
    {
      if (IsToSelect)
      {
        InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
        InviteListHeader.EmailInstance.IsSelectAllChecked = true;
        this._selectedEmailCount = 0;
        for (int index = 0; index < this._displayEmailContacts.Count; ++index)
        {
          if (!this._displayEmailContacts[index].IsSelected)
            this._displayEmailContacts[index].IsSelected = true;
          else
            ++this._selectedEmailCount;
        }
      }
      else
      {
        InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        InviteListHeader.EmailInstance.IsSelectAllChecked = false;
        for (int index = 0; index < this._displayEmailContacts.Count; ++index)
          this._displayEmailContacts[index].IsSelected = false;
        this._selectedEmailCount = 0;
      }
      this.ShowPreviewPanel(IsToSelect);
    }

    private void checkBoxEmailHeader_Checked(object sender, RoutedEventArgs e)
    {
      if (InviteListHeader.EmailInstance.IsSelectAllChecked)
        return;
      this.SelectAllEmailContacts(true);
    }

    private void checkBoxEmailHeader_Unchecked(object sender, RoutedEventArgs e)
    {
      if (!InviteListHeader.EmailInstance.IsSelectAllChecked)
        return;
      this.SelectAllEmailContacts(false);
    }

    private void checkBoxListItem_Loaded(object sender, RoutedEventArgs e)
    {
      if (!(sender is CheckBox checkBox))
        return;
      checkBox.Checked += new RoutedEventHandler(this.checkBoxListItem_Checked);
      checkBox.Unchecked += new RoutedEventHandler(this.checkBoxListItem_Unchecked);
    }

    private void checkBoxListItem_UnLoaded(object sender, RoutedEventArgs e)
    {
      if (!(sender is CheckBox checkBox))
        return;
      ((ToggleButton) checkBox).Checked -= new RoutedEventHandler(this.checkBoxListItem_Checked);
      ((ToggleButton) checkBox).Unchecked -= new RoutedEventHandler(this.checkBoxListItem_Unchecked);
    }

    private void checkBoxListItem_Checked(object sender, RoutedEventArgs e)
    {
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        ++this._selectedSmsCount;
        int count = this._displaySmsContacts != null ? this._displaySmsContacts.Count : 0;
        if (this._selectedSmsCount >= count)
        {
          this._selectedSmsCount = count;
          InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
          InviteListHeader.SMSInstance.IsSelectAllChecked = true;
        }
      }
      else if (this.pivotInviteType.SelectedIndex == 1)
      {
        ++this._selectedEmailCount;
        int count = this._displayEmailContacts != null ? this._displayEmailContacts.Count : 0;
        if (this._selectedEmailCount >= count)
        {
          this._selectedEmailCount = count;
          InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
          InviteListHeader.EmailInstance.IsSelectAllChecked = true;
        }
      }
      this.ShowPreviewPanel(true);
    }

    private void checkBoxListItem_Unchecked(object sender, RoutedEventArgs e)
    {
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        --this._selectedSmsCount;
        if (this._selectedSmsCount > 0)
          return;
        this._selectedSmsCount = 0;
        InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        InviteListHeader.SMSInstance.IsSelectAllChecked = false;
        this.ShowPreviewPanel(false);
      }
      else
      {
        if (this.pivotInviteType.SelectedIndex != 1)
          return;
        --this._selectedEmailCount;
        if (this._selectedEmailCount > 0)
          return;
        this._selectedEmailCount = 0;
        InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        InviteListHeader.EmailInstance.IsSelectAllChecked = false;
        this.ShowPreviewPanel(false);
      }
    }

    private void textListItem_Tap(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxListItem", e);
    }

    private void textListItem_Hold(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxListItem", e);
    }

    private void checkBoxEmailHeaderText_Tap(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxEmailHeader", e);
    }

    private void checkBoxEmailHeaderText_Hold(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxEmailHeader", e);
    }

    private void checkBoxSMSHeaderText_Tap(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxSmsHeader", e);
    }

    private void checkBoxSMSHeaderText_Hold(object sender, GestureEventArgs e)
    {
      this.OnCheckBoxRelatedElementTapped(sender as FrameworkElement, "checkBoxSmsHeader", e);
    }

    private void OnCheckBoxRelatedElementTapped(
      FrameworkElement ralatedElement,
      string specifiedCheckBoxName = "",
      GestureEventArgs e = null)
    {
      if (ralatedElement == null || !(ralatedElement.Parent is Panel parent))
        return;
      checkBox = (CheckBox) null;
      for (int index = 0; index < ((PresentationFrameworkCollection<UIElement>) parent.Children).Count && (!(((PresentationFrameworkCollection<UIElement>) parent.Children)[index] is CheckBox checkBox) || !string.IsNullOrEmpty(specifiedCheckBoxName) && !((FrameworkElement) checkBox).Name.Equals(specifiedCheckBoxName)); ++index)
        checkBox = (CheckBox) null;
      if (checkBox == null)
        return;
      bool? isChecked = ((ToggleButton) checkBox).IsChecked;
      if (isChecked.HasValue)
      {
        bool? nullable = isChecked;
        if ((nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        {
          ((ToggleButton) checkBox).IsChecked = new bool?(false);
          goto label_9;
        }
      }
      ((ToggleButton) checkBox).IsChecked = new bool?(true);
label_9:
      if (e == null)
        return;
      e.Handled = true;
    }

    private void ShowPreviewPanel(bool IsToShow)
    {
      if (IsToShow)
      {
        this.AppBarController.EnableButton(this.buttonPreview);
        this.AppBarController.EnableButton(this.buttonCancel);
      }
      else
      {
        this.AppBarController.DisableButton(this.buttonPreview);
        this.AppBarController.DisableButton(this.buttonCancel);
      }
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      if (((UIElement) this.textBoxSearch).Visibility == null)
      {
        e.Cancel = true;
        this.ShowSearchBox(false, this.pivotInviteType.SelectedIndex);
        this.RefreshInvitePrompt(false);
      }
      else
      {
        if (this._isSmsListInGroupView || this._isEmailListInGroupView)
          return;
        e.Cancel = true;
        if (this.WaitingForClickResult)
          return;
        this.WaitingForClickResult = true;
        AppManager.Instance.DataManager.SmsContactList = (ContactsPayload) null;
        AppManager.Instance.DataManager.EmailContactList = (InviteEmailSelectionPayload) null;
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteDisplayMainMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
        TangoEventPageBase.SendMessage((ISendableMessage) new ContactsDisplayMainMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      }
    }

    private void previewButton_Click(object sender, EventArgs e)
    {
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        InviteSMSSelectedPayload.Builder builder = InviteSMSSelectedPayload.CreateBuilder();
        IList<Contact> contactsList = AppManager.Instance.DataManager.SmsContactList.ContactsList;
        for (int index = 0; index < this._displaySmsContacts.Count; ++index)
        {
          if (this._displaySmsContacts[index].IsSelected)
          {
            Contact contactData = this._displaySmsContacts[index].ContactData;
            this.Assert((object) contactData);
            if (contactData != null)
              builder.AddContact(contactData);
          }
        }
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSelectedMessage(TangoEventPageBase.GetNextSeqId(), builder));
      }
      else if (this.pivotInviteType.SelectedIndex == 1)
      {
        InviteContactsSelectedPayload.Builder builder1 = InviteContactsSelectedPayload.CreateBuilder();
        IList<Contact> contactList = AppManager.Instance.DataManager.EmailContactList.ContactList;
        for (int index = 0; index < this._displayEmailContacts.Count; ++index)
        {
          if (this._displayEmailContacts[index].IsSelected)
          {
            Contact contactData = this._displayEmailContacts[index].ContactData;
            this.Assert((object) contactData);
            if (contactData != null)
            {
              Invitee.Builder builder2 = Invitee.CreateBuilder();
              builder2.SetEmail(contactData.Email);
              builder2.SetFirstname(contactData.Firstname);
              builder2.SetLastname(contactData.Lastname);
              if (contactData.PhoneNumber != null)
                builder2.SetPhonenumber(contactData.PhoneNumber.SubscriberNumber);
              builder1.AddInvitee(builder2.Build());
            }
          }
        }
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailComposerMessage(TangoEventPageBase.GetNextSeqId(), builder1));
      }
      if (!this.CurrentInSearchMode())
        return;
      this.ShowSearchBox(false, this.pivotInviteType.SelectedIndex);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        this.SelectAllSmsContacts(false);
      }
      else
      {
        if (this.pivotInviteType.SelectedIndex != 1)
          return;
        this.SelectAllEmailContacts(false);
      }
    }

    private void buttonSearch_Click(object sender, EventArgs e)
    {
      this.ShowSearchBox(true, this.pivotInviteType.SelectedIndex);
    }

    private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
      this._contactFilter.DoFilter(this.textBoxSearch.Text, 3);
    }

    private void OnFilterUpdate(bool isFinished, bool hasResult, bool hasUncheckedItem)
    {
      ((UIElement) this.noSearchResultText).Visibility = hasResult ? (Visibility) 1 : (Visibility) 0;
      if (!isFinished)
        return;
      if (this.pivotInviteType.SelectedIndex == 0)
      {
        if (this._contactFilter.HasUncheckedItem)
        {
          InviteListHeader.SMSInstance.IsSelectAllChecked = false;
          InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        }
        else
        {
          InviteListHeader.SMSInstance.IsSelectAllChecked = true;
          InviteListHeader.SMSInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
        }
        ((UIElement) this.listSelectorSms).UpdateLayout();
      }
      else
      {
        if (this.pivotInviteType.SelectedIndex != 1)
          return;
        if (this._contactFilter.HasUncheckedItem)
        {
          InviteListHeader.EmailInstance.IsSelectAllChecked = false;
          InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("select_all");
        }
        else
        {
          InviteListHeader.EmailInstance.IsSelectAllChecked = true;
          InviteListHeader.EmailInstance.SelectAllText = ResourceLoader.GetForCurrentView("LangResource").GetString("unselect_all");
        }
        ((UIElement) this.listSelectorEmail).UpdateLayout();
      }
    }

    private void OnListScrollingStarted(object sender, EventArgs e)
    {
      this._contactFilter.PauseSearching();
      this.HideKeyboard();
    }

    private void OnListScrollingCompleted(object sender, EventArgs e)
    {
      this._contactFilter.ResumeSearching();
    }

    private void listSelectorSms_GroupViewOpened(object sender, GroupViewOpenedEventArgs e)
    {
      this._isSmsListInGroupView = true;
    }

    private void listSelectorSms_GroupViewClosing(object sender, GroupViewClosingEventArgs e)
    {
      this._isSmsListInGroupView = false;
    }

    private void listSelectorEmail_GroupViewOpened(object sender, GroupViewOpenedEventArgs e)
    {
      this._isEmailListInGroupView = true;
    }

    private void listSelectorEmail_GroupViewClosing(object sender, GroupViewClosingEventArgs e)
    {
      this._isEmailListInGroupView = false;
    }

    private void smsListHeader_tap(object sender, GestureEventArgs e) => e.Handled = false;

    
  }
}
