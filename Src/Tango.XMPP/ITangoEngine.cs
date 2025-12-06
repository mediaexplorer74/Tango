using System;

namespace Tango.XMPP
{
    /// <summary>
    /// Interface for the Tango engine
    /// </summary>
    public interface ITangoEngine
    {
        /// <summary>
        /// Sets the environment for the engine
        /// </summary>
        /// <param name="logger">Logger instance</param>
        /// <param name="appDir">Application directory</param>
        void SetEnvironment(IWPLogger logger, string appDir);
        
        /// <summary>
        /// Initializes the engine
        /// </summary>
        void Initialize();
        
        /// <summary>
        /// Registers a message receiver
        /// </summary>
        /// <param name="callback">Event callback</param>
        void RegisterMessageReceiver(IEventCallback callback);
        
        /// <summary>
        /// Finalizes the engine
        /// </summary>
        void FinalizeEngine();
        
        /// <summary>
        /// Starts the engine
        /// </summary>
        void Start();
        
        /// <summary>
        /// Stops the engine
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Gets the next sequence ID
        /// </summary>
        /// <param name="nextSid">Next sequence ID</param>
        void GetNextSequenceId(ref long nextSid);
        
        /// <summary>
        /// Registers a device info driver
        /// </summary>
        /// <param name="devinfoDriver">Device info driver</param>
        void RegisterDevInfoDriver(IDevInfoDriver devinfoDriver);
        
        /// <summary>
        /// Sets and looks up country code
        /// </summary>
        /// <param name="retCountryId">Return country ID</param>
        /// <param name="isoCode0">First character of ISO code</param>
        /// <param name="isoCode1">Second character of ISO code</param>
        void SetAndLookupCountryCode(out int retCountryId, char isoCode0, char isoCode1);
        
        /// <summary>
        /// Gets the version
        /// </summary>
        /// <param name="versionSize">Version buffer size</param>
        /// <param name="versionData">Version data buffer</param>
        /// <param name="dataLen">Data length</param>
        void GetVersion(int versionSize, byte[] versionData, out int dataLen);
        
        /// <summary>
        /// Gets the push service name
        /// </summary>
        /// <param name="nameSize">Name buffer size</param>
        /// <param name="nameData">Name data buffer</param>
        /// <param name="nameLen">Name length</param>
        void GetPushServiceName(int nameSize, byte[] nameData, out int nameLen);
        
        /// <summary>
        /// Gets the target device
        /// </summary>
        /// <param name="bufferSize">Buffer size</param>
        /// <param name="buffer">Buffer</param>
        /// <param name="bufLen">Buffer length</param>
        void GetTargetDevice(int bufferSize, byte[] buffer, out int bufLen);
    }
}