// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.KoreanLanguageHelper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

#nullable disable
namespace Tango.Toolbox
{
  public class KoreanLanguageHelper
  {
    public static readonly int KOREAN_UNICODE_START = 44032;
    public static readonly int KOREAN_HEADER_GRAPHEME_START = 4352;
    public static readonly int KOREAN_HEADER_GRAPHEME_COUNT = 19;

    public static bool IsDuplicatedConsonants(int consonantIndex)
    {
      return consonantIndex == 1 || consonantIndex == 4 || consonantIndex == 8 || consonantIndex == 10 || consonantIndex == 13;
    }
  }
}
