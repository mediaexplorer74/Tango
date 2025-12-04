// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.RendererDriver
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tango.Toolbox;

#nullable disable
namespace Tango.Drivers
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class RendererDriver : IRendererDriver
  {
    private const int MAX_VIDEO_RENDER_QUEUE_SIZE = 3;
    private RendererDriver.RenderVideoFrameHandlerDelegate _renderVideoHandler;

    public RendererDriver() => this.VideoRenderQueue = new Queue<VideoRenderBuffer>();

    public void Init(
      RendererDriver.RenderVideoFrameHandlerDelegate renderVideoHandler)
    {
      this._renderVideoHandler = renderVideoHandler;
    }

    void IRendererDriver.RenderVideoFrame(
      [MarshalAs(UnmanagedType.LPArray), In] byte[] buffer,
      int length,
      int width,
      int height,
      int linesize)
    {
      VideoRenderBuffer videoRenderBuffer = new VideoRenderBuffer();
      videoRenderBuffer.Buffer = (byte[]) buffer.Clone();
      videoRenderBuffer.Height = height;
      videoRenderBuffer.Width = width;
      lock ("VideoRenderBuffer")
      {
        if (this.VideoRenderQueue.Count > 3)
        {
          Logger.Trace("RenderVideoFrame(), queue is full, dropped one");
          this.VideoRenderQueue.Dequeue();
        }
        this.VideoRenderQueue.Enqueue(videoRenderBuffer);
      }
    }

    public IRendererDriverConnector Connector { set; get; }

    public Queue<VideoRenderBuffer> VideoRenderQueue { get; set; }

    public delegate void RenderVideoFrameHandlerDelegate(byte[] buffer, int width, int height);
  }
}
