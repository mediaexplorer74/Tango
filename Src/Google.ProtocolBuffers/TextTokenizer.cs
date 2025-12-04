// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.TextTokenizer
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Globalization;
using System.Text.RegularExpressions;

#nullable disable
namespace Google.ProtocolBuffers
{
  internal sealed class TextTokenizer
  {
    private readonly string text;
    private string currentToken;
    private int matchPos;
    private int pos;
    private int line;
    private int column;
    private int previousLine;
    private int previousColumn;
    internal static readonly Regex WhitespaceAndCommentPattern = new Regex("\\G(?>(\\s|(#.*$))+)", RegexOptions.Multiline);
    private static readonly Regex TokenPattern = new Regex("\\G[a-zA-Z_](?>[0-9a-zA-Z_+-]*)|\\G[0-9+-](?>[0-9a-zA-Z_.+-]*)|\\G\"(?>([^\"\\\n\\\\]|\\\\.)*)(\"|\\\\?$)|\\G'(?>([^\"\\\n\\\\]|\\\\.)*)('|\\\\?$)", RegexOptions.Multiline);
    private static readonly Regex DoubleInfinity = new Regex("^-?inf(inity)?$", RegexOptions.IgnoreCase);
    private static readonly Regex FloatInfinity = new Regex("^-?inf(inity)?f?$", RegexOptions.IgnoreCase);
    private static readonly Regex FloatNan = new Regex("^nanf?$", RegexOptions.IgnoreCase);

    public TextTokenizer(string text)
    {
      this.text = text;
      this.SkipWhitespace();
      this.NextToken();
    }

    public bool AtEnd => this.currentToken.Length == 0;

    public void NextToken()
    {
      this.previousLine = this.line;
      this.previousColumn = this.column;
      for (; this.pos < this.matchPos; ++this.pos)
      {
        if (this.text[this.pos] == '\n')
        {
          ++this.line;
          this.column = 0;
        }
        else
          ++this.column;
      }
      if (this.matchPos == this.text.Length)
      {
        this.currentToken = "";
      }
      else
      {
        Match match = TextTokenizer.TokenPattern.Match(this.text, this.matchPos);
        if (match.Success)
        {
          this.currentToken = match.Value;
          this.matchPos += match.Length;
        }
        else
        {
          this.currentToken = this.text[this.matchPos].ToString();
          ++this.matchPos;
        }
        this.SkipWhitespace();
      }
    }

    private void SkipWhitespace()
    {
      Match match = TextTokenizer.WhitespaceAndCommentPattern.Match(this.text, this.matchPos);
      if (!match.Success)
        return;
      this.matchPos += match.Length;
    }

    public bool TryConsume(string token)
    {
      if (!(this.currentToken == token))
        return false;
      this.NextToken();
      return true;
    }

    public void Consume(string token)
    {
      if (!this.TryConsume(token))
        throw this.CreateFormatException("Expected \"" + token + "\".");
    }

    public bool LookingAtInteger()
    {
      if (this.currentToken.Length == 0)
        return false;
      char ch = this.currentToken[0];
      return '0' <= ch && ch <= '9' || ch == '-' || ch == '+';
    }

    public string ConsumeIdentifier()
    {
      foreach (char ch in this.currentToken)
      {
        if (('a' > ch || ch > 'z') && ('A' > ch || ch > 'Z') && ('0' > ch || ch > '9') && ch != '_' && ch != '.')
          throw this.CreateFormatException("Expected identifier.");
      }
      string currentToken = this.currentToken;
      this.NextToken();
      return currentToken;
    }

    public int ConsumeInt32()
    {
      try
      {
        int int32 = TextFormat.ParseInt32(this.currentToken);
        this.NextToken();
        return int32;
      }
      catch (FormatException ex)
      {
        throw this.CreateIntegerParseException(ex);
      }
    }

    public uint ConsumeUInt32()
    {
      try
      {
        uint uint32 = TextFormat.ParseUInt32(this.currentToken);
        this.NextToken();
        return uint32;
      }
      catch (FormatException ex)
      {
        throw this.CreateIntegerParseException(ex);
      }
    }

    public long ConsumeInt64()
    {
      try
      {
        long int64 = TextFormat.ParseInt64(this.currentToken);
        this.NextToken();
        return int64;
      }
      catch (FormatException ex)
      {
        throw this.CreateIntegerParseException(ex);
      }
    }

    public ulong ConsumeUInt64()
    {
      try
      {
        ulong uint64 = TextFormat.ParseUInt64(this.currentToken);
        this.NextToken();
        return uint64;
      }
      catch (FormatException ex)
      {
        throw this.CreateIntegerParseException(ex);
      }
    }

    public double ConsumeDouble()
    {
      if (TextTokenizer.DoubleInfinity.IsMatch(this.currentToken))
      {
        bool flag = this.currentToken.StartsWith("-");
        this.NextToken();
        return !flag ? double.PositiveInfinity : double.NegativeInfinity;
      }
      if (this.currentToken.Equals("nan", StringComparison.OrdinalIgnoreCase))
      {
        this.NextToken();
        return double.NaN;
      }
      try
      {
        double num = double.Parse(this.currentToken, (IFormatProvider) CultureInfo.InvariantCulture);
        this.NextToken();
        return num;
      }
      catch (FormatException ex)
      {
        throw this.CreateFloatParseException((Exception) ex);
      }
      catch (OverflowException ex)
      {
        throw this.CreateFloatParseException((Exception) ex);
      }
    }

    public float ConsumeFloat()
    {
      if (TextTokenizer.FloatInfinity.IsMatch(this.currentToken))
      {
        bool flag = this.currentToken.StartsWith("-");
        this.NextToken();
        return !flag ? float.PositiveInfinity : float.NegativeInfinity;
      }
      if (TextTokenizer.FloatNan.IsMatch(this.currentToken))
      {
        this.NextToken();
        return float.NaN;
      }
      if (this.currentToken.EndsWith("f"))
        this.currentToken = this.currentToken.TrimEnd('f');
      try
      {
        float num = float.Parse(this.currentToken, (IFormatProvider) CultureInfo.InvariantCulture);
        this.NextToken();
        return num;
      }
      catch (FormatException ex)
      {
        throw this.CreateFloatParseException((Exception) ex);
      }
      catch (OverflowException ex)
      {
        throw this.CreateFloatParseException((Exception) ex);
      }
    }

    public bool ConsumeBoolean()
    {
      if (this.currentToken == "true")
      {
        this.NextToken();
        return true;
      }
      if (!(this.currentToken == "false"))
        throw this.CreateFormatException("Expected \"true\" or \"false\".");
      this.NextToken();
      return false;
    }

    public string ConsumeString() => this.ConsumeByteString().ToStringUtf8();

    public ByteString ConsumeByteString()
    {
      char ch = this.currentToken.Length > 0 ? this.currentToken[0] : char.MinValue;
      switch (ch)
      {
        case '"':
        case '\'':
          if (this.currentToken.Length >= 2)
          {
            if ((int) this.currentToken[this.currentToken.Length - 1] == (int) ch)
            {
              try
              {
                ByteString byteString = TextFormat.UnescapeBytes(this.currentToken.Substring(1, this.currentToken.Length - 2));
                this.NextToken();
                return byteString;
              }
              catch (FormatException ex)
              {
                throw this.CreateFormatException(ex.Message);
              }
            }
          }
          throw this.CreateFormatException("String missing ending quote.");
        default:
          throw this.CreateFormatException("Expected string.");
      }
    }

    public FormatException CreateFormatException(string description)
    {
      return new FormatException((this.line + 1).ToString() + ":" + (object) (this.column + 1) + ": " + description);
    }

    public FormatException CreateFormatExceptionPreviousToken(string description)
    {
      return new FormatException((this.previousLine + 1).ToString() + ":" + (object) (this.previousColumn + 1) + ": " + description);
    }

    private FormatException CreateIntegerParseException(FormatException e)
    {
      return this.CreateFormatException("Couldn't parse integer: " + e.Message);
    }

    private FormatException CreateFloatParseException(Exception e)
    {
      return this.CreateFormatException("Couldn't parse number: " + e.Message);
    }
  }
}
