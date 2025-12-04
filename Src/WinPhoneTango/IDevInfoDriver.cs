using System;

namespace WinPhoneTango
{
    public interface IDevInfoDriver
    {
        string GetDeviceId();
        string GetOsVersion();
        string GetModel();
    }
}