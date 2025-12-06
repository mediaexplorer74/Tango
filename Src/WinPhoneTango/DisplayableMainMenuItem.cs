using System;
using Windows.UI.Xaml;

namespace WinPhoneTango
{
    public class DisplayableMainMenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public int Number { get; set; }
        public Visibility Visibility { get; set; }
        public Visibility ShowNumber { get; set; }
        
        public DisplayableMainMenuItem()
        {
            Number = 0;
            Visibility = Visibility.Visible;
            ShowNumber = Visibility.Collapsed;
        }
    }
}
