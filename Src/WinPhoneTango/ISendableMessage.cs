using System;

namespace WinPhoneTango
{
    public interface ISendableMessage
    {
        int MsgType { get; }
        byte[] MsgByteString { get; }
    }
}