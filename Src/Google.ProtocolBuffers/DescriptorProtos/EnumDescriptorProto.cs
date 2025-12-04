// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.EnumDescriptorProto
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public sealed class EnumDescriptorProto : 
    GeneratedMessage<EnumDescriptorProto, EnumDescriptorProto.Builder>,
    IDescriptorProto<EnumOptions>
  {
    public const int NameFieldNumber = 1;
    public const int ValueFieldNumber = 2;
    public const int OptionsFieldNumber = 3;
    private static readonly EnumDescriptorProto defaultInstance = new EnumDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private PopsicleList<EnumValueDescriptorProto> value_ = new PopsicleList<EnumValueDescriptorProto>();
    private bool hasOptions;
    private EnumOptions options_ = EnumOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static EnumDescriptorProto DefaultInstance => EnumDescriptorProto.defaultInstance;

    public override EnumDescriptorProto DefaultInstanceForType
    {
      get => EnumDescriptorProto.defaultInstance;
    }

    protected override EnumDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_EnumDescriptorProto__Descriptor;
    }

    protected override FieldAccessorTable<EnumDescriptorProto, EnumDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_EnumDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public IList<EnumValueDescriptorProto> ValueList
    {
      get => (IList<EnumValueDescriptorProto>) this.value_;
    }

    public int ValueCount => this.value_.Count;

    public EnumValueDescriptorProto GetValue(int index) => this.value_[index];

    public bool HasOptions => this.hasOptions;

    public EnumOptions Options => this.options_;

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<EnumValueDescriptorProto, EnumValueDescriptorProto.Builder> abstractMessageLite in (IEnumerable<EnumValueDescriptorProto>) this.ValueList)
        {
          if (!abstractMessageLite.IsInitialized)
            return false;
        }
        return !this.HasOptions || this.Options.IsInitialized;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasName)
        output.WriteString(1, this.Name);
      foreach (EnumValueDescriptorProto valueDescriptorProto in (IEnumerable<EnumValueDescriptorProto>) this.ValueList)
        output.WriteMessage(2, (IMessageLite) valueDescriptorProto);
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
        foreach (EnumValueDescriptorProto valueDescriptorProto in (IEnumerable<EnumValueDescriptorProto>) this.ValueList)
          num += CodedOutputStream.ComputeMessageSize(2, (IMessageLite) valueDescriptorProto);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(3, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static EnumDescriptorProto ParseFrom(ByteString data)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(byte[] data)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(Stream input)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return EnumDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static EnumDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(CodedInputStream input)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumDescriptorProto.Builder CreateBuilder() => new EnumDescriptorProto.Builder();

    public override EnumDescriptorProto.Builder ToBuilder()
    {
      return EnumDescriptorProto.CreateBuilder(this);
    }

    public override EnumDescriptorProto.Builder CreateBuilderForType()
    {
      return new EnumDescriptorProto.Builder();
    }

    public static EnumDescriptorProto.Builder CreateBuilder(EnumDescriptorProto prototype)
    {
      return new EnumDescriptorProto.Builder().MergeFrom(prototype);
    }

    static EnumDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : GeneratedBuilder<EnumDescriptorProto, EnumDescriptorProto.Builder>
    {
      private EnumDescriptorProto result = new EnumDescriptorProto();

      protected override EnumDescriptorProto.Builder ThisBuilder => this;

      protected override EnumDescriptorProto MessageBeingBuilt => this.result;

      public override EnumDescriptorProto.Builder Clear()
      {
        this.result = new EnumDescriptorProto();
        return this;
      }

      public override EnumDescriptorProto.Builder Clone()
      {
        return new EnumDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => EnumDescriptorProto.Descriptor;

      public override EnumDescriptorProto DefaultInstanceForType
      {
        get => EnumDescriptorProto.DefaultInstance;
      }

      public override EnumDescriptorProto BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.value_.MakeReadOnly();
        EnumDescriptorProto result = this.result;
        this.result = (EnumDescriptorProto) null;
        return result;
      }

      public override EnumDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is EnumDescriptorProto)
          return this.MergeFrom((EnumDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override EnumDescriptorProto.Builder MergeFrom(EnumDescriptorProto other)
      {
        if (other == EnumDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.value_.Count != 0)
          this.AddRange<EnumValueDescriptorProto>((IEnumerable<EnumValueDescriptorProto>) other.value_, (IList<EnumValueDescriptorProto>) this.result.value_);
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override EnumDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override EnumDescriptorProto.Builder MergeFrom(
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
              EnumValueDescriptorProto.Builder builder1 = EnumValueDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder1, extensionRegistry);
              this.AddValue(builder1.BuildPartial());
              continue;
            case 26:
              EnumOptions.Builder builder2 = EnumOptions.CreateBuilder();
              if (this.HasOptions)
                builder2.MergeFrom(this.Options);
              input.ReadMessage((IBuilderLite) builder2, extensionRegistry);
              this.Options = builder2.BuildPartial();
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

      public EnumDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public EnumDescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public IPopsicleList<EnumValueDescriptorProto> ValueList
      {
        get => (IPopsicleList<EnumValueDescriptorProto>) this.result.value_;
      }

      public int ValueCount => this.result.ValueCount;

      public EnumValueDescriptorProto GetValue(int index) => this.result.GetValue(index);

      public EnumDescriptorProto.Builder SetValue(int index, EnumValueDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.value_[index] = value;
        return this;
      }

      public EnumDescriptorProto.Builder SetValue(
        int index,
        EnumValueDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.value_[index] = builderForValue.Build();
        return this;
      }

      public EnumDescriptorProto.Builder AddValue(EnumValueDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.value_.Add(value);
        return this;
      }

      public EnumDescriptorProto.Builder AddValue(EnumValueDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.value_.Add(builderForValue.Build());
        return this;
      }

      public EnumDescriptorProto.Builder AddRangeValue(IEnumerable<EnumValueDescriptorProto> values)
      {
        this.AddRange<EnumValueDescriptorProto>(values, (IList<EnumValueDescriptorProto>) this.result.value_);
        return this;
      }

      public EnumDescriptorProto.Builder ClearValue()
      {
        this.result.value_.Clear();
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public EnumOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public EnumDescriptorProto.Builder SetOptions(EnumOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public EnumDescriptorProto.Builder SetOptions(EnumOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public EnumDescriptorProto.Builder MergeOptions(EnumOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == EnumOptions.DefaultInstance ? value : EnumOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public EnumDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = EnumOptions.DefaultInstance;
        return this;
      }
    }
  }
}
