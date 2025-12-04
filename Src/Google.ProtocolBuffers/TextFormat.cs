// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.TextFormat
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public static class TextFormat
  {
    public static void Print(IMessage message, TextWriter output)
    {
      TextGenerator generator = new TextGenerator(output, "\n");
      TextFormat.Print(message, generator);
    }

    public static void Print(UnknownFieldSet fields, TextWriter output)
    {
      TextGenerator generator = new TextGenerator(output, "\n");
      TextFormat.PrintUnknownFields(fields, generator);
    }

    public static string PrintToString(IMessage message)
    {
      StringWriter output = new StringWriter();
      TextFormat.Print(message, (TextWriter) output);
      return output.ToString();
    }

    public static string PrintToString(UnknownFieldSet fields)
    {
      StringWriter output = new StringWriter();
      TextFormat.Print(fields, (TextWriter) output);
      return output.ToString();
    }

    private static void Print(IMessage message, TextGenerator generator)
    {
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) message.AllFields)
        TextFormat.PrintField(allField.Key, allField.Value, generator);
      TextFormat.PrintUnknownFields(message.UnknownFields, generator);
    }

    internal static void PrintField(FieldDescriptor field, object value, TextGenerator generator)
    {
      if (field.IsRepeated)
      {
        foreach (object obj in (IEnumerable) value)
          TextFormat.PrintSingleField(field, obj, generator);
      }
      else
        TextFormat.PrintSingleField(field, value, generator);
    }

    private static void PrintSingleField(
      FieldDescriptor field,
      object value,
      TextGenerator generator)
    {
      if (field.IsExtension)
      {
        generator.Print("[");
        if (field.ContainingType.Options.MessageSetWireFormat && field.FieldType == FieldType.Message && field.IsOptional && field.ExtensionScope == field.MessageType)
          generator.Print(field.MessageType.FullName);
        else
          generator.Print(field.FullName);
        generator.Print("]");
      }
      else if (field.FieldType == FieldType.Group)
        generator.Print(field.MessageType.Name);
      else
        generator.Print(field.Name);
      if (field.MappedType == MappedType.Message)
      {
        generator.Print(" {\n");
        generator.Indent();
      }
      else
        generator.Print(": ");
      TextFormat.PrintFieldValue(field, value, generator);
      if (field.MappedType == MappedType.Message)
      {
        generator.Outdent();
        generator.Print("}");
      }
      generator.Print("\n");
    }

    private static void PrintFieldValue(
      FieldDescriptor field,
      object value,
      TextGenerator generator)
    {
      switch (field.FieldType)
      {
        case FieldType.Double:
        case FieldType.Float:
        case FieldType.Int64:
        case FieldType.UInt64:
        case FieldType.Int32:
        case FieldType.Fixed64:
        case FieldType.Fixed32:
        case FieldType.UInt32:
        case FieldType.SFixed32:
        case FieldType.SFixed64:
        case FieldType.SInt32:
        case FieldType.SInt64:
          generator.Print(((IConvertible) value).ToString((IFormatProvider) CultureInfo.InvariantCulture));
          break;
        case FieldType.Bool:
          generator.Print((bool) value ? "true" : "false");
          break;
        case FieldType.String:
          generator.Print("\"");
          generator.Print(TextFormat.EscapeText((string) value));
          generator.Print("\"");
          break;
        case FieldType.Group:
        case FieldType.Message:
          if (value is IMessageLite && !(value is IMessage))
            throw new NotSupportedException("Lite messages are not supported.");
          TextFormat.Print((IMessage) value, generator);
          break;
        case FieldType.Bytes:
          generator.Print("\"");
          generator.Print(TextFormat.EscapeBytes((ByteString) value));
          generator.Print("\"");
          break;
        case FieldType.Enum:
          if (value is IEnumLite && !(value is EnumValueDescriptor))
            throw new NotSupportedException("Lite enumerations are not supported.");
          generator.Print(((DescriptorBase<EnumValueDescriptorProto, EnumValueOptions>) value).Name);
          break;
      }
    }

    private static void PrintUnknownFields(UnknownFieldSet unknownFields, TextGenerator generator)
    {
      foreach (KeyValuePair<int, UnknownField> field in (IEnumerable<KeyValuePair<int, UnknownField>>) unknownFields.FieldDictionary)
      {
        string text = field.Key.ToString() + ": ";
        UnknownField unknownField = field.Value;
        foreach (ulong varint in (IEnumerable<ulong>) unknownField.VarintList)
        {
          generator.Print(text);
          generator.Print(varint.ToString());
          generator.Print("\n");
        }
        foreach (uint fixed32 in (IEnumerable<uint>) unknownField.Fixed32List)
        {
          generator.Print(text);
          generator.Print(string.Format("0x{0:x8}", (object) fixed32));
          generator.Print("\n");
        }
        foreach (ulong fixed64 in (IEnumerable<ulong>) unknownField.Fixed64List)
        {
          generator.Print(text);
          generator.Print(string.Format("0x{0:x16}", (object) fixed64));
          generator.Print("\n");
        }
        foreach (ByteString lengthDelimited in (IEnumerable<ByteString>) unknownField.LengthDelimitedList)
        {
          generator.Print(field.Key.ToString());
          generator.Print(": \"");
          generator.Print(TextFormat.EscapeBytes(lengthDelimited));
          generator.Print("\"\n");
        }
        foreach (UnknownFieldSet group in (IEnumerable<UnknownFieldSet>) unknownField.GroupList)
        {
          generator.Print(field.Key.ToString());
          generator.Print(" {\n");
          generator.Indent();
          TextFormat.PrintUnknownFields(group, generator);
          generator.Outdent();
          generator.Print("}\n");
        }
      }
    }

    internal static ulong ParseUInt64(string text)
    {
      return (ulong) TextFormat.ParseInteger(text, false, true);
    }

    internal static long ParseInt64(string text) => TextFormat.ParseInteger(text, true, true);

    internal static uint ParseUInt32(string text)
    {
      return (uint) TextFormat.ParseInteger(text, false, false);
    }

    internal static int ParseInt32(string text) => (int) TextFormat.ParseInteger(text, true, false);

    internal static float ParseFloat(string text)
    {
      switch (text)
      {
        case "-inf":
        case "-infinity":
        case "-inff":
        case "-infinityf":
          return float.NegativeInfinity;
        case "inf":
        case "infinity":
        case "inff":
        case "infinityf":
          return float.PositiveInfinity;
        case "nan":
        case "nanf":
          return float.NaN;
        default:
          return float.Parse(text, (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    internal static double ParseDouble(string text)
    {
      switch (text)
      {
        case "-inf":
        case "-infinity":
          return double.NegativeInfinity;
        case "inf":
        case "infinity":
          return double.PositiveInfinity;
        case "nan":
          return double.NaN;
        default:
          return double.Parse(text, (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    private static long ParseInteger(string text, bool isSigned, bool isLong)
    {
      string str = text;
      bool flag = false;
      if (text.StartsWith("-"))
      {
        if (!isSigned)
          throw new FormatException("Number must be positive: " + str);
        flag = true;
        text = text.Substring(1);
      }
      int fromBase = 10;
      if (text.StartsWith("0x"))
      {
        fromBase = 16;
        text = text.Substring(2);
      }
      else if (text.StartsWith("0"))
        fromBase = 8;
      ulong num1;
      try
      {
        num1 = fromBase == 10 ? ulong.Parse(text) : Convert.ToUInt64(text, fromBase);
      }
      catch (OverflowException ex)
      {
        throw new FormatException("Number out of range for " + string.Format("{0}-bit {1}signed integer", (object) (isLong ? 64 : 32), isSigned ? (object) "" : (object) "un") + ": " + str);
      }
      if (flag)
      {
        ulong num2 = isLong ? 9223372036854775808UL : 2147483648UL;
        if (num1 > num2)
          throw new FormatException("Number out of range for " + string.Format("{0}-bit signed integer", (object) (isLong ? 64 : 32)) + ": " + str);
        return -(long) num1;
      }
      ulong num3 = isSigned ? (isLong ? (ulong) long.MaxValue : (ulong) int.MaxValue) : (isLong ? ulong.MaxValue : (ulong) uint.MaxValue);
      return num1 <= num3 ? (long) num1 : throw new FormatException("Number out of range for " + string.Format("{0}-bit {1}signed integer", (object) (isLong ? 64 : 32), isSigned ? (object) "" : (object) "un") + ": " + str);
    }

    private static bool IsOctal(char c) => '0' <= c && c <= '7';

    private static bool IsHex(char c)
    {
      if ('0' <= c && c <= '9' || 'a' <= c && c <= 'f')
        return true;
      return 'A' <= c && c <= 'F';
    }

    private static int ParseDigit(char c)
    {
      if ('0' <= c && c <= '9')
        return (int) c - 48;
      return 'a' <= c && c <= 'z' ? (int) c - 97 + 10 : (int) c - 65 + 10;
    }

    internal static string UnescapeText(string input)
    {
      return TextFormat.UnescapeBytes(input).ToStringUtf8();
    }

    internal static string EscapeText(string input)
    {
      return TextFormat.EscapeBytes(ByteString.CopyFromUtf8(input));
    }

    internal static string EscapeBytes(ByteString input)
    {
      StringBuilder stringBuilder = new StringBuilder(input.Length);
      foreach (byte num in input)
      {
        switch (num)
        {
          case 7:
            stringBuilder.Append("\\a");
            continue;
          case 8:
            stringBuilder.Append("\\b");
            continue;
          case 9:
            stringBuilder.Append("\\t");
            continue;
          case 10:
            stringBuilder.Append("\\n");
            continue;
          case 11:
            stringBuilder.Append("\\v");
            continue;
          case 12:
            stringBuilder.Append("\\f");
            continue;
          case 13:
            stringBuilder.Append("\\r");
            continue;
          case 34:
            stringBuilder.Append("\\\"");
            continue;
          case 39:
            stringBuilder.Append("\\'");
            continue;
          case 92:
            stringBuilder.Append("\\\\");
            continue;
          default:
            if (num >= (byte) 32 && num < (byte) 128)
            {
              stringBuilder.Append((char) num);
              continue;
            }
            stringBuilder.Append('\\');
            stringBuilder.Append((char) (48 + ((int) num >> 6 & 3)));
            stringBuilder.Append((char) (48 + ((int) num >> 3 & 7)));
            stringBuilder.Append((char) (48 + ((int) num & 7)));
            continue;
        }
      }
      return stringBuilder.ToString();
    }

    internal static ByteString UnescapeBytes(string input)
    {
      byte[] bytes = new byte[input.Length];
      int count = 0;
      for (int index = 0; index < input.Length; ++index)
      {
        char ch1 = input[index];
        if (ch1 > '\u007F' || ch1 < ' ')
          throw new FormatException("Escaped string must only contain ASCII");
        if (ch1 != '\\')
        {
          bytes[count++] = (byte) ch1;
        }
        else
        {
          if (index + 1 >= input.Length)
            throw new FormatException("Invalid escape sequence: '\\' at end of string.");
          ++index;
          char c = input[index];
          switch (c)
          {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
              int num1 = TextFormat.ParseDigit(c);
              if (index + 1 < input.Length && TextFormat.IsOctal(input[index + 1]))
              {
                ++index;
                num1 = num1 * 8 + TextFormat.ParseDigit(input[index]);
              }
              if (index + 1 < input.Length && TextFormat.IsOctal(input[index + 1]))
              {
                ++index;
                num1 = num1 * 8 + TextFormat.ParseDigit(input[index]);
              }
              bytes[count++] = (byte) num1;
              continue;
            default:
              char ch2 = c;
              if (ch2 <= '\\')
              {
                if (ch2 != '"')
                {
                  if (ch2 != '\'')
                  {
                    if (ch2 == '\\')
                    {
                      bytes[count++] = (byte) 92;
                      continue;
                    }
                  }
                  else
                  {
                    bytes[count++] = (byte) 39;
                    continue;
                  }
                }
                else
                {
                  bytes[count++] = (byte) 34;
                  continue;
                }
              }
              else if (ch2 <= 'f')
              {
                switch ((int) ch2 - 97)
                {
                  case 0:
                    bytes[count++] = (byte) 7;
                    continue;
                  case 1:
                    bytes[count++] = (byte) 8;
                    continue;
                  default:
                    if (ch2 == 'f')
                    {
                      bytes[count++] = (byte) 12;
                      continue;
                    }
                    break;
                }
              }
              else if (ch2 != 'n')
              {
                switch ((int) ch2 - 114)
                {
                  case 0:
                    bytes[count++] = (byte) 13;
                    continue;
                  case 2:
                    bytes[count++] = (byte) 9;
                    continue;
                  case 4:
                    bytes[count++] = (byte) 11;
                    continue;
                  case 6:
                    if (index + 1 >= input.Length || !TextFormat.IsHex(input[index + 1]))
                      throw new FormatException("Invalid escape sequence: '\\x' with no digits");
                    ++index;
                    int num2 = TextFormat.ParseDigit(input[index]);
                    if (index + 1 < input.Length && TextFormat.IsHex(input[index + 1]))
                    {
                      ++index;
                      num2 = num2 * 16 + TextFormat.ParseDigit(input[index]);
                    }
                    bytes[count++] = (byte) num2;
                    continue;
                }
              }
              else
              {
                bytes[count++] = (byte) 10;
                continue;
              }
              throw new FormatException("Invalid escape sequence: '\\" + (object) c + "'");
          }
        }
      }
      return ByteString.CopyFrom(bytes, 0, count);
    }

    public static void Merge(string text, IBuilder builder)
    {
      TextFormat.Merge(text, ExtensionRegistry.Empty, builder);
    }

    public static void Merge(TextReader reader, IBuilder builder)
    {
      TextFormat.Merge(reader, ExtensionRegistry.Empty, builder);
    }

    public static void Merge(TextReader reader, ExtensionRegistry registry, IBuilder builder)
    {
      TextFormat.Merge(reader.ReadToEnd(), registry, builder);
    }

    public static void Merge(string text, ExtensionRegistry registry, IBuilder builder)
    {
      TextTokenizer tokenizer = new TextTokenizer(text);
      while (!tokenizer.AtEnd)
        TextFormat.MergeField(tokenizer, registry, builder);
    }

    private static void MergeField(
      TextTokenizer tokenizer,
      ExtensionRegistry extensionRegistry,
      IBuilder builder)
    {
      MessageDescriptor descriptorForType = builder.DescriptorForType;
      ExtensionInfo extensionInfo = (ExtensionInfo) null;
      FieldDescriptor field;
      if (tokenizer.TryConsume("["))
      {
        StringBuilder stringBuilder = new StringBuilder(tokenizer.ConsumeIdentifier());
        while (tokenizer.TryConsume("."))
        {
          stringBuilder.Append(".");
          stringBuilder.Append(tokenizer.ConsumeIdentifier());
        }
        extensionInfo = extensionRegistry[stringBuilder.ToString()];
        if (extensionInfo == null)
          throw tokenizer.CreateFormatExceptionPreviousToken("Extension \"" + (object) stringBuilder + "\" not found in the ExtensionRegistry.");
        if (extensionInfo.Descriptor.ContainingType != descriptorForType)
          throw tokenizer.CreateFormatExceptionPreviousToken("Extension \"" + (object) stringBuilder + "\" does not extend message type \"" + descriptorForType.FullName + "\".");
        tokenizer.Consume("]");
        field = extensionInfo.Descriptor;
      }
      else
      {
        string name = tokenizer.ConsumeIdentifier();
        field = descriptorForType.FindDescriptor<FieldDescriptor>(name);
        if (field == null)
        {
          string lower = name.ToLower();
          field = descriptorForType.FindDescriptor<FieldDescriptor>(lower);
          if (field != null && field.FieldType != FieldType.Group)
            field = (FieldDescriptor) null;
        }
        if (field != null && field.FieldType == FieldType.Group && field.MessageType.Name != name)
          field = (FieldDescriptor) null;
        if (field == null)
          throw tokenizer.CreateFormatExceptionPreviousToken("Message type \"" + descriptorForType.FullName + "\" has no field named \"" + name + "\".");
      }
      object obj = (object) null;
      if (field.MappedType == MappedType.Message)
      {
        tokenizer.TryConsume(":");
        string token;
        if (tokenizer.TryConsume("<"))
        {
          token = ">";
        }
        else
        {
          tokenizer.Consume("{");
          token = "}";
        }
        if (extensionInfo == null)
        {
          IBuilder builder1 = builder.CreateBuilderForField(field);
          while (!tokenizer.TryConsume(token))
          {
            if (tokenizer.AtEnd)
              throw tokenizer.CreateFormatException("Expected \"" + token + "\".");
            TextFormat.MergeField(tokenizer, extensionRegistry, builder1);
          }
          obj = (object) builder1.WeakBuild();
        }
        else
        {
          if (!(extensionInfo.DefaultInstance.WeakCreateBuilderForType() is IBuilder builder2))
            throw new NotSupportedException("Lite messages are not supported.");
          while (!tokenizer.TryConsume(token))
          {
            if (tokenizer.AtEnd)
              throw tokenizer.CreateFormatException("Expected \"" + token + "\".");
            TextFormat.MergeField(tokenizer, extensionRegistry, builder2);
          }
          obj = (object) builder2.WeakBuild();
        }
      }
      else
      {
        tokenizer.Consume(":");
        switch (field.FieldType)
        {
          case FieldType.Double:
            obj = (object) tokenizer.ConsumeDouble();
            break;
          case FieldType.Float:
            obj = (object) tokenizer.ConsumeFloat();
            break;
          case FieldType.Int64:
          case FieldType.SFixed64:
          case FieldType.SInt64:
            obj = (object) tokenizer.ConsumeInt64();
            break;
          case FieldType.UInt64:
          case FieldType.Fixed64:
            obj = (object) tokenizer.ConsumeUInt64();
            break;
          case FieldType.Int32:
          case FieldType.SFixed32:
          case FieldType.SInt32:
            obj = (object) tokenizer.ConsumeInt32();
            break;
          case FieldType.Fixed32:
          case FieldType.UInt32:
            obj = (object) tokenizer.ConsumeUInt32();
            break;
          case FieldType.Bool:
            obj = (object) tokenizer.ConsumeBoolean();
            break;
          case FieldType.String:
            obj = (object) tokenizer.ConsumeString();
            break;
          case FieldType.Group:
          case FieldType.Message:
            throw new InvalidOperationException("Can't get here.");
          case FieldType.Bytes:
            obj = (object) tokenizer.ConsumeByteString();
            break;
          case FieldType.Enum:
            EnumDescriptor enumType = field.EnumType;
            if (tokenizer.LookingAtInteger())
            {
              int number = tokenizer.ConsumeInt32();
              obj = (object) enumType.FindValueByNumber(number);
              if (obj == null)
                throw tokenizer.CreateFormatExceptionPreviousToken("Enum type \"" + enumType.FullName + "\" has no value with number " + (object) number + ".");
              break;
            }
            string name = tokenizer.ConsumeIdentifier();
            obj = (object) enumType.FindValueByName(name);
            if (obj == null)
              throw tokenizer.CreateFormatExceptionPreviousToken("Enum type \"" + enumType.FullName + "\" has no value named \"" + name + "\".");
            break;
        }
      }
      if (field.IsRepeated)
        builder.WeakAddRepeatedField(field, obj);
      else
        builder.SetField(field, obj);
    }
  }
}
