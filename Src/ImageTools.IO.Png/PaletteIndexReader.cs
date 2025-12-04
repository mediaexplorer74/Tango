// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.PaletteIndexReader
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

#nullable disable
namespace ImageTools.IO.Png
{
  internal sealed class PaletteIndexReader : IColorReader
  {
    private int _row;
    private byte[] _palette;
    private byte[] _paletteAlpha;

    public PaletteIndexReader(byte[] palette, byte[] paletteAlpha)
    {
      this._palette = palette;
      this._paletteAlpha = paletteAlpha;
    }

    public void ReadScanline(byte[] scanline, byte[] pixels, PngHeader header)
    {
      if (this._paletteAlpha != null && this._paletteAlpha.Length > 0)
      {
        for (int index1 = 0; index1 < scanline.Length; ++index1)
        {
          int index2 = (int) scanline[index1];
          int index3 = (this._row * header.Width + index1) * 4;
          pixels[index3] = this._palette[index2 * 3];
          pixels[index3 + 1] = this._palette[index2 * 3 + 1];
          pixels[index3 + 2] = this._palette[index2 * 3 + 2];
          pixels[index3 + 3] = this._paletteAlpha.Length <= index2 ? byte.MaxValue : this._paletteAlpha[index2];
        }
      }
      else
      {
        for (int index4 = 0; index4 < scanline.Length; ++index4)
        {
          int num = (int) scanline[index4];
          int index5 = (this._row * header.Width + index4) * 4;
          pixels[index5] = this._palette[num * 3];
          pixels[index5 + 1] = this._palette[num * 3 + 1];
          pixels[index5 + 2] = this._palette[num * 3 + 2];
          pixels[index5 + 3] = byte.MaxValue;
        }
      }
      ++this._row;
    }
  }
}
