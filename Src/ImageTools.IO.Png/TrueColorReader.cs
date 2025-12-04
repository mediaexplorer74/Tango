// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.TrueColorReader
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

using System;

#nullable disable
namespace ImageTools.IO.Png
{
  internal sealed class TrueColorReader : IColorReader
  {
    private int _row;
    private bool _useAlpha;

    public TrueColorReader(bool useAlpha) => this._useAlpha = useAlpha;

    public void ReadScanline(byte[] scanline, byte[] pixels, PngHeader header)
    {
      if (this._useAlpha)
      {
        Array.Copy((Array) scanline, 0, (Array) pixels, this._row * header.Width * 4, scanline.Length);
      }
      else
      {
        for (int index1 = 0; index1 < scanline.Length / 3; ++index1)
        {
          int index2 = (this._row * header.Width + index1) * 4;
          pixels[index2] = scanline[index1 * 3];
          pixels[index2 + 1] = scanline[index1 * 3 + 1];
          pixels[index2 + 2] = scanline[index1 * 3 + 2];
          pixels[index2 + 3] = byte.MaxValue;
        }
      }
      ++this._row;
    }
  }
}
