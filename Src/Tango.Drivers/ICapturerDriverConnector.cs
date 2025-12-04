// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.ICapturerDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("829924F8-895D-4153-8BF1-8472B7A6DC79")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface ICapturerDriverConnector
  {
    void RegisterCapturerDriver(ICapturerDriver CapturerDriver);

    void SendVideoCaptueredData([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] buffer, int length, long timestamp, bool isFrontCam);
  }
}
