// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.App
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public sealed partial class App : Application
  {
    
    public App()
    {
      this.UnhandledException += this.Application_UnhandledException;
      this.InitializeComponent();
      this.InitCustomThemeColors();
    }

    private void InitCustomThemeColors()
    {
      CustomThemeColorHelper.ApplyThemeColorToResource(Application.Current.Resources);
    }

    private void InitEngine() => AppManager.Instance.EngineCom.Start();

    private void UninitEngine()
    {
      if (!AppManager.Instance.EngineCom.IsEngineStarted)
        return;
      AppManager.Instance.Stop();
      AppManager.Instance.EngineCom.Stop();
    }

    private void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      if (e.Exception != null)
      {
        Tango.Toolbox.Logger.Trace(string.Format("UnhandledException({0}): {1}\n{2}", (object) e.Exception.GetType().FullName, (object) e.Exception.Message, (object) e.Exception.StackTrace));
      }
      if (!Debugger.IsAttached)
        return;
      Debugger.Break();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      Tango.Toolbox.Logger.Trace("OnLaunched is called");

      this.InitEngine();

      Frame rootFrame = Window.Current.Content as Frame;
      if (rootFrame == null)
      {
        rootFrame = new Frame();
        Window.Current.Content = rootFrame;
      }

      if (rootFrame.Content == null)
      {
        rootFrame.Navigate(typeof(WelcomePage), e.Arguments);
      }

      Window.Current.Activate();
    }
    
  }
}
