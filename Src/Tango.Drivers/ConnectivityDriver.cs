// UWP compatible stub - no Phone dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class ConnectivityDriver : IConnectivityDriver
  {
    public IConnectivityDriverConnector ConnectivityDriverConnector { get; set; }

    public void GetIsNetworkAvailable(out int isAvailable)
    {
      isAvailable = 0; // UWP stub - network not available
    }

    public void GetNetworkType(out int networkType)
    {
      networkType = 0; // UWP stub - unknown network type
    }

    public bool IsNetworkAvailable()
    {
      return false; // UWP stub - network not available
    }

    public string GetNetworkType()
    {
      return "UWP-Stub";
    }

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
