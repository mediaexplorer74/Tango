// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.NameHelpers
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.Globalization;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  internal class NameHelpers
  {
    internal static string UnderscoresToPascalCase(string input)
    {
      return NameHelpers.UnderscoresToPascalOrCamelCase(input, true);
    }

    internal static string UnderscoresToCamelCase(string input)
    {
      return NameHelpers.UnderscoresToPascalOrCamelCase(input, false);
    }

    private static string UnderscoresToPascalOrCamelCase(string input, bool pascal)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool flag = pascal;
      for (int index = 0; index < input.Length; ++index)
      {
        char c = input[index];
        if ('a' <= c && c <= 'z')
        {
          if (flag)
            stringBuilder.Append(char.ToUpper(c));
          else
            stringBuilder.Append(c);
          flag = false;
        }
        else if ('A' <= c && c <= 'Z')
        {
          if (index == 0 && !pascal)
            stringBuilder.Append(char.ToLower(c));
          else
            stringBuilder.Append(c);
          flag = false;
        }
        else if ('0' <= c && c <= '9')
        {
          stringBuilder.Append(c);
          flag = true;
        }
        else
          flag = true;
      }
      return stringBuilder.ToString();
    }

    internal static string StripProto(string text)
    {
      if (!NameHelpers.StripSuffix(ref text, ".protodevel"))
        NameHelpers.StripSuffix(ref text, ".proto");
      return text;
    }

    internal static bool StripSuffix(ref string text, string suffix)
    {
      if (!text.EndsWith(suffix))
        return false;
      text = text.Substring(0, text.Length - suffix.Length);
      return true;
    }
  }
}
