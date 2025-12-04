// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.ISoundEffPlayerDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("146AFB58-F521-4DBF-BEC9-37041F6B7D17")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface ISoundEffPlayerDriverConnector
  {
    void RegisterDriver(ISoundEffPlayerDriver driver);
  }
}
