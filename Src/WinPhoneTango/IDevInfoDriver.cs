using System;
using System.Runtime.InteropServices;

namespace WinPhoneTango
{
    [ComImport]
    [Guid("A1B2C3D4-E5F6-4ABC-8DEF-0123456789AB")]  // Placeholder GUID
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDevInfoDriver
    {
        string GetDeviceId();
        string GetOsVersion();
        string GetModel();
    }
}