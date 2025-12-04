// UWP compatible stub - no contacts functionality
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class ContactsDriver : IContactsDriver
  {
    public IContactsDriverConnector ContactsDriverConnector { get; set; }

    public void SearchContacts(string filter)
    {
      throw new NotSupportedException("Contacts search not available in UWP");
    }

    public object GetContactPhoto(string contactId)
    {
      return null; // UWP stub - no photo available
    }

    public void GetAllContacts()
    {
      throw new NotSupportedException("GetAllContacts not available in UWP");
    }

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
