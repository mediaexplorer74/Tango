// Decompiled with JetBrains decompiler
// Type: ImageTools.DownloadCompletedEventArgs
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools
{
  public class DownloadCompletedEventArgs : EventArgs
  {
    public bool Cancelled { get; set; }
    public Exception Error { get; set; }
    public object Result { get; set; }

    public DownloadCompletedEventArgs()
    {
    }

    public DownloadCompletedEventArgs(object result, Exception error, bool cancelled)
    {
      this.Result = result;
      this.Error = error;
      this.Cancelled = cancelled;
    }
  }
}
