using System;

namespace sgiggle.xmpp
{
    public interface IWPMessageSender
    {
        void SendMessage(int msg_type, int size, byte[] payload);
    }
}