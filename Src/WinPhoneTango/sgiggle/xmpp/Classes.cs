using System;

namespace sgiggle.xmpp
{
    public class CallEntry
    {
        public string Name { get; set; }
        public string LastCallText { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class NavigationEventArgs : EventArgs
    {
        public object Parameter { get; set; }
    }

    public class RoutedEventArgs : EventArgs
    {
        public object OriginalSource { get; set; }
    }

    public class SelectionChangedEventArgs : RoutedEventArgs
    {
        public object AddedItems { get; set; }
        public object RemovedItems { get; set; }
    }

    public class TimerElapsedEventArgs : EventArgs
    {
        public object State { get; set; }
    }

    public class TextChangedEventArgs : RoutedEventArgs
    {
        public string Text { get; set; }
    }

    public class GroupViewOpenedEventArgs : RoutedEventArgs
    {
        public object Group { get; set; }
    }

    public class GroupViewClosingEventArgs : RoutedEventArgs
    {
        public object Group { get; set; }
    }

    public class GroupViewClosedEventArgs : RoutedEventArgs
    {
        public object Group { get; set; }
    }

    public class GroupViewOpeningEventArgs : RoutedEventArgs
    {
        public object Group { get; set; }
    }

    public class GestureEventArgs : RoutedEventArgs
    {
        public object Gesture { get; set; }
    }

    public class GameTimer
    {
        public event EventHandler<object> Tick;
        
        public void Start() { }
        public void Stop() { }
    }

    public class GameTimerEventArgs : EventArgs
    {
        public object State { get; set; }
    }

    public class PhotoCamera
    {
        // Заглушка для камеры
    }

    public class BitmapImage
    {
        public BitmapImage(Uri uri) { }
    }

    public class CountryCode
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public int Id { get; set; }
    }
    
}