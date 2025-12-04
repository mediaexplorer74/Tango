// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.PngChunkTypes
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

#nullable disable
namespace ImageTools.IO.Png
{
  internal static class PngChunkTypes
  {
    public const string Header = "IHDR";
    public const string Palette = "PLTE";
    public const string Data = "IDAT";
    public const string End = "IEND";
    public const string PaletteAlpha = "tRNS";
    public const string Text = "tEXt";
    public const string Gamma = "gAMA";
  }
}
