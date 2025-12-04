// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IRecorderDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("2FE4063F-74FD-4c6f-BD2A-BED090D4590D")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IRecorderDriverConnector
  {
    void RegisterRecorderDriver(IRecorderDriver RecorderDriver);

    void OnAudioBufferReady([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), In, Out] byte[] Buffer, int Length);
  }
}
