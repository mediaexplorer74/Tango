using System;
using System.Threading.Tasks;
using Tango.Messages;

namespace Tango.XMPP
{
    /// <summary>
    /// Test class for sending Tango messages
    /// </summary>
    public class TestMessageSender
    {
        private TangoMessageHandler messageHandler;
        
        /// <summary>
        /// Creates a new instance of the test message sender
        /// </summary>
        public TestMessageSender()
        {
            this.messageHandler = new TangoMessageHandler();
            
            // Subscribe to message events
            this.messageHandler.TangoMessageReceived += OnTangoMessageReceived;
        }
        
        /// <summary>
        /// Sends a test register user message
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendTestRegisterUserMessage(string to)
        {
            var registerPayload = new RegisterUserPayload
            {
                Username = "testuser",
                Password = "testpass",
                Email = "test@example.com",
                PhoneNumber = "+1234567890",
                DisplayName = "Test User"
            };
            
            await this.messageHandler.SendPayloadMessageAsync(to, MessageType.RegisterUser, registerPayload);
        }
        
        /// <summary>
        /// Sends a test contacts message
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendTestContactsMessage(string to)
        {
            var contactsPayload = new ContactsPayload();
            
            // Add some test contacts
            contactsPayload.Contacts.Add(new Contact
            {
                Id = "1",
                Name = "John Doe",
                PhoneNumber = "+1234567891",
                Email = "john@example.com",
                IsOnline = true
            });
            
            contactsPayload.Contacts.Add(new Contact
            {
                Id = "2",
                Name = "Jane Smith",
                PhoneNumber = "+1234567892",
                Email = "jane@example.com",
                IsOnline = false
            });
            
            await this.messageHandler.SendPayloadMessageAsync(to, MessageType.Contacts, contactsPayload);
        }
        
        /// <summary>
        /// Sends a test media session message
        /// </summary>
        /// <param name="to">Recipient JID</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public async Task SendTestMediaSessionMessage(string to)
        {
            var mediaPayload = new MediaSessionPayload
            {
                SessionId = Guid.NewGuid().ToString(),
                CallerId = "user1",
                CalleeId = "user2",
                MediaType = MediaType.Video,
                State = SessionState.Initiated
            };
            
            await this.messageHandler.SendPayloadMessageAsync(to, MessageType.MediaSession, mediaPayload);
        }
        
        #region Event Handlers
        
        private void OnTangoMessageReceived(object sender, TangoMessageEventArgs e)
        {
            Console.WriteLine($"Tango message received from {e.From}");
            Console.WriteLine($"Message type: {e.MessageType}");
            Console.WriteLine($"Timestamp: {e.Timestamp}");
            
            // Try to deserialize specific payload types
            switch (e.MessageType)
            {
                case MessageType.RegisterUser:
                    var registerPayload = messageHandler.DeserializePayload<RegisterUserPayload>(e.Payload);
                    if (registerPayload != null)
                    {
                        Console.WriteLine($"Register user: {registerPayload.Username}, {registerPayload.Email}");
                    }
                    break;
                    
                case MessageType.Contacts:
                    var contactsPayload = messageHandler.DeserializePayload<ContactsPayload>(e.Payload);
                    if (contactsPayload != null)
                    {
                        Console.WriteLine($"Contacts count: {contactsPayload.Contacts.Count}");
                        foreach (var contact in contactsPayload.Contacts)
                        {
                            Console.WriteLine($"  - {contact.Name} ({contact.Email})");
                        }
                    }
                    break;
                    
                case MessageType.MediaSession:
                    var mediaPayload = messageHandler.DeserializePayload<MediaSessionPayload>(e.Payload);
                    if (mediaPayload != null)
                    {
                        Console.WriteLine($"Media session: {mediaPayload.SessionId}, {mediaPayload.MediaType}");
                    }
                    break;
            }
        }
        
        #endregion
    }
}