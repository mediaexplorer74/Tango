// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.ToastNotificationClientImpl
// Assembly: WinPhoneTango, Version=1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using Windows.UI.Xaml;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class ToastNotificationClientImpl : ToastNotificationClientBase
  {
    private const string CHANNEL_NAME = "Tango.Me.WinPhone.Channel";

    public ToastNotificationClientImpl()
      : base("Tango.Me.WinPhone.Channel")
    {
    }

    public new void Init(string serviceName)
    {
      base.Init(serviceName);
      if (this.Type == ToastNotificationClientBase.ChannelType.ExistChannelExistUri)
        Logger.Trace("The push channel already exists, just use it and get the Uri directly.");
      else if (this.Type == ToastNotificationClientBase.ChannelType.ExistChannelNewUri)
      {
        Logger.Trace("The push channel already exists, but can't find uri!!!");
      }
      else
      {
        if (this.Type != ToastNotificationClientBase.ChannelType.NewChannel)
          return;
        Logger.Trace("The push channel is not found, create a new one.");
      }
    }

    protected override void UpdateDeviceToken()
    {
      Logger.Trace("URI = " + this.DeviceToken);
      if (this.DeviceToken.Length <= 0)
        return;
      TangoDeviceTokenPayload.Builder builder = TangoDeviceTokenPayload.CreateBuilder();
      builder.SetDevicetoken(this.DeviceToken);
      builder.SetDevicetokentype(DeviceTokenType.DEVICE_TOKEN_WINPHONE); // This might need to be updated to UWP token type
      TangoEventPageBase.SendMessage((ISendableMessage) new TangoDeviceTokenMessage(TangoEventPageBase.GetNextSeqId(), builder));
    }

    protected override void ShellToastNotificationReceived(
      string text1,
      string text2,
      string relativeUri)
    {
      Logger.Trace("A push message (" + text1 + " " + text2 + ") is received: " + relativeUri);
      var dispatcher = Window.Current?.Dispatcher;
      if (dispatcher != null)
      {
        dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
          AppManager.Instance.PushEventManager.HandlePushEvent(text1, text2, relativeUri);
        });
      }
      else
        Logger.Trace("Dispatcher is not available, we have to skip the push message.");
    }

    protected override void OnChannelErrorOccurred(object e) // Changed parameter type as NotificationChannelErrorEventArgs is WP7-specific
    {
      Logger.Trace("A push notification error occurred.");
    }
  }
}
