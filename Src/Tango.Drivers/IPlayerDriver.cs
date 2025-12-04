// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IPlayerDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("64A8BF37-4E1D-4b59-B6AB-66BB43D4D839")]
  [ComVisible(true)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IPlayerDriver
  {
    void StartAudioPlaying();

    void StopAudioPlaying();
  }
}
