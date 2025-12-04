using System;

namespace sgiggle.xmpp
{
    public interface ISendableMessage
    {
        int MsgType { get; }
        byte[] MsgByteString { get; }
    }
}