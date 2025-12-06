using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tango.Toolbox;
using Tango.Messages; // Protocol Buffer generated messages

namespace Tango.XMPP
{
    /// <summary>
    /// Handles Tango-specific message processing
    /// </summary>
    public class TangoMessageHandler
    {
        private XmppServiceManager xmppService;
        
        /// <summary>
        /// Event raised when a Tango message is received
        /// </summary>
        public event EventHandler<TangoMessageEventArgs> TangoMessageReceived;
        
        /// <summary>
        /// Creates a new instance of the Tango message handler
        /// </summary>
        public TangoMessageHandler()
        {
            this.xmppService = XmppServiceManager.Instance;
            
            // Subscribe to XMPP events
            this.xmppService.MessageReceived += OnXmppMessageReceived;
            this.xmppService.PresenceReceived += OnXmppPresenceReceived;
        }
        
        /// <summary>
        /// Sends a Tango message
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <param name="messageType">Message type</param>
        /// <param name="payload">Message payload</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendTangoMessageAsync(string to, MessageType messageType, byte[] payload)
        {
            // Create a Tango message format using Protocol Buffers
            var tangoMessage = new TangoMessage
            {
                Type = messageType,
                Timestamp = DateTime.UtcNow.ToBinary(),
                Payload = payload ?? new byte[0]
            };
            
            // Serialize the message using Protocol Buffers
            byte[] serializedMessage = tangoMessage.ToByteArray();
            
            // Convert to Base64 string for XMPP transmission
            string messageBody = Convert.ToBase64String(serializedMessage);
            
            // Send via XMPP
            await this.xmppService.SendMessageAsync(to, messageBody);
        }
        
        /// <summary>
        /// Sends a specific payload message
        /// </summary>
        /// <typeparam name="T">Type of payload</typeparam>
        /// <param name="to">Recipient JID</param>
        /// <param name="messageType">Message type</param>
        /// <param name="payload">Payload to send</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendPayloadMessageAsync<T>(string to, MessageType messageType, T payload) where T : Google.Protobuf.IMessage<T>, new()
        {
            // Serialize the payload
            byte[] payloadBytes = payload.ToByteArray();
            
            // Send as Tango message
            await SendTangoMessageAsync(to, messageType, payloadBytes);
        }
        
        /// <summary>
        /// Deserializes a Tango message from a Base64 string
        /// </summary>
        /// <param name="messageBody">Base64 encoded message string</param>
        /// <returns>Deserialized Tango message or null if failed</returns>
        private TangoMessage DeserializeTangoMessage(string messageBody)
        {
            try
            {
                // Convert from Base64
                byte[] messageBytes = Convert.FromBase64String(messageBody);
                
                // Deserialize using Protocol Buffers
                return TangoMessage.Parser.ParseFrom(messageBytes);
            }
            catch (Exception ex)
            {
                Logger.Trace($"Failed to deserialize Tango message: {ex.Message}");
            }
            
            return null;
        }
        
        /// <summary>
        /// Deserializes a specific payload from message bytes
        /// </summary>
        /// <typeparam name="T">Type of payload</typeparam>
        /// <param name="payloadBytes">Payload bytes</param>
        /// <returns>Deserialized payload or null if failed</returns>
        public T DeserializePayload<T>(byte[] payloadBytes) where T : Google.Protobuf.IMessage<T>, new()
        {
            try
            {
                // Parse the payload
                var parser = new T().Parser;
                return (T)parser.ParseFrom(payloadBytes);
            }
            catch (Exception ex)
            {
                Logger.Trace($"Failed to deserialize payload: {ex.Message}");
            }
            
            return default(T);
        }
        
        #region Event Handlers
        
        private void OnXmppMessageReceived(object sender, MessageEventArgs e)
        {
            Logger.Trace($"XMPP message received from {e.From}: {e.Body}");
            
            // Try to deserialize as a Tango message
            var tangoMessage = DeserializeTangoMessage(e.Body);
            if (tangoMessage != null)
            {
                var tangoEventArgs = new TangoMessageEventArgs
                {
                    From = e.From,
                    To = e.To,
                    MessageType = tangoMessage.Type,
                    Payload = tangoMessage.Payload.ToByteArray(),
                    Timestamp = DateTime.FromBinary(tangoMessage.Timestamp)
                };
                
                TangoMessageReceived?.Invoke(this, tangoEventArgs);
            }
        }
        
        private void OnXmppPresenceReceived(object sender, PresenceEventArgs e)
        {
            Logger.Trace($"XMPP presence received from {e.From}: {e.Show} - {e.Status}");
            // Handle presence information if needed
        }
        
        #endregion
    }
    
    /// <summary>
    /// Event arguments for Tango message events
    /// </summary>
    public class TangoMessageEventArgs : EventArgs
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
        /// Message type
        /// </summary>
        public MessageType MessageType { get; set; }
        
        /// <summary>
        /// Message payload
        /// </summary>
        public byte[] Payload { get; set; }
        
        /// <summary>
        /// Message timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}