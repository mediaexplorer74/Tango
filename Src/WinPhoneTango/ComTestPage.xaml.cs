// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.ComTestPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace WinPhoneTango
{
  public partial class ComTestPage : TangoEventPageBase
  {
    

    public ComTestPage() => this.InitializeComponent();

    private void btTest_Click(object sender, RoutedEventArgs e)
    {
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      AppManager.Instance.EngineCom.Engine.start();
      this.TextOut.Text = "Engine is started!";
    }

    private void buttonEnterUI_Click(object sender, RoutedEventArgs e)
    {
      AppManager.Instance.EngineCom.Engine.stop();
      AppManager.Instance.EngineCom.Engine.fini();
      ((Page) this).NavigationService.Navigate(new Uri("/WelcomePage.xaml", UriKind.Relative));
    }

    
  }
}
