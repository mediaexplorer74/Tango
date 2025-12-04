// UWP compatible stub - no XNA or camera dependencies
using System;
using System.Diagnostics;
using System.Windows;
using Tango.Toolbox;

#nullable disable
namespace Tango.Drivers
{
  public class CapturerDriver : ICapturerDriver
  {
    public ICapturerDriverConnector CapturerDriverConnector { get; set; }

    public bool IsCameraInitialized(int cameraIndex) => false;

    public bool IsCameraReady(int cameraIndex) => false;

    public bool IsCapturing(int cameraIndex) => false;

    public void Init(int cameraIndex)
    {
      throw new NotSupportedException("Camera initialization not available in UWP");
    }

    public void UnInit(int cameraIndex)
    {
      throw new NotSupportedException("Camera deinitialization not available in UWP");
    }

    public void DetectCamera(out int backCameraIndex, out int frontCameraIndex)
    {
      backCameraIndex = -1;
      frontCameraIndex = -1;
    }

    public void InitializeCamera(int cameraIndex)
    {
      throw new NotSupportedException("Camera initialization not available in UWP");
    }

    public void CaptureImage(int cameraIndex)
    {
      throw new NotSupportedException("Camera capture not available in UWP");
    }

    public void StartVideoCapturing(int cameraIndex)
    {
      throw new NotSupportedException("Video recording not available in UWP");
    }

    public void StopVideoCapturing(int cameraIndex)
    {
      throw new NotSupportedException("Video recording not available in UWP");
    }

    public void StartRecording(int cameraIndex)
    {
      throw new NotSupportedException("Video recording not available in UWP");
    }

    public void StopRecording(int cameraIndex)
    {
      throw new NotSupportedException("Video recording not available in UWP");
    }

    public void SetVideoCaptureFrameInterval(int cameraIndex, uint interval)
    {
      throw new NotSupportedException("Video capture settings not available in UWP");
    }

    public void SetVideoCropSize(int cameraIndex, int width, int height)
    {
      throw new NotSupportedException("Video capture settings not available in UWP");
    }

    public void SetViewFinderSource(int cameraIndex, object source)
    {
      // UWP stub - no viewfinder functionality
    }

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }

    public delegate void SetViewFinderSourceDelegate(int cameraIndex, object source);
  }
}
