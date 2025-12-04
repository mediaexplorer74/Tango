using System;
using Windows.UI.Xaml;

namespace WinPhoneTango
{
    // Классы для совместимости с UWP вместо WP7-специфичных элементов
    
    public class NavigationEventArgs : EventArgs
    {
        public string Parameter { get; set; }
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
    
    public class TimerElapsedEventArgs : EventArgs
    {
        public object State { get; set; }
    }
    
    public class CountryCode
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public int Id { get; set; }
    }
    
    // Заменяем устаревшие WP7 элементы на UWP эквиваленты
    public class PivotItem
    {
        public UIElement Content { get; set; }
        public string Header { get; set; }
    }
}