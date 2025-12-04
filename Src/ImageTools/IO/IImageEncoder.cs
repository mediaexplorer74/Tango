// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.IImageEncoder
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System.IO;

#nullable disable
namespace ImageTools.IO
{
  public interface IImageEncoder
  {
    string Extension { get; }

    bool IsSupportedFileExtension(string extension);

    void Encode(ExtendedImage image, Stream stream);
  }
}
