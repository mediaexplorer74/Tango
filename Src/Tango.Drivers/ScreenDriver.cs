// UWP compatible stub - no Phone dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class ScreenDriver : IScreenDriver
  {
    public IScreenDriverConnector ScreenDriverConnector { get; set; }

    public void CaptureScreen()
    {
      throw new NotSupportedException("Screen capture not available in UWP");
    }

    public void SetUserIdleDetectionMode(int mode)
    {
      throw new NotSupportedException("Idle detection not available in UWP");
    }

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
