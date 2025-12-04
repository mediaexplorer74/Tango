// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.KoreanGraphemeMapper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System.Collections.Generic;

#nullable disable
namespace Tango.Toolbox
{
  public class KoreanGraphemeMapper : GraphemeMapper
  {
    private static object _instanceLock = new object();
    private static KoreanGraphemeMapper _instance;
    private Dictionary<int, char> _graphemeMap;

    public static KoreanGraphemeMapper Instance
    {
      get
      {
        if (KoreanGraphemeMapper._instance == null)
        {
          lock (KoreanGraphemeMapper._instanceLock)
          {
            if (KoreanGraphemeMapper._instance == null)
              KoreanGraphemeMapper._instance = new KoreanGraphemeMapper();
          }
        }
        return KoreanGraphemeMapper._instance;
      }
    }

    private KoreanGraphemeMapper() => this.InitMap();

    private void InitMap()
    {
      this._graphemeMap = new Dictionary<int, char>();
      for (int index = 0; index < KoreanLanguageHelper.KOREAN_HEADER_GRAPHEME_COUNT; ++index)
      {
        if (KoreanLanguageHelper.IsDuplicatedConsonants(index))
          this._graphemeMap.Add(index, (char) (KoreanLanguageHelper.KOREAN_HEADER_GRAPHEME_START + index - 1));
        else
          this._graphemeMap.Add(index, (char) (KoreanLanguageHelper.KOREAN_HEADER_GRAPHEME_START + index));
      }
    }

    protected override bool GetFirstGrapheme(char character, out char grapheme)
    {
      return this._graphemeMap.TryGetValue(((int) character - 44032) / 588, out grapheme);
    }

    protected override bool IsValidCharacter(char character)
    {
      return !char.IsWhiteSpace(character) && (int) character > KoreanLanguageHelper.KOREAN_UNICODE_START;
    }

    public static void Test()
    {
      IGraphemeMapper graphemeMapper = (IGraphemeMapper) new KoreanGraphemeMapper();
      char grapheme;
      graphemeMapper.GetFirstGraphemeOfCharacter('자', out grapheme);
      graphemeMapper.GetFirstGraphemeOfCharacter('댾', out grapheme);
      graphemeMapper.GetFirstGraphemeOfCharacter('쾶', out grapheme);
      graphemeMapper.GetFirstGraphemeOfCharacter('我', out grapheme);
      graphemeMapper.GetFirstGraphemeOfCharacter('a', out grapheme);
    }
  }
}
