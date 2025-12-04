// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.EngineCom
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Globalization;
using System.Text;
using Windows.Storage;
using Tango.Drivers;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class EngineCom
  {
    public const string CLSID_WPTangoEngine = "C1FF8E39-B5F9-4E1E-A6C0-9C9F411BF61D";
    public const string CLSID_WPMessageSender = "EC85075D-4E62-47BC-A8CF-3FE1F6BFB984";
    private const string ENGINE_DLL_NAME = "EngineCOM.dll";
    public const string DEV_NAME_HTC = "wp7_htc";
    public const string DEV_NAME_LG = "wp7_lg";
    private const int VERSION_BUFFER_SIZE = 50;
    private const int PUSH_SERVICE_NAME_BUFFER_SIZE = 128;
    private const int DEVICE_NAME_SIZE = 50;

    public string IsolatedStoragePath { get; private set; }

    public string Version { get; private set; }

    public string PushServiceName { get; private set; }

    public string TargetDevice { get; private set; }

    public string InstallationPath { get; private set; }

    public bool IsEngineStarted { get; private set; }

    public IWPTangoEngine Engine { get; private set; }

    public IWPMessageSender Sender { get; private set; }

    private IContactsDriverConnector ContactsDriverConnector { get; set; }

    private ISoundEffPlayerDriverConnector SoundEffPlayerDriverConnector { get; set; }

    private IConnectivityDriverConnector ConnectivityDriverConnector { get; set; }

    private IScreenDriverConnector ScreenDriverConnector { get; set; }

    private IRecorderDriverConnector RecorderDriverConnector { get; set; }

    private IPlayerDriverConnector PlayerDriverConnector { get; set; }

    private ICapturerDriverConnector CapturerDriverConnector { get; set; }

    private IRendererDriverConnector RendererDriverConnector { get; set; }

    private IAudioModeMonitorDriverConnector AudioModeMonitorDriverConnector { get; set; }

    public void Start()
    {
      if (this.IsEngineStarted)
        return;
      Logger.Trace("Start the engine.");
      this.Engine.init();
      this.Engine.register_msg_receiver((IEventCallback) AppManager.Instance.CallBackManager);
      this.InitTangoEnvironment();
      this.SetTargetDevice();
      this.Engine.start();
      this.IsEngineStarted = true;
      Logger.Trace("Engine started.");
    }

    public void Stop()
    {
      if (!this.IsEngineStarted)
        return;
      Logger.Trace("Stop the engine.");
      this.IsEngineStarted = false;
      this.Engine.stop();
      this.Engine.fini();
      Logger.Trace("Engine stopped.");
    }

    public EngineCom()
    {
      this.InitPath();
      this.TargetDevice = string.Empty;
      // Note: ComBridge is WP7-specific, this might need to be replaced with UWP equivalent if available
      // For now, we'll assume the COM components can be instantiated directly in UWP
      this.Engine = (IWPTangoEngine) new WPTangoEngine();
      this.Engine.set_environment((IWPLogger) new Logger(), this.IsolatedStoragePath);
      this.Engine.register_devinfo_driver((IDevInfoDriver) DriversManager.Instance.DevInfoDriver);
      string lower = RegionInfo.CurrentRegion.TwoLetterISORegionName.ToLower();
      int retCountryId = 1;
      this.Engine.set_and_lookup_country_code(out retCountryId, lower[0], lower[1]);
      AppManager.Instance.DataManager.PhoneCountryId = retCountryId.ToString();
      this.Sender = (IWPMessageSender) new WPMessageSender();
      // Initialize driver connectors - these might need to be updated to work with UWP
      this.ContactsDriverConnector = (IContactsDriverConnector) new Tango.Drivers.ContactsDriverConnector();
      this.ContactsDriverConnector.RegisterContactsDriver((IContactsDriver) DriversManager.Instance.ContactsDriver);
      DriversManager.Instance.ContactsDriver.ContactsDriverConnector = this.ContactsDriverConnector;
      this.CapturerDriverConnector = (ICapturerDriverConnector) new Tango.Drivers.CapturerDriverConnector();
      this.CapturerDriverConnector.RegisterCapturerDriver((ICapturerDriver) DriversManager.Instance.CapturerDriver);
      DriversManager.Instance.CapturerDriver.Connector = this.CapturerDriverConnector;
      this.RendererDriverConnector = (IRendererDriverConnector) new Tango.Drivers.RendererDriverConnector();
      this.RendererDriverConnector.RegisterRendererDriver((IRendererDriver) DriversManager.Instance.RendererDriver);
      DriversManager.Instance.RendererDriver.Connector = this.RendererDriverConnector;
      this.ScreenDriverConnector = (IScreenDriverConnector) new Tango.Drivers.ScreenDriverConnector();
      this.ScreenDriverConnector.RegisterDriver((IScreenDriver) DriversManager.Instance.ScreenDriver);
      this.AudioModeMonitorDriverConnector = (IAudioModeMonitorDriverConnector) new Tango.Drivers.AudioModeMonitorDriverConnector();
      this.AudioModeMonitorDriverConnector.RegisterDriver((IAudioModeMonitorDriver) DriversManager.Instance.AudioModeMonitorDriver);
      this.SoundEffPlayerDriverConnector = (ISoundEffPlayerDriverConnector) new Tango.Drivers.SoundEffPlayerDriverConnector();
      this.SoundEffPlayerDriverConnector.RegisterDriver((ISoundEffPlayerDriver) DriversManager.Instance.SoundEffPlayerDriver);
      try
      {
        this.RecorderDriverConnector = (IRecorderDriverConnector) new Tango.Drivers.RecorderDriverConnector();
        this.RecorderDriverConnector.RegisterRecorderDriver((IRecorderDriver) DriversManager.Instance.RecorderDriver);
        DriversManager.Instance.RecorderDriver.Connector = this.RecorderDriverConnector;
      }
      catch (Exception ex)
      {
        Logger.Trace("new RecorderDriverConnector() failed with error: " + ex.Message);
      }
      try
      {
        this.PlayerDriverConnector = (IPlayerDriverConnector) new Tango.Drivers.PlayerDriverConnector();
        this.PlayerDriverConnector.RegisterPlayerDriver((IPlayerDriver) DriversManager.Instance.PlayerDriver);
        DriversManager.Instance.PlayerDriver.Connector = this.PlayerDriverConnector;
      }
      catch (Exception ex)
      {
        Logger.Trace("new PlayerDriverConnector() failed with error: " + ex.Message);
      }
      this.ConnectivityDriverConnector = (IConnectivityDriverConnector) new Tango.Drivers.ConnectivityDriverConnector();
      this.ConnectivityDriverConnector.RegisterConnectivityDriver((IConnectivityDriver) DriversManager.Instance.ConnectivityDriver);
    }

    public void InitTangoEnvironment()
    {
      byte[] numArray1 = new byte[50];
      int datalen;
      this.Engine.get_version(50, numArray1, out datalen);
      try
      {
        this.Version = Encoding.UTF8.GetString(numArray1, 0, datalen);
      }
      catch (Exception ex)
      {
        this.Version = string.Empty;
        Logger.Trace("cannot decode version.\n" + ex.Message);
      }
      byte[] numArray2 = new byte[128];
      int namelen;
      this.Engine.get_push_service_name(128, numArray2, out namelen);
      try
      {
        this.PushServiceName = Encoding.UTF8.GetString(numArray2, 0, namelen);
      }
      catch (Exception ex)
      {
        this.PushServiceName = string.Empty;
        Logger.Trace("cannot decode PushServiceName.\n" + ex.Message);
      }
      Logger.Trace("InitTangoEnvironment: Version=" + this.Version + "; PushServiceName=" + this.PushServiceName);
    }

    public void SetTargetDevice()
    {
      byte[] numArray = new byte[50];
      int buflen;
      this.Engine.get_target_device(50, numArray, out buflen);
      try
      {
        this.TargetDevice = Encoding.UTF8.GetString(numArray, 0, buflen);
      }
      catch (Exception ex)
      {
        this.TargetDevice = string.Empty;
        Logger.Trace("cannot decode TargetDevice.\n" + ex.Message);
      }
    }

    private void InitPath()
    {
      try
      {
        // In UWP, we use ApplicationData instead of WMAppManifest.xml
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        this.IsolatedStoragePath = localFolder.Path + "\\";
        StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
        this.InstallationPath = installedLocation.Path + "\\";
      }
      catch (Exception ex)
      {
        Logger.Trace("InitPath() failed with error: " + ex.Message);
      }
    }
  }
}
