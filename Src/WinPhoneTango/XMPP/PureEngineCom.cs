using System;
using System.Globalization;
using System.Text;
using Windows.Storage;
using Tango.Drivers;
using Tango.Toolbox;
using WinPhoneTango;

namespace Tango.XMPP
{
    /// <summary>
    /// Pure C# implementation of EngineCom that replaces COM dependencies
    /// </summary>
    public class PureEngineCom
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

        public ITangoEngine Engine { get; private set; }

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
            this.Engine.Initialize();
            // Note: We're using our XMPP-based message handling instead of COM callbacks
            this.InitTangoEnvironment();
            this.SetTargetDevice();
            this.Engine.Start();
            this.IsEngineStarted = true;
            Logger.Trace("Engine started.");
        }

        public void Stop()
        {
            if (!this.IsEngineStarted)
                return;
            Logger.Trace("Stop the engine.");
            this.IsEngineStarted = false;
            this.Engine.Stop();
            this.Engine.FinalizeEngine();
            Logger.Trace("Engine stopped.");
        }

        public PureEngineCom()
        {
            this.InitPath();
            this.TargetDevice = string.Empty;
            
            // Use our pure C# implementations instead of COM components
            this.Engine = new PureTangoEngine();
            this.Engine.SetEnvironment(new Logger(), this.IsolatedStoragePath);
            this.Engine.RegisterDevInfoDriver(DriversManager.Instance.DevInfoDriver);
            
            string lower = RegionInfo.CurrentRegion.TwoLetterISORegionName.ToLower();
            int retCountryId = 1;
            this.Engine.SetAndLookupCountryCode(out retCountryId, lower[0], lower[1]);
            AppManager.Instance.DataManager.PhoneCountryId = retCountryId.ToString();
            
            this.Sender = new PureMessageSender();
            ((PureMessageSender)this.Sender).SetLogger(new Logger());
            
            // Initialize driver connectors - these might need to be updated to work with UWP
            this.ContactsDriverConnector = (IContactsDriverConnector)new Tango.Drivers.ContactsDriverConnector();
            this.ContactsDriverConnector.RegisterContactsDriver((IContactsDriver)DriversManager.Instance.ContactsDriver);
            DriversManager.Instance.ContactsDriver.ContactsDriverConnector = this.ContactsDriverConnector;
            this.CapturerDriverConnector = (ICapturerDriverConnector)new Tango.Drivers.CapturerDriverConnector();
            this.CapturerDriverConnector.RegisterCapturerDriver((ICapturerDriver)DriversManager.Instance.CapturerDriver);
            DriversManager.Instance.CapturerDriver.Connector = this.CapturerDriverConnector;
            this.RendererDriverConnector = (IRendererDriverConnector)new Tango.Drivers.RendererDriverConnector();
            this.RendererDriverConnector.RegisterRendererDriver((IRendererDriver)DriversManager.Instance.RendererDriver);
            DriversManager.Instance.RendererDriver.Connector = this.RendererDriverConnector;
            this.ScreenDriverConnector = (IScreenDriverConnector)new Tango.Drivers.ScreenDriverConnector();
            this.ScreenDriverConnector.RegisterDriver((IScreenDriver)DriversManager.Instance.ScreenDriver);
            this.AudioModeMonitorDriverConnector = (IAudioModeMonitorDriverConnector)new Tango.Drivers.AudioModeMonitorDriverConnector();
            this.AudioModeMonitorDriverConnector.RegisterDriver((IAudioModeMonitorDriver)DriversManager.Instance.AudioModeMonitorDriver);
            this.SoundEffPlayerDriverConnector = (ISoundEffPlayerDriverConnector)new Tango.Drivers.SoundEffPlayerDriverConnector();
            this.SoundEffPlayerDriverConnector.RegisterDriver((ISoundEffPlayerDriver)DriversManager.Instance.SoundEffPlayerDriver);
            try
            {
                this.RecorderDriverConnector = (IRecorderDriverConnector)new Tango.Drivers.RecorderDriverConnector();
                this.RecorderDriverConnector.RegisterRecorderDriver((IRecorderDriver)DriversManager.Instance.RecorderDriver);
                DriversManager.Instance.RecorderDriver.Connector = this.RecorderDriverConnector;
            }
            catch (Exception ex)
            {
                Logger.Trace("new RecorderDriverConnector() failed with error: " + ex.Message);
            }
            try
            {
                this.PlayerDriverConnector = (IPlayerDriverConnector)new Tango.Drivers.PlayerDriverConnector();
                this.PlayerDriverConnector.RegisterPlayerDriver((IPlayerDriver)DriversManager.Instance.PlayerDriver);
                DriversManager.Instance.PlayerDriver.Connector = this.PlayerDriverConnector;
            }
            catch (Exception ex)
            {
                Logger.Trace("new PlayerDriverConnector() failed with error: " + ex.Message);
            }
            this.ConnectivityDriverConnector = (IConnectivityDriverConnector)new Tango.Drivers.ConnectivityDriverConnector();
            this.ConnectivityDriverConnector.RegisterConnectivityDriver((IConnectivityDriver)DriversManager.Instance.ConnectivityDriver);
        }

        public void InitTangoEnvironment()
        {
            byte[] numArray1 = new byte[50];
            int datalen;
            this.Engine.GetVersion(50, numArray1, out datalen);
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
            this.Engine.GetPushServiceName(128, numArray2, out namelen);
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
            this.Engine.GetTargetDevice(50, numArray, out buflen);
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