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
using Windows.Networking.PushNotifications;
using Windows.UI.Core;

#nullable disable
namespace WinPhoneTango
{
  public class ToastNotificationClientImpl : ToastNotificationClientBase
  {
    private const string CHANNEL_NAME = "Tango.Me.WinPhone.Channel";
    private PushNotificationChannel _channel;

    public ToastNotificationClientImpl()
      : base("Tango.Me.WinPhone.Channel")
    {
    }

    public override void Init(string serviceName)
    {
      // Create or retrieve WNS channel asynchronously
      _ = InitAsync(serviceName);
    }

    private async System.Threading.Tasks.Task InitAsync(string serviceName)
    {
      try
      {
        _channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
        this.DeviceToken = _channel.Uri; // set via base class property (we'll add if missing via reflection later)
        _channel.PushNotificationReceived += Channel_PushNotificationReceived;

        Logger.Trace("WNS channel created: " + _channel.Uri);
        UpdateDeviceToken();
      }
      catch (Exception ex)
      {
        Logger.Trace("Init push channel failed: " + ex.Message);
        OnChannelErrorOccurred(new NotificationChannelErrorEventArgs { Error = ex });
      }
    }

    private void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
    {
      // Simplified: extract toast contents
      string text1 = string.Empty;
      string text2 = string.Empty;
      try
      {
        if (args.ToastNotification?.Content != null)
        {
          var nodes = args.ToastNotification.Content.GetElementsByTagName("text");
          if (nodes.Count > 0) text1 = nodes[0].InnerText ?? string.Empty;
          if (nodes.Count > 1) text2 = nodes[1].InnerText ?? string.Empty;
        }
      }
      catch { }

      var dispatcher = Window.Current?.Dispatcher;
      if (dispatcher != null)
      {
        dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
          AppManager.Instance.PushEventManager.HandlePushEvent(text1, text2, _channel.Uri);
        });
      }
    }

    protected override void OnChannelErrorOccurred(NotificationChannelErrorEventArgs e)
    {
      Logger.Trace("A push notification error occurred: " + (e?.Error?.Message ?? "unknown"));
    }

    protected virtual void UpdateDeviceToken()
    {
      if (_channel == null)
      {
        Logger.Trace("No channel available to update device token.");
        return;
      }
      Logger.Trace("URI = " + _channel.Uri);
      if (string.IsNullOrEmpty(_channel.Uri))
        return;
      TangoDeviceTokenPayload.Builder builder = TangoDeviceTokenPayload.CreateBuilder();
      builder.SetDevicetoken(_channel.Uri);
      builder.SetDevicetokentype(DeviceTokenType.DEVICE_TOKEN_WINPHONE);
      TangoEventPageBase.SendMessage((ISendableMessage) new TangoDeviceTokenMessage(TangoEventPageBase.GetNextSeqId(), builder));
    }

    // Provide DeviceToken property to match previous usage
    public string DeviceToken { get; private set; } = string.Empty;
  }

  // Simple shim for NotificationChannelErrorEventArgs used by the abstract base
  public class NotificationChannelErrorEventArgs
  {
    public Exception Error { get; set; }
  }
}
