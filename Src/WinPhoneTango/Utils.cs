using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WinPhoneTango
{
    public static class Utils
    {
        // Заменяем устаревшие WP7-специфичные утилиты
        
        public static Visibility ConvertBoolToVisibility(bool value)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
        
        public static bool ConvertVisibilityToBool(Visibility value)
        {
            return value == Visibility.Visible;
        }
        
        public static void NavigateToPage<T>(Frame frame, object parameter = null) where T : Page
        {
            frame.Navigate(typeof(T), parameter);
        }
    }
}