// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public sealed class FieldDescriptorProto : 
    GeneratedMessage<FieldDescriptorProto, FieldDescriptorProto.Builder>,
    IDescriptorProto<FieldOptions>
  {
    public const int NameFieldNumber = 1;
    public const int NumberFieldNumber = 3;
    public const int LabelFieldNumber = 4;
    public const int TypeFieldNumber = 5;
    public const int TypeNameFieldNumber = 6;
    public const int ExtendeeFieldNumber = 2;
    public const int DefaultValueFieldNumber = 7;
    public const int OptionsFieldNumber = 8;
    private static readonly FieldDescriptorProto defaultInstance = new FieldDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private bool hasNumber;
    private int number_;
    private bool hasLabel;
    private FieldDescriptorProto.Types.Label label_ = FieldDescriptorProto.Types.Label.LABEL_OPTIONAL;
    private bool hasType;
    private FieldDescriptorProto.Types.Type type_ = FieldDescriptorProto.Types.Type.TYPE_DOUBLE;
    private bool hasTypeName;
    private string typeName_ = "";
    private bool hasExtendee;
    private string extendee_ = "";
    private bool hasDefaultValue;
    private string defaultValue_ = "";
    private bool hasOptions;
    private FieldOptions options_ = FieldOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static FieldDescriptorProto DefaultInstance => FieldDescriptorProto.defaultInstance;

    public override FieldDescriptorProto DefaultInstanceForType
    {
      get => FieldDescriptorProto.defaultInstance;
    }

    protected override FieldDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FieldDescriptorProto__Descriptor;
    }

    protected override FieldAccessorTable<FieldDescriptorProto, FieldDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_FieldDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public bool HasNumber => this.hasNumber;

    public int Number => this.number_;

    public bool HasLabel => this.hasLabel;

    public FieldDescriptorProto.Types.Label Label => this.label_;

    public bool HasType => this.hasType;

    public FieldDescriptorProto.Types.Type Type => this.type_;

    public bool HasTypeName => this.hasTypeName;

    public string TypeName => this.typeName_;

    public bool HasExtendee => this.hasExtendee;

    public string Extendee => this.extendee_;

    public bool HasDefaultValue => this.hasDefaultValue;

    public string DefaultValue => this.defaultValue_;

    public bool HasOptions => this.hasOptions;

    public FieldOptions Options => this.options_;

    public override bool IsInitialized => !this.HasOptions || this.Options.IsInitialized;

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasName)
        output.WriteString(1, this.Name);
      if (this.HasExtendee)
        output.WriteString(2, this.Extendee);
      if (this.HasNumber)
        output.WriteInt32(3, this.Number);
      if (this.HasLabel)
        output.WriteEnum(4, (int) this.Label);
      if (this.HasType)
        output.WriteEnum(5, (int) this.Type);
      if (this.HasTypeName)
        output.WriteString(6, this.TypeName);
      if (this.HasDefaultValue)
        output.WriteString(7, this.DefaultValue);
      if (this.HasOptions)
        output.WriteMessage(8, (IMessageLite) this.Options);
      this.UnknownFields.WriteTo(output);
    }

    public override int SerializedSize
    {
      get
      {
        int memoizedSerializedSize = this.memoizedSerializedSize;
        if (memoizedSerializedSize != -1)
          return memoizedSerializedSize;
        int num = 0;
        if (this.HasName)
          num += CodedOutputStream.ComputeStringSize(1, this.Name);
        if (this.HasNumber)
          num += CodedOutputStream.ComputeInt32Size(3, this.Number);
        if (this.HasLabel)
          num += CodedOutputStream.ComputeEnumSize(4, (int) this.Label);
        if (this.HasType)
          num += CodedOutputStream.ComputeEnumSize(5, (int) this.Type);
        if (this.HasTypeName)
          num += CodedOutputStream.ComputeStringSize(6, this.TypeName);
        if (this.HasExtendee)
          num += CodedOutputStream.ComputeStringSize(2, this.Extendee);
        if (this.HasDefaultValue)
          num += CodedOutputStream.ComputeStringSize(7, this.DefaultValue);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(8, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static FieldDescriptorProto ParseFrom(ByteString data)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(byte[] data)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(Stream input)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return FieldDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static FieldDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return FieldDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(CodedInputStream input)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FieldDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return FieldDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldDescriptorProto.Builder CreateBuilder()
    {
      return new FieldDescriptorProto.Builder();
    }

    public override FieldDescriptorProto.Builder ToBuilder()
    {
      return FieldDescriptorProto.CreateBuilder(this);
    }

    public override FieldDescriptorProto.Builder CreateBuilderForType()
    {
      return new FieldDescriptorProto.Builder();
    }

    public static FieldDescriptorProto.Builder CreateBuilder(FieldDescriptorProto prototype)
    {
      return new FieldDescriptorProto.Builder().MergeFrom(prototype);
    }

    static FieldDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public static class Types
    {
      public enum Type
      {
        TYPE_DOUBLE = 1,
        TYPE_FLOAT = 2,
        TYPE_INT64 = 3,
        TYPE_UINT64 = 4,
        TYPE_INT32 = 5,
        TYPE_FIXED64 = 6,
        TYPE_FIXED32 = 7,
        TYPE_BOOL = 8,
        TYPE_STRING = 9,
        TYPE_GROUP = 10, // 0x0000000A
        TYPE_MESSAGE = 11, // 0x0000000B
        TYPE_BYTES = 12, // 0x0000000C
        TYPE_UINT32 = 13, // 0x0000000D
        TYPE_ENUM = 14, // 0x0000000E
        TYPE_SFIXED32 = 15, // 0x0000000F
        TYPE_SFIXED64 = 16, // 0x00000010
        TYPE_SINT32 = 17, // 0x00000011
        TYPE_SINT64 = 18, // 0x00000012
      }

      public enum Label
      {
        LABEL_OPTIONAL = 1,
        LABEL_REQUIRED = 2,
        LABEL_REPEATED = 3,
      }
    }

    public sealed class Builder : 
      GeneratedBuilder<FieldDescriptorProto, FieldDescriptorProto.Builder>
    {
      private FieldDescriptorProto result = new FieldDescriptorProto();

      protected override FieldDescriptorProto.Builder ThisBuilder => this;

      protected override FieldDescriptorProto MessageBeingBuilt => this.result;

      public override FieldDescriptorProto.Builder Clear()
      {
        this.result = new FieldDescriptorProto();
        return this;
      }

      public override FieldDescriptorProto.Builder Clone()
      {
        return new FieldDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => FieldDescriptorProto.Descriptor;

      public override FieldDescriptorProto DefaultInstanceForType
      {
        get => FieldDescriptorProto.DefaultInstance;
      }

      public override FieldDescriptorProto BuildPartial()
      {
        FieldDescriptorProto fieldDescriptorProto = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
        this.result = (FieldDescriptorProto) null;
        return fieldDescriptorProto;
      }

      public override FieldDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is FieldDescriptorProto)
          return this.MergeFrom((FieldDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override FieldDescriptorProto.Builder MergeFrom(FieldDescriptorProto other)
      {
        if (other == FieldDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.HasNumber)
          this.Number = other.Number;
        if (other.HasLabel)
          this.Label = other.Label;
        if (other.HasType)
          this.Type = other.Type;
        if (other.HasTypeName)
          this.TypeName = other.TypeName;
        if (other.HasExtendee)
          this.Extendee = other.Extendee;
        if (other.HasDefaultValue)
          this.DefaultValue = other.DefaultValue;
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override FieldDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override FieldDescriptorProto.Builder MergeFrom(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry)
      {
        UnknownFieldSet.Builder unknownFields = (UnknownFieldSet.Builder) null;
        while (true)
        {
          uint tag = input.ReadTag();
          switch (tag)
          {
            case 0:
              goto label_2;
            case 10:
              this.Name = input.ReadString();
              continue;
            case 18:
              this.Extendee = input.ReadString();
              continue;
            case 24:
              this.Number = input.ReadInt32();
              continue;
            case 32:
              int num1 = input.ReadEnum();
              if (!Enum.IsDefined(typeof (FieldDescriptorProto.Types.Label), (object) num1))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                unknownFields.MergeVarintField(4, (ulong) num1);
                continue;
              }
              this.Label = (FieldDescriptorProto.Types.Label) num1;
              continue;
            case 40:
              int num2 = input.ReadEnum();
              if (!Enum.IsDefined(typeof (FieldDescriptorProto.Types.Type), (object) num2))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                unknownFields.MergeVarintField(5, (ulong) num2);
                continue;
              }
              this.Type = (FieldDescriptorProto.Types.Type) num2;
              continue;
            case 50:
              this.TypeName = input.ReadString();
              continue;
            case 58:
              this.DefaultValue = input.ReadString();
              continue;
            case 66:
              FieldOptions.Builder builder = FieldOptions.CreateBuilder();
              if (this.HasOptions)
                builder.MergeFrom(this.Options);
              input.ReadMessage((IBuilderLite) builder, extensionRegistry);
              this.Options = builder.BuildPartial();
              continue;
            default:
              if (!WireFormat.IsEndGroupTag(tag))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                this.ParseUnknownField(input, unknownFields, extensionRegistry, tag);
                continue;
              }
              goto label_6;
          }
        }
label_2:
        if (unknownFields != null)
          this.UnknownFields = unknownFields.Build();
        return this;
label_6:
        if (unknownFields != null)
          this.UnknownFields = unknownFields.Build();
        return this;
      }

      public bool HasName => this.result.HasName;

      public string Name
      {
        get => this.result.Name;
        set => this.SetName(value);
      }

      public FieldDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public bool HasNumber => this.result.HasNumber;

      public int Number
      {
        get => this.result.Number;
        set => this.SetNumber(value);
      }

      public FieldDescriptorProto.Builder SetNumber(int value)
      {
        this.result.hasNumber = true;
        this.result.number_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearNumber()
      {
        this.result.hasNumber = false;
        this.result.number_ = 0;
        return this;
      }

      public bool HasLabel => this.result.HasLabel;

      public FieldDescriptorProto.Types.Label Label
      {
        get => this.result.Label;
        set => this.SetLabel(value);
      }

      public FieldDescriptorProto.Builder SetLabel(FieldDescriptorProto.Types.Label value)
      {
        this.result.hasLabel = true;
        this.result.label_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearLabel()
      {
        this.result.hasLabel = false;
        this.result.label_ = FieldDescriptorProto.Types.Label.LABEL_OPTIONAL;
        return this;
      }

      public bool HasType => this.result.HasType;

      public FieldDescriptorProto.Types.Type Type
      {
        get => this.result.Type;
        set => this.SetType(value);
      }

      public FieldDescriptorProto.Builder SetType(FieldDescriptorProto.Types.Type value)
      {
        this.result.hasType = true;
        this.result.type_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearType()
      {
        this.result.hasType = false;
        this.result.type_ = FieldDescriptorProto.Types.Type.TYPE_DOUBLE;
        return this;
      }

      public bool HasTypeName => this.result.HasTypeName;

      public string TypeName
      {
        get => this.result.TypeName;
        set => this.SetTypeName(value);
      }

      public FieldDescriptorProto.Builder SetTypeName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasTypeName = true;
        this.result.typeName_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearTypeName()
      {
        this.result.hasTypeName = false;
        this.result.typeName_ = "";
        return this;
      }

      public bool HasExtendee => this.result.HasExtendee;

      public string Extendee
      {
        get => this.result.Extendee;
        set => this.SetExtendee(value);
      }

      public FieldDescriptorProto.Builder SetExtendee(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasExtendee = true;
        this.result.extendee_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearExtendee()
      {
        this.result.hasExtendee = false;
        this.result.extendee_ = "";
        return this;
      }

      public bool HasDefaultValue => this.result.HasDefaultValue;

      public string DefaultValue
      {
        get => this.result.DefaultValue;
        set => this.SetDefaultValue(value);
      }

      public FieldDescriptorProto.Builder SetDefaultValue(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasDefaultValue = true;
        this.result.defaultValue_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder ClearDefaultValue()
      {
        this.result.hasDefaultValue = false;
        this.result.defaultValue_ = "";
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public FieldOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public FieldDescriptorProto.Builder SetOptions(FieldOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public FieldDescriptorProto.Builder SetOptions(FieldOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public FieldDescriptorProto.Builder MergeOptions(FieldOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == FieldOptions.DefaultInstance ? value : FieldOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public FieldDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = FieldOptions.DefaultInstance;
        return this;
      }
    }
  }
}
