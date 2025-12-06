using System;
using System.Threading.Tasks;
using Tango.Toolbox;

namespace Tango.XMPP
{
    /// <summary>
    /// Manages the XMPP service lifecycle
    /// </summary>
    public class XmppServiceManager
    {
        private static XmppServiceManager instance;
        private TangoXmppClient xmppClient;
        private bool isConnected;
        
        /// <summary>
        /// Gets the singleton instance of the XMPP service manager
        /// </summary>
        public static XmppServiceManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new XmppServiceManager();
                return instance;
            }
        }
        
        /// <summary>
        /// Event raised when a message is received
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceived;
        
        /// <summary>
        /// Event raised when presence information is received
        /// </summary>
        public event EventHandler<PresenceEventArgs> PresenceReceived;
        
        /// <summary>
        /// Event raised when the connection state changes
        /// </summary>
        public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;
        
        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private XmppServiceManager()
        {
        }
        
        /// <summary>
        /// Initializes the XMPP service
        /// </summary>
        /// <param name="host">XMPP server host</param>
        /// <param name="port">XMPP server port</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task InitializeAsync(string host, int port, string username, string password)
        {
            try
            {
                Logger.Trace("Initializing XMPP service...");
                
                // Create XMPP client
                this.xmppClient = new TangoXmppClient(host, port);
                
                // Subscribe to events
                this.xmppClient.MessageReceived += OnMessageReceived;
                this.xmppClient.PresenceReceived += OnPresenceReceived;
                this.xmppClient.ConnectionStateChanged += OnConnectionStateChanged;
                
                // Connect to server
                this.isConnected = await this.xmppClient.ConnectAsync(username, password);
                
                Logger.Trace($"XMPP service initialization {(this.isConnected ? "successful" : "failed")}");
            }
            catch (Exception ex)
            {
                Logger.Trace($"Failed to initialize XMPP service: {ex.Message}");
                this.isConnected = false;
            }
        }
        
        /// <summary>
        /// Shuts down the XMPP service
        /// </summary>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task ShutdownAsync()
        {
            Logger.Trace("Shutting down XMPP service...");
            
            if (this.xmppClient != null)
            {
                await this.xmppClient.DisconnectAsync();
                this.xmppClient = null;
                this.isConnected = false;
            }
            
            Logger.Trace("XMPP service shut down");
        }
        
        /// <summary>
        /// Sends a message
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <param name="message">Message content</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendMessageAsync(string to, string message)
        {
            if (this.xmppClient != null && this.isConnected)
            {
                await this.xmppClient.SendMessageAsync(to, message);
            }
        }
        
        /// <summary>
        /// Sets the user's presence
        /// </summary>
        /// <param name="show">Presence show value</param>
        /// <param name="status">Status message</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SetPresenceAsync(string show, string status)
        {
            if (this.xmppClient != null && this.isConnected)
            {
                await this.xmppClient.SetPresenceAsync(show, status);
            }
        }
        
        /// <summary>
        /// Gets the current connection state
        /// </summary>
        public bool IsConnected => this.isConnected;
        
        #region Event Handlers
        
        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            Logger.Trace($"Message received from {e.From}: {e.Body}");
            MessageReceived?.Invoke(this, e);
        }
        
        private void OnPresenceReceived(object sender, PresenceEventArgs e)
        {
            Logger.Trace($"Presence received from {e.From}: {e.Show} - {e.Status}");
            PresenceReceived?.Invoke(this, e);
        }
        
        private void OnConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            Logger.Trace($"Connection state changed to {e.State}");
            this.isConnected = e.State == Waher.Networking.XMPP.XmppState.Connected;
            ConnectionStateChanged?.Invoke(this, e);
        }
        
        #endregion
    }
}