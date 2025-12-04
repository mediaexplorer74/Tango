// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IAudioModeMonitorDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [ComVisible(true)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("3B3BDF1C-60CE-4BF6-A1EB-A25EA9002854")]
  [ComImport]
  public interface IAudioModeMonitorDriver
  {
    void OnAudioModeChanging(int oldAudioMode, int newAudioMode);

    void OnAudioModeChanged(int newAudioMode);

    void GetSysAudioPath(out int path);
  }
}
