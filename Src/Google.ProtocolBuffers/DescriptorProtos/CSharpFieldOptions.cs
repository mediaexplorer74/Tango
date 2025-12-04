// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions
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
  public sealed class CSharpFieldOptions : 
    GeneratedMessage<CSharpFieldOptions, CSharpFieldOptions.Builder>
  {
    public const int PropertyNameFieldNumber = 1;
    private static readonly CSharpFieldOptions defaultInstance = new CSharpFieldOptions.Builder().BuildPartial();
    private bool hasPropertyName;
    private string propertyName_ = "";
    private int memoizedSerializedSize = -1;

    public static CSharpFieldOptions DefaultInstance => CSharpFieldOptions.defaultInstance;

    public override CSharpFieldOptions DefaultInstanceForType => CSharpFieldOptions.defaultInstance;

    protected override CSharpFieldOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => CSharpOptions.internal__static_google_protobuf_CSharpFieldOptions__Descriptor;
    }

    protected override FieldAccessorTable<CSharpFieldOptions, CSharpFieldOptions.Builder> InternalFieldAccessors
    {
      get => CSharpOptions.internal__static_google_protobuf_CSharpFieldOptions__FieldAccessorTable;
    }

    public bool HasPropertyName => this.hasPropertyName;

    public string PropertyName => this.propertyName_;

    public override bool IsInitialized => true;

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasPropertyName)
        output.WriteString(1, this.PropertyName);
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
        if (this.HasPropertyName)
          num += CodedOutputStream.ComputeStringSize(1, this.PropertyName);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static CSharpFieldOptions ParseFrom(ByteString data)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(byte[] data)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(Stream input)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFieldOptions ParseDelimitedFrom(Stream input)
    {
      return CSharpFieldOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static CSharpFieldOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return CSharpFieldOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(CodedInputStream input)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static CSharpFieldOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return CSharpFieldOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFieldOptions.Builder CreateBuilder() => new CSharpFieldOptions.Builder();

    public override CSharpFieldOptions.Builder ToBuilder()
    {
      return CSharpFieldOptions.CreateBuilder(this);
    }

    public override CSharpFieldOptions.Builder CreateBuilderForType()
    {
      return new CSharpFieldOptions.Builder();
    }

    public static CSharpFieldOptions.Builder CreateBuilder(CSharpFieldOptions prototype)
    {
      return new CSharpFieldOptions.Builder().MergeFrom(prototype);
    }

    static CSharpFieldOptions()
    {
      object.ReferenceEquals((object) CSharpOptions.Descriptor, (object) null);
    }

    public sealed class Builder : GeneratedBuilder<CSharpFieldOptions, CSharpFieldOptions.Builder>
    {
      private CSharpFieldOptions result = new CSharpFieldOptions();

      protected override CSharpFieldOptions.Builder ThisBuilder => this;

      protected override CSharpFieldOptions MessageBeingBuilt => this.result;

      public override CSharpFieldOptions.Builder Clear()
      {
        this.result = new CSharpFieldOptions();
        return this;
      }

      public override CSharpFieldOptions.Builder Clone()
      {
        return new CSharpFieldOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => CSharpFieldOptions.Descriptor;

      public override CSharpFieldOptions DefaultInstanceForType
      {
        get => CSharpFieldOptions.DefaultInstance;
      }

      public override CSharpFieldOptions BuildPartial()
      {
        CSharpFieldOptions csharpFieldOptions = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
        this.result = (CSharpFieldOptions) null;
        return csharpFieldOptions;
      }

      public override CSharpFieldOptions.Builder MergeFrom(IMessage other)
      {
        if (other is CSharpFieldOptions)
          return this.MergeFrom((CSharpFieldOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override CSharpFieldOptions.Builder MergeFrom(CSharpFieldOptions other)
      {
        if (other == CSharpFieldOptions.DefaultInstance)
          return this;
        if (other.HasPropertyName)
          this.PropertyName = other.PropertyName;
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override CSharpFieldOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override CSharpFieldOptions.Builder MergeFrom(
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
              this.PropertyName = input.ReadString();
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

      public bool HasPropertyName => this.result.HasPropertyName;

      public string PropertyName
      {
        get => this.result.PropertyName;
        set => this.SetPropertyName(value);
      }

      public CSharpFieldOptions.Builder SetPropertyName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasPropertyName = true;
        this.result.propertyName_ = value;
        return this;
      }

      public CSharpFieldOptions.Builder ClearPropertyName()
      {
        this.result.hasPropertyName = false;
        this.result.propertyName_ = "";
        return this;
      }
    }
  }
}
