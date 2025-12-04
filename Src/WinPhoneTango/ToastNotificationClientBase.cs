using System;
using Windows.Networking.PushNotifications;

namespace WinPhoneTango
{
    public abstract class ToastNotificationClientBase
    {
        protected string ChannelName { get; private set; }

        public ToastNotificationClientBase(string channelName)
        {
            ChannelName = channelName;
        }

        public abstract void Init(string serviceName);

        protected abstract void OnChannelErrorOccurred(NotificationChannelErrorEventArgs e);
    }
}