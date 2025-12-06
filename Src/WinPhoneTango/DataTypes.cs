using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace WinPhoneTango
{
    // Basic data types and enums
    public enum Visibility
    {
        Visible,
        Collapsed
    }
    
    public class CallEntry
    {
        public string Name { get; set; }
        public string LastCallText { get; set; }
        public SolidColorBrush LastCallColor { get; set; }
    }
    
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    
    public class BitmapImage
    {
        public BitmapImage(Uri uri) { }
    }
    
    public class DispatcherTimer
    {
        public event EventHandler<object> Tick;
        
        public void Start() { }
        public void Stop() { }
        public TimeSpan Interval { get; set; }
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
        // Placeholder for camera functionality
    }
    
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public SolidColorBrush Fill { get; set; }
    }
    
    public class PivotItem
    {
        public UIElement Content { get; set; }
        public object Header { get; set; }
    }
    
    public class LongListSelector
    {
        // Placeholder for WP7 LongListSelector control
    }
    
    public class CountryCode
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public int Id { get; set; }
    }
    
    public class FrameworkElement : UIElement
    {
        public object DataContext { get; set; }
    }
    
    public class PublicGrouping<TKey, TElement>
    {
        public int Count { get; set; }
        public TKey Key { get; set; }
        public bool HasItems { get; set; }
        
        public PublicGrouping(TKey key, System.Collections.Generic.IEnumerable<TElement> items)
        {
            Key = key;
            Count = 0;
            HasItems = false;
        }
    }
    
    public class PublicGroupings<TKey, TElement>
    {
        public int Count { get; set; }
    }
}