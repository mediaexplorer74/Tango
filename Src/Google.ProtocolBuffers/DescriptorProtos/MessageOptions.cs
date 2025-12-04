// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.MessageOptions
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
  public sealed class MessageOptions : ExtendableMessage<MessageOptions, MessageOptions.Builder>
  {
    public const int MessageSetWireFormatFieldNumber = 1;
    public const int NoStandardDescriptorAccessorFieldNumber = 2;
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly MessageOptions defaultInstance = new MessageOptions.Builder().BuildPartial();
    private bool hasMessageSetWireFormat;
    private bool messageSetWireFormat_;
    private bool hasNoStandardDescriptorAccessor;
    private bool noStandardDescriptorAccessor_;
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static MessageOptions DefaultInstance => MessageOptions.defaultInstance;

    public override MessageOptions DefaultInstanceForType => MessageOptions.defaultInstance;

    protected override MessageOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_MessageOptions__Descriptor;
    }

    protected override FieldAccessorTable<MessageOptions, MessageOptions.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_MessageOptions__FieldAccessorTable;
      }
    }

    public bool HasMessageSetWireFormat => this.hasMessageSetWireFormat;

    public bool MessageSetWireFormat => this.messageSetWireFormat_;

    public bool HasNoStandardDescriptorAccessor => this.hasNoStandardDescriptorAccessor;

    public bool NoStandardDescriptorAccessor => this.noStandardDescriptorAccessor_;

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
      ExtendableMessage<MessageOptions, MessageOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<MessageOptions, MessageOptions.Builder>) this);
      if (this.HasMessageSetWireFormat)
        output.WriteBool(1, this.MessageSetWireFormat);
      if (this.HasNoStandardDescriptorAccessor)
        output.WriteBool(2, this.NoStandardDescriptorAccessor);
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
        if (this.HasMessageSetWireFormat)
          num += CodedOutputStream.ComputeBoolSize(1, this.MessageSetWireFormat);
        if (this.HasNoStandardDescriptorAccessor)
          num += CodedOutputStream.ComputeBoolSize(2, this.NoStandardDescriptorAccessor);
        foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
          num += CodedOutputStream.ComputeMessageSize(999, (IMessageLite) uninterpretedOption);
        int serializedSize = num + this.ExtensionsSerializedSize + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static MessageOptions ParseFrom(ByteString data)
    {
      return MessageOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MessageOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return MessageOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MessageOptions ParseFrom(byte[] data)
    {
      return MessageOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static MessageOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return MessageOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static MessageOptions ParseFrom(Stream input)
    {
      return MessageOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MessageOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return MessageOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MessageOptions ParseDelimitedFrom(Stream input)
    {
      return MessageOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static MessageOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return MessageOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static MessageOptions ParseFrom(CodedInputStream input)
    {
      return MessageOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static MessageOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return MessageOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static MessageOptions.Builder CreateBuilder() => new MessageOptions.Builder();

    public override MessageOptions.Builder ToBuilder() => MessageOptions.CreateBuilder(this);

    public override MessageOptions.Builder CreateBuilderForType() => new MessageOptions.Builder();

    public static MessageOptions.Builder CreateBuilder(MessageOptions prototype)
    {
      return new MessageOptions.Builder().MergeFrom(prototype);
    }

    static MessageOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : ExtendableBuilder<MessageOptions, MessageOptions.Builder>
    {
      private MessageOptions result = new MessageOptions();

      protected override MessageOptions.Builder ThisBuilder => this;

      protected override MessageOptions MessageBeingBuilt => this.result;

      public override MessageOptions.Builder Clear()
      {
        this.result = new MessageOptions();
        return this;
      }

      public override MessageOptions.Builder Clone()
      {
        return new MessageOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => MessageOptions.Descriptor;

      public override MessageOptions DefaultInstanceForType => MessageOptions.DefaultInstance;

      public override MessageOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        MessageOptions result = this.result;
        this.result = (MessageOptions) null;
        return result;
      }

      public override MessageOptions.Builder MergeFrom(IMessage other)
      {
        if (other is MessageOptions)
          return this.MergeFrom((MessageOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override MessageOptions.Builder MergeFrom(MessageOptions other)
      {
        if (other == MessageOptions.DefaultInstance)
          return this;
        if (other.HasMessageSetWireFormat)
          this.MessageSetWireFormat = other.MessageSetWireFormat;
        if (other.HasNoStandardDescriptorAccessor)
          this.NoStandardDescriptorAccessor = other.NoStandardDescriptorAccessor;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<MessageOptions, MessageOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override MessageOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override MessageOptions.Builder MergeFrom(
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
            case 8:
              this.MessageSetWireFormat = input.ReadBool();
              continue;
            case 16:
              this.NoStandardDescriptorAccessor = input.ReadBool();
              continue;
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

      public bool HasMessageSetWireFormat => this.result.HasMessageSetWireFormat;

      public bool MessageSetWireFormat
      {
        get => this.result.MessageSetWireFormat;
        set => this.SetMessageSetWireFormat(value);
      }

      public MessageOptions.Builder SetMessageSetWireFormat(bool value)
      {
        this.result.hasMessageSetWireFormat = true;
        this.result.messageSetWireFormat_ = value;
        return this;
      }

      public MessageOptions.Builder ClearMessageSetWireFormat()
      {
        this.result.hasMessageSetWireFormat = false;
        this.result.messageSetWireFormat_ = false;
        return this;
      }

      public bool HasNoStandardDescriptorAccessor => this.result.HasNoStandardDescriptorAccessor;

      public bool NoStandardDescriptorAccessor
      {
        get => this.result.NoStandardDescriptorAccessor;
        set => this.SetNoStandardDescriptorAccessor(value);
      }

      public MessageOptions.Builder SetNoStandardDescriptorAccessor(bool value)
      {
        this.result.hasNoStandardDescriptorAccessor = true;
        this.result.noStandardDescriptorAccessor_ = value;
        return this;
      }

      public MessageOptions.Builder ClearNoStandardDescriptorAccessor()
      {
        this.result.hasNoStandardDescriptorAccessor = false;
        this.result.noStandardDescriptorAccessor_ = false;
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

      public MessageOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public MessageOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public MessageOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public MessageOptions.Builder AddUninterpretedOption(
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public MessageOptions.Builder AddRangeUninterpretedOption(
        IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public MessageOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
