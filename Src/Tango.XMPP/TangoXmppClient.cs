using System;
using System.Threading.Tasks;
using Waher.Networking.XMPP;

namespace Tango.XMPP
{
    /// <summary>
    /// XMPP client implementation for Tango messaging
    /// </summary>
    public class TangoXmppClient
    {
        private XmppClient client;
        private string host;
        private int port;
        private string username;
        private string password;
        
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
        /// Creates a new instance of the Tango XMPP client
        /// </summary>
        /// <param name="host">XMPP server host</param>
        /// <param name="port">XMPP server port</param>
        public TangoXmppClient(string host, int port = 5222)
        {
            this.host = host;
            this.port = port;
        }
        
        /// <summary>
        /// Connects to the XMPP server
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task<bool> ConnectAsync(string username, string password)
        {
            this.username = username;
            this.password = password;
            
            try
            {
                // Create XMPP client
                this.client = new XmppClient(this.host, this.port, this.username, this.password);
                
                // Subscribe to events
                this.client.OnMessage += Client_OnMessage;
                this.client.OnPresence += Client_OnPresence;
                this.client.OnConnectionStateChanged += Client_OnConnectionStateChanged;
                
                // Connect to server
                await this.client.Connect();
                
                return true;
            }
            catch (Exception ex)
            {
                // Log error
                System.Diagnostics.Debug.WriteLine($"Failed to connect: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Disconnects from the XMPP server
        /// </summary>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task DisconnectAsync()
        {
            if (this.client != null)
            {
                await this.client.Disconnect();
                this.client.Dispose();
                this.client = null;
            }
        }
        
        /// <summary>
        /// Sends a message to a recipient
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <param name="message">Message content</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendMessageAsync(string to, string message)
        {
            if (this.client != null && this.client.State == XmppState.Connected)
            {
                await this.client.SendMessage(to, message);
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
            if (this.client != null && this.client.State == XmppState.Connected)
            {
                await this.client.SetPresence(show, status);
            }
        }
        
        #region Event Handlers
        
        private void Client_OnMessage(object sender, MessageEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }
        
        private void Client_OnPresence(object sender, PresenceEventArgs e)
        {
            PresenceReceived?.Invoke(this, e);
        }
        
        private void Client_OnConnectionStateChanged(object sender, XmppState NewState)
        {
            ConnectionStateChanged?.Invoke(this, new ConnectionStateChangedEventArgs(NewState));
        }
        
        #endregion
    }
    
    /// <summary>
    /// Event arguments for message events
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// From JID
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// To JID
        /// </summary>
        public string To { get; set; }
        
        /// <summary>
        /// Message body
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Message type
        /// </summary>
        public string Type { get; set; }
    }
    
    /// <summary>
    /// Event arguments for presence events
    /// </summary>
    public class PresenceEventArgs : EventArgs
    {
        /// <summary>
        /// From JID
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// To JID
        /// </summary>
        public string To { get; set; }
        
        /// <summary>
        /// Presence show value
        /// </summary>
        public string Show { get; set; }
        
        /// <summary>
        /// Status message
        /// </summary>
        public string Status { get; set; }
    }
    
    /// <summary>
    /// Event arguments for connection state changes
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// New connection state
        /// </summary>
        public XmppState State { get; set; }
        
        /// <summary>
        /// Creates a new instance of ConnectionStateChangedEventArgs
        /// </summary>
        /// <param name="state">New connection state</param>
        public ConnectionStateChangedEventArgs(XmppState state)
        {
            this.State = state;
        }
    }
}