// Decompiled with JetBrains decompiler
// Type: ImageTools.DownloadProgressChangedEventArgs
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools
{
  public class DownloadProgressChangedEventArgs : EventArgs
  {
    public long BytesReceived { get; set; }
    public long TotalBytesToReceive { get; set; }
    public int ProgressPercentage { get; set; }

    public DownloadProgressChangedEventArgs()
    {
    }

    public DownloadProgressChangedEventArgs(long bytesReceived, long totalBytesToReceive, int progressPercentage)
    {
      this.BytesReceived = bytesReceived;
      this.TotalBytesToReceive = totalBytesToReceive;
      this.ProgressPercentage = progressPercentage;
    }
  }
}
