// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.ChineseGraphemeMapper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

#nullable disable
namespace Tango.Toolbox
{
  public class ChineseGraphemeMapper : GraphemeMapper
  {
    private static object _instanceLock = new object();
    private static ChineseGraphemeMapper _instance;
    private Dictionary<string, string> _unicodeToPinyinMap;
    private static readonly string DB_FILE_PATH = "Resources/unicode_to_hanyu_pinyin.txt";

    public static ChineseGraphemeMapper Instance
    {
      get
      {
        if (ChineseGraphemeMapper._instance == null)
        {
          lock (ChineseGraphemeMapper._instanceLock)
          {
            if (ChineseGraphemeMapper._instance == null)
              ChineseGraphemeMapper._instance = new ChineseGraphemeMapper();
          }
        }
        return ChineseGraphemeMapper._instance;
      }
    }

    private ChineseGraphemeMapper() => this.InitializeResources();

    private void InitializeResources()
    {
      this._unicodeToPinyinMap = new Dictionary<string, string>();
      try
      {
        //StreamReader streamReader = new StreamReader(Application.GetResourceStream(new Uri(ChineseGraphemeMapper.DB_FILE_PATH, UriKind.Relative)).Stream);
        //if (streamReader == null)
        {
          Logger.Trace("[ChineseGraphemeMapper::InitializeResources]error reading db file");
        }
        //else
        {
          //string str;
          //while ((str = streamReader.ReadLine()) != null)
          //{
            //string[] strArray = str.Split(' ');
            //if (strArray != null && strArray.Length == 2)
            //  this._unicodeToPinyinMap.Add(strArray[0], strArray[1]);
            //else
            //  Logger.Trace("[ChineseGraphemeMapper::InitializeResources]wrong line found in db file");
          //}
        }
      }
      catch (IOException ex)
      {
        Logger.Trace("[ChineseGraphemeMapper::InitializeResources] error reading db file" + ex.ToString());
      }
    }

    protected override bool GetFirstGrapheme(char character, out char grapheme)
    {
      grapheme = char.MinValue;
      string pinyinFormatString = this.GetPinyinFormatString(character);
      if (string.IsNullOrEmpty(pinyinFormatString))
        return false;
      int num1 = pinyinFormatString.IndexOf(ChineseGraphemeMapper.PinyinFormatMark.LEFT_BRACKET);
      int num2 = pinyinFormatString.IndexOf(ChineseGraphemeMapper.PinyinFormatMark.RIGHT_BRACKET);
      string str = pinyinFormatString.Substring(num1 + ChineseGraphemeMapper.PinyinFormatMark.LEFT_BRACKET.Length, num2 - num1);
      if (string.IsNullOrEmpty(str))
        return false;
      grapheme = str.Trim()[0];
      return true;
    }

    protected override bool IsValidCharacter(char character)
    {
      return character >= '一' && character <= '龥';
    }

    private string GetPinyinFormatString(char character)
    {
      string key = string.Format("{0:X}", (object) Convert.ToInt32(character));
      string str;
      return string.IsNullOrEmpty(key) || !this._unicodeToPinyinMap.TryGetValue(key, out str) ? string.Empty : str;
    }

    public static bool Test()
    {
      IGraphemeMapper graphemeMapper = (IGraphemeMapper) new ChineseGraphemeMapper();
      char grapheme;
      bool graphemeOfCharacter = graphemeMapper.GetFirstGraphemeOfCharacter('我', out grapheme);
      graphemeOfCharacter = graphemeMapper.GetFirstGraphemeOfCharacter('哈', out grapheme);
      graphemeOfCharacter = graphemeMapper.GetFirstGraphemeOfCharacter('垚', out grapheme);
      graphemeOfCharacter = graphemeMapper.GetFirstGraphemeOfCharacter('曾', out grapheme);
      graphemeOfCharacter = graphemeMapper.GetFirstGraphemeOfCharacter('a', out grapheme);
      return graphemeMapper.GetFirstGraphemeOfCharacter('쾶', out grapheme);
    }

    private static class PinyinFormatMark
    {
      public static readonly string LEFT_BRACKET = "(";
      public static readonly string RIGHT_BRACKET = ")";
      public static readonly string COMMA = ",";
    }
  }
}
