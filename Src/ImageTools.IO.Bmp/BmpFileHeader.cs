// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Bmp.BmpFileHeader
// Assembly: ImageTools.IO.Bmp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CA5E000-9BA5-446B-BCEE-3A948EBA69F3
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Bmp.dll

#nullable disable
namespace ImageTools.IO.Bmp
{
  internal class BmpFileHeader
  {
    public const int Size = 14;
    public short Type;
    public int FileSize;
    public int Reserved;
    public int Offset;
  }
}
