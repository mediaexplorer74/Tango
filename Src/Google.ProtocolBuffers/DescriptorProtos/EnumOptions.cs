// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.EnumOptions
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
  public sealed class EnumOptions : ExtendableMessage<EnumOptions, EnumOptions.Builder>
  {
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly EnumOptions defaultInstance = new EnumOptions.Builder().BuildPartial();
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static EnumOptions DefaultInstance => EnumOptions.defaultInstance;

    public override EnumOptions DefaultInstanceForType => EnumOptions.defaultInstance;

    protected override EnumOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_EnumOptions__Descriptor;
    }

    protected override FieldAccessorTable<EnumOptions, EnumOptions.Builder> InternalFieldAccessors
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_EnumOptions__FieldAccessorTable;
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
      ExtendableMessage<EnumOptions, EnumOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<EnumOptions, EnumOptions.Builder>) this);
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

    public static EnumOptions ParseFrom(ByteString data)
    {
      return EnumOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return EnumOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumOptions ParseFrom(byte[] data)
    {
      return EnumOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static EnumOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return EnumOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static EnumOptions ParseFrom(Stream input)
    {
      return EnumOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return EnumOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumOptions ParseDelimitedFrom(Stream input)
    {
      return EnumOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static EnumOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return EnumOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumOptions ParseFrom(CodedInputStream input)
    {
      return EnumOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static EnumOptions ParseFrom(CodedInputStream input, ExtensionRegistry extensionRegistry)
    {
      return EnumOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static EnumOptions.Builder CreateBuilder() => new EnumOptions.Builder();

    public override EnumOptions.Builder ToBuilder() => EnumOptions.CreateBuilder(this);

    public override EnumOptions.Builder CreateBuilderForType() => new EnumOptions.Builder();

    public static EnumOptions.Builder CreateBuilder(EnumOptions prototype)
    {
      return new EnumOptions.Builder().MergeFrom(prototype);
    }

    static EnumOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : ExtendableBuilder<EnumOptions, EnumOptions.Builder>
    {
      private EnumOptions result = new EnumOptions();

      protected override EnumOptions.Builder ThisBuilder => this;

      protected override EnumOptions MessageBeingBuilt => this.result;

      public override EnumOptions.Builder Clear()
      {
        this.result = new EnumOptions();
        return this;
      }

      public override EnumOptions.Builder Clone()
      {
        return new EnumOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => EnumOptions.Descriptor;

      public override EnumOptions DefaultInstanceForType => EnumOptions.DefaultInstance;

      public override EnumOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        EnumOptions result = this.result;
        this.result = (EnumOptions) null;
        return result;
      }

      public override EnumOptions.Builder MergeFrom(IMessage other)
      {
        if (other is EnumOptions)
          return this.MergeFrom((EnumOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override EnumOptions.Builder MergeFrom(EnumOptions other)
      {
        if (other == EnumOptions.DefaultInstance)
          return this;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<EnumOptions, EnumOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override EnumOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override EnumOptions.Builder MergeFrom(
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

      public EnumOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public EnumOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public EnumOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public EnumOptions.Builder AddUninterpretedOption(UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public EnumOptions.Builder AddRangeUninterpretedOption(IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public EnumOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
