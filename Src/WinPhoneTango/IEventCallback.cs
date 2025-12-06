using System;
using System.Runtime.InteropServices;

namespace WinPhoneTango
{
    [ComImport]
    [Guid("F4CF507A-8E8B-4C3D-9A4F-5E6B7C8D9E0F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEventCallback
    {
        void HandleEvent(int eventId, int size, byte[] payload);
    }
}
