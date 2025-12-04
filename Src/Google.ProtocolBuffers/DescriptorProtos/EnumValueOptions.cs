// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.EnumValueOptions
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
  public sealed class EnumValueOptions : 
    ExtendableMessage<EnumValueOptions, EnumValueOptions.Builder>
  {
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly EnumValueOptions defaultInstance = new EnumValueOptions.Builder().BuildPartial();
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static EnumValueOptions DefaultInstance => EnumValueOptions.defaultInstance;

    public override EnumValueOptions DefaultInstanceForType => EnumValueOptions.defaultInstance;

    protected override EnumValueOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_EnumValueOptions__Descriptor;
    }

    protected override FieldAccessorTable<EnumValueOptions, EnumValueOptions.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_EnumValueOptions__FieldAccessorTable;
      }
    }

    public IList<UninterpretedOption> UninterpretedOptionList
    {
      get => (IList<UninterpretedOption>) this.uninterpretedOption_;
    }

    public int UninterpretedOptionCount => this.uninterpretedOption_.Count;

    public UninterpretedOption GetUninterpretedOption(int index)
    {
      return this.uninterpretedOption_[index];
    }

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<UninterpretedOption, UninterpretedOption.Builder> uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
        {
          if (!uninterpretedOption.IsInitialized)
            return false;
        }
        return this.ExtensionsAreInitialized;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      ExtendableMessage<EnumValueOptions, EnumValueOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<EnumValueOptions, EnumValueOptions.Builder>) this);
      foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
        output.WriteMessage(999, (IMessageLite) uninterpretedOption);
      extensionWriter.WriteUntil(536870912, output);
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
        foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
          num += CodedOutputStream.ComputeMessageSize(999, (IMessageLite) uninterpretedOption);
        int serializedSize = num + this.ExtensionsSerializedSize + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static EnumValueOptions ParseFrom(ByteString data)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(byte[] data)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(Stream input)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueOptions ParseDelimitedFrom(Stream input)
    {
      return EnumValueOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static EnumValueOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(CodedInputStream input)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumValueOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return EnumValueOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumValueOptions.Builder CreateBuilder() => new EnumValueOptions.Builder();

    public override EnumValueOptions.Builder ToBuilder() => EnumValueOptions.CreateBuilder(this);

    public override EnumValueOptions.Builder CreateBuilderForType()
    {
      return new EnumValueOptions.Builder();
    }

    public static EnumValueOptions.Builder CreateBuilder(EnumValueOptions prototype)
    {
      return new EnumValueOptions.Builder().MergeFrom(prototype);
    }

    static EnumValueOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : ExtendableBuilder<EnumValueOptions, EnumValueOptions.Builder>
    {
      private EnumValueOptions result = new EnumValueOptions();

      protected override EnumValueOptions.Builder ThisBuilder => this;

      protected override EnumValueOptions MessageBeingBuilt => this.result;

      public override EnumValueOptions.Builder Clear()
      {
        this.result = new EnumValueOptions();
        return this;
      }

      public override EnumValueOptions.Builder Clone()
      {
        return new EnumValueOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => EnumValueOptions.Descriptor;

      public override EnumValueOptions DefaultInstanceForType => EnumValueOptions.DefaultInstance;

      public override EnumValueOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        EnumValueOptions result = this.result;
        this.result = (EnumValueOptions) null;
        return result;
      }

      public override EnumValueOptions.Builder MergeFrom(IMessage other)
      {
        if (other is EnumValueOptions)
          return this.MergeFrom((EnumValueOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override EnumValueOptions.Builder MergeFrom(EnumValueOptions other)
      {
        if (other == EnumValueOptions.DefaultInstance)
          return this;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<EnumValueOptions, EnumValueOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override EnumValueOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override EnumValueOptions.Builder MergeFrom(
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
            case 7994:
              UninterpretedOption.Builder builder = UninterpretedOption.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder, extensionRegistry);
              this.AddUninterpretedOption(builder.BuildPartial());
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

      public IPopsicleList<UninterpretedOption> UninterpretedOptionList
      {
        get => (IPopsicleList<UninterpretedOption>) this.result.uninterpretedOption_;
      }

      public int UninterpretedOptionCount => this.result.UninterpretedOptionCount;

      public UninterpretedOption GetUninterpretedOption(int index)
      {
        return this.result.GetUninterpretedOption(index);
      }

      public EnumValueOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public EnumValueOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public EnumValueOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public EnumValueOptions.Builder AddUninterpretedOption(
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public EnumValueOptions.Builder AddRangeUninterpretedOption(
        IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public EnumValueOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
