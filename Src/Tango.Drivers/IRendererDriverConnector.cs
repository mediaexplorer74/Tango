// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IRendererDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("495248EF-9C82-472a-A220-9DFA568D248F")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IRendererDriverConnector
  {
    void RegisterRendererDriver(IRendererDriver RendererDriver);

    void GetScreenLog([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] Buffer, int Length, out int DataLen);
  }
}
