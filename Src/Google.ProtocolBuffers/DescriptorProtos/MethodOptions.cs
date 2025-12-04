// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.MethodOptions
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
  public sealed class MethodOptions : ExtendableMessage<MethodOptions, MethodOptions.Builder>
  {
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly MethodOptions defaultInstance = new MethodOptions.Builder().BuildPartial();
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static MethodOptions DefaultInstance => MethodOptions.defaultInstance;

    public override MethodOptions DefaultInstanceForType => MethodOptions.defaultInstance;

    protected override MethodOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_MethodOptions__Descriptor;
    }

    protected override FieldAccessorTable<MethodOptions, MethodOptions.Builder> InternalFieldAccessors
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_MethodOptions__FieldAccessorTable;
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
      ExtendableMessage<MethodOptions, MethodOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<MethodOptions, MethodOptions.Builder>) this);
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

    public static MethodOptions ParseFrom(ByteString data)
    {
      return MethodOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MethodOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return MethodOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MethodOptions ParseFrom(byte[] data)
    {
      return MethodOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MethodOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return MethodOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MethodOptions ParseFrom(Stream input)
    {
      return MethodOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MethodOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return MethodOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodOptions ParseDelimitedFrom(Stream input)
    {
      return MethodOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static MethodOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return MethodOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodOptions ParseFrom(CodedInputStream input)
    {
      return MethodOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MethodOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return MethodOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MethodOptions.Builder CreateBuilder() => new MethodOptions.Builder();

    public override MethodOptions.Builder ToBuilder() => MethodOptions.CreateBuilder(this);

    public override MethodOptions.Builder CreateBuilderForType() => new MethodOptions.Builder();

    public static MethodOptions.Builder CreateBuilder(MethodOptions prototype)
    {
      return new MethodOptions.Builder().MergeFrom(prototype);
    }

    static MethodOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : ExtendableBuilder<MethodOptions, MethodOptions.Builder>
    {
      private MethodOptions result = new MethodOptions();

      protected override MethodOptions.Builder ThisBuilder => this;

      protected override MethodOptions MessageBeingBuilt => this.result;

      public override MethodOptions.Builder Clear()
      {
        this.result = new MethodOptions();
        return this;
      }

      public override MethodOptions.Builder Clone()
      {
        return new MethodOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => MethodOptions.Descriptor;

      public override MethodOptions DefaultInstanceForType => MethodOptions.DefaultInstance;

      public override MethodOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        MethodOptions result = this.result;
        this.result = (MethodOptions) null;
        return result;
      }

      public override MethodOptions.Builder MergeFrom(IMessage other)
      {
        if (other is MethodOptions)
          return this.MergeFrom((MethodOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override MethodOptions.Builder MergeFrom(MethodOptions other)
      {
        if (other == MethodOptions.DefaultInstance)
          return this;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<MethodOptions, MethodOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override MethodOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override MethodOptions.Builder MergeFrom(
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

      public MethodOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public MethodOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public MethodOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public MethodOptions.Builder AddUninterpretedOption(
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public MethodOptions.Builder AddRangeUninterpretedOption(
        IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public MethodOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
