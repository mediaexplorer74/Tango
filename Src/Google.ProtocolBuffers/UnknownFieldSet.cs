// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.UnknownFieldSet
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class UnknownFieldSet : IMessageLite
  {
    private static readonly UnknownFieldSet defaultInstance = new UnknownFieldSet((IDictionary<int, UnknownField>) new Dictionary<int, UnknownField>());
    private readonly IDictionary<int, UnknownField> fields;

    private UnknownFieldSet(IDictionary<int, UnknownField> fields) => this.fields = fields;

    public static UnknownFieldSet.Builder CreateBuilder() => new UnknownFieldSet.Builder();

    public static UnknownFieldSet.Builder CreateBuilder(UnknownFieldSet original)
    {
      return new UnknownFieldSet.Builder().MergeFrom(original);
    }

    public static UnknownFieldSet DefaultInstance => UnknownFieldSet.defaultInstance;

    public IDictionary<int, UnknownField> FieldDictionary
    {
      get => Dictionaries.AsReadOnly<int, UnknownField>(this.fields);
    }

    public bool HasField(int field) => this.fields.ContainsKey(field);

    public UnknownField this[int number]
    {
      get
      {
        UnknownField defaultInstance;
        if (!this.fields.TryGetValue(number, out defaultInstance))
          defaultInstance = UnknownField.DefaultInstance;
        return defaultInstance;
      }
    }

    public void WriteTo(CodedOutputStream output)
    {
      foreach (KeyValuePair<int, UnknownField> @field in (IEnumerable<KeyValuePair<int, UnknownField>>) this.fields)
        @field.Value.WriteTo(@field.Key, output);
    }

    public int SerializedSize
    {
      get
      {
        int serializedSize = 0;
        foreach (KeyValuePair<int, UnknownField> @field in (IEnumerable<KeyValuePair<int, UnknownField>>) this.fields)
          serializedSize += @field.Value.GetSerializedSize(@field.Key);
        return serializedSize;
      }
    }

    public override string ToString() => TextFormat.PrintToString(this);

    public void PrintTo(TextWriter writer) => TextFormat.Print(this, writer);

    public ByteString ToByteString()
    {
      ByteString.CodedBuilder codedBuilder = new ByteString.CodedBuilder(this.SerializedSize);
      this.WriteTo(codedBuilder.CodedOutput);
      return codedBuilder.Build();
    }

    public byte[] ToByteArray()
    {
      byte[] flatArray = new byte[this.SerializedSize];
      CodedOutputStream instance = CodedOutputStream.CreateInstance(flatArray);
      this.WriteTo(instance);
      instance.CheckNoSpaceLeft();
      return flatArray;
    }

    public void WriteTo(Stream output)
    {
      CodedOutputStream instance = CodedOutputStream.CreateInstance(output);
      this.WriteTo(instance);
      instance.Flush();
    }

    public void WriteAsMessageSetTo(CodedOutputStream output)
    {
      foreach (KeyValuePair<int, UnknownField> @field in (IEnumerable<KeyValuePair<int, UnknownField>>) this.fields)
        @field.Value.WriteAsMessageSetExtensionTo(@field.Key, output);
    }

    public int SerializedSizeAsMessageSet
    {
      get
      {
        int sizeAsMessageSet = 0;
        foreach (KeyValuePair<int, UnknownField> @field in (IEnumerable<KeyValuePair<int, UnknownField>>) this.fields)
          sizeAsMessageSet += @field.Value.GetSerializedSizeAsMessageSetExtension(@field.Key);
        return sizeAsMessageSet;
      }
    }

    public override bool Equals(object other)
    {
      if (object.ReferenceEquals((object) this, other))
        return true;
      return other is UnknownFieldSet unknownFieldSet && Dictionaries.Equals<int, UnknownField>(this.fields, unknownFieldSet.fields);
    }

    public override int GetHashCode() => Dictionaries.GetHashCode<int, UnknownField>(this.fields);

    public static UnknownFieldSet ParseFrom(CodedInputStream input)
    {
      return UnknownFieldSet.CreateBuilder().MergeFrom(input).Build();
    }

    public static UnknownFieldSet ParseFrom(ByteString data)
    {
      return UnknownFieldSet.CreateBuilder().MergeFrom(data).Build();
    }

    public static UnknownFieldSet ParseFrom(byte[] data)
    {
      return UnknownFieldSet.CreateBuilder().MergeFrom(data).Build();
    }

    public static UnknownFieldSet ParseFrom(Stream input)
    {
      return UnknownFieldSet.CreateBuilder().MergeFrom(input).Build();
    }

    public bool IsInitialized => this.fields != null;

    public void WriteDelimitedTo(Stream output)
    {
      CodedOutputStream instance = CodedOutputStream.CreateInstance(output);
      instance.WriteRawVarint32((uint) this.SerializedSize);
      this.WriteTo(instance);
      instance.Flush();
    }

    public IBuilderLite WeakCreateBuilderForType() => (IBuilderLite) new UnknownFieldSet.Builder();

    public IBuilderLite WeakToBuilder() => (IBuilderLite) new UnknownFieldSet.Builder(this.fields);

    public IMessageLite WeakDefaultInstanceForType
    {
      get => (IMessageLite) UnknownFieldSet.defaultInstance;
    }

    public sealed class Builder : IBuilderLite
    {
      private IDictionary<int, UnknownField> fields;
      private int lastFieldNumber;
      private UnknownField.Builder lastField;

      internal Builder()
      {
        this.fields = (IDictionary<int, UnknownField>) new SortedList<int, UnknownField>();
      }

      internal Builder(IDictionary<int, UnknownField> dictionary)
      {
        this.fields = (IDictionary<int, UnknownField>) new SortedList<int, UnknownField>(dictionary);
      }

      private UnknownField.Builder GetFieldBuilder(int number)
      {
        if (this.lastField != null)
        {
          if (number == this.lastFieldNumber)
            return this.lastField;
          this.AddField(this.lastFieldNumber, this.lastField.Build());
        }
        if (number == 0)
          return (UnknownField.Builder) null;
        this.lastField = UnknownField.CreateBuilder();
        UnknownField other;
        if (this.fields.TryGetValue(number, out other))
          this.lastField.MergeFrom(other);
        this.lastFieldNumber = number;
        return this.lastField;
      }

      public UnknownFieldSet Build()
      {
        this.GetFieldBuilder(0);
        UnknownFieldSet unknownFieldSet = this.fields.Count == 0 ? UnknownFieldSet.DefaultInstance : new UnknownFieldSet(this.fields);
        this.fields = (IDictionary<int, UnknownField>) null;
        return unknownFieldSet;
      }

      public UnknownFieldSet.Builder AddField(int number, UnknownField field)
      {
        if (number == 0)
          throw new ArgumentOutOfRangeException(nameof (number), "Zero is not a valid field number.");
        if (this.lastField != null && this.lastFieldNumber == number)
        {
          this.lastField = (UnknownField.Builder) null;
          this.lastFieldNumber = 0;
        }
        this.fields[number] = field;
        return this;
      }

      public UnknownFieldSet.Builder Clear()
      {
        this.fields.Clear();
        this.lastFieldNumber = 0;
        this.lastField = (UnknownField.Builder) null;
        return this;
      }

      public UnknownFieldSet.Builder MergeFrom(CodedInputStream input)
      {
        uint tag;
        do
        {
          tag = input.ReadTag();
        }
        while (tag != 0U && this.MergeFieldFrom(tag, input));
        return this;
      }

      [CLSCompliant(false)]
      public bool MergeFieldFrom(uint tag, CodedInputStream input)
      {
        int tagFieldNumber = WireFormat.GetTagFieldNumber(tag);
        switch (WireFormat.GetTagWireType(tag))
        {
          case WireFormat.WireType.Varint:
            this.GetFieldBuilder(tagFieldNumber).AddVarint(input.ReadUInt64());
            return true;
          case WireFormat.WireType.Fixed64:
            this.GetFieldBuilder(tagFieldNumber).AddFixed64(input.ReadFixed64());
            return true;
          case WireFormat.WireType.LengthDelimited:
            this.GetFieldBuilder(tagFieldNumber).AddLengthDelimited(input.ReadBytes());
            return true;
          case WireFormat.WireType.StartGroup:
            UnknownFieldSet.Builder builder = UnknownFieldSet.CreateBuilder();
            input.ReadUnknownGroup(tagFieldNumber, (IBuilderLite) builder);
            this.GetFieldBuilder(tagFieldNumber).AddGroup(builder.Build());
            return true;
          case WireFormat.WireType.EndGroup:
            return false;
          case WireFormat.WireType.Fixed32:
            this.GetFieldBuilder(tagFieldNumber).AddFixed32(input.ReadFixed32());
            return true;
          default:
            throw InvalidProtocolBufferException.InvalidWireType();
        }
      }

      public UnknownFieldSet.Builder MergeFrom(Stream input)
      {
        CodedInputStream instance = CodedInputStream.CreateInstance(input);
        this.MergeFrom(instance);
        instance.CheckLastTagWas(0U);
        return this;
      }

      public UnknownFieldSet.Builder MergeFrom(ByteString data)
      {
        CodedInputStream codedInput = data.CreateCodedInput();
        this.MergeFrom(codedInput);
        codedInput.CheckLastTagWas(0U);
        return this;
      }

      public UnknownFieldSet.Builder MergeFrom(byte[] data)
      {
        CodedInputStream instance = CodedInputStream.CreateInstance(data);
        this.MergeFrom(instance);
        instance.CheckLastTagWas(0U);
        return this;
      }

      [CLSCompliant(false)]
      public UnknownFieldSet.Builder MergeVarintField(int number, ulong value)
      {
        if (number == 0)
          throw new ArgumentOutOfRangeException(nameof (number), "Zero is not a valid field number.");
        this.GetFieldBuilder(number).AddVarint(value);
        return this;
      }

      public UnknownFieldSet.Builder MergeFrom(UnknownFieldSet other)
      {
        if (other != UnknownFieldSet.DefaultInstance)
        {
          foreach (KeyValuePair<int, UnknownField> field in (IEnumerable<KeyValuePair<int, UnknownField>>) other.fields)
            this.MergeField(field.Key, field.Value);
        }
        return this;
      }

      public bool HasField(int number)
      {
        if (number == 0)
          throw new ArgumentOutOfRangeException(nameof (number), "Zero is not a valid field number.");
        return number == this.lastFieldNumber || this.fields.ContainsKey(number);
      }

      public UnknownFieldSet.Builder MergeField(int number, UnknownField field)
      {
        if (number == 0)
          throw new ArgumentOutOfRangeException(nameof (number), "Zero is not a valid field number.");
        if (this.HasField(number))
          this.GetFieldBuilder(number).MergeFrom(field);
        else
          this.AddField(number, field);
        return this;
      }

      internal void MergeFrom(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry,
        IBuilder builder)
      {
        uint tag;
        do
        {
          tag = input.ReadTag();
        }
        while (tag != 0U && this.MergeFieldFrom(input, extensionRegistry, builder, tag));
      }

      internal bool MergeFieldFrom(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry,
        IBuilder builder,
        uint tag)
      {
        MessageDescriptor descriptorForType = builder.DescriptorForType;
        if (descriptorForType.Options.MessageSetWireFormat && (int) tag == (int) WireFormat.MessageSetTag.ItemStart)
        {
          this.MergeMessageSetExtensionFromCodedStream(input, extensionRegistry, builder);
          return true;
        }
        WireFormat.WireType tagWireType = WireFormat.GetTagWireType(tag);
        int tagFieldNumber = WireFormat.GetTagFieldNumber(tag);
        IMessageLite messageLite = (IMessageLite) null;
        FieldDescriptor fieldDescriptor;
        if (descriptorForType.IsExtensionNumber(tagFieldNumber))
        {
          ExtensionInfo extensionInfo = extensionRegistry[descriptorForType, tagFieldNumber];
          if (extensionInfo == null)
          {
            fieldDescriptor = (FieldDescriptor) null;
          }
          else
          {
            fieldDescriptor = extensionInfo.Descriptor;
            messageLite = extensionInfo.DefaultInstance;
          }
        }
        else
          fieldDescriptor = descriptorForType.FindFieldByNumber(tagFieldNumber);
        if (fieldDescriptor == null || tagWireType != WireFormat.GetWireType(fieldDescriptor))
          return this.MergeFieldFrom(tag, input);
        if (fieldDescriptor.IsPacked)
        {
          int byteLimit = (int) input.ReadRawVarint32();
          int oldLimit = input.PushLimit(byteLimit);
          if (fieldDescriptor.FieldType == FieldType.Enum)
          {
            while (!input.ReachedLimit)
            {
              int number = input.ReadEnum();
              object valueByNumber = (object) fieldDescriptor.EnumType.FindValueByNumber(number);
              if (valueByNumber == null)
                return true;
              builder.WeakAddRepeatedField(fieldDescriptor, valueByNumber);
            }
          }
          else
          {
            while (!input.ReachedLimit)
            {
              object obj = input.ReadPrimitiveField(fieldDescriptor.FieldType);
              builder.WeakAddRepeatedField(fieldDescriptor, obj);
            }
          }
          input.PopLimit(oldLimit);
        }
        else
        {
          object obj;
          switch (fieldDescriptor.FieldType)
          {
            case FieldType.Group:
            case FieldType.Message:
              IBuilderLite builder1 = messageLite == null ? (IBuilderLite) builder.CreateBuilderForField(fieldDescriptor) : messageLite.WeakCreateBuilderForType();
              if (!fieldDescriptor.IsRepeated)
                builder1.WeakMergeFrom((IMessageLite) builder[fieldDescriptor]);
              if (fieldDescriptor.FieldType == FieldType.Group)
                input.ReadGroup(fieldDescriptor.FieldNumber, builder1, extensionRegistry);
              else
                input.ReadMessage(builder1, extensionRegistry);
              obj = (object) builder1.WeakBuild();
              break;
            case FieldType.Enum:
              int number = input.ReadEnum();
              obj = (object) fieldDescriptor.EnumType.FindValueByNumber(number);
              if (obj == null)
              {
                this.MergeVarintField(tagFieldNumber, (ulong) number);
                return true;
              }
              break;
            default:
              obj = input.ReadPrimitiveField(fieldDescriptor.FieldType);
              break;
          }
          if (fieldDescriptor.IsRepeated)
            builder.WeakAddRepeatedField(fieldDescriptor, obj);
          else
            builder[fieldDescriptor] = obj;
        }
        return true;
      }

      private void MergeMessageSetExtensionFromCodedStream(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry,
        IBuilder builder)
      {
        MessageDescriptor descriptorForType = builder.DescriptorForType;
        int num = 0;
        ByteString byteString = (ByteString) null;
        IBuilderLite builder1 = (IBuilderLite) null;
        FieldDescriptor field = (FieldDescriptor) null;
        uint tag;
        do
        {
          tag = input.ReadTag();
          if (tag != 0U)
          {
            if ((int) tag == (int) WireFormat.MessageSetTag.TypeID)
            {
              num = input.ReadInt32();
              if (num != 0)
              {
                ExtensionInfo extensionInfo = extensionRegistry[descriptorForType, num];
                if (extensionInfo != null)
                {
                  field = extensionInfo.Descriptor;
                  builder1 = extensionInfo.DefaultInstance.WeakCreateBuilderForType();
                  IMessageLite message = (IMessageLite) builder[field];
                  if (message != null)
                    builder1.WeakMergeFrom(message);
                  if (byteString != null)
                  {
                    builder1.WeakMergeFrom(byteString.CreateCodedInput());
                    byteString = (ByteString) null;
                  }
                }
                else if (byteString != null)
                {
                  this.MergeField(num, UnknownField.CreateBuilder().AddLengthDelimited(byteString).Build());
                  byteString = (ByteString) null;
                }
              }
            }
            else if ((int) tag == (int) WireFormat.MessageSetTag.Message)
            {
              if (num == 0)
                byteString = input.ReadBytes();
              else if (builder1 == null)
                this.MergeField(num, UnknownField.CreateBuilder().AddLengthDelimited(input.ReadBytes()).Build());
              else
                input.ReadMessage(builder1, extensionRegistry);
            }
          }
          else
            break;
        }
        while (input.SkipField(tag));
        input.CheckLastTagWas(WireFormat.MessageSetTag.ItemEnd);
        if (builder1 == null)
          return;
        builder[field] = (object) builder1.WeakBuild();
      }

      bool IBuilderLite.IsInitialized => this.fields != null;

      IBuilderLite IBuilderLite.WeakClear() => (IBuilderLite) this.Clear();

      IBuilderLite IBuilderLite.WeakMergeFrom(IMessageLite message)
      {
        return (IBuilderLite) this.MergeFrom((UnknownFieldSet) message);
      }

      IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data)
      {
        return (IBuilderLite) this.MergeFrom(data);
      }

      IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data, ExtensionRegistry registry)
      {
        return (IBuilderLite) this.MergeFrom(data);
      }

      IBuilderLite IBuilderLite.WeakMergeFrom(CodedInputStream input)
      {
        return (IBuilderLite) this.MergeFrom(input);
      }

      IBuilderLite IBuilderLite.WeakMergeFrom(CodedInputStream input, ExtensionRegistry registry)
      {
        return (IBuilderLite) this.MergeFrom(input);
      }

      IMessageLite IBuilderLite.WeakBuild() => (IMessageLite) this.Build();

      IMessageLite IBuilderLite.WeakBuildPartial() => (IMessageLite) this.Build();

      IBuilderLite IBuilderLite.WeakClone() => this.Build().WeakToBuilder();

      IMessageLite IBuilderLite.WeakDefaultInstanceForType
      {
        get => (IMessageLite) UnknownFieldSet.DefaultInstance;
      }
    }
  }
}
