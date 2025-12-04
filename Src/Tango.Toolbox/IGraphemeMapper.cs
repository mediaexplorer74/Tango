// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.IGraphemeMapper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

#nullable disable
namespace Tango.Toolbox
{
  public interface IGraphemeMapper
  {
    bool GetFirstGraphemeOfCharacter(char character, out char grapheme);
  }
}
