// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.ICapturerDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [Guid("F6BCC9ED-B682-4f0d-8CE3-C9F8EF3F6343")]
  [ComVisible(true)]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  public interface ICapturerDriver
  {
    void Init(int target);

    void StartVideoCapturing(int target);

    void StopVideoCapturing(int target);

    void UnInit(int target);

    void SetVideoCaptureFrameInterval(int target, uint milliseconds);

    void SetVideoCropSize(int target, int width, int height);

    void DetectCamera(out int isBackCameraAvailable, out int isFrontCameraAvailable);
  }
}
