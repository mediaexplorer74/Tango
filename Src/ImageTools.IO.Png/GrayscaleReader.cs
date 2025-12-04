// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.GrayscaleReader
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

#nullable disable
namespace ImageTools.IO.Png
{
  internal sealed class GrayscaleReader : IColorReader
  {
    private int _row;
    private bool _useAlpha;

    public GrayscaleReader(bool useAlpha) => this._useAlpha = useAlpha;

    public void ReadScanline(byte[] scanline, byte[] pixels, PngHeader header)
    {
      if (this._useAlpha)
      {
        for (int index1 = 0; index1 < scanline.Length / 2; ++index1)
        {
          int index2 = (this._row * header.Width + index1) * 4;
          pixels[index2] = scanline[index1 * 2];
          pixels[index2 + 1] = scanline[index1 * 2];
          pixels[index2 + 2] = scanline[index1 * 2];
          pixels[index2 + 3] = scanline[index1 * 2 + 1];
        }
      }
      else
      {
        for (int index3 = 0; index3 < scanline.Length; ++index3)
        {
          int index4 = (this._row * header.Width + index3) * 4;
          pixels[index4] = scanline[index3];
          pixels[index4 + 1] = scanline[index3];
          pixels[index4 + 2] = scanline[index3];
          pixels[index4 + 3] = byte.MaxValue;
        }
      }
      ++this._row;
    }
  }
}
