// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.Logger
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

#nullable disable
namespace Tango.Toolbox
{
  public class Logger : IWPLogger
  {
    private static Socket _socket;
    private static string _serverName;
    private static int _serverPort;

    public void Trace(StringBuilder log)
    {
        //
    }

    public void DebugWriteLine(StringBuilder log)
    {
      if (log.Length <= 0)
        return;
      Logger.TraceImpl(log.ToString(), false, false);
    }

    public static void SetUdpServer(string serverName, int serverPort)
    {
      if (Logger._socket == null)
        Logger._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
      Logger._serverName = serverName;
      Logger._serverPort = serverPort;
    }

    public static void Trace(string logStr) => Logger.TraceImpl(logStr, true, true);

    private static void TraceImpl(string logStr, bool withTime, bool lineEnd)
    {
      string str = string.Empty;
      if (withTime)
      {
        DateTime localTime = DateTime.Now.ToLocalTime();
        str = string.Format("{0} {1:D2} {2:D2} {3:D2}:{4:D2}:{5:D2}.{6:D3} (C#) ", (object) localTime.Year, (object) localTime.Month, (object) localTime.Day, (object) localTime.Hour, (object) localTime.Minute, (object) localTime.Second, (object) localTime.Millisecond);
      }
      if (Logger._socket != null)
      {
        SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        e.RemoteEndPoint = (EndPoint) new DnsEndPoint(Logger._serverName, Logger._serverPort, AddressFamily.InterNetwork);
        byte[] bytes = Encoding.UTF8.GetBytes(str + logStr + (lineEnd ? "\n" : string.Empty));
        e.SetBuffer(bytes, 0, bytes.Length);
        Logger._socket.SendToAsync(e);
      }
      else
      {
        if (lineEnd)
          return;
        int length = logStr.Length;
      }
    }
  }
}
