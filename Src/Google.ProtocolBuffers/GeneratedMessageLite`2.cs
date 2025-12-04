// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedMessageLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class GeneratedMessageLite<TMessage, TBuilder> : 
    AbstractMessageLite<TMessage, TBuilder>
    where TMessage : GeneratedMessageLite<TMessage, TBuilder>
    where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
  {
    protected abstract TMessage ThisMessage { get; }

    public override sealed string ToString()
    {
      using (StringWriter writer = new StringWriter())
      {
        this.PrintTo((TextWriter) writer);
        return writer.ToString();
      }
    }

    protected static void PrintField<T>(string name, IList<T> value, TextWriter writer)
    {
      foreach (T obj in (IEnumerable<T>) value)
        GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, (object) obj, writer);
    }

    protected static void PrintField(string name, bool hasValue, object value, TextWriter writer)
    {
      if (!hasValue)
        return;
      switch (value)
      {
        case IMessageLite _:
          writer.WriteLine("{0} {{", (object) name);
          ((IMessageLite) value).PrintTo(writer);
          writer.WriteLine("}");
          break;
        case ByteString _:
        case string _:
          writer.Write("{0}: \"", (object) name);
          if (value is string)
            GeneratedMessageLite<TMessage, TBuilder>.EscapeBytes((IEnumerable<byte>) Encoding.UTF8.GetBytes((string) value), writer);
          else
            GeneratedMessageLite<TMessage, TBuilder>.EscapeBytes((IEnumerable<byte>) value, writer);
          writer.WriteLine("\"");
          break;
        case bool flag:
          writer.WriteLine("{0}: {1}", (object) name, flag ? (object) "true" : (object) "false");
          break;
        case IEnumLite _:
          writer.WriteLine("{0}: {1}", (object) name, (object) ((IEnumLite) value).Name);
          break;
        default:
          writer.WriteLine("{0}: {1}", (object) name, (object) ((IConvertible) value).ToString((IFormatProvider) CultureInfo.InvariantCulture));
          break;
      }
    }

    private static void EscapeBytes(IEnumerable<byte> input, TextWriter writer)
    {
      foreach (byte num in input)
      {
        switch (num)
        {
          case 7:
            writer.Write("\\a");
            continue;
          case 8:
            writer.Write("\\b");
            continue;
          case 9:
            writer.Write("\\t");
            continue;
          case 10:
            writer.Write("\\n");
            continue;
          case 11:
            writer.Write("\\v");
            continue;
          case 12:
            writer.Write("\\f");
            continue;
          case 13:
            writer.Write("\\r");
            continue;
          case 34:
            writer.Write("\\\"");
            continue;
          case 39:
            writer.Write("\\'");
            continue;
          case 92:
            writer.Write("\\\\");
            continue;
          default:
            if (num >= (byte) 32 && num < (byte) 128)
            {
              writer.Write((char) num);
              continue;
            }
            writer.Write('\\');
            writer.Write((char) (48 + ((int) num >> 6 & 3)));
            writer.Write((char) (48 + ((int) num >> 3 & 7)));
            writer.Write((char) (48 + ((int) num & 7)));
            continue;
        }
      }
    }
  }
}
