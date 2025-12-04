// Decompiled with JetBrains decompiler
// Type: ImageTools.IImageResizer
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

#nullable disable
namespace ImageTools
{
  public interface IImageResizer
  {
    void Resize(ImageBase source, ImageBase target, int width, int height);
  }
}
