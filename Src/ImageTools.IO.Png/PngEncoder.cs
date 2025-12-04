// UWP compatible PNG encoder stub
using ImageTools.Helpers;
using System;
using System.IO;

#nullable disable
namespace ImageTools.IO.Png
{
  public class PngEncoder : IImageEncoder
  {
    public string Extension => "PNG";

    public bool IsSupportedFileExtension(string extension)
    {
      Guard.NotNullOrEmpty(extension, nameof (extension));
      return extension.ToUpper() == "PNG";
    }

    public void Encode(ExtendedImage image, Stream stream)
    {
      // UWP stub - PNG encoding not available without SharpZipLib
      throw new NotSupportedException("PNG encoding not available in UWP without SharpZipLib");
    }
  }
}
