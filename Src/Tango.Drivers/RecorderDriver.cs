// UWP compatible stub - no XNA audio dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class RecorderDriver : IRecorderDriver
  {
    public IRecorderDriverConnector RecorderDriverConnector { get; set; }

    public void Start()
    {
      throw new NotSupportedException("Audio recording not available in UWP");
    }

    public void StartAudioRecording()
    {
      throw new NotSupportedException("Audio recording not available in UWP");
    }

    public void Stop()
    {
      throw new NotSupportedException("Audio recording not available in UWP");
    }

    public void StopAudioRecording()
    {
      throw new NotSupportedException("Audio recording not available in UWP");
    }

    public bool IsRecording => false;

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
