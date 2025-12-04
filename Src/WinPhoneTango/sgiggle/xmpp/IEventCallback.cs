using System;

namespace sgiggle.xmpp
{
    public interface IEventCallback
    {
        void HandleEvent(int event_id, int size, byte[] payload);
    }
}