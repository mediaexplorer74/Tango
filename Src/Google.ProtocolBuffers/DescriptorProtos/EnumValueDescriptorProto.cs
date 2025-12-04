// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.EnumValueDescriptorProto
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
  public sealed class EnumValueDescriptorProto : 
    GeneratedMessage<EnumValueDescriptorProto, EnumValueDescriptorProto.Builder>,
    IDescriptorProto<EnumValueOptions>
  {
    public const int NameFieldNumber = 1;
    public const int NumberFieldNumber = 2;
    public const int OptionsFieldNumber = 3;
    private static readonly EnumValueDescriptorProto defaultInstance = new EnumValueDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private bool hasNumber;
    private int number_;
    private bool hasOptions;
    private EnumValueOptions options_ = EnumValueOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static EnumValueDescriptorProto DefaultInstance
    {
      get => EnumValueDescriptorProto.defaultInstance;
    }

    public override EnumValueDescriptorProto DefaultInstanceForType
    {
      get => EnumValueDescriptorProto.defaultInstance;
    }

    protected override EnumValueDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_EnumValueDescriptorProto__Descriptor;
      }
    }

    protected override FieldAccessorTable<EnumValueDescriptorProto, EnumValueDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_EnumValueDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public bool HasNumber => this.hasNumber;

    public int Number => this.number_;

    public bool HasOptions => this.hasOptions;

    public EnumValueOptions Options => this.options_;

    public override bool IsInitialized => !this.HasOptions || this.Options.IsInitialized;

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasName)
        output.WriteString(1, this.Name);
      if (this.HasNumber)
        output.WriteInt32(2, this.Number);
      if (this.HasOptions)
        output.WriteMessage(3, (IMessageLite) this.Options);
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
          num += CodedOutputStream.ComputeInt32Size(2, this.Number);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(3, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static EnumValueDescriptorProto ParseFrom(ByteString data)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(byte[] data)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(
      byte[] data,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(Stream input)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(CodedInputStream input)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumValueDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueDescriptorProto.Builder CreateBuilder()
    {
      return new EnumValueDescriptorProto.Builder();
    }

    public override EnumValueDescriptorProto.Builder ToBuilder()
    {
      return EnumValueDescriptorProto.CreateBuilder(this);
    }

    public override EnumValueDescriptorProto.Builder CreateBuilderForType()
    {
      return new EnumValueDescriptorProto.Builder();
    }

    public static EnumValueDescriptorProto.Builder CreateBuilder(EnumValueDescriptorProto prototype)
    {
      return new EnumValueDescriptorProto.Builder().MergeFrom(prototype);
    }

    static EnumValueDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : 
      GeneratedBuilder<EnumValueDescriptorProto, EnumValueDescriptorProto.Builder>
    {
      private EnumValueDescriptorProto result = new EnumValueDescriptorProto();

      protected override EnumValueDescriptorProto.Builder ThisBuilder => this;

      protected override EnumValueDescriptorProto MessageBeingBuilt => this.result;

      public override EnumValueDescriptorProto.Builder Clear()
      {
        this.result = new EnumValueDescriptorProto();
        return this;
      }

      public override EnumValueDescriptorProto.Builder Clone()
      {
        return new EnumValueDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => EnumValueDescriptorProto.Descriptor;

      public override EnumValueDescriptorProto DefaultInstanceForType
      {
        get => EnumValueDescriptorProto.DefaultInstance;
      }

      public override EnumValueDescriptorProto BuildPartial()
      {
        EnumValueDescriptorProto valueDescriptorProto = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
        this.result = (EnumValueDescriptorProto) null;
        return valueDescriptorProto;
      }

      public override EnumValueDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is EnumValueDescriptorProto)
          return this.MergeFrom((EnumValueDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override EnumValueDescriptorProto.Builder MergeFrom(EnumValueDescriptorProto other)
      {
        if (other == EnumValueDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.HasNumber)
          this.Number = other.Number;
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override EnumValueDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override EnumValueDescriptorProto.Builder MergeFrom(
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
            case 16:
              this.Number = input.ReadInt32();
              continue;
            case 26:
              EnumValueOptions.Builder builder = EnumValueOptions.CreateBuilder();
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

      public EnumValueDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public EnumValueDescriptorProto.Builder ClearName()
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

      public EnumValueDescriptorProto.Builder SetNumber(int value)
      {
        this.result.hasNumber = true;
        this.result.number_ = value;
        return this;
      }

      public EnumValueDescriptorProto.Builder ClearNumber()
      {
        this.result.hasNumber = false;
        this.result.number_ = 0;
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public EnumValueOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public EnumValueDescriptorProto.Builder SetOptions(EnumValueOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public EnumValueDescriptorProto.Builder SetOptions(EnumValueOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public EnumValueDescriptorProto.Builder MergeOptions(EnumValueOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == EnumValueOptions.DefaultInstance ? value : EnumValueOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public EnumValueDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = EnumValueOptions.DefaultInstance;
        return this;
      }
    }
  }
}
