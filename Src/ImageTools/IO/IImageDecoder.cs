// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.IImageDecoder
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System.IO;

#nullable disable
namespace ImageTools.IO
{
  public interface IImageDecoder
  {
    int HeaderSize { get; }

    bool IsSupportedFileExtension(string extension);

    bool IsSupportedFileFormat(byte[] header);

    void Decode(ExtendedImage image, Stream stream);
  }
}
