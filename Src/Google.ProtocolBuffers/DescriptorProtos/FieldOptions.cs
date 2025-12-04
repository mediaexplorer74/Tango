// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.FieldOptions
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
  public sealed class FieldOptions : ExtendableMessage<FieldOptions, FieldOptions.Builder>
  {
    public const int CtypeFieldNumber = 1;
    public const int PackedFieldNumber = 2;
    public const int DeprecatedFieldNumber = 3;
    public const int ExperimentalMapKeyFieldNumber = 9;
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly FieldOptions defaultInstance = new FieldOptions.Builder().BuildPartial();
    private bool hasCtype;
    private FieldOptions.Types.CType ctype_;
    private bool hasPacked;
    private bool packed_;
    private bool hasDeprecated;
    private bool deprecated_;
    private bool hasExperimentalMapKey;
    private string experimentalMapKey_ = "";
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static FieldOptions DefaultInstance => FieldOptions.defaultInstance;

    public override FieldOptions DefaultInstanceForType => FieldOptions.defaultInstance;

    protected override FieldOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FieldOptions__Descriptor;
    }

    protected override FieldAccessorTable<FieldOptions, FieldOptions.Builder> InternalFieldAccessors
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FieldOptions__FieldAccessorTable;
    }

    public bool HasCtype => this.hasCtype;

    public FieldOptions.Types.CType Ctype => this.ctype_;

    public bool HasPacked => this.hasPacked;

    public bool Packed => this.packed_;

    public bool HasDeprecated => this.hasDeprecated;

    public bool Deprecated => this.deprecated_;

    public bool HasExperimentalMapKey => this.hasExperimentalMapKey;

    public string ExperimentalMapKey => this.experimentalMapKey_;

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
      ExtendableMessage<FieldOptions, FieldOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<FieldOptions, FieldOptions.Builder>) this);
      if (this.HasCtype)
        output.WriteEnum(1, (int) this.Ctype);
      if (this.HasPacked)
        output.WriteBool(2, this.Packed);
      if (this.HasDeprecated)
        output.WriteBool(3, this.Deprecated);
      if (this.HasExperimentalMapKey)
        output.WriteString(9, this.ExperimentalMapKey);
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
        if (this.HasCtype)
          num += CodedOutputStream.ComputeEnumSize(1, (int) this.Ctype);
        if (this.HasPacked)
          num += CodedOutputStream.ComputeBoolSize(2, this.Packed);
        if (this.HasDeprecated)
          num += CodedOutputStream.ComputeBoolSize(3, this.Deprecated);
        if (this.HasExperimentalMapKey)
          num += CodedOutputStream.ComputeStringSize(9, this.ExperimentalMapKey);
        foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
          num += CodedOutputStream.ComputeMessageSize(999, (IMessageLite) uninterpretedOption);
        int serializedSize = num + this.ExtensionsSerializedSize + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static FieldOptions ParseFrom(ByteString data)
    {
      return FieldOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FieldOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return FieldOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FieldOptions ParseFrom(byte[] data)
    {
      return FieldOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FieldOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return FieldOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FieldOptions ParseFrom(Stream input)
    {
      return FieldOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FieldOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FieldOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldOptions ParseDelimitedFrom(Stream input)
    {
      return FieldOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static FieldOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FieldOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldOptions ParseFrom(CodedInputStream input)
    {
      return FieldOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FieldOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return FieldOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FieldOptions.Builder CreateBuilder() => new FieldOptions.Builder();

    public override FieldOptions.Builder ToBuilder() => FieldOptions.CreateBuilder(this);

    public override FieldOptions.Builder CreateBuilderForType() => new FieldOptions.Builder();

    public static FieldOptions.Builder CreateBuilder(FieldOptions prototype)
    {
      return new FieldOptions.Builder().MergeFrom(prototype);
    }

    static FieldOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public static class Types
    {
      public enum CType
      {
        STRING,
        CORD,
        STRING_PIECE,
      }
    }

    public sealed class Builder : ExtendableBuilder<FieldOptions, FieldOptions.Builder>
    {
      private FieldOptions result = new FieldOptions();

      protected override FieldOptions.Builder ThisBuilder => this;

      protected override FieldOptions MessageBeingBuilt => this.result;

      public override FieldOptions.Builder Clear()
      {
        this.result = new FieldOptions();
        return this;
      }

      public override FieldOptions.Builder Clone()
      {
        return new FieldOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => FieldOptions.Descriptor;

      public override FieldOptions DefaultInstanceForType => FieldOptions.DefaultInstance;

      public override FieldOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        FieldOptions result = this.result;
        this.result = (FieldOptions) null;
        return result;
      }

      public override FieldOptions.Builder MergeFrom(IMessage other)
      {
        if (other is FieldOptions)
          return this.MergeFrom((FieldOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override FieldOptions.Builder MergeFrom(FieldOptions other)
      {
        if (other == FieldOptions.DefaultInstance)
          return this;
        if (other.HasCtype)
          this.Ctype = other.Ctype;
        if (other.HasPacked)
          this.Packed = other.Packed;
        if (other.HasDeprecated)
          this.Deprecated = other.Deprecated;
        if (other.HasExperimentalMapKey)
          this.ExperimentalMapKey = other.ExperimentalMapKey;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<FieldOptions, FieldOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override FieldOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override FieldOptions.Builder MergeFrom(
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
              int num = input.ReadEnum();
              if (!Enum.IsDefined(typeof (FieldOptions.Types.CType), (object) num))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                unknownFields.MergeVarintField(1, (ulong) num);
                continue;
              }
              this.Ctype = (FieldOptions.Types.CType) num;
              continue;
            case 16:
              this.Packed = input.ReadBool();
              continue;
            case 24:
              this.Deprecated = input.ReadBool();
              continue;
            case 74:
              this.ExperimentalMapKey = input.ReadString();
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

      public bool HasCtype => this.result.HasCtype;

      public FieldOptions.Types.CType Ctype
      {
        get => this.result.Ctype;
        set => this.SetCtype(value);
      }

      public FieldOptions.Builder SetCtype(FieldOptions.Types.CType value)
      {
        this.result.hasCtype = true;
        this.result.ctype_ = value;
        return this;
      }

      public FieldOptions.Builder ClearCtype()
      {
        this.result.hasCtype = false;
        this.result.ctype_ = FieldOptions.Types.CType.STRING;
        return this;
      }

      public bool HasPacked => this.result.HasPacked;

      public bool Packed
      {
        get => this.result.Packed;
        set => this.SetPacked(value);
      }

      public FieldOptions.Builder SetPacked(bool value)
      {
        this.result.hasPacked = true;
        this.result.packed_ = value;
        return this;
      }

      public FieldOptions.Builder ClearPacked()
      {
        this.result.hasPacked = false;
        this.result.packed_ = false;
        return this;
      }

      public bool HasDeprecated => this.result.HasDeprecated;

      public bool Deprecated
      {
        get => this.result.Deprecated;
        set => this.SetDeprecated(value);
      }

      public FieldOptions.Builder SetDeprecated(bool value)
      {
        this.result.hasDeprecated = true;
        this.result.deprecated_ = value;
        return this;
      }

      public FieldOptions.Builder ClearDeprecated()
      {
        this.result.hasDeprecated = false;
        this.result.deprecated_ = false;
        return this;
      }

      public bool HasExperimentalMapKey => this.result.HasExperimentalMapKey;

      public string ExperimentalMapKey
      {
        get => this.result.ExperimentalMapKey;
        set => this.SetExperimentalMapKey(value);
      }

      public FieldOptions.Builder SetExperimentalMapKey(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasExperimentalMapKey = true;
        this.result.experimentalMapKey_ = value;
        return this;
      }

      public FieldOptions.Builder ClearExperimentalMapKey()
      {
        this.result.hasExperimentalMapKey = false;
        this.result.experimentalMapKey_ = "";
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

      public FieldOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public FieldOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public FieldOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public FieldOptions.Builder AddUninterpretedOption(UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public FieldOptions.Builder AddRangeUninterpretedOption(
        IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public FieldOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
