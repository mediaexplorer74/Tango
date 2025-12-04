// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.DataManager
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System.Collections.Generic;

#nullable disable
namespace WinPhoneTango
{
  public class DataManager
  {
    public DataManager()
    {
      this.PhoneCountryId = "1";
      this.MissedCallCount = 0;
      this.TipsHtmlString = string.Empty;
      this.IsEnableOnScreenLog = false;
    }

    public string PhoneCountryId { get; set; }

    public string SelectedCountryId { get; set; }

    public RegisterUserPayload UserData { get; set; }

    public string LastFormattedNumber { get; set; }

    public bool IsAddressBookLoaded { get; set; }

    public MediaSessionPayload CallingData { get; set; }

    public string RemoteCallingUserDisplayName { get; set; }

    public ContactsPayload ContactList { get; set; }

    public CallEntriesPayload CallLogData { get; set; }

    public bool IsCallLogUpdatedFromServer { get; set; }

    public ContactsPayload SmsContactList { get; set; }

    public InviteEmailSelectionPayload EmailContactList { get; set; }

    public InviteOptionsPayload InviteOptions { get; set; }

    public InviteSMSSelectedPayload SmsInfo { get; set; }

    public InviteEmailComposerPayload EmailInfo { get; set; }

    public ContactsPayload InvitingContact { get; set; }

    public string LastError { get; set; }

    public int MissedCallCount { get; set; }

    public IList<OperationalAlert> AlertsList { get; set; }

    public string TipsHtmlString { get; set; }

    public InCallAlertPayload InCallAlert { get; set; }

    public AudioModePayload.Builder AudioMode { get; set; }

    public VideoModePayload VideoMode { get; set; }

    public bool IsEnableOnScreenLog { get; set; }
  }
}
