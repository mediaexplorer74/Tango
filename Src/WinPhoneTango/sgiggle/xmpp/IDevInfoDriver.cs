using System;

namespace sgiggle.xmpp
{
    public interface IDevInfoDriver
    {
        string GetDeviceId();
        string GetOSVersion();
        string GetModel();
    }
}