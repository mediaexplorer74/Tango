using System;
using System.Runtime.InteropServices;

namespace WinPhoneTango
{
    [ComImport]
    [Guid("EC85075D-4E62-47BC-A8CF-3FE1F6BFB984")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPMessageSender
    {
        void Send(int msgType, int size, byte[] payload);
    }
}
