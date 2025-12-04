// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.MethodDescriptorProto
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
  public sealed class MethodDescriptorProto : 
    GeneratedMessage<MethodDescriptorProto, MethodDescriptorProto.Builder>,
    IDescriptorProto<MethodOptions>
  {
    public const int NameFieldNumber = 1;
    public const int InputTypeFieldNumber = 2;
    public const int OutputTypeFieldNumber = 3;
    public const int OptionsFieldNumber = 4;
    private static readonly MethodDescriptorProto defaultInstance = new MethodDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private bool hasInputType;
    private string inputType_ = "";
    private bool hasOutputType;
    private string outputType_ = "";
    private bool hasOptions;
    private MethodOptions options_ = MethodOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static MethodDescriptorProto DefaultInstance => MethodDescriptorProto.defaultInstance;

    public override MethodDescriptorProto DefaultInstanceForType
    {
      get => MethodDescriptorProto.defaultInstance;
    }

    protected override MethodDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_MethodDescriptorProto__Descriptor;
    }

    protected override FieldAccessorTable<MethodDescriptorProto, MethodDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_MethodDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public bool HasInputType => this.hasInputType;

    public string InputType => this.inputType_;

    public bool HasOutputType => this.hasOutputType;

    public string OutputType => this.outputType_;

    public bool HasOptions => this.hasOptions;

    public MethodOptions Options => this.options_;

    public override bool IsInitialized => !this.HasOptions || this.Options.IsInitialized;

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasName)
        output.WriteString(1, this.Name);
      if (this.HasInputType)
        output.WriteString(2, this.InputType);
      if (this.HasOutputType)
        output.WriteString(3, this.OutputType);
      if (this.HasOptions)
        output.WriteMessage(4, (IMessageLite) this.Options);
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
        if (this.HasInputType)
          num += CodedOutputStream.ComputeStringSize(2, this.InputType);
        if (this.HasOutputType)
          num += CodedOutputStream.ComputeStringSize(3, this.OutputType);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(4, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static MethodDescriptorProto ParseFrom(ByteString data)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(byte[] data)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(Stream input)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return MethodDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static MethodDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return MethodDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(CodedInputStream input)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MethodDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return MethodDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodDescriptorProto.Builder CreateBuilder()
    {
      return new MethodDescriptorProto.Builder();
    }

    public override MethodDescriptorProto.Builder ToBuilder()
    {
      return MethodDescriptorProto.CreateBuilder(this);
    }

    public override MethodDescriptorProto.Builder CreateBuilderForType()
    {
      return new MethodDescriptorProto.Builder();
    }

    public static MethodDescriptorProto.Builder CreateBuilder(MethodDescriptorProto prototype)
    {
      return new MethodDescriptorProto.Builder().MergeFrom(prototype);
    }

    static MethodDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : 
      GeneratedBuilder<MethodDescriptorProto, MethodDescriptorProto.Builder>
    {
      private MethodDescriptorProto result = new MethodDescriptorProto();

      protected override MethodDescriptorProto.Builder ThisBuilder => this;

      protected override MethodDescriptorProto MessageBeingBuilt => this.result;

      public override MethodDescriptorProto.Builder Clear()
      {
        this.result = new MethodDescriptorProto();
        return this;
      }

      public override MethodDescriptorProto.Builder Clone()
      {
        return new MethodDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => MethodDescriptorProto.Descriptor;

      public override MethodDescriptorProto DefaultInstanceForType
      {
        get => MethodDescriptorProto.DefaultInstance;
      }

      public override MethodDescriptorProto BuildPartial()
      {
        MethodDescriptorProto methodDescriptorProto = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
        this.result = (MethodDescriptorProto) null;
        return methodDescriptorProto;
      }

      public override MethodDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is MethodDescriptorProto)
          return this.MergeFrom((MethodDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override MethodDescriptorProto.Builder MergeFrom(MethodDescriptorProto other)
      {
        if (other == MethodDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.HasInputType)
          this.InputType = other.InputType;
        if (other.HasOutputType)
          this.OutputType = other.OutputType;
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override MethodDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override MethodDescriptorProto.Builder MergeFrom(
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
              this.InputType = input.ReadString();
              continue;
            case 26:
              this.OutputType = input.ReadString();
              continue;
            case 34:
              MethodOptions.Builder builder = MethodOptions.CreateBuilder();
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

      public MethodDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public MethodDescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public bool HasInputType => this.result.HasInputType;

      public string InputType
      {
        get => this.result.InputType;
        set => this.SetInputType(value);
      }

      public MethodDescriptorProto.Builder SetInputType(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasInputType = true;
        this.result.inputType_ = value;
        return this;
      }

      public MethodDescriptorProto.Builder ClearInputType()
      {
        this.result.hasInputType = false;
        this.result.inputType_ = "";
        return this;
      }

      public bool HasOutputType => this.result.HasOutputType;

      public string OutputType
      {
        get => this.result.OutputType;
        set => this.SetOutputType(value);
      }

      public MethodDescriptorProto.Builder SetOutputType(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOutputType = true;
        this.result.outputType_ = value;
        return this;
      }

      public MethodDescriptorProto.Builder ClearOutputType()
      {
        this.result.hasOutputType = false;
        this.result.outputType_ = "";
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public MethodOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public MethodDescriptorProto.Builder SetOptions(MethodOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public MethodDescriptorProto.Builder SetOptions(MethodOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public MethodDescriptorProto.Builder MergeOptions(MethodOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == MethodOptions.DefaultInstance ? value : MethodOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public MethodDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = MethodOptions.DefaultInstance;
        return this;
      }
    }
  }
}
