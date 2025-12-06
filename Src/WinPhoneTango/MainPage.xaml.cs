// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.MainPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Tango.Messages;
using Windows.ApplicationModel.Resources;


#nullable disable
namespace WinPhoneTango
{
  public partial class MainPage : TangoEventPageBase
  {
    private static readonly string[] menuIcons = new string[5]
    {
      "contacts.png",
      "recents.png",
      "video_mail.png",
      "invite.png",
      "settings.png"
    };
    private ObservableCollection<DisplayableMainMenuItem> _menuList;
    

    public MainPage()
    {
      this.IsGoBackable = true;
      this.InitializeComponent();
    }

    private void LoadMainMenu()
    {
      string[] strArray = new string[5]
      {
        ResourceLoader.GetForCurrentView("LangResource").GetString("contacts_tab"),
        ResourceLoader.GetForCurrentView("LangResource").GetString("call_log_tab"),
        ResourceLoader.GetForCurrentView("LangResource").GetString("video_mail_tab"),
        ResourceLoader.GetForCurrentView("LangResource").GetString("invite_tab"),
        ResourceLoader.GetForCurrentView("LangResource").GetString("settings_tab")
      };
      int[] numArray = new int[5]
      {
        0,
        AppManager.Instance.DataManager.MissedCallCount,
        1,
        0,
        0
      };
      this._menuList = new ObservableCollection<DisplayableMainMenuItem>();
      for (int index = 0; index < 5; ++index)
      {
        DisplayableMainMenuItem displayableMainMenuItem = new DisplayableMainMenuItem();
        displayableMainMenuItem.Icon = (ImageSource) new BitmapImage(new Uri("ms-appx:///WinPhoneTango/Resources/" + MainPage.menuIcons[index]));
        displayableMainMenuItem.Title = strArray[index];
        displayableMainMenuItem.Number = numArray[index];
        displayableMainMenuItem.Visibility = Visibility.Visible;
        if (index == 2)
          displayableMainMenuItem.Visibility = Visibility.Collapsed;
        this._menuList.Add(displayableMainMenuItem);
      }
      ((ItemsControl) this.mainListBox).ItemsSource = (IEnumerable) this._menuList;
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      if (this.mainListBox != null)
      {
        var selector = this.mainListBox as ListViewBase;
        if (selector != null)
          selector.SelectedIndex = -1;
      }
      base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      this.ClearBackEntries();
      this.LoadMainMenu();
      TangoEventPageBase.SendMessage((ISendableMessage) new ContactsDisplayMainMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      base.OnNavigatedTo(e);
    }

    public override void HandleTangoEvent(int messageId)
    {
      if (messageId != 35113 && messageId != 35117)
        return;
      this.LoadMainMenu();
    }

    private void mainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (this.mainListBox == null || this.mainListBox.SelectedIndex < 0)
        return;
      
      switch (this.mainListBox.SelectedIndex)
      {
        case 0:
          Frame.Navigate(typeof(ContactPage));
          break;
        case 1:
          TangoEventPageBase.SendMessage((ISendableMessage) new RequestCallLogMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 2:
          Frame.Navigate(typeof(VideoMailPage));
          break;
        case 3:
          TangoEventPageBase.SendMessage((ISendableMessage) new InviteDisplayMainMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
          break;
        case 4:
          TangoEventPageBase.SendMessage((ISendableMessage) new DisplaySettingsMessage(TangoEventPageBase.GetNextSeqId(), DisplaySettingsPayload.CreateBuilder()));
          break;
      }
    }

    
  }
}
