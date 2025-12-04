// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IPlayerDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("046C641E-1E6D-42c5-AB08-2D5AC0B2F94A")]
  [ComImport]
  public interface IPlayerDriverConnector
  {
    void RegisterPlayerDriver(IPlayerDriver PlayerDriver);

    void GetAudioParams(
      out uint frameIntervalInMs,
      out uint bufferSize,
      out uint sampleRateInHz,
      out uint bitsPerSample,
      out uint channelCount);

    void GetAudioFrameData([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] Buffer, int Length, out uint RetSize);
  }
}
