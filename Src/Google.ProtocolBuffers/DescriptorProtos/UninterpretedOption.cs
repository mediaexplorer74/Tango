// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.UninterpretedOption
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
  public sealed class UninterpretedOption : 
    GeneratedMessage<UninterpretedOption, UninterpretedOption.Builder>
  {
    public const int NameFieldNumber = 2;
    public const int IdentifierValueFieldNumber = 3;
    public const int PositiveIntValueFieldNumber = 4;
    public const int NegativeIntValueFieldNumber = 5;
    public const int DoubleValueFieldNumber = 6;
    public const int StringValueFieldNumber = 7;
    private static readonly UninterpretedOption defaultInstance = new UninterpretedOption.Builder().BuildPartial();
    private PopsicleList<UninterpretedOption.Types.NamePart> name_ = new PopsicleList<UninterpretedOption.Types.NamePart>();
    private bool hasIdentifierValue;
    private string identifierValue_ = "";
    private bool hasPositiveIntValue;
    private ulong positiveIntValue_;
    private bool hasNegativeIntValue;
    private long negativeIntValue_;
    private bool hasDoubleValue;
    private double doubleValue_;
    private bool hasStringValue;
    private ByteString stringValue_ = ByteString.Empty;
    private int memoizedSerializedSize = -1;

    public static UninterpretedOption DefaultInstance => UninterpretedOption.defaultInstance;

    public override UninterpretedOption DefaultInstanceForType
    {
      get => UninterpretedOption.defaultInstance;
    }

    protected override UninterpretedOption ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_UninterpretedOption__Descriptor;
    }

    protected override FieldAccessorTable<UninterpretedOption, UninterpretedOption.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_UninterpretedOption__FieldAccessorTable;
      }
    }

    public IList<UninterpretedOption.Types.NamePart> NameList
    {
      get => (IList<UninterpretedOption.Types.NamePart>) this.name_;
    }

    public int NameCount => this.name_.Count;

    public UninterpretedOption.Types.NamePart GetName(int index) => this.name_[index];

    public bool HasIdentifierValue => this.hasIdentifierValue;

    public string IdentifierValue => this.identifierValue_;

    public bool HasPositiveIntValue => this.hasPositiveIntValue;

    [CLSCompliant(false)]
    public ulong PositiveIntValue => this.positiveIntValue_;

    public bool HasNegativeIntValue => this.hasNegativeIntValue;

    public long NegativeIntValue => this.negativeIntValue_;

    public bool HasDoubleValue => this.hasDoubleValue;

    public double DoubleValue => this.doubleValue_;

    public bool HasStringValue => this.hasStringValue;

    public ByteString StringValue => this.stringValue_;

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<UninterpretedOption.Types.NamePart, UninterpretedOption.Types.NamePart.Builder> name in (IEnumerable<UninterpretedOption.Types.NamePart>) this.NameList)
        {
          if (!name.IsInitialized)
            return false;
        }
        return true;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      foreach (UninterpretedOption.Types.NamePart name in (IEnumerable<UninterpretedOption.Types.NamePart>) this.NameList)
        output.WriteMessage(2, (IMessageLite) name);
      if (this.HasIdentifierValue)
        output.WriteString(3, this.IdentifierValue);
      if (this.HasPositiveIntValue)
        output.WriteUInt64(4, this.PositiveIntValue);
      if (this.HasNegativeIntValue)
        output.WriteInt64(5, this.NegativeIntValue);
      if (this.HasDoubleValue)
        output.WriteDouble(6, this.DoubleValue);
      if (this.HasStringValue)
        output.WriteBytes(7, this.StringValue);
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
        foreach (UninterpretedOption.Types.NamePart name in (IEnumerable<UninterpretedOption.Types.NamePart>) this.NameList)
          num += CodedOutputStream.ComputeMessageSize(2, (IMessageLite) name);
        if (this.HasIdentifierValue)
          num += CodedOutputStream.ComputeStringSize(3, this.IdentifierValue);
        if (this.HasPositiveIntValue)
          num += CodedOutputStream.ComputeUInt64Size(4, this.PositiveIntValue);
        if (this.HasNegativeIntValue)
          num += CodedOutputStream.ComputeInt64Size(5, this.NegativeIntValue);
        if (this.HasDoubleValue)
          num += CodedOutputStream.ComputeDoubleSize(6, this.DoubleValue);
        if (this.HasStringValue)
          num += CodedOutputStream.ComputeBytesSize(7, this.StringValue);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static UninterpretedOption ParseFrom(ByteString data)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(byte[] data)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(Stream input)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static UninterpretedOption ParseDelimitedFrom(Stream input)
    {
      return UninterpretedOption.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static UninterpretedOption ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return UninterpretedOption.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(CodedInputStream input)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static UninterpretedOption ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return UninterpretedOption.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static UninterpretedOption.Builder CreateBuilder() => new UninterpretedOption.Builder();

    public override UninterpretedOption.Builder ToBuilder()
    {
      return UninterpretedOption.CreateBuilder(this);
    }

    public override UninterpretedOption.Builder CreateBuilderForType()
    {
      return new UninterpretedOption.Builder();
    }

    public static UninterpretedOption.Builder CreateBuilder(UninterpretedOption prototype)
    {
      return new UninterpretedOption.Builder().MergeFrom(prototype);
    }

    static UninterpretedOption()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public static class Types
    {
      public sealed class NamePart : 
        GeneratedMessage<UninterpretedOption.Types.NamePart, UninterpretedOption.Types.NamePart.Builder>
      {
        public const int NamePart_FieldNumber = 1;
        public const int IsExtensionFieldNumber = 2;
        private static readonly UninterpretedOption.Types.NamePart defaultInstance = new UninterpretedOption.Types.NamePart.Builder().BuildPartial();
        private bool hasNamePart_;
        private string namePart_ = "";
        private bool hasIsExtension;
        private bool isExtension_;
        private int memoizedSerializedSize = -1;

        public static UninterpretedOption.Types.NamePart DefaultInstance
        {
          get => UninterpretedOption.Types.NamePart.defaultInstance;
        }

        public override UninterpretedOption.Types.NamePart DefaultInstanceForType
        {
          get => UninterpretedOption.Types.NamePart.defaultInstance;
        }

        protected override UninterpretedOption.Types.NamePart ThisMessage => this;

        public static MessageDescriptor Descriptor
        {
          get
          {
            return DescriptorProtoFile.internal__static_google_protobuf_UninterpretedOption_NamePart__Descriptor;
          }
        }

        protected override FieldAccessorTable<UninterpretedOption.Types.NamePart, UninterpretedOption.Types.NamePart.Builder> InternalFieldAccessors
        {
          get
          {
            return DescriptorProtoFile.internal__static_google_protobuf_UninterpretedOption_NamePart__FieldAccessorTable;
          }
        }

        public bool HasNamePart_ => this.hasNamePart_;

        public string NamePart_ => this.namePart_;

        public bool HasIsExtension => this.hasIsExtension;

        public bool IsExtension => this.isExtension_;

        public override bool IsInitialized => this.hasNamePart_ && this.hasIsExtension;

        public override void WriteTo(CodedOutputStream output)
        {
          int serializedSize = this.SerializedSize;
          if (this.HasNamePart_)
            output.WriteString(1, this.NamePart_);
          if (this.HasIsExtension)
            output.WriteBool(2, this.IsExtension);
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
            if (this.HasNamePart_)
              num += CodedOutputStream.ComputeStringSize(1, this.NamePart_);
            if (this.HasIsExtension)
              num += CodedOutputStream.ComputeBoolSize(2, this.IsExtension);
            int serializedSize = num + this.UnknownFields.SerializedSize;
            this.memoizedSerializedSize = serializedSize;
            return serializedSize;
          }
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(ByteString data)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(
          ByteString data,
          ExtensionRegistry extensionRegistry)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(byte[] data)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(
          byte[] data,
          ExtensionRegistry extensionRegistry)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(Stream input)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(
          Stream input,
          ExtensionRegistry extensionRegistry)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseDelimitedFrom(Stream input)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseDelimitedFrom(
          Stream input,
          ExtensionRegistry extensionRegistry)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(CodedInputStream input)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart ParseFrom(
          CodedInputStream input,
          ExtensionRegistry extensionRegistry)
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static UninterpretedOption.Types.NamePart.Builder CreateBuilder()
        {
          return new UninterpretedOption.Types.NamePart.Builder();
        }

        public override UninterpretedOption.Types.NamePart.Builder ToBuilder()
        {
          return UninterpretedOption.Types.NamePart.CreateBuilder(this);
        }

        public override UninterpretedOption.Types.NamePart.Builder CreateBuilderForType()
        {
          return new UninterpretedOption.Types.NamePart.Builder();
        }

        public static UninterpretedOption.Types.NamePart.Builder CreateBuilder(
          UninterpretedOption.Types.NamePart prototype)
        {
          return new UninterpretedOption.Types.NamePart.Builder().MergeFrom(prototype);
        }

        static NamePart()
        {
          object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
        }

        public sealed class Builder : 
          GeneratedBuilder<UninterpretedOption.Types.NamePart, UninterpretedOption.Types.NamePart.Builder>
        {
          private UninterpretedOption.Types.NamePart result = new UninterpretedOption.Types.NamePart();

          protected override UninterpretedOption.Types.NamePart.Builder ThisBuilder => this;

          protected override UninterpretedOption.Types.NamePart MessageBeingBuilt => this.result;

          public override UninterpretedOption.Types.NamePart.Builder Clear()
          {
            this.result = new UninterpretedOption.Types.NamePart();
            return this;
          }

          public override UninterpretedOption.Types.NamePart.Builder Clone()
          {
            return new UninterpretedOption.Types.NamePart.Builder().MergeFrom(this.result);
          }

          public override MessageDescriptor DescriptorForType
          {
            get => UninterpretedOption.Types.NamePart.Descriptor;
          }

          public override UninterpretedOption.Types.NamePart DefaultInstanceForType
          {
            get => UninterpretedOption.Types.NamePart.DefaultInstance;
          }

          public override UninterpretedOption.Types.NamePart BuildPartial()
          {
            UninterpretedOption.Types.NamePart namePart = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
            this.result = (UninterpretedOption.Types.NamePart) null;
            return namePart;
          }

          public override UninterpretedOption.Types.NamePart.Builder MergeFrom(IMessage other)
          {
            if (other is UninterpretedOption.Types.NamePart)
              return this.MergeFrom((UninterpretedOption.Types.NamePart) other);
            base.MergeFrom(other);
            return this;
          }

          public override UninterpretedOption.Types.NamePart.Builder MergeFrom(
            UninterpretedOption.Types.NamePart other)
          {
            if (other == UninterpretedOption.Types.NamePart.DefaultInstance)
              return this;
            if (other.HasNamePart_)
              this.NamePart_ = other.NamePart_;
            if (other.HasIsExtension)
              this.IsExtension = other.IsExtension;
            this.MergeUnknownFields(other.UnknownFields);
            return this;
          }

          public override UninterpretedOption.Types.NamePart.Builder MergeFrom(
            CodedInputStream input)
          {
            return this.MergeFrom(input, ExtensionRegistry.Empty);
          }

          public override UninterpretedOption.Types.NamePart.Builder MergeFrom(
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
                  this.NamePart_ = input.ReadString();
                  continue;
                case 16:
                  this.IsExtension = input.ReadBool();
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

          public bool HasNamePart_ => this.result.HasNamePart_;

          public string NamePart_
          {
            get => this.result.NamePart_;
            set => this.SetNamePart_(value);
          }

          public UninterpretedOption.Types.NamePart.Builder SetNamePart_(string value)
          {
            Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
            this.result.hasNamePart_ = true;
            this.result.namePart_ = value;
            return this;
          }

          public UninterpretedOption.Types.NamePart.Builder ClearNamePart_()
          {
            this.result.hasNamePart_ = false;
            this.result.namePart_ = "";
            return this;
          }

          public bool HasIsExtension => this.result.HasIsExtension;

          public bool IsExtension
          {
            get => this.result.IsExtension;
            set => this.SetIsExtension(value);
          }

          public UninterpretedOption.Types.NamePart.Builder SetIsExtension(bool value)
          {
            this.result.hasIsExtension = true;
            this.result.isExtension_ = value;
            return this;
          }

          public UninterpretedOption.Types.NamePart.Builder ClearIsExtension()
          {
            this.result.hasIsExtension = false;
            this.result.isExtension_ = false;
            return this;
          }
        }
      }
    }

    public sealed class Builder : GeneratedBuilder<UninterpretedOption, UninterpretedOption.Builder>
    {
      private UninterpretedOption result = new UninterpretedOption();

      protected override UninterpretedOption.Builder ThisBuilder => this;

      protected override UninterpretedOption MessageBeingBuilt => this.result;

      public override UninterpretedOption.Builder Clear()
      {
        this.result = new UninterpretedOption();
        return this;
      }

      public override UninterpretedOption.Builder Clone()
      {
        return new UninterpretedOption.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => UninterpretedOption.Descriptor;

      public override UninterpretedOption DefaultInstanceForType
      {
        get => UninterpretedOption.DefaultInstance;
      }

      public override UninterpretedOption BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.name_.MakeReadOnly();
        UninterpretedOption result = this.result;
        this.result = (UninterpretedOption) null;
        return result;
      }

      public override UninterpretedOption.Builder MergeFrom(IMessage other)
      {
        if (other is UninterpretedOption)
          return this.MergeFrom((UninterpretedOption) other);
        base.MergeFrom(other);
        return this;
      }

      public override UninterpretedOption.Builder MergeFrom(UninterpretedOption other)
      {
        if (other == UninterpretedOption.DefaultInstance)
          return this;
        if (other.name_.Count != 0)
          this.AddRange<UninterpretedOption.Types.NamePart>((IEnumerable<UninterpretedOption.Types.NamePart>) other.name_, (IList<UninterpretedOption.Types.NamePart>) this.result.name_);
        if (other.HasIdentifierValue)
          this.IdentifierValue = other.IdentifierValue;
        if (other.HasPositiveIntValue)
          this.PositiveIntValue = other.PositiveIntValue;
        if (other.HasNegativeIntValue)
          this.NegativeIntValue = other.NegativeIntValue;
        if (other.HasDoubleValue)
          this.DoubleValue = other.DoubleValue;
        if (other.HasStringValue)
          this.StringValue = other.StringValue;
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override UninterpretedOption.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override UninterpretedOption.Builder MergeFrom(
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
            case 18:
              UninterpretedOption.Types.NamePart.Builder builder = UninterpretedOption.Types.NamePart.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder, extensionRegistry);
              this.AddName(builder.BuildPartial());
              continue;
            case 26:
              this.IdentifierValue = input.ReadString();
              continue;
            case 32:
              this.PositiveIntValue = input.ReadUInt64();
              continue;
            case 40:
              this.NegativeIntValue = input.ReadInt64();
              continue;
            case 49:
              this.DoubleValue = input.ReadDouble();
              continue;
            case 58:
              this.StringValue = input.ReadBytes();
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

      public IPopsicleList<UninterpretedOption.Types.NamePart> NameList
      {
        get => (IPopsicleList<UninterpretedOption.Types.NamePart>) this.result.name_;
      }

      public int NameCount => this.result.NameCount;

      public UninterpretedOption.Types.NamePart GetName(int index) => this.result.GetName(index);

      public UninterpretedOption.Builder SetName(
        int index,
        UninterpretedOption.Types.NamePart value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.name_[index] = value;
        return this;
      }

      public UninterpretedOption.Builder SetName(
        int index,
        UninterpretedOption.Types.NamePart.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.name_[index] = builderForValue.Build();
        return this;
      }

      public UninterpretedOption.Builder AddName(UninterpretedOption.Types.NamePart value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.name_.Add(value);
        return this;
      }

      public UninterpretedOption.Builder AddName(
        UninterpretedOption.Types.NamePart.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.name_.Add(builderForValue.Build());
        return this;
      }

      public UninterpretedOption.Builder AddRangeName(
        IEnumerable<UninterpretedOption.Types.NamePart> values)
      {
        this.AddRange<UninterpretedOption.Types.NamePart>(values, (IList<UninterpretedOption.Types.NamePart>) this.result.name_);
        return this;
      }

      public UninterpretedOption.Builder ClearName()
      {
        this.result.name_.Clear();
        return this;
      }

      public bool HasIdentifierValue => this.result.HasIdentifierValue;

      public string IdentifierValue
      {
        get => this.result.IdentifierValue;
        set => this.SetIdentifierValue(value);
      }

      public UninterpretedOption.Builder SetIdentifierValue(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasIdentifierValue = true;
        this.result.identifierValue_ = value;
        return this;
      }

      public UninterpretedOption.Builder ClearIdentifierValue()
      {
        this.result.hasIdentifierValue = false;
        this.result.identifierValue_ = "";
        return this;
      }

      public bool HasPositiveIntValue => this.result.HasPositiveIntValue;

      [CLSCompliant(false)]
      public ulong PositiveIntValue
      {
        get => this.result.PositiveIntValue;
        set => this.SetPositiveIntValue(value);
      }

      [CLSCompliant(false)]
      public UninterpretedOption.Builder SetPositiveIntValue(ulong value)
      {
        this.result.hasPositiveIntValue = true;
        this.result.positiveIntValue_ = value;
        return this;
      }

      public UninterpretedOption.Builder ClearPositiveIntValue()
      {
        this.result.hasPositiveIntValue = false;
        this.result.positiveIntValue_ = 0UL;
        return this;
      }

      public bool HasNegativeIntValue => this.result.HasNegativeIntValue;

      public long NegativeIntValue
      {
        get => this.result.NegativeIntValue;
        set => this.SetNegativeIntValue(value);
      }

      public UninterpretedOption.Builder SetNegativeIntValue(long value)
      {
        this.result.hasNegativeIntValue = true;
        this.result.negativeIntValue_ = value;
        return this;
      }

      public UninterpretedOption.Builder ClearNegativeIntValue()
      {
        this.result.hasNegativeIntValue = false;
        this.result.negativeIntValue_ = 0L;
        return this;
      }

      public bool HasDoubleValue => this.result.HasDoubleValue;

      public double DoubleValue
      {
        get => this.result.DoubleValue;
        set => this.SetDoubleValue(value);
      }

      public UninterpretedOption.Builder SetDoubleValue(double value)
      {
        this.result.hasDoubleValue = true;
        this.result.doubleValue_ = value;
        return this;
      }

      public UninterpretedOption.Builder ClearDoubleValue()
      {
        this.result.hasDoubleValue = false;
        this.result.doubleValue_ = 0.0;
        return this;
      }

      public bool HasStringValue => this.result.HasStringValue;

      public ByteString StringValue
      {
        get => this.result.StringValue;
        set => this.SetStringValue(value);
      }

      public UninterpretedOption.Builder SetStringValue(ByteString value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasStringValue = true;
        this.result.stringValue_ = value;
        return this;
      }

      public UninterpretedOption.Builder ClearStringValue()
      {
        this.result.hasStringValue = false;
        this.result.stringValue_ = ByteString.Empty;
        return this;
      }
    }
  }
}
