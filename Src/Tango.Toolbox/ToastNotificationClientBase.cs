// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.ToastNotificationClientBase
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.IsolatedStorage;

#nullable disable
namespace Tango.Toolbox
{
  // Stubs to replace deprecated Microsoft.Phone.Notification types; functionality is disabled for UWP.
  public class HttpNotificationChannel : IDisposable
  {
    public Uri ChannelUri { get; set; }
    public bool IsShellToastBound { get; set; }
    public bool IsShellTileBound { get; set; }

    public HttpNotificationChannel(string channelName) { }
    public HttpNotificationChannel(string channelName, string serviceName) { }

    public static HttpNotificationChannel Find(string channelName) => null;

    public void Open() { }
    public void Close() { }
    public void Dispose() { }

    public void BindToShellToast() { IsShellToastBound = true; }
    public void UnbindToShellToast() { IsShellToastBound = false; }
    public void BindToShellTile() { IsShellTileBound = true; }
    public void UnbindToShellTile() { IsShellTileBound = false; }

    public event EventHandler<NotificationChannelUriEventArgs> ChannelUriUpdated;
    public event EventHandler<NotificationChannelErrorEventArgs> ErrorOccurred;
    public event EventHandler<NotificationEventArgs> ShellToastNotificationReceived;
  }

  public class NotificationChannelUriEventArgs : EventArgs
  {
    public Uri ChannelUri { get; set; }
  }

  public class NotificationChannelErrorEventArgs : EventArgs
  {
    public int ErrorType { get; set; }
  }

  public class NotificationEventArgs : EventArgs
  {
    public IDictionary<string, string> Collection { get; set; }
  }

  public abstract class ToastNotificationClientBase
  {
    private string _channelName = string.Empty;
    private string _serviceName = string.Empty;
    private static readonly string SETTING_KEY_LAST_SERVICE_NAME = "TNCBLSN";

    public string DeviceToken { get; private set; }

    public ToastNotificationClientBase.ChannelType Type { get; private set; }

    protected abstract void UpdateDeviceToken();

    protected abstract void ShellToastNotificationReceived(
      string text1,
      string text2,
      string relativeUri);

    protected abstract void OnChannelErrorOccurred(NotificationChannelErrorEventArgs e);

    public ToastNotificationClientBase(string channelName)
    {
      this._channelName = channelName;
      this.Type = ToastNotificationClientBase.ChannelType.NotReady;
    }

    public void Init(string serviceName)
    {
      this._serviceName = serviceName;
      Logger.Trace("ToastNotificationClientBase::Init() channelName=" + this._channelName + ", serviceName=" + this._serviceName);
      this.InitImpl();
    }

    private void InitImpl()
    {
      HttpNotificationChannel pushChannel = HttpNotificationChannel.Find(this._channelName);
      if (pushChannel != null)
      {
        if (this._serviceName == null)
          this._serviceName = string.Empty;
        //IsolatedStorageSettings applicationSettings = IsolatedStorageSettings.ApplicationSettings;
        //string empty = string.Empty;
        //if (applicationSettings.Contains(ToastNotificationClientBase.SETTING_KEY_LAST_SERVICE_NAME))
        //  empty = (string) applicationSettings[ToastNotificationClientBase.SETTING_KEY_LAST_SERVICE_NAME];
        //if (!empty.Equals(this._serviceName))
        {
          //applicationSettings[ToastNotificationClientBase.SETTING_KEY_LAST_SERVICE_NAME] = (object) this._serviceName;
          //Logger.Trace(string.Format("Service name changed from \"{0}\" to \"{1}\"", (object) empty, (object) this._serviceName));
          this.CloseChannel(ref pushChannel);
        }
      }
      if (pushChannel == null)
      {
        this.Type = ToastNotificationClientBase.ChannelType.NewChannel;
        pushChannel = !string.IsNullOrEmpty(this._serviceName) ? new HttpNotificationChannel(this._channelName, this._serviceName) : new HttpNotificationChannel(this._channelName);
        pushChannel.Open();
      }
      else if (pushChannel.ChannelUri == (Uri) null)
      {
        this.Type = ToastNotificationClientBase.ChannelType.ExistChannelNewUri;
        this.CloseChannel(ref pushChannel);
        pushChannel = !string.IsNullOrEmpty(this._serviceName) ? new HttpNotificationChannel(this._channelName, this._serviceName) : new HttpNotificationChannel(this._channelName);
        pushChannel.Open();
      }
      else
        this.Type = ToastNotificationClientBase.ChannelType.ExistChannelExistUri;
      pushChannel.ChannelUriUpdated += new EventHandler<NotificationChannelUriEventArgs>(this.ChannelUriUpdated);
      pushChannel.ErrorOccurred += new EventHandler<NotificationChannelErrorEventArgs>(this.ChannelErrorOccurred);
      pushChannel.ShellToastNotificationReceived += new EventHandler<NotificationEventArgs>(this.ShellToastNotificationReceived);
      if (!pushChannel.IsShellToastBound)
      {
        Logger.Trace("Bind pushChannel to shell toast");
        pushChannel.BindToShellToast();
      }
      if (!pushChannel.IsShellTileBound)
      {
        Logger.Trace("Bind pushChannel to shell tile");
        pushChannel.BindToShellTile();
      }
      if (!(pushChannel.ChannelUri != (Uri) null))
        return;
      this.DeviceToken = pushChannel.ChannelUri.ToString();
      this.UpdateDeviceToken();
    }

    private void CloseChannel(ref HttpNotificationChannel pushChannel)
    {
      if (pushChannel == null)
        return;
      try
      {
        if (pushChannel.IsShellTileBound)
          pushChannel.UnbindToShellTile();
        if (pushChannel.IsShellToastBound)
          pushChannel.UnbindToShellToast();
        pushChannel.Close();
        pushChannel.Dispose();
      }
      catch (Exception ex)
      {
        Logger.Trace("CloseChannel failed, exception: " + ex.Message);
      }
      pushChannel = (HttpNotificationChannel) null;
    }

    private void ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
    {
      if (!(e.ChannelUri != (Uri) null))
        return;
      this.DeviceToken = e.ChannelUri.ToString();
      this.UpdateDeviceToken();
    }

    private void ChannelErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
    {
      switch ((int) e.ErrorType)
      {
        case 1:
          this.InitImpl();
          break;
      }
      this.OnChannelErrorOccurred(e);
    }

    private void ShellToastNotificationReceived(object sender, NotificationEventArgs e)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      foreach (string key in (IEnumerable<string>) e.Collection.Keys)
      {
        if (string.Compare(key, "wp:Param", StringComparison.OrdinalIgnoreCase) == 0)
          empty1 = e.Collection[key];
        else if (string.Compare(key, "wp:Text1", StringComparison.OrdinalIgnoreCase) == 0)
          empty2 = e.Collection[key];
        else if (string.Compare(key, "wp:Text2", StringComparison.OrdinalIgnoreCase) == 0)
          empty3 = e.Collection[key];
      }
      this.ShellToastNotificationReceived(empty2, empty3, empty1);
    }

    public enum ChannelType
    {
      NotReady,
      NewChannel,
      ExistChannelNewUri,
      ExistChannelExistUri,
    }
  }
}
