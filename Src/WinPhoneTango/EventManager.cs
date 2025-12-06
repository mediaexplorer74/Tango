// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.EventManager
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Reflection;
using Windows.UI.Popups;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;
using Windows.ApplicationModel.Resources;

#nullable disable
namespace WinPhoneTango
{
  public class EventManager : UIManagerInterface
  {
    public const string WELCOME_PAGE = "WelcomePage";
    public const string REGISTER_PAGE = "RegisterPage";
    public const string PROFILE_PAGE = "RegisterPage";
    public const string MAIN_PAGE = "MainPage";
    public const string CONTACT_PAGE = "ContactPage";
    public const string COUNTRY_SELECT_PAGE = "CountrySelectorPage";
    public const string CALLHISTORY_PAGE = "CallHistoryPage";
    public const string INCOMING_CALL_PAGE = "IncomingCallPage";
    public const string DIALING_PAGE = "IncomingCallPage";
    public const string VIDEOCALL_PAGE = "AudioVideoCallPage";
    public const string VIDEOMAIL_PAGE = "VideoMailPage";
    public const string INVITE_CONTACT_PAGE = "InviteContactPage";
    public const string INVITE_PAGE = "InvitePage";
    public const string SETTINGS_PAGE = "SettingsPage";
    public const string TIPS_PAGE = "TipsPage";
    private string _toRemoveNavigationPage;
    private bool _makeCallFromContactList;
    private bool? _isAppStartFromPush = new bool?();
    private object _appStartEventLock = new object();
    private bool _isLoginCompleted;
    private TangoEventPageBase _currentPage;

    public EventManager() => DriversManager.Instance.UIManager = (UIManagerInterface) this;

    public event EventManager.CurrentPageUpdatedDelegate CurrentPageUpdated;

    public override bool? IsAppStartFromPush() => this._isAppStartFromPush;

    public override void ResigerCallEndedCallback(
      UIManagerInterface.CallEndedDelegate callback,
      bool toRegister)
    {
      if (toRegister)
        this.CallEnded += callback;
      else
        this.CallEnded -= callback;
    }

    public event UIManagerInterface.CallEndedDelegate CallEnded;

    public override bool ResigerUIStartedCallback(
      UIManagerInterface.UIStartedDelegate callback,
      bool toRegister)
    {
      if (toRegister)
      {
        lock (this._appStartEventLock)
        {
          if (this._isAppStartFromPush.HasValue)
            return false;
          this.UIStarted += callback;
        }
        return true;
      }
      this.UIStarted -= callback;
      return true;
    }

    public event UIManagerInterface.UIStartedDelegate UIStarted;

    public bool IsLoginCompleted => this._isLoginCompleted;

    public TangoEventPageBase CurrentPage
    {
      get => this._currentPage;
      set
      {
        this._currentPage = value;
        Logger.Trace("CallBackManager.CurrentPage is " + (this._currentPage == null ? "NONE" : ((object) this._currentPage).GetType().Name));
        if (this._currentPage != null && !this._isAppStartFromPush.HasValue)
        {
          lock (this._appStartEventLock)
            this._isAppStartFromPush = new bool?(this.CurrentPageName.Equals("IncomingCallPage"));
          Logger.Trace(string.Format("Start page is {0}, isAppStartFromPush = {1}", (object) this.CurrentPageName, (object) this._isAppStartFromPush));
          if (this.UIStarted != null)
            this.UIStarted();
        }
        if (this._toRemoveNavigationPage != null && this._toRemoveNavigationPage.Length > 0 && this._currentPage != null && this._currentPage.BackEntryPageName.Equals(this._toRemoveNavigationPage))
          this._currentPage.RemoveBackEntry();
        if (this.CurrentPageUpdated == null)
          return;
        this.CurrentPageUpdated();
      }
    }

    public bool HandleTangoEvent(int messageId, byte[] data)
    {
      if (this.CurrentPage == null)
        return false;
      Logger.Trace("get an event from core! (type = " + messageId.ToString() + ", size = " + (object) data.Length + ")");
      switch (messageId)
      {
        case 35003:
          this.NavigateToPage("AudioVideoCallPage", string.Empty, messageId);
          break;
        case 35011:
          if (!this._isLoginCompleted || !this.CurrentPageName.Equals("ContactPage"))
          {
            this._isLoginCompleted = true;
            if (this.CurrentPageName.Equals("InviteContactPage") || this._makeCallFromContactList)
            {
              this._makeCallFromContactList = false;
              this.NavigateToPage("ContactPage", string.Empty, messageId);
              break;
            }
            this.NavigateToPage("MainPage", string.Empty, messageId);
            break;
          }
          break;
        case 35015:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          this.NavigateToPage("IncomingCallPage", IncomingCallPage.NAVIGATION_WAY_PARAM + "=" + IncomingCallPage.NAVIGATION_WAY_TYPE_SEND, messageId);
          break;
        case 35017:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          this.NavigateToPage("IncomingCallPage", IncomingCallPage.NAVIGATION_WAY_PARAM + "=" + IncomingCallPage.NAVIGATION_WAY_TYPE_RECEIVE, messageId);
          break;
        case 35019:
          AppManager.Instance.DataManager.LastError = OptionalPayload.ParseFrom(data).Message;
          this.SendEventToPage("IncomingCallPage", messageId);
          var resourceLoader = ResourceLoader.GetForCurrentView("LangResource");
          var errorMessageKey = AppManager.Instance.DataManager.LastError.ToLower();
          var errorMessage = resourceLoader.GetString(errorMessageKey);
          if (string.IsNullOrEmpty(errorMessage))
              errorMessage = resourceLoader.GetString("call_error_msg");
          var dialog = new MessageDialog(errorMessage, resourceLoader.GetString("call_error_title"));
          dialog.Commands.Add(new UICommand(resourceLoader.GetString("ok_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 0;
          var result = await dialog.ShowAsync();
          TangoEventPageBase.SendMessage((ISendableMessage) new AcknowledgeCallErrorMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          AppManager.Instance.DataManager.CallingData = (MediaSessionPayload) null;
          break;
        case 35021:
        case 35023:
        case 35025:
        case 35069:
        case 35071:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          this.NavigateToPage("AudioVideoCallPage", string.Empty, messageId);
          break;
        case 35027:
          AppManager.Instance.DataManager.UserData = RegisterUserPayload.ParseFrom(data);
          this.NavigateToPage("RegisterPage", RegisterPage.NAVIGATION_EDITMODE_PARAM + "=1");
          break;
        case 35031:
          AppManager.Instance.DataManager.UserData = RegisterUserPayload.ParseFrom(data);
          this.NavigateToPage("RegisterPage");
          break;
        case 35037:
          ContactsPayload from1 = ContactsPayload.ParseFrom(data);
          ContactsSource source = from1.Source;
          if (from1 != null && (AppManager.Instance.DataManager.ContactList == null || !ListComparator<Contact>.ListEqual(AppManager.Instance.DataManager.ContactList.ContactsList, from1.ContactsList)))
          {
            AppManager.Instance.DataManager.ContactList = from1;
            Logger.Trace("update " + AppManager.Instance.DataManager.ContactList.ContactsCount.ToString() + " contacts, from server = " + AppManager.Instance.DataManager.ContactList.FromServer.ToString());
            this.SendEventToPage("ContactPage", messageId);
          }
          else
          {
            if (source != AppManager.Instance.DataManager.ContactList.Source)
            {
              Logger.Trace("no need to update contacts (source changed from " + (object) AppManager.Instance.DataManager.ContactList.Source + "), from server = " + AppManager.Instance.DataManager.ContactList.FromServer.ToString());
              AppManager.Instance.DataManager.ContactList = from1;
            }
            else
              Logger.Trace("no need to update contacts, from server = " + AppManager.Instance.DataManager.ContactList.FromServer.ToString());
            this.SendEventToPage("ContactPage", 1, false);
          }
          Logger.Trace("get UPDATE_TANGO_USERS_TYPE event, source = " + source.ToString() + " AppManager.Instance.DataManager.IsAddressBookLoaded = " + AppManager.Instance.DataManager.IsAddressBookLoaded.ToString());
          if ((source == ContactsSource.LOCAL_STORAGE_ONLY || source == ContactsSource.ADDRESS_BOOK_AND_LOCAL_STORAGE) && !AppManager.Instance.DataManager.IsAddressBookLoaded)
          {
            AppManager.Instance.DataManager.IsAddressBookLoaded = true;
            this.SendEventToPage("IncomingCallPage", 3, false);
            break;
          }
          break;
        case 35038:
          AppManager.Instance.DataManager.AlertsList = UpdateAlertsPayload.ParseFrom(data).AlertsList;
          this.SendEventToPage("SettingsPage", messageId);
          break;
        case 35039:
          AppManager.Instance.DataManager.InviteOptions = InviteOptionsPayload.ParseFrom(data);
          this.NavigateToPage("InvitePage", string.Empty, messageId);
          break;
        case 35041:
          if (!this.CurrentPageName.Equals("InvitePage"))
          {
            this.NavigateToPage("InvitePage");
            break;
          }
          InviteEmailSelectionPayload from2 = InviteEmailSelectionPayload.ParseFrom(data);
          if (from2 != null && (AppManager.Instance.DataManager.EmailContactList == null || !ListComparator<Contact>.ListEqual(AppManager.Instance.DataManager.EmailContactList.ContactList, from2.ContactList)))
          {
            AppManager.Instance.DataManager.EmailContactList = InviteEmailSelectionPayload.ParseFrom(data);
            this.SendEventToPage("InvitePage", messageId);
            break;
          }
          break;
        case 35049:
          AppManager.Instance.DataManager.UserData = RegisterUserPayload.ParseFrom(data);
          this.NavigateToPage("SettingsPage");
          break;
        case 35051:
          this.SendEventToPage("RegisterPage", messageId);
          var dialog = new MessageDialog(ResourceLoader.GetForCurrentView("LangResource").GetString("account_verification_msg"), ResourceLoader.GetForCurrentView("LangResource").GetString("account_verification_title"));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("yes_button")));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("no_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 1;
          var result = await dialog.ShowAsync();
          if (result.Label == ResourceLoader.GetForCurrentView("LangResource").GetString("yes_button"))
          {
            TangoEventPageBase.SendMessage((ISendableMessage) new ValidationRequestMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
            break;
          }
          TangoEventPageBase.SendMessage((ISendableMessage) new EndStateNoChangeMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 35057:
          AppManager.Instance.DataManager.EmailInfo = InviteEmailComposerPayload.ParseFrom(data);
          this.SendEventToPage("InvitePage", messageId);
          this.SendEventToPage("InviteContactPage", messageId);
          break;
        case 35059:
          if (!this.CurrentPageName.Equals("InvitePage"))
          {
            this.NavigateToPage("InvitePage");
            break;
          }
          ContactsPayload from3 = ContactsPayload.ParseFrom(data);
          if (from3 != null && (AppManager.Instance.DataManager.SmsContactList == null || !ListComparator<Contact>.ListEqual(AppManager.Instance.DataManager.SmsContactList.ContactsList, from3.ContactsList)))
          {
            AppManager.Instance.DataManager.SmsContactList = from3;
            this.SendEventToPage("InvitePage", messageId);
            break;
          }
          break;
        case 35061:
          AppManager.Instance.DataManager.SmsInfo = InviteSMSSelectedPayload.ParseFrom(data);
          this.SendEventToPage("InvitePage", messageId);
          this.SendEventToPage("InviteContactPage", messageId);
          break;
        case 35065:
          var dialog = new MessageDialog(OptionalPayload.ParseFrom(data).Message, ResourceLoader.GetForCurrentView("LangResource").GetString("account_verification_title"));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("ok_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 0;
          var result = await dialog.ShowAsync();
          break;
        case 35067:
          this.NavigateToPage("TipsPage");
          break;
        case 35073:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          if (AppManager.Instance.DataManager.CallingData != null)
          {
            var dialog = new MessageDialog(AppManager.Instance.DataManager.CallingData.Displayname + ResourceLoader.GetForCurrentView("LangResource").GetString("ignored_call_text"), ResourceLoader.GetForCurrentView("LangResource").GetString("call_status_ended"));
            dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("ok_button")));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;
            var result = await dialog.ShowAsync();
            TangoEventPageBase.SendMessage((ISendableMessage) new ClearMissedCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
            break;
          }
          break;
        case 35077:
          this.SendEventToPage("AudioVideoCallPage", messageId);
          break;
        case 35079:
          this.SendEventToPage("AudioVideoCallPage", messageId);
          break;
        case 35080:
          AppManager.Instance.DataManager.InCallAlert = InCallAlertPayload.ParseFrom(data);
          this.SendEventToPage("AudioVideoCallPage", messageId);
          break;
        case 35083:
          AudioModePayload from4 = AudioModePayload.ParseFrom(data);
          if (AppManager.Instance.DataManager.AudioMode != null)
            Logger.Trace(string.Format("AudioMode: (Current: mute = {0}, speaker = {1}, devchange = {2})", (object) AppManager.Instance.DataManager.AudioMode.Muted, (object) AppManager.Instance.DataManager.AudioMode.Speakeron, (object) AppManager.Instance.DataManager.AudioMode.Devchange));
          if (AppManager.Instance.DataManager.AudioMode == null || AppManager.Instance.DataManager.AudioMode.Muted != from4.Muted || AppManager.Instance.DataManager.AudioMode.Speakeron != from4.Speakeron)
          {
            AppManager.Instance.DataManager.AudioMode = from4.ToBuilder();
            Logger.Trace(string.Format("AudioMode changed. (Changed to: mute = {0}, speaker = {1}, devchange = {2})", (object) from4.Muted, (object) from4.Speakeron, (object) from4.Devchange));
            this.SendEventToPage("AudioVideoCallPage", messageId);
            break;
          }
          Logger.Trace("AudioMode doesn't change, ignore the event.");
          break;
        case 35085:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          TangoEventPageBase.SendMessage((ISendableMessage) new TerminateCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
          AppManager.Instance.DataManager.CallingData = (MediaSessionPayload) null;
          break;
        case 35087:
          PhoneFormattedPayload from5 = PhoneFormattedPayload.ParseFrom(data);
          AppManager.Instance.DataManager.LastFormattedNumber = from5 != null ? from5.Formattednumber : "";
          this.SendEventToPage("RegisterPage", messageId);
          break;
        case 35088:
          Logger.Trace("Receive a VALIDATION_RESULT_TYPE, type = " + ValidationResultPayload.ParseFrom(data).Result.ToString());
          break;
        case 35089:
          this.SendEventToPage("AudioVideoCallPage", messageId);
          break;
        case 35090:
          this.SendEventToPage("RegisterPage", messageId);
          var dialog = new MessageDialog(ResourceLoader.GetForCurrentView("LangResource").GetString("registration_failed_due_to_network"), ResourceLoader.GetForCurrentView("LangResource").GetString("registration_failed_title"));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("ok_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 0;
          var result = await dialog.ShowAsync();
          TangoEventPageBase.SendMessage((ISendableMessage) new AcknowledgeRegistrationErrorMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 35091:
          AppManager.Instance.DataManager.InvitingContact = ContactsPayload.ParseFrom(data);
          this.NavigateToPage("InviteContactPage");
          break;
        case 35092:
        case 35093:
          CallEntriesPayload from6 = CallEntriesPayload.ParseFrom(data);
          bool flag = from6 != null && (AppManager.Instance.DataManager.CallLogData == null || !ListComparator<CallEntry>.ListEqual(AppManager.Instance.DataManager.CallLogData.EntriesList, from6.EntriesList));
          if (messageId == 35092)
          {
            if (!this.CurrentPageName.Equals("CallHistoryPage"))
              AppManager.Instance.DataManager.IsCallLogUpdatedFromServer = false;
            if (flag)
            {
              AppManager.Instance.DataManager.CallLogData = from6;
              Logger.Trace("display " + AppManager.Instance.DataManager.CallLogData.EntriesCount.ToString() + " call logs, result from = " + AppManager.Instance.DataManager.CallLogData.ResultType.ToString());
              this.NavigateToPage("CallHistoryPage", string.Empty, messageId);
              break;
            }
            this.NavigateToPage("CallHistoryPage");
            break;
          }
          if (from6.ResultType == CallEntriesPayload.Types.ResultType.SERVER)
            AppManager.Instance.DataManager.IsCallLogUpdatedFromServer = true;
          if (flag)
          {
            AppManager.Instance.DataManager.CallLogData = from6;
            Logger.Trace("update " + AppManager.Instance.DataManager.CallLogData.EntriesCount.ToString() + " call logs, result from = " + AppManager.Instance.DataManager.CallLogData.ResultType.ToString());
            this.SendEventToPage("CallHistoryPage", messageId);
            break;
          }
          Logger.Trace("no need to update call logs, result from = " + AppManager.Instance.DataManager.CallLogData.ResultType.ToString());
          this.SendEventToPage("CallHistoryPage", 2, false);
          break;
        case 35100:
          OtherRegisteredDevicePayload.Builder builder = OtherRegisteredDevicePayload.CreateBuilder();
          var dialog = new MessageDialog(ResourceLoader.GetForCurrentView("LangResource").GetString("other_device_msg"), ResourceLoader.GetForCurrentView("LangResource").GetString("other_device_title"));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("yes_button")));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("no_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 1;
          var result = await dialog.ShowAsync();
          if (result.Label == ResourceLoader.GetForCurrentView("LangResource").GetString("yes_button"))
            builder.SetRegistered(true);
          else
            builder.SetRegistered(false);
          TangoEventPageBase.SendMessage((ISendableMessage) new OtherRegisteredDeviceMessage(TangoEventPageBase.GetNextSeqId(), builder));
          break;
        case 35101:
          var dialog = new MessageDialog(ResourceLoader.GetForCurrentView("LangResource").GetString("other_device_del_msg"), ResourceLoader.GetForCurrentView("LangResource").GetString("other_device_del_title"));
          dialog.Commands.Add(new UICommand(ResourceLoader.GetForCurrentView("LangResource").GetString("ok_button")));
          dialog.DefaultCommandIndex = 0;
          dialog.CancelCommandIndex = 0;
          var result = await dialog.ShowAsync();
          TangoEventPageBase.SendMessage((ISendableMessage) new DismissVerificationWithOtherDeviceMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 35113:
          AppManager.Instance.DataManager.CallingData = MediaSessionPayload.ParseFrom(data);
          break;
        case 35117:
          AppManager.Instance.DataManager.MissedCallCount = (int) UnreadMissedCallNumberPayload.ParseFrom(data).Number;
          TangoEventPageBase.UpdateTile(AppManager.Instance.DataManager.MissedCallCount);
          Logger.Trace("Unread Missed calls is: " + (object) AppManager.Instance.DataManager.MissedCallCount);
          this.SendEventToPage("MainPage", messageId);
          break;
        default:
          Logger.Trace("WARNING no handler, message id:" + (object) messageId);
          break;
      }
      return true;
    }

    private string CurrentPageName
    {
      get => this.CurrentPage == null ? string.Empty : ((object) this.CurrentPage).GetType().Name;
    }

    private void CheckIsCallEnded(string targetPageName, string currentPageName)
    {
      if (targetPageName.Equals(currentPageName) || (!currentPageName.Equals("IncomingCallPage") && !currentPageName.Equals("IncomingCallPage") || targetPageName.Equals("AudioVideoCallPage")) && !currentPageName.Equals("AudioVideoCallPage"))
        return;
      Logger.Trace(string.Format("Navigate from {0} to {1} is marked as call ended.", (object) currentPageName, (object) targetPageName));
      if (this.CallEnded == null)
        return;
      this.CallEnded();
    }

    public void NavigateToPage(string targetPageName, string param = "", int messageId = -1)
    {
      INavigatable currentPage = (INavigatable) this.CurrentPage;
      if (this.CurrentPage == null)
        Logger.Trace("UI page is not available, can't navigate to " + targetPageName);
      else if (this.CurrentPageName.Equals(targetPageName))
      {
        Logger.Trace("UI page to be navigated is just the current one (" + targetPageName + ")");
        if (messageId < 0)
          return;
        this.SendEventToPage(targetPageName, messageId);
      }
      else if (currentPage == null)
        Logger.Trace("UI page is not navigatable, can't navigate to " + targetPageName);
      else if (this.CurrentPageName.Equals("CountrySelectorPage") && targetPageName.Equals("RegisterPage") || this.CurrentPageName.Equals("RegisterPage") && targetPageName.Equals("CountrySelectorPage"))
      {
        Logger.Trace("UI page to be navigated is considered the same (from " + this.CurrentPageName + ", to " + targetPageName + ")");
        if (messageId < 0)
          return;
        this.SendEventToPage(targetPageName, messageId);
      }
      else
      {
        this._toRemoveNavigationPage = this.CurrentPage.IsGoBackable ? "" : this.CurrentPageName;
        if (targetPageName.Equals("IncomingCallPage"))
          this._makeCallFromContactList = this.CurrentPageName.Equals("ContactPage");
        this.CurrentPage.SleepIfNeeded();
        if (this.CurrentPage.BackEntryPageName.Equals(targetPageName))
        {
          Logger.Trace("Go back from " + this.CurrentPageName + " to " + targetPageName);
          if (currentPage.GoBack())
          {
            Logger.Trace("Set the current page to null to make the events during the navigation can be queued.");
            this.CheckIsCallEnded(targetPageName, this.CurrentPageName);
            this._currentPage = (TangoEventPageBase) null;
          }
          else
            Logger.Trace("Go back failed, the navigation event has to be ignored.");
        }
        else
        {
          string empty = string.Empty;
          if (messageId >= 0)
          {
            string str = TangoEventPageBase.NAVIGATION_MESSAGE_ID_PARAM + "=" + (object) messageId;
            param = string.IsNullOrEmpty(param) ? str : str + "&" + param;
          }
          Logger.Trace("Navigate from " + this.CurrentPageName + " to " + targetPageName + (string.IsNullOrEmpty(param) ? string.Empty : " with param: " + param));
          string str1 = "/" + targetPageName + ".xaml";
          if (currentPage.Navigate(new Uri(str1 + (!string.IsNullOrEmpty(param) ? "?" + param : string.Empty), UriKind.Relative)))
          {
            Logger.Trace("Set the current page to null to make the events during the navigation can be queued.");
            this.CheckIsCallEnded(targetPageName, this.CurrentPageName);
            this._currentPage = (TangoEventPageBase) null;
          }
          else
            Logger.Trace("Navigate failed, the navigation event has to be ignored.");
        }
      }
    }

    private void SendEventToPage(string targetPageName, int messageId, bool isFromEngine = true)
    {
      if (this.CurrentPage == null)
      {
        Logger.Trace("can't send event #" + messageId.ToString() + (isFromEngine ? string.Empty : "(app)") + " to UI page, since there is no page available.");
      }
      else
      {
        if (targetPageName.Length != 0 && !this.CurrentPageName.Equals(targetPageName))
          return;
        Logger.Trace("send event #" + messageId.ToString() + (isFromEngine ? string.Empty : "(app)") + " to UI page");
        if (isFromEngine)
          this.CurrentPage.HandleTangoEvent(messageId);
        else
          this.CurrentPage.HandleAppEvent(messageId);
      }
    }

    public delegate void CurrentPageUpdatedDelegate();
  }
}
