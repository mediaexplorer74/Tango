using System;
using System.Globalization;
using System.Text;
using Tango.Toolbox;
using WinPhoneTango;

namespace Tango.XMPP
{
    /// <summary>
    /// Pure C# implementation of the Tango engine
    /// </summary>
    public class PureTangoEngine : ITangoEngine
    {
        private IWPLogger logger;
        private string appDirectory;
        private IEventCallback eventCallback;
        private IDevInfoDriver devInfoDriver;
        private bool isInitialized;
        private bool isStarted;
        private Random random;
        
        /// <summary>
        /// Creates a new instance of the PureTangoEngine
        /// </summary>
        public PureTangoEngine()
        {
            this.random = new Random();
            this.isInitialized = false;
            this.isStarted = false;
        }
        
        /// <summary>
        /// Sets the environment for the engine
        /// </summary>
        /// <param name="logger">Logger instance</param>
        /// <param name="appDir">Application directory</param>
        public void SetEnvironment(IWPLogger logger, string appDir)
        {
            this.logger = logger;
            this.appDirectory = appDir;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Environment set");
            }
        }
        
        /// <summary>
        /// Initializes the engine
        /// </summary>
        public void Initialize()
        {
            if (this.isInitialized)
                return;
                
            this.isInitialized = true;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Initialized");
            }
        }
        
        /// <summary>
        /// Registers a message receiver
        /// </summary>
        /// <param name="callback">Event callback</param>
        public void RegisterMessageReceiver(IEventCallback callback)
        {
            this.eventCallback = callback;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Message receiver registered");
            }
        }
        
        /// <summary>
        /// Finalizes the engine
        /// </summary>
        public void FinalizeEngine()
        {
            this.isInitialized = false;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Finalized");
            }
        }
        
        /// <summary>
        /// Starts the engine
        /// </summary>
        public void Start()
        {
            if (this.isStarted)
                return;
                
            this.isStarted = true;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Started");
            }
        }
        
        /// <summary>
        /// Stops the engine
        /// </summary>
        public void Stop()
        {
            if (!this.isStarted)
                return;
                
            this.isStarted = false;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Stopped");
            }
        }
        
        /// <summary>
        /// Gets the next sequence ID
        /// </summary>
        /// <param name="nextSid">Next sequence ID</param>
        public void GetNextSequenceId(ref long nextSid)
        {
            nextSid = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds + this.random.Next(1000);
            
            if (this.logger != null)
            {
                this.logger.Trace($"PureTangoEngine: Next sequence ID = {nextSid}");
            }
        }
        
        /// <summary>
        /// Registers a device info driver
        /// </summary>
        /// <param name="devinfoDriver">Device info driver</param>
        public void RegisterDevInfoDriver(IDevInfoDriver devinfoDriver)
        {
            this.devInfoDriver = devinfoDriver;
            
            if (this.logger != null)
            {
                this.logger.Trace("PureTangoEngine: Device info driver registered");
            }
        }
        
        /// <summary>
        /// Sets and looks up country code
        /// </summary>
        /// <param name="retCountryId">Return country ID</param>
        /// <param name="isoCode0">First character of ISO code</param>
        /// <param name="isoCode1">Second character of ISO code</param>
        public void SetAndLookupCountryCode(out int retCountryId, char isoCode0, char isoCode1)
        {
            // Simple implementation that returns a default country ID
            retCountryId = 1; // Default to US
            
            if (this.logger != null)
            {
                this.logger.Trace($"PureTangoEngine: Country code set to {isoCode0}{isoCode1}, ID = {retCountryId}");
            }
        }
        
        /// <summary>
        /// Gets the version
        /// </summary>
        /// <param name="versionSize">Version buffer size</param>
        /// <param name="versionData">Version data buffer</param>
        /// <param name="dataLen">Data length</param>
        public void GetVersion(int versionSize, byte[] versionData, out int dataLen)
        {
            string version = "1.0.0.0"; // Default version
            byte[] versionBytes = Encoding.UTF8.GetBytes(version);
            
            dataLen = Math.Min(versionSize, versionBytes.Length);
            Array.Copy(versionBytes, versionData, dataLen);
            
            if (this.logger != null)
            {
                this.logger.Trace($"PureTangoEngine: Version = {version}");
            }
        }
        
        /// <summary>
        /// Gets the push service name
        /// </summary>
        /// <param name="nameSize">Name buffer size</param>
        /// <param name="nameData">Name data buffer</param>
        /// <param name="nameLen">Name length</param>
        public void GetPushServiceName(int nameSize, byte[] nameData, out int nameLen)
        {
            string serviceName = "TangoPushService"; // Default service name
            byte[] nameBytes = Encoding.UTF8.GetBytes(serviceName);
            
            nameLen = Math.Min(nameSize, nameBytes.Length);
            Array.Copy(nameBytes, nameData, nameLen);
            
            if (this.logger != null)
            {
                this.logger.Trace($"PureTangoEngine: Push service name = {serviceName}");
            }
        }
        
        /// <summary>
        /// Gets the target device
        /// </summary>
        /// <param name="bufferSize">Buffer size</param>
        /// <param name="buffer">Buffer</param>
        /// <param name="bufLen">Buffer length</param>
        public void GetTargetDevice(int bufferSize, byte[] buffer, out int bufLen)
        {
            string deviceName = "UWPDevice"; // Default device name
            byte[] deviceBytes = Encoding.UTF8.GetBytes(deviceName);
            
            bufLen = Math.Min(bufferSize, deviceBytes.Length);
            Array.Copy(deviceBytes, buffer, bufLen);
            
            if (this.logger != null)
            {
                this.logger.Trace($"PureTangoEngine: Target device = {deviceName}");
            }
        }
        
        /// <summary>
        /// Simulates receiving a message from the XMPP service
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="size">Message size</param>
        /// <param name="payload">Message payload</param>
        public void SimulateMessageReceived(int eventId, int size, byte[] payload)
        {
            if (this.eventCallback != null)
            {
                this.eventCallback.HandleEvent(eventId, size, payload);
            }
        }

      
    }
}