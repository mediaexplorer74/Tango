// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Png.PngChunk
// Assembly: ImageTools.IO.Png, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 913BCB8E-4E5E-40FF-9958-92528869A980
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Png.dll

#nullable disable
namespace ImageTools.IO.Png
{
  internal sealed class PngChunk
  {
    public int Length;
    public string Type;
    public byte[] Data;
    public uint Crc;
  }
}
