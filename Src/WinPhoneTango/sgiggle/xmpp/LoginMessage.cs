namespace sgiggle.xmpp
{
    public class LoginMessage : ISendableMessage
    {
        public int MsgType { get; private set; }
        public byte[] MsgByteString { get; private set; }
        
        public LoginMessage(int msgType, LoginPayload payload)
        {
            MsgType = msgType;
            // In a real implementation, we would serialize the payload to bytes
            MsgByteString = new byte[0];
        }
    }
}