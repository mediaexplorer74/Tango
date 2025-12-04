// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Gif.GifLogicalScreenDescriptor
// Assembly: ImageTools.IO.Gif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA7F4B99-2235-4710-895B-B5451D936C00
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Gif.dll

using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace ImageTools.IO.Gif
{
  internal sealed class GifLogicalScreenDescriptor
  {
    public short Width;
    public short Height;
    public byte Packed;
    public byte Background;
    [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "Perhaps used later.")]
    public byte AspectRatio;
    public bool GlobalColorTableFlag;
    [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "Perhaps used later.")]
    public bool SortFlag;
    [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "Perhaps used later.")]
    public byte ColorResolution;
    public int GlobalColorTableSize;
  }
}
