// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Bmp.BmpInfoHeader
// Assembly: ImageTools.IO.Bmp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CA5E000-9BA5-446B-BCEE-3A948EBA69F3
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Bmp.dll

#nullable disable
namespace ImageTools.IO.Bmp
{
  internal class BmpInfoHeader
  {
    public const int Size = 40;
    public int HeaderSize;
    public int Width;
    public int Height;
    public short Planes;
    public short BitsPerPixel;
    public BmpCompression Compression;
    public int ImageSize;
    public int XPelsPerMeter;
    public int YPelsPerMeter;
    public int ClrUsed;
    public int ClrImportant;
  }
}
