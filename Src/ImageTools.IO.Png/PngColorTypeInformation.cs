// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.PngColorTypeInformation
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

using System;

#nullable disable
namespace ImageTools.IO.Png
{
  internal sealed class PngColorTypeInformation
  {
    public int[] SupportedBitDepths { get; private set; }

    public Func<byte[], byte[], IColorReader> ScanlineReaderFactory { get; private set; }

    public int ScanlineFactor { get; private set; }

    public PngColorTypeInformation(
      int scanlineFactor,
      int[] supportedBitDepths,
      Func<byte[], byte[], IColorReader> scanlineReaderFactory)
    {
      this.ScanlineFactor = scanlineFactor;
      this.ScanlineReaderFactory = scanlineReaderFactory;
      this.SupportedBitDepths = supportedBitDepths;
    }

    public IColorReader CreateColorReader(byte[] palette, byte[] paletteAlpha)
    {
      return this.ScanlineReaderFactory(palette, paletteAlpha);
    }
  }
}
