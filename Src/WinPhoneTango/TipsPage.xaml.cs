// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.TipsPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Tango.Messages;
using Windows.ApplicationModel.Resources;

#nullable disable
namespace WinPhoneTango
{
  public partial class TipsPage : TangoEventPageBase
  {
   

    public TipsPage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
      // In UWP, use HttpClient for web requests instead of WebRequest
      this.StartLoadingProgress(this.waitingBar);
      this.webViewTips.Source = new Uri(ResourceLoader.GetForCurrentView("LangResource").GetString("tips_url"));
      this.webViewTips.NavigationCompleted += WebViewTips_NavigationCompleted;
    }

    private void WebViewTips_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
    {
        this.StopLoadingProgress();
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      TangoEventPageBase.SendMessage((ISendableMessage) new DisplaySettingsMessage(TangoEventPageBase.GetNextSeqId(), DisplaySettingsPayload.CreateBuilder()));
      e.Cancel = true;
    }

    // Removed InitializeComponent method to prevent conflicts with XAML-generated code
  }
}
