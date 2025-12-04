// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.AudioModeMonitorDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;
using Tango.Toolbox;

#nullable disable
namespace Tango.Drivers
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class AudioModeMonitorDriver : IAudioModeMonitorDriver
  {
    private SystemMediaController _systemMediaController = new SystemMediaController();

    public AudioModeMonitorDriver.AudioMode CurrentAudioMode { get; private set; }

    public AudioModeMonitorDriver()
    {
      this.CurrentAudioMode = AudioModeMonitorDriver.AudioMode.AM_INVALID;
    }

    public bool IsCallingOrInCall()
    {
      return this.CurrentAudioMode == AudioModeMonitorDriver.AudioMode.AM_INCALL || this.CurrentAudioMode == AudioModeMonitorDriver.AudioMode.AM_RING || this.CurrentAudioMode == AudioModeMonitorDriver.AudioMode.AM_RINGBACK;
    }

    void IAudioModeMonitorDriver.OnAudioModeChanging(int oldAudioMode, int newAudioMode)
    {
      Logger.Trace(string.Format("Audio mode is changing from {0} to {1}", (object) (AudioModeMonitorDriver.AudioMode) oldAudioMode, (object) (AudioModeMonitorDriver.AudioMode) newAudioMode));
      if ((oldAudioMode == 0 || oldAudioMode == 4) && (newAudioMode == 1 || newAudioMode == 2 || newAudioMode == 3))
      {
        this._systemMediaController.PauseSystemMedia();
      }
      else
      {
        if (newAudioMode != 0 && newAudioMode != 4 || oldAudioMode != 1 && oldAudioMode != 2 && oldAudioMode != 3)
          return;
        this._systemMediaController.ResumeSystemMedia();
      }
    }

    void IAudioModeMonitorDriver.OnAudioModeChanged(int newAudioMode)
    {
      this.CurrentAudioMode = (AudioModeMonitorDriver.AudioMode) newAudioMode;
    }

    void IAudioModeMonitorDriver.GetSysAudioPath(out int path)
    {
      if (SamsungRegistryManager.Instance.IsEnabled)
      {
        uint num1 = 0;
        SamsungRegistryManager.Instance.RegistryGetDWORD(SamsungRegistryManager.HKEY_LOCAL_MACHINE, "System\\State\\Hardware", "Bluetooth", out num1);
        if (num1 == 19U || num1 == 29U)
        {
          path = 6;
        }
        else
        {
          uint num2 = 0;
          SamsungRegistryManager.Instance.RegistryGetDWORD(SamsungRegistryManager.HKEY_LOCAL_MACHINE, "System\\State\\Hardware", "Headset", out num2);
          if (num2 != 0U)
          {
            SamsungRegistryManager.Instance.RegistryGetDWORD(SamsungRegistryManager.HKEY_LOCAL_MACHINE, "SoftWare\\Samsung\\Audio", "EarJackType", out num2);
            path = num2 == 2U ? 2 : 3;
          }
          else
            path = 0;
        }
      }
      else
        path = 0;
    }

    private enum AudioPath
    {
      AudioPathUnknown,
      AudioPathReceiver,
      AudioPathHeadsetWithMic,
      AudioPathHeadsetWithoutMic,
      AudioPathHeadsetWithMicAndSpeaker,
      AudioPathHeadsetWithoutMicAndSpeaker,
      AudioPathBluetooth,
      AudioPathBluetoothAndSpeaker,
      AudioPathSpeaker,
    }

    public enum AudioMode
    {
      AM_NORMAL,
      AM_INCALL,
      AM_RING,
      AM_RINGBACK,
      AM_INVALID,
    }

    private enum SamsungEarJackType
    {
      EARJACK_TYPE_NONE,
      EARJACK_TYPE_3_POLES,
      EARJACK_TYPE_4_POLES,
    }
  }
}
