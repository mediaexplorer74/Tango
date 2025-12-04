// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IDevInfoDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("656968A7-C2F1-4f39-BD53-FE6C273CEBFF")]
  [ComVisible(true)]
  [ComImport]
  public interface IDevInfoDriver
  {
    void device_id([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] data, int buffsize, ref int size);

    void device_model([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] char[] data, int buffsize, out int size);

    void subscriber_number(StringBuilder subscriberNumber, int isSubscriberNumInternational);

    void get_locale([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] char[] data, int buffsize, out int size);
  }
}
