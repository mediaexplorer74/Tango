// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IRendererDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComVisible(true)]
  [Guid("A02A49F4-E0B7-4571-8C10-D33EEDE8BE1C")]
  [ComImport]
  public interface IRendererDriver
  {
    void RenderVideoFrame([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), In] byte[] buffer, int length, int width, int height, int linesize);
  }
}
