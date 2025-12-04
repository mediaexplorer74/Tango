// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.ISoundEffPlayerDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [Guid("EEA90A6C-A912-4769-ADC0-95D2D9A7FEFD")]
  [ComVisible(true)]
  [ComImport]
  public interface ISoundEffPlayerDriver
  {
    void Play(SoundType SoundType);

    void Stop();
  }
}
