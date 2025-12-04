// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.TextGenerator
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.IO;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class TextGenerator
  {
    private readonly string lineBreak;
    private readonly TextWriter writer;
    private bool atStartOfLine = true;
    private readonly StringBuilder indent = new StringBuilder();

    public TextGenerator(TextWriter writer, string lineBreak)
    {
      this.writer = writer;
      this.lineBreak = lineBreak;
    }

    public void Indent() => this.indent.Append("  ");

    public void Outdent()
    {
      if (this.indent.Length == 0)
        throw new InvalidOperationException("Too many calls to Outdent()");
      this.indent.Length -= 2;
    }

    public void WriteLine(string text)
    {
      this.Print(text);
      this.Print("\n");
    }

    public void WriteLine(string format, params object[] args)
    {
      this.WriteLine(string.Format(format, args));
    }

    public void WriteLine() => this.WriteLine("");

    public void Print(string text)
    {
      int startIndex = 0;
      for (int index = 0; index < text.Length; ++index)
      {
        if (text[index] == '\n')
        {
          this.Write(text.Substring(startIndex, index - startIndex));
          this.Write(this.lineBreak);
          startIndex = index + 1;
          this.atStartOfLine = true;
        }
      }
      this.Write(text.Substring(startIndex));
    }

    public void Write(string format, params object[] args)
    {
      this.Write(string.Format(format, args));
    }

    private void Write(string data)
    {
      if (data.Length == 0)
        return;
      if (this.atStartOfLine)
      {
        this.atStartOfLine = false;
        this.writer.Write((object) this.indent);
      }
      this.writer.Write(data);
    }
  }
}
