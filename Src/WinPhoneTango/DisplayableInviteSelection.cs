using System;
using Windows.UI.Xaml;

namespace WinPhoneTango
{
    public class DisplayableInviteSelection
    {
        public string Name { get; set; }
        public string InviteeInfo { get; set; }
        public bool IsSelected { get; set; }
        public Visibility Visibility { get; set; }
        
        public DisplayableInviteSelection()
        {
            Visibility = Visibility.Visible;
            IsSelected = false;
        }
    }
}
