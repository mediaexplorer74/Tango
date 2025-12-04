// UWP compatible PNG decoder stub
using ImageTools.Helpers;
using System;
using System.IO;

#nullable disable
namespace ImageTools.IO.Png
{
  public class PngDecoder : IImageDecoder
  {
    public int HeaderSize => 8;

    public bool IsSupportedFileExtension(string extension)
    {
      Guard.NotNullOrEmpty(extension, nameof (extension));
      return extension.ToUpper() == "PNG";
    }

    public bool IsSupportedFileFormat(byte[] header)
    {
      bool flag = false;
      if (header.Length >= 8)
        flag = header[0] == (byte) 137 && header[1] == (byte) 80 && header[2] == (byte) 78 && header[3] == (byte) 71 && header[4] == (byte) 13 && header[5] == (byte) 10 && header[6] == (byte) 26 && header[7] == (byte) 10;
      return flag;
    }

    public void Decode(ExtendedImage image, Stream stream)
    {
      // UWP stub - PNG decoding not available without SharpZipLib
      throw new NotSupportedException("PNG decoding not available in UWP without SharpZipLib");
    }
  }
}
