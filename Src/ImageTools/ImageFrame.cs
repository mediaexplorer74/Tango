// Decompiled with JetBrains decompiler
// Type: ImageTools.ImageFrame
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Diagnostics.Contracts;

#nullable disable
namespace ImageTools
{
  public class ImageFrame : ImageBase
  {
    public ImageFrame(ImageFrame other)
      : base((ImageBase) other)
    {
      Contract.Requires<ArgumentNullException>(other != null, "Other image cannot be null.");
      Contract.Requires<ArgumentException>(other.IsFilled, "Other image has not been loaded.");
      Contract.Ensures(this.IsFilled);
    }

    public ImageFrame()
    {
    }
  }
}
