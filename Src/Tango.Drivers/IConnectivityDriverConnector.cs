// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IConnectivityDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("90ACCF67-2DCA-44bc-A4EC-3B50111BD2B4")]
  [ComImport]
  public interface IConnectivityDriverConnector
  {
    void RegisterConnectivityDriver(IConnectivityDriver connectivityDriver);
  }
}
