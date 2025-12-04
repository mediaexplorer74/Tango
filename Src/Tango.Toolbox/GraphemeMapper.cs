// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.GraphemeMapper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

#nullable disable
namespace Tango.Toolbox
{
  public abstract class GraphemeMapper : IGraphemeMapper
  {
    public bool GetFirstGraphemeOfCharacter(char character, out char grapheme)
    {
      if (this.IsValidCharacter(character))
        return this.GetFirstGrapheme(character, out grapheme);
      grapheme = char.MinValue;
      return false;
    }

    protected abstract bool IsValidCharacter(char character);

    protected abstract bool GetFirstGrapheme(char character, out char grapheme);
  }
}
