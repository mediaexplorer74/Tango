// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.PushEventManager
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using Windows.Storage;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class PushEventManager
  {
    public static readonly string LAST_PUSH_TIME = "lastPushTime";

    public void HandlePushEvent(string text1, string text2, string navigationPage)
    {
      if (!string.IsNullOrEmpty(navigationPage))
      {
        string str = navigationPage;
        string empty = string.Empty;
        int length = str.IndexOf(".xaml");
        if (length > 0)
        {
          if (str.Length > length + 6)
          {
            str.Substring(length + 6);
            str = str.Substring(0, length);
            int num = str.LastIndexOf('/');
            if (num >= 0)
              str = str.Substring(num + 1);
          }
          switch (str)
          {
            case "IncomingCallPage":
              if (this.IsTheSameCallPush(navigationPage, true))
                break;
              PutAppInForegroundPayload.Builder builder = PutAppInForegroundPayload.CreateBuilder();
              builder.SetDoLogin(true);
              TangoEventPageBase.SendMessage((ISendableMessage) new PutAppInForegroundMessage(TangoEventPageBase.GetNextSeqId(), builder));
              break;
            case "WelcomePage":
              if (this.GetUriParamValue(navigationPage, WelcomePage.PUSH_PARAM_KEY_PUSH_FLAG).Equals(WelcomePage.PUSH_PARAM_VALUE_PUSH_FLAG))
              {
                string uriParamValue = this.GetUriParamValue(navigationPage, WelcomePage.PUSH_PARAM_KEY_VALIDATION_CODE);
                if (DriversManager.Instance.AudioModeMonitorDriver.IsCallingOrInCall())
                {
                  Logger.Trace(string.Format("The app got a validation code: {0} for PC, however, we are in a call, we have to ignore it.", (object) uriParamValue));
                  break;
                }
                WelcomePage.ShowValidationCode(uriParamValue);
                break;
              }
              Logger.Trace("Unknown welcome page notification.");
              break;
            default:
              Logger.Trace("WARNING: Unknown push messages! no handler.");
              break;
          }
        }
        else
          Logger.Trace("Error page xaml format: " + navigationPage);
      }
      else
        Logger.Trace("A push notification without uri is ignored.");
    }

    private void SaveLastCallPushUri(string uri)
    {
      this.SaveLastCallPushUri(this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_CALLER_JID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_CALL_ID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_SESSION_ID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_TIMESTAMP));
    }

    private void SaveLastCallPushUri(
      string callerJid,
      string callId,
      string sessionId,
      string timestamp)
    {
      ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
      localSettings.Values[IncomingCallPage.PUSH_PARAM_CALLER_JID] = callerJid;
      localSettings.Values[IncomingCallPage.PUSH_PARAM_CALL_ID] = callId;
      localSettings.Values[IncomingCallPage.PUSH_PARAM_SESSION_ID] = sessionId;
      localSettings.Values[IncomingCallPage.PUSH_PARAM_TIMESTAMP] = timestamp;
      localSettings.Values[PushEventManager.LAST_PUSH_TIME] = DateTime.Now.Ticks;
    }

    private bool IsTheSameCallPush(string uri, bool SaveIt)
    {
      return this.IsTheSameCallPush(this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_CALLER_JID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_CALL_ID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_SESSION_ID), this.GetUriParamValue(uri, IncomingCallPage.PUSH_PARAM_TIMESTAMP), SaveIt);
    }

    public bool IsTheSameCallPush(
      string callerJid,
      string callId,
      string sessionId,
      string timestamp,
      bool toSaveIt)
    {
      ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
      if (!localSettings.Values.ContainsKey(PushEventManager.LAST_PUSH_TIME) || !localSettings.Values.ContainsKey(IncomingCallPage.PUSH_PARAM_CALLER_JID) || !localSettings.Values.ContainsKey(IncomingCallPage.PUSH_PARAM_CALL_ID) || !localSettings.Values.ContainsKey(IncomingCallPage.PUSH_PARAM_SESSION_ID) || !localSettings.Values.ContainsKey(IncomingCallPage.PUSH_PARAM_TIMESTAMP))
      {
        if (toSaveIt)
          this.SaveLastCallPushUri(callerJid, callId, sessionId, timestamp);
        Logger.Trace("Setting is not found, treat as a new push call, show it.");
        return false;
      }
      if (DateTime.Now.Subtract(new DateTime((long) localSettings.Values[PushEventManager.LAST_PUSH_TIME])).TotalSeconds > 120.0 || !callerJid.Equals(localSettings.Values[IncomingCallPage.PUSH_PARAM_CALLER_JID]) || !callId.Equals(localSettings.Values[IncomingCallPage.PUSH_PARAM_CALL_ID]) || !sessionId.Equals(localSettings.Values[IncomingCallPage.PUSH_PARAM_SESSION_ID]) || !timestamp.Equals(localSettings.Values[IncomingCallPage.PUSH_PARAM_TIMESTAMP]))
      {
        if (toSaveIt)
          this.SaveLastCallPushUri(callerJid, callId, sessionId, timestamp);
        Logger.Trace("A new push call received, show it.");
        return false;
      }
      Logger.Trace("Do nothing, since the user has already picked up the push call.");
      return true;
    }

    private string GetUriParamValue(string uri, string key)
    {
      int startIndex1 = uri.IndexOf('?');
      if (startIndex1 < 0)
        return string.Empty;
      int num1 = uri.IndexOf(key + (object) '=', startIndex1);
      if (num1 < 0)
        return string.Empty;
      int startIndex2 = num1 + (key.Length + 1);
      int num2 = uri.IndexOf('&', startIndex2);
      return num2 <= 0 ? uri.Substring(startIndex2) : uri.Substring(startIndex2, num2 - startIndex2);
    }
  }
}
