// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IAudioModeMonitorDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("CF522B02-3F3E-4D6A-9001-6719391170FE")]
  [ComImport]
  public interface IAudioModeMonitorDriverConnector
  {
    void RegisterDriver(IAudioModeMonitorDriver AudioModeMonitorDriver);
  }
}
