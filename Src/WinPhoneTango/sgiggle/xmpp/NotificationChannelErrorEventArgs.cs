using System;

namespace sgiggle.xmpp
{
    public class NotificationChannelErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorType { get; set; }
    }
}