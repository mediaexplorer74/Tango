// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IConnectivityDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [ComVisible(true)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("16167087-8BFF-423d-BA9A-2C85D15E2B1F")]
  [ComImport]
  public interface IConnectivityDriver
  {
    void GetNetworkType(out int networkType);

    void GetIsNetworkAvailable(out int networkStatus);
  }
}
