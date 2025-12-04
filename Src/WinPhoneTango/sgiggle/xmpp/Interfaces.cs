using System;

namespace sgiggle.xmpp
{
    public interface IEventCallback
    {
        void HandleEvent(int eventId, int size, byte[] payload);
    }
    
    public interface IDevInfoDriver
    {
        string GetDeviceId();
        string GetOsVersion();
        string GetModel();
    }
    
    public interface IWPLogger
    {
        void DebugWriteLine(System.Text.StringBuilder log);
    }
}