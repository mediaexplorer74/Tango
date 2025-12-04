// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Bmp.BmpEncoder
// Assembly: ImageTools.IO.Bmp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CA5E000-9BA5-446B-BCEE-3A948EBA69F3
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Bmp.dll

using ImageTools.Helpers;
using System.Globalization;
using System.IO;

#nullable disable
namespace ImageTools.IO.Bmp
{
  public class BmpEncoder : IImageEncoder
  {
    public string Extension => "bmp";

    public bool IsSupportedFileExtension(string extension)
    {
      Guard.NotNullOrEmpty(extension, nameof (extension));
      string upper = extension.ToUpper();
      return upper == "BMP" || upper == "DIP";
    }

    public void Encode(ExtendedImage image, Stream stream)
    {
      Guard.NotNull((object) image, nameof (image));
      Guard.NotNull((object) stream, nameof (stream));
      int pixelWidth = image.PixelWidth;
      int num = image.PixelWidth * 3 % 4;
      if (num != 0)
        pixelWidth += 4 - num;
      using (BinaryWriter writer = new BinaryWriter(stream))
      {
        BmpEncoder.Write(writer, new BmpFileHeader()
        {
          Type = (short) 19778,
          Offset = 54,
          FileSize = 54 + image.PixelHeight * pixelWidth * 3
        });
        BmpEncoder.Write(writer, new BmpInfoHeader()
        {
          HeaderSize = 40,
          Height = image.PixelHeight,
          Width = image.PixelWidth,
          BitsPerPixel = (short) 24,
          Planes = (short) 1,
          Compression = BmpCompression.RGB,
          ImageSize = image.PixelHeight * pixelWidth * 3,
          ClrUsed = 0,
          ClrImportant = 0
        });
        BmpEncoder.WriteImage(writer, image);
        writer.Flush();
      }
    }

    private static void WriteImage(BinaryWriter writer, ExtendedImage image)
    {
      int num = image.PixelWidth * 3 % 4;
      if (num != 0)
        num = 4 - num;
      byte[] pixels = image.Pixels;
      for (int index1 = image.PixelHeight - 1; index1 >= 0; --index1)
      {
        for (int index2 = 0; index2 < image.PixelWidth; ++index2)
        {
          int index3 = (index1 * image.PixelWidth + index2) * 4;
          writer.Write(pixels[index3 + 2]);
          writer.Write(pixels[index3 + 1]);
          writer.Write(pixels[index3]);
        }
        for (int index4 = 0; index4 < num; ++index4)
          writer.Write((byte) 0);
      }
    }

    private static void Write(BinaryWriter writer, BmpFileHeader fileHeader)
    {
      writer.Write(fileHeader.Type);
      writer.Write(fileHeader.FileSize);
      writer.Write(fileHeader.Reserved);
      writer.Write(fileHeader.Offset);
    }

    private static void Write(BinaryWriter writer, BmpInfoHeader infoHeader)
    {
      writer.Write(infoHeader.HeaderSize);
      writer.Write(infoHeader.Width);
      writer.Write(infoHeader.Height);
      writer.Write(infoHeader.Planes);
      writer.Write(infoHeader.BitsPerPixel);
      writer.Write((int) infoHeader.Compression);
      writer.Write(infoHeader.ImageSize);
      writer.Write(infoHeader.XPelsPerMeter);
      writer.Write(infoHeader.YPelsPerMeter);
      writer.Write(infoHeader.ClrUsed);
      writer.Write(infoHeader.ClrImportant);
    }
  }
}
