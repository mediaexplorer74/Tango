// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.IncomingCallPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using Microsoft.Phone.Controls;
using sgiggle.xmpp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public partial class IncomingCallPage : TangoEventPageBase
  {
    public static readonly string NAVIGATION_WAY_PARAM = "way";
    public static readonly string NAVIGATION_WAY_TYPE_SEND = "send";
    public static readonly string NAVIGATION_WAY_TYPE_RECEIVE = "recv";
    public static readonly string NAVIGATION_WAY_TYPE_PUSH = "push";
    public static readonly string PUSH_PARAM_CALLER_JID = "callerId";
    public static readonly string PUSH_PARAM_CALLER_AID = "callerAcctId";
    public static readonly string PUSH_PARAM_CALL_ID = "cid";
    public static readonly string PUSH_PARAM_SESSION_ID = "sid";
    public static readonly string PUSH_PARAM_TIMESTAMP = "timestamp";
    public static readonly string PUSH_PARAM_DISPLAY_NAME = nameof (callerName);
    private IncomingCallPage.PageType? _pageType = new IncomingCallPage.PageType?();
    private bool _remotePhotoInQuery;
    

    public IncomingCallPage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      if (this._pageType.HasValue)
        return;
      string way = IncomingCallPage.NAVIGATION_WAY_TYPE_SEND;
      if (((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.NAVIGATION_WAY_PARAM))
        way = ((Page) this).NavigationContext.QueryString[IncomingCallPage.NAVIGATION_WAY_PARAM].ToLower();
      this.Init(way);
    }

    private void Init(string way)
    {
      if (way.Equals(IncomingCallPage.NAVIGATION_WAY_TYPE_PUSH))
      {
        this._pageType = new IncomingCallPage.PageType?(IncomingCallPage.PageType.Push);
        this.callType.Text = LangResource.push_call_alert;
        ((UIElement) this.panelAnswerOrNot).Visibility = (Visibility) 0;
        ((UIElement) this.panelEndCall).Visibility = (Visibility) 1;
        string callerJid = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_CALLER_JID) ? ((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_CALLER_JID] : string.Empty;
        string str1 = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_CALLER_AID) ? ((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_CALLER_AID] : string.Empty;
        string callId = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_CALL_ID) ? ((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_CALL_ID] : string.Empty;
        string sessionId = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_SESSION_ID) ? ((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_SESSION_ID] : string.Empty;
        string str2 = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_DISPLAY_NAME) ? ((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_DISPLAY_NAME] : string.Empty;
        this.callerName.Text = str2;
        AppManager.Instance.DataManager.RemoteCallingUserDisplayName = str2;
        int num = ((Page) this).NavigationContext.QueryString.ContainsKey(IncomingCallPage.PUSH_PARAM_TIMESTAMP) ? int.Parse(((Page) this).NavigationContext.QueryString[IncomingCallPage.PUSH_PARAM_TIMESTAMP]) : 0;
        Logger.Trace("callerJId=" + callerJid + " callerAId=" + str1 + " callId=" + callId + " sessionId=" + sessionId + " displayName=" + str2 + " timeStamp=" + num.ToString());
        if (AppManager.Instance.PushEventManager.IsTheSameCallPush(callerJid, callId, sessionId, num.ToString(), true))
        {
          AppManager.Instance.Start();
          return;
        }
        MediaSessionPayload.Builder builder1 = MediaSessionPayload.CreateBuilder();
        builder1.SetAccountId(str1);
        builder1.SetDisplayname(str2);
        builder1.SetFromUi(true);
        builder1.SetCallid(callId);
        builder1.SetSessionId(sessionId);
        AppManager.Instance.DataManager.CallingData = (MediaSessionPayload) new MakeCallMessage(TangoEventPageBase.GetNextSeqId(), builder1).MsgPayload;
        LoginCallPayload.Builder builder2 = LoginCallPayload.CreateBuilder();
        builder2.SetFromUI(true);
        builder2.SetPresent(true);
        builder2.SetPeername(callerJid);
        builder2.SetCallid(callId);
        builder2.SetSessionid(sessionId);
        builder2.SetUsername(str2);
        builder2.SetNotificationtimestamp(num);
        TangoEventPageBase.SendMessage((ISendableMessage) new LoginNotificationMessage(TangoEventPageBase.GetNextSeqId(), builder2));
        AppManager.Instance.Start(false);
      }
      else if (AppManager.Instance.DataManager.CallingData != null)
      {
        AppManager.Instance.DataManager.RemoteCallingUserDisplayName = AppManager.Instance.DataManager.CallingData.Displayname;
        if (way.Equals(IncomingCallPage.NAVIGATION_WAY_TYPE_RECEIVE))
        {
          this.callerName.Text = AppManager.Instance.DataManager.CallingData.Displayname;
          this._pageType = new IncomingCallPage.PageType?(IncomingCallPage.PageType.RecvCall);
          this.callType.Text = LangResource.receiver_call_alert;
          ((UIElement) this.panelAnswerOrNot).Visibility = (Visibility) 0;
          ((UIElement) this.panelEndCall).Visibility = (Visibility) 1;
        }
        else if (way.Equals(IncomingCallPage.NAVIGATION_WAY_TYPE_SEND))
        {
          this.calleeName.Text = AppManager.Instance.DataManager.CallingData.Displayname;
          this._pageType = new IncomingCallPage.PageType?(IncomingCallPage.PageType.SendCall);
          this.callType.Text = LangResource.call_status_pre_dialing;
          ((UIElement) this.panelAnswerOrNot).Visibility = (Visibility) 1;
          ((UIElement) this.panelEndCall).Visibility = (Visibility) 0;
        }
      }
      this.LoadRemoteUserPhoto();
    }

    private void LoadRemoteUserPhoto()
    {
      if (AppManager.Instance.DataManager.CallingData == null)
        return;
      if (ContactsDriver.IsValidDeviceContactId(AppManager.Instance.DataManager.CallingData.DeviceContactId))
      {
        BitmapImage byDeviceContactId = DriversManager.Instance.ContactsDriver.GetPhotoByDeviceContactId(AppManager.Instance.DataManager.CallingData.DeviceContactId);
        if (byDeviceContactId == null)
          return;
        this.remotePhoto.Source = (ImageSource) byDeviceContactId;
      }
      else
      {
        if (string.IsNullOrEmpty(AppManager.Instance.DataManager.CallingData.AccountId) || this._remotePhotoInQuery || !AppManager.Instance.DataManager.IsAddressBookLoaded)
          return;
        this._remotePhotoInQuery = true;
        DriversManager.Instance.ContactsDriver.QueryPhotoByContactAsync(this.GetTangoContactByAccountId(AppManager.Instance.DataManager.CallingData.AccountId), new ContactsDriver.OnUserPhotoReadyDelegate(this.ContactsDriver_OnUserPhotoReady));
      }
    }

    private void ContactsDriver_OnUserPhotoReady(BitmapImage image)
    {
      if (!this._remotePhotoInQuery)
        return;
      if (image != null)
        this.remotePhoto.Source = (ImageSource) image;
      this._remotePhotoInQuery = false;
    }

    private Contact GetTangoContactByAccountId(string accountId)
    {
      Logger.Trace("[GetTangoContactByAccountId] accountId = " + accountId);
      if (string.IsNullOrEmpty(accountId))
        return (Contact) null;
      if (AppManager.Instance.DataManager.ContactList == null)
      {
        Logger.Trace("[GetTangoContactByAccountId] ContactList is null");
        return (Contact) null;
      }
      IEnumerator<Contact> enumerator = AppManager.Instance.DataManager.ContactList.ContactsList.GetEnumerator();
      while (enumerator.MoveNext())
      {
        Contact current = enumerator.Current;
        if (accountId.Equals(current.Accountid))
          return current;
      }
      return (Contact) null;
    }

    public override void HandleTangoEvent(int messageId)
    {
      switch (messageId)
      {
        case 35003:
        case 35021:
          Logger.Trace("Process Event SEND_CALL_ACCEPTED_TYPE");
          this.callType.Text = LangResource.call_status_connecting;
          ((UIElement) this.panelAnswerOrNot).Visibility = (Visibility) 1;
          ((UIElement) this.panelEndCall).Visibility = (Visibility) 0;
          break;
        case 35015:
          this.callType.Text = LangResource.sender_call_alert;
          break;
        case 35017:
          this.Init(IncomingCallPage.NAVIGATION_WAY_TYPE_RECEIVE);
          break;
        case 35019:
          this.callType.Text = LangResource.call_error_title;
          ((UIElement) this.callType).UpdateLayout();
          break;
      }
    }

    public override void HandleAppEvent(int messageId)
    {
      if (messageId != 3)
        return;
      this.LoadRemoteUserPhoto();
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      e.Cancel = true;
      if (this.IsRejectCallAvailable())
        this.RejectCall();
      else if (this.IsEndCallAvailable())
        this.EndCall();
      else
        Logger.Trace("[IncomingCallPage::OnBackKeyPress] Wrong calling state got");
    }

    private bool IsRejectCallAvailable() => ((UIElement) this.panelAnswerOrNot).Visibility == 0;

    private bool IsEndCallAvailable() => ((UIElement) this.panelEndCall).Visibility == 0;

    private void buttonEndCall_Click(object sender, RoutedEventArgs e) => this.EndCall();

    private void EndCall()
    {
      if (this.WaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
      if (AppManager.Instance.DataManager.CallingData == null)
        return;
      TangoEventPageBase.SendMessage((ISendableMessage) new TerminateCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
    }

    private void buttonAcceptCall_Click(object sender, RoutedEventArgs e)
    {
      if (this.WaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
      this.Assert((object) AppManager.Instance.DataManager.CallingData);
      if (AppManager.Instance.DataManager.CallingData == null)
        return;
      TangoEventPageBase.SendMessage((ISendableMessage) new AcceptCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
    }

    private void buttonRejectCall_Click(object sender, RoutedEventArgs e) => this.RejectCall();

    private void RejectCall()
    {
      if (this.WaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
      this.Assert((object) AppManager.Instance.DataManager.CallingData);
      this.callType.Text = LangResource.call_status_ended;
      IncomingCallPage.PageType? pageType = this._pageType;
      if ((pageType.GetValueOrDefault() != IncomingCallPage.PageType.Push ? 0 : (pageType.HasValue ? 1 : 0)) != 0)
      {
        ((ISoundEffPlayerDriver) DriversManager.Instance.SoundEffPlayerDriver).Stop();
        ((UIElement) this.panelAnswerOrNotButtons).Visibility = (Visibility) 1;
        this.waitingBar.IsIndeterminate = true;
        ((UIElement) this.waitingBar).Visibility = (Visibility) 0;
        ((DependencyObject) this).Dispatcher.BeginInvoke((Action) (() =>
        {
          if (AppManager.Instance.DataManager.CallingData != null)
            TangoEventPageBase.SendMessage((ISendableMessage) new RejectCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
          Logger.Trace("Reject push call, delay a while to quit app.");
          Thread.Sleep(4000);
          Logger.Trace("Start to quit app, as user rejected push call.");
          App.Quit();
        }));
      }
      else
      {
        if (AppManager.Instance.DataManager.CallingData == null)
          return;
        TangoEventPageBase.SendMessage((ISendableMessage) new RejectCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
      }
    }

    

    private enum PageType
    {
      SendCall,
      RecvCall,
      Push,
    }
  }
}
