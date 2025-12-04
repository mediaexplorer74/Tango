// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IContactsDriverConnector
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("F00C678A-033A-458A-BD03-9461847A30E5")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface IContactsDriverConnector
  {
    void RegisterContactsDriver(IContactsDriver ContactsDriver);

    void OnGetAllContactsComplete([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), In] byte[] Buffer, int Length, [MarshalAs(UnmanagedType.Bool)] bool result);

    void GetContactByAccountId([MarshalAs(UnmanagedType.LPWStr)] string account_id, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), Out] byte[] Buffer, ref int Length, [MarshalAs(UnmanagedType.Bool)] out bool result);
  }
}
