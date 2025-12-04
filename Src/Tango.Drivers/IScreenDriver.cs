// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.IScreenDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("EDA4DDE6-B35A-44A4-B3D8-7151D0E2962B")]
  [InterfaceType(ComInterfaceType.InterfaceIsDual)]
  [ComVisible(true)]
  [ComImport]
  public interface IScreenDriver
  {
    void SetUserIdleDetectionMode(int isToTurnOn);
  }
}
