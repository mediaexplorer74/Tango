// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.ServiceOptions
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
  public sealed class ServiceOptions : ExtendableMessage<ServiceOptions, ServiceOptions.Builder>
  {
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly ServiceOptions defaultInstance = new ServiceOptions.Builder().BuildPartial();
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static ServiceOptions DefaultInstance => ServiceOptions.defaultInstance;

    public override ServiceOptions DefaultInstanceForType => ServiceOptions.defaultInstance;

    protected override ServiceOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_ServiceOptions__Descriptor;
    }

    protected override FieldAccessorTable<ServiceOptions, ServiceOptions.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_ServiceOptions__FieldAccessorTable;
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
      ExtendableMessage<ServiceOptions, ServiceOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<ServiceOptions, ServiceOptions.Builder>) this);
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

    public static ServiceOptions ParseFrom(ByteString data)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static ServiceOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static ServiceOptions ParseFrom(byte[] data)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static ServiceOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static ServiceOptions ParseFrom(Stream input)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static ServiceOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceOptions ParseDelimitedFrom(Stream input)
    {
      return ServiceOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static ServiceOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceOptions ParseFrom(CodedInputStream input)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static ServiceOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceOptions.Builder CreateBuilder() => new ServiceOptions.Builder();

    public override ServiceOptions.Builder ToBuilder() => ServiceOptions.CreateBuilder(this);

    public override ServiceOptions.Builder CreateBuilderForType() => new ServiceOptions.Builder();

    public static ServiceOptions.Builder CreateBuilder(ServiceOptions prototype)
    {
      return new ServiceOptions.Builder().MergeFrom(prototype);
    }

    static ServiceOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : ExtendableBuilder<ServiceOptions, ServiceOptions.Builder>
    {
      private ServiceOptions result = new ServiceOptions();

      protected override ServiceOptions.Builder ThisBuilder => this;

      protected override ServiceOptions MessageBeingBuilt => this.result;

      public override ServiceOptions.Builder Clear()
      {
        this.result = new ServiceOptions();
        return this;
      }

      public override ServiceOptions.Builder Clone()
      {
        return new ServiceOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => ServiceOptions.Descriptor;

      public override ServiceOptions DefaultInstanceForType => ServiceOptions.DefaultInstance;

      public override ServiceOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        ServiceOptions result = this.result;
        this.result = (ServiceOptions) null;
        return result;
      }

      public override ServiceOptions.Builder MergeFrom(IMessage other)
      {
        if (other is ServiceOptions)
          return this.MergeFrom((ServiceOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override ServiceOptions.Builder MergeFrom(ServiceOptions other)
      {
        if (other == ServiceOptions.DefaultInstance)
          return this;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<ServiceOptions, ServiceOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override ServiceOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override ServiceOptions.Builder MergeFrom(
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

      public ServiceOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public ServiceOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public ServiceOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public ServiceOptions.Builder AddUninterpretedOption(
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public ServiceOptions.Builder AddRangeUninterpretedOption(
        IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public ServiceOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
