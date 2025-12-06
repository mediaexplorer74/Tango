using System;

namespace sgiggle.xmpp
{
    public class TimerElapsedEventArgs : EventArgs
    {
        public object State { get; set; }
    }

    public class GestureEventArgs : EventArgs
    {
        public bool Handled { get; set; }
    }

    public class GroupViewOpenedEventArgs : EventArgs { public object Group { get; set; } }
    public class GroupViewClosingEventArgs : EventArgs { public object Group { get; set; } }
    public class GroupViewClosedEventArgs : EventArgs { public object Group { get; set; } }

    // Note: TextChangedEventArgs collides with Windows.UI.Xaml.Controls.TextChangedEventArgs and was removed to allow UWP event types to be used.
}
