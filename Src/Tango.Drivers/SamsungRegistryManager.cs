// UWP compatible stub - no Phone dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class SamsungRegistryManager
  {
    public static SamsungRegistryManager Instance { get; } = new SamsungRegistryManager();
    public const uint HKEY_LOCAL_MACHINE = 0x80000002;

    public bool IsEnabled
    {
      get { return false; } // UWP stub - not enabled
    }

    public bool IsSamsungDevice()
    {
      return false; // UWP stub - not a Samsung device
    }

    public void RegistryGetDWORD(uint hKey, string subKey, string valueName, out uint result)
    {
      result = 0; // UWP stub - return default value
    }

    public void SetRegistryValue(string key, string value)
    {
      throw new NotSupportedException("Registry access not available in UWP");
    }
  }
}
