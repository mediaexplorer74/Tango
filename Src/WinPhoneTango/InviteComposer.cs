// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.InviteComposer
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using Windows.ApplicationModel.Chat;
using Windows.ApplicationModel.Email;
using sgiggle.xmpp;
using System.Collections.Generic;
using Tango.Toolbox;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public class InviteComposer
  {
    private const int MAX_SMS_INVITE_LENGTH = 1600;
    private const int MAX_EMAIL_INVITE_LENGTH = 32000;

    public static void InviteBySms(IList<object> contactList)
    {
      SmsComposeTask smsComposeTask1 = new SmsComposeTask();
      smsComposeTask1.To = string.Empty;
      for (int index = 0; index < contactList.Count; ++index)
      {
        if (contactList[index].PhoneNumber != null && !string.IsNullOrEmpty(contactList[index].PhoneNumber.SubscriberNumber))
        {
          if (smsComposeTask1.To.Length + contactList[index].PhoneNumber.SubscriberNumber.Length > 1600)
          {
            Logger.Trace("Sms \"to\" field exceeds max length, cut it.");
            break;
          }
          SmsComposeTask smsComposeTask2 = smsComposeTask1;
          smsComposeTask2.To = smsComposeTask2.To + contactList[index].PhoneNumber.SubscriberNumber + ";";
        }
      }
      smsComposeTask1.Body = LangResource.invite_sms_body;
      smsComposeTask1.Show();
    }

    public static void InviteByEmail(IList<object> inviteeList)
    {
      EmailComposeTask emailComposeTask1 = new EmailComposeTask();
      emailComposeTask1.To = string.Empty;
      for (int index = 0; index < inviteeList.Count; ++index)
      {
        if (inviteeList[index].Email != null && inviteeList[index].Email.Length > 0)
        {
          if (emailComposeTask1.To.Length + inviteeList[index].Email.Length >= 32000)
          {
            Logger.Trace("Emal \"to\" field exceeds max length, cut it.");
            break;
          }
          EmailComposeTask emailComposeTask2 = emailComposeTask1;
          emailComposeTask2.To = emailComposeTask2.To + inviteeList[index].Email + ";";
        }
      }
      emailComposeTask1.Subject = LangResource.invite_email_subject;
      emailComposeTask1.Body = LangResource.invite_email_body;
      emailComposeTask1.Show();
    }
  }
}
