// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.VideoMailViewPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using System.Windows.Threading;

#nullable disable
namespace WinPhoneTango
{
  public partial class VideoMailViewPage : TangoEventPageBase
  {
    private DispatcherTimer _timer;
    private DateTime _startTime;
    private double _totalTime = 90.0;
    

    public VideoMailViewPage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnLoaded);
      this._timer = new DispatcherTimer();
      this._timer.Interval = TimeSpan.FromSeconds(0.1);
      this._timer.Tick += new EventHandler(this.OnTimer);
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      try
      {
        this.textCallUserName.Text = ((Page) this).NavigationContext.QueryString["name"].ToString();
        this._startTime = DateTime.Now;
        this._timer.Start();
      }
      catch (Exception ex)
      {
      }
    }

    private void OnTimer(object sender, EventArgs e)
    {
      TimeSpan timeSpan = DateTime.Now.Subtract(this._startTime);
      string str = timeSpan.ToString();
      this.textPlayedTime.Text = str.IndexOf('.') > 0 ? str.Substring(0, str.IndexOf('.')) : str;
      if (timeSpan.TotalSeconds >= this._totalTime)
        this._timer.Stop();
      ((FrameworkElement) this.progressBar).Width = (double) (int) (0.5 + timeSpan.TotalSeconds / this._totalTime * ((FrameworkElement) this.borderProgressBar).Width);
    }

    
  }
}
