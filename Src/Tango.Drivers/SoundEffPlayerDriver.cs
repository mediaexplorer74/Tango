// UWP compatible stub - no XNA audio dependencies
using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Drivers
{
  public class SoundEffPlayerDriver : ISoundEffPlayerDriver
  {
    public ISoundEffPlayerDriverConnector SoundEffPlayerDriverConnector { get; set; }

    public void Play(SoundType soundType)
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public void PlaySound(string soundName)
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public void Stop()
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public void StopSound()
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public void PauseSound()
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public void ResumeSound()
    {
      throw new NotSupportedException("Sound effects not available in UWP");
    }

    public bool IsPlaying => false;

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
