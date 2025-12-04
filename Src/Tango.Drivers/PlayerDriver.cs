// UWP compatible stub - no XNA audio dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class PlayerDriver : IPlayerDriver
  {
    public IPlayerDriverConnector PlayerDriverConnector { get; set; }

    public void Play()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public void StartAudioPlaying()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public void Stop()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public void StopAudioPlaying()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public void Pause()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public void Resume()
    {
      throw new NotSupportedException("Audio playback not available in UWP");
    }

    public bool IsPlaying => false;

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
