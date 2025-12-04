// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.WelcomePage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public partial class WelcomePage : TangoEventPageBase
  {
    public static readonly string PUSH_PARAM_KEY_PUSH_FLAG = "way";
    public static readonly string PUSH_PARAM_VALUE_PUSH_FLAG = "push";
    public static readonly string PUSH_PARAM_KEY_VALIDATION_CODE = "code";
    

    public WelcomePage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnLoaded);
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      AppManager.Instance.Start();
    }

   
  }
}
