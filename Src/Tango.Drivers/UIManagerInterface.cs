// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.UIManagerInterface
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

#nullable disable
namespace Tango.Drivers
{
  public abstract class UIManagerInterface
  {
    public abstract bool? IsAppStartFromPush();

    public abstract void ResigerCallEndedCallback(
      UIManagerInterface.CallEndedDelegate callback,
      bool toRegister);

    public abstract bool ResigerUIStartedCallback(
      UIManagerInterface.UIStartedDelegate callback,
      bool toRegister);

    public delegate void CallEndedDelegate();

    public delegate void UIStartedDelegate();
  }
}
