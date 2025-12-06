using System;
using Windows.UI.Xaml;

namespace WinPhoneTango
{
    public class DisplayableContact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsTangoUser { get; set; }
        public Visibility Visibility { get; set; }
        
        public DisplayableContact()
        {
            Visibility = Visibility.Visible;
        }
    }
}
