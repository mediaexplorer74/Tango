// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IContactsDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("FDE6C73A-2909-4028-A2E9-FECCBF9B98C0")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComVisible(true)]
  [ComImport]
  public interface IContactsDriver
  {
    void GetAllContacts();
  }
}
