// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IRecorderDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [ComVisible(true)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("6CE4EBA3-B1EA-4851-A841-E2262B2E6219")]
  [ComImport]
  public interface IRecorderDriver
  {
    void StartAudioRecording();

    void StopAudioRecording();
  }
}
