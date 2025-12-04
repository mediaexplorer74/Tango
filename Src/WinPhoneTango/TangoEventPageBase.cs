// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.TangoEventPageBase
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System.Threading;
using Windows.UI.Core;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class TangoEventPageBase : Page, INavigatable
  {
    public static readonly string NAVIGATION_MESSAGE_ID_PARAM = "messageId";
    private static TimeSpan MINIMUM_DURATION = TimeSpan.FromMilliseconds(800.0);
    private bool _isInitialized;
    private DispatcherTimer _loadingTimer;
    private ProgressBar _waitingBar;
    private bool _attachWaitingForClickResult;

    public bool IsGoBackable { get; protected set; }

    protected bool WaitingForClickResult { get; set; }

    public bool IsLoaded { get; set; }

    public DateTime NavigatedTime { get; private set; }

    protected int StartWithMessageId { get; private set; }

    protected object AppBarController { get; set; }

    protected TangoEventPageBase()
    {
      this.IsGoBackable = false;
      this.StartWithMessageId = -1;
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnLoaded);
      ((FrameworkElement) this).Unloaded += new RoutedEventHandler(this.OnUnloaded);
      this.AppBarController = null; // Removed ApplicationBar controller as it's WP7-specific
      this.ApplyThemeColorToResource(((FrameworkElement) this).Resources);
      SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
    }

    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        if (!IsGoBackable)
        {
            e.Handled = true;
            return;
        }
        
        if (DateTime.Now - this.NavigatedTime < TangoEventPageBase.MINIMUM_DURATION || AppManager.Instance.EventManager.CurrentPage == null)
        {
            Logger.Trace("back key press ignored");
            e.Handled = true;
        }
        else
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }

    protected void SetColorToElementTree(DependencyObject root)
    {
      int childrenCount = VisualTreeHelper.GetChildrenCount(root);
      for (int index = 0; index < childrenCount; ++index)
      {
        DependencyObject child = VisualTreeHelper.GetChild(root, index);
        if (child is FrameworkElement frameworkElement)
          this.ApplyThemeColorToResource(frameworkElement.Resources);
        this.SetColorToElementTree(child);
      }
    }

    protected void ApplyThemeColorToResource(ResourceDictionary resource)
    {
      CustomThemeColorHelper.ApplyThemeColorToResource(resource);
    }

    protected void InitAppBarController()
    {
      // WP7 ApplicationBar specific code removed for UWP
    }

    protected virtual void OnAppBarVisibilityChanged(object sender, EventArgs e)
    {
    }

    protected void EnableTiltEffect()
    {
      // TiltEffect is WP7-specific, removed for UWP
    }

    public static void SendMessage(ISendableMessage message)
    {
      if (AppManager.Instance.EngineCom.IsEngineStarted)
      {
        Logger.Trace("send a message to engine core! (type = " + message.MsgType.ToString() + ", size = " + message.MsgByteString.ToByteArray().Length.ToString() + ")");
        byte[] byteArray = message.MsgByteString.ToByteArray();
        AppManager.Instance.EngineCom.Sender.SendMessage(message.MsgType, byteArray.Length, byteArray);
      }
      else
        Logger.Trace("unable to send a message when engine is not started! (type = " + message.MsgType.ToString() + ", size = " + message.MsgByteString.ToByteArray().Length.ToString() + ")");
    }

    public virtual void HandleTangoEvent(int messageId)
    {
    }

    public virtual void HandleAppEvent(int messageId)
    {
    }

    protected virtual void OnInitialized()
    {
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      this.IsLoaded = true;
      if (this._isInitialized)
        return;
      this._isInitialized = true;
      this.OnInitialized();
      if (this.StartWithMessageId <= 0)
        return;
      Logger.Trace(string.Format("send navigation start message:{0} to page", (object) this.StartWithMessageId));
      this.HandleTangoEvent(this.StartWithMessageId);
    }

    private void OnUnloaded(object sender, RoutedEventArgs e) => this.IsLoaded = false;

    public void SleepIfNeeded()
    {
      TimeSpan timeSpan = DateTime.Now - this.NavigatedTime;
      if (timeSpan.CompareTo(TangoEventPageBase.MINIMUM_DURATION) >= 0)
        return;
      TimeSpan timeout = TangoEventPageBase.MINIMUM_DURATION - timeSpan;
      Logger.Trace("before navigation sleep " + (object) timeout);
      Thread.Sleep(timeout);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      if (Frame != null)
      {
        // NavigationService events not needed in UWP
      }
      if (AppManager.Instance.EventManager.CurrentPage != null)
        Logger.Trace("OnNavigatedFrom set page " + ((object) AppManager.Instance.EventManager.CurrentPage).GetType().Name + " to null");
      AppManager.Instance.EventManager.CurrentPage = (TangoEventPageBase) null;
      this.StopLoadingProgress();
      base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      this.NavigatedTime = DateTime.Now;
      
      if (Frame != null)
      {
        // NavigationService events not needed in UWP
      }
      
      if (e.Parameter != null && e.Parameter.ToString().Contains(TangoEventPageBase.NAVIGATION_MESSAGE_ID_PARAM))
      {
          string param = e.Parameter.ToString();
          // Extract message id from parameter if needed
          this.StartWithMessageId = -1; // Reset for now since UWP doesn't use the same navigation context
      }
      
      Logger.Trace("OnNavigatedTo " + ((object) this).GetType().Name);
      AppManager.Instance.EventManager.CurrentPage = this;
      this.WaitingForClickResult = false;
      
      // ApplicationBar is WP7-specific, removed for UWP
    }

    protected void NavigateToPage(string pageName, string param = "", int messageId = -1)
    {
      AppManager.Instance.EventManager.NavigateToPage(pageName, param, messageId);
    }

    protected void GoBackToFormerPage() => this.GoBackImpl();

    bool INavigatable.Navigate(Uri source) => this.NavigateImpl(source);

    bool INavigatable.GoBack() => this.GoBackImpl();

    private bool NavigateImpl(Uri source)
    {
      if (App.IsQuiting)
        return false;
      if (Frame != null)
        return Frame.Navigate(source, source.Fragment); // Pass fragment as parameter
      Logger.Trace("TangoEventPageBase: can't navigate since Frame is null!");
      return false;
    }

    private bool GoBackImpl()
    {
      if (App.IsQuiting)
        return false;
      if (Frame != null && Frame.CanGoBack)
      {
        Frame.GoBack();
        return true;
      }
      Logger.Trace("TangoEventPageBase: UI page can't go back!");
      return false;
    }

    private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      Logger.Trace(((object) this).GetType().Name + " - OnNavigationFailed(), exception: " + e.Exception.ToString());
      AppManager.Instance.EventManager.CurrentPage = this;
    }

    private void OnNavigationStopped(object sender, NavigationEventArgs e)
    {
      Logger.Trace(((object) this).GetType().Name + " - OnNavigationStopped()");
      AppManager.Instance.EventManager.CurrentPage = this;
    }

    public static long GetNextSeqId()
    {
      long next_sid = 0;
      if (AppManager.Instance.EngineCom.IsEngineStarted)
        AppManager.Instance.EngineCom.Engine.message_router_get_next_sequence_id(ref next_sid);
      else
        Logger.Trace("unable to get next sequence id from message router when engine is not started!");
      return next_sid;
    }

    protected void ClearBackEntries()
    {
      if (Frame == null)
        return;
      Logger.Trace("clear back entries");
      // In UWP, Frame.BackStack can be cleared differently if needed
    }

    public string BackEntryPageName
    {
      get
      {
        if (Frame != null && Frame.BackStack != null && Frame.BackStack.Count > 0)
        {
          var entry = Frame.BackStack.LastOrDefault();
          if (entry != null)
          {
            string str = entry.SourcePageType.Name;
            string backEntryPageName = string.Empty;
            Logger.Trace("find page name: " + str);
            return str;
          }
        }
        return string.Empty;
      }
    }

    public void RemoveBackEntry()
    {
      if (Frame == null || !Frame.CanGoBack)
        return;
      Logger.Trace("TangoEventPageBase: remove back entry");
      Frame.BackStack.RemoveAt(Frame.BackStack.Count - 1);
    }

    protected void Assert(object objShouldNotBeNull)
    {
    }

    public static void UpdateTile(int countFieldValue)
    {
      // ShellTile is WP7-specific, use UWP equivalent if needed
      // For UWP, we would use TileUpdateManager
    }

    public void StartLoadingProgress(
      ProgressBar waitingBar,
      bool attachWaitingForClickResult = false,
      int timeout = 15)
    {
      this.Assert((object) waitingBar);
      if (waitingBar == null)
        return;
      waitingBar.IsIndeterminate = true;
      this._loadingTimer = new DispatcherTimer();
      this._loadingTimer.Interval = TimeSpan.FromSeconds((double) timeout);
      this._loadingTimer.Tick += new EventHandler(this.OnLoadingTimeOut);
      this._loadingTimer.Start();
      this._waitingBar = waitingBar;
      if (((FrameworkElement) this._waitingBar).Parent is StackPanel && ((UIElement) this._waitingBar).Visibility == null)
        ((UIElement) this._waitingBar).Opacity = 1.0;
      else
        ((UIElement) this._waitingBar).Visibility = Visibility.Visible;
      this._attachWaitingForClickResult = attachWaitingForClickResult;
      if (!this._attachWaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
    }

    public void StopLoadingProgress()
    {
      if (this._loadingTimer != null)
      {
        this._loadingTimer.Stop();
        this._loadingTimer = null;
      }
      if (this._waitingBar != null)
      {
        this._waitingBar.IsIndeterminate = false;
        if (((FrameworkElement) this._waitingBar).Parent is StackPanel)
          ((UIElement) this._waitingBar).Opacity = 0.0;
        else
          ((UIElement) this._waitingBar).Visibility = Visibility.Collapsed;
        this._waitingBar = null;
      }
      if (this._attachWaitingForClickResult)
        this.WaitingForClickResult = false;
      this._attachWaitingForClickResult = false;
    }

    private void OnLoadingTimeOut(object sender, EventArgs e) => this.StopLoadingProgress();

    protected virtual void OnBackKeyPress(CancelEventArgs e)
    {
      Logger.Trace("back key pressed");
      if (DateTime.Now - this.NavigatedTime < TangoEventPageBase.MINIMUM_DURATION || AppManager.Instance.EventManager.CurrentPage == null)
      {
        Logger.Trace("back key press ignored");
        e.Cancel = true;
      }
      else
        // base.OnBackKeyPress(e); // This method doesn't exist in UWP Page
        e.Cancel = false;
    }

    protected void HideKeyboard() => ((Control) this).Focus();
  }
}
