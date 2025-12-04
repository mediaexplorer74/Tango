// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.DescriptorProto
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
  public sealed class DescriptorProto : 
    GeneratedMessage<DescriptorProto, DescriptorProto.Builder>,
    IDescriptorProto<MessageOptions>
  {
    public const int NameFieldNumber = 1;
    public const int FieldFieldNumber = 2;
    public const int ExtensionFieldNumber = 6;
    public const int NestedTypeFieldNumber = 3;
    public const int EnumTypeFieldNumber = 4;
    public const int ExtensionRangeFieldNumber = 5;
    public const int OptionsFieldNumber = 7;
    private static readonly DescriptorProto defaultInstance = new DescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private PopsicleList<FieldDescriptorProto> field_ = new PopsicleList<FieldDescriptorProto>();
    private PopsicleList<FieldDescriptorProto> extension_ = new PopsicleList<FieldDescriptorProto>();
    private PopsicleList<DescriptorProto> nestedType_ = new PopsicleList<DescriptorProto>();
    private PopsicleList<EnumDescriptorProto> enumType_ = new PopsicleList<EnumDescriptorProto>();
    private PopsicleList<DescriptorProto.Types.ExtensionRange> extensionRange_ = new PopsicleList<DescriptorProto.Types.ExtensionRange>();
    private bool hasOptions;
    private MessageOptions options_ = MessageOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static DescriptorProto DefaultInstance => DescriptorProto.defaultInstance;

    public override DescriptorProto DefaultInstanceForType => DescriptorProto.defaultInstance;

    protected override DescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_DescriptorProto__Descriptor;
    }

    protected override FieldAccessorTable<DescriptorProto, DescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_DescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public IList<FieldDescriptorProto> FieldList => (IList<FieldDescriptorProto>) this.field_;

    public int FieldCount => this.field_.Count;

    public FieldDescriptorProto GetField(int index) => this.field_[index];

    public IList<FieldDescriptorProto> ExtensionList
    {
      get => (IList<FieldDescriptorProto>) this.extension_;
    }

    public int ExtensionCount => this.extension_.Count;

    public FieldDescriptorProto GetExtension(int index) => this.extension_[index];

    public IList<DescriptorProto> NestedTypeList => (IList<DescriptorProto>) this.nestedType_;

    public int NestedTypeCount => this.nestedType_.Count;

    public DescriptorProto GetNestedType(int index) => this.nestedType_[index];

    public IList<EnumDescriptorProto> EnumTypeList => (IList<EnumDescriptorProto>) this.enumType_;

    public int EnumTypeCount => this.enumType_.Count;

    public EnumDescriptorProto GetEnumType(int index) => this.enumType_[index];

    public IList<DescriptorProto.Types.ExtensionRange> ExtensionRangeList
    {
      get => (IList<DescriptorProto.Types.ExtensionRange>) this.extensionRange_;
    }

    public int ExtensionRangeCount => this.extensionRange_.Count;

    public DescriptorProto.Types.ExtensionRange GetExtensionRange(int index)
    {
      return this.extensionRange_[index];
    }

    public bool HasOptions => this.hasOptions;

    public MessageOptions Options => this.options_;

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<FieldDescriptorProto, FieldDescriptorProto.Builder> @field in (IEnumerable<FieldDescriptorProto>) this.FieldList)
        {
          if (!@field.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<FieldDescriptorProto, FieldDescriptorProto.Builder> extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
        {
          if (!extension.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<DescriptorProto, DescriptorProto.Builder> nestedType in (IEnumerable<DescriptorProto>) this.NestedTypeList)
        {
          if (!nestedType.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<EnumDescriptorProto, EnumDescriptorProto.Builder> enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
        {
          if (!enumType.IsInitialized)
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
      foreach (FieldDescriptorProto field in (IEnumerable<FieldDescriptorProto>) this.FieldList)
        output.WriteMessage(2, (IMessageLite) field);
      foreach (DescriptorProto nestedType in (IEnumerable<DescriptorProto>) this.NestedTypeList)
        output.WriteMessage(3, (IMessageLite) nestedType);
      foreach (EnumDescriptorProto enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
        output.WriteMessage(4, (IMessageLite) enumType);
      foreach (DescriptorProto.Types.ExtensionRange extensionRange in (IEnumerable<DescriptorProto.Types.ExtensionRange>) this.ExtensionRangeList)
        output.WriteMessage(5, (IMessageLite) extensionRange);
      foreach (FieldDescriptorProto extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
        output.WriteMessage(6, (IMessageLite) extension);
      if (this.HasOptions)
        output.WriteMessage(7, (IMessageLite) this.Options);
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
        foreach (FieldDescriptorProto @field in (IEnumerable<FieldDescriptorProto>) this.FieldList)
          num += CodedOutputStream.ComputeMessageSize(2, (IMessageLite) @field);
        foreach (FieldDescriptorProto extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
          num += CodedOutputStream.ComputeMessageSize(6, (IMessageLite) extension);
        foreach (DescriptorProto nestedType in (IEnumerable<DescriptorProto>) this.NestedTypeList)
          num += CodedOutputStream.ComputeMessageSize(3, (IMessageLite) nestedType);
        foreach (EnumDescriptorProto enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
          num += CodedOutputStream.ComputeMessageSize(4, (IMessageLite) enumType);
        foreach (DescriptorProto.Types.ExtensionRange extensionRange in (IEnumerable<DescriptorProto.Types.ExtensionRange>) this.ExtensionRangeList)
          num += CodedOutputStream.ComputeMessageSize(5, (IMessageLite) extensionRange);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(7, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static DescriptorProto ParseFrom(ByteString data)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static DescriptorProto ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static DescriptorProto ParseFrom(byte[] data)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static DescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static DescriptorProto ParseFrom(Stream input)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static DescriptorProto ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static DescriptorProto ParseDelimitedFrom(Stream input)
    {
      return DescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static DescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return DescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static DescriptorProto ParseFrom(CodedInputStream input)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static DescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return DescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static DescriptorProto.Builder CreateBuilder() => new DescriptorProto.Builder();

    public override DescriptorProto.Builder ToBuilder() => DescriptorProto.CreateBuilder(this);

    public override DescriptorProto.Builder CreateBuilderForType() => new DescriptorProto.Builder();

    public static DescriptorProto.Builder CreateBuilder(DescriptorProto prototype)
    {
      return new DescriptorProto.Builder().MergeFrom(prototype);
    }

    static DescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public static class Types
    {
      public sealed class ExtensionRange : 
        GeneratedMessage<DescriptorProto.Types.ExtensionRange, DescriptorProto.Types.ExtensionRange.Builder>
      {
        public const int StartFieldNumber = 1;
        public const int EndFieldNumber = 2;
        private static readonly DescriptorProto.Types.ExtensionRange defaultInstance = new DescriptorProto.Types.ExtensionRange.Builder().BuildPartial();
        private bool hasStart;
        private int start_;
        private bool hasEnd;
        private int end_;
        private int memoizedSerializedSize = -1;

        public static DescriptorProto.Types.ExtensionRange DefaultInstance
        {
          get => DescriptorProto.Types.ExtensionRange.defaultInstance;
        }

        public override DescriptorProto.Types.ExtensionRange DefaultInstanceForType
        {
          get => DescriptorProto.Types.ExtensionRange.defaultInstance;
        }

        protected override DescriptorProto.Types.ExtensionRange ThisMessage => this;

        public static MessageDescriptor Descriptor
        {
          get
          {
            return DescriptorProtoFile.internal__static_google_protobuf_DescriptorProto_ExtensionRange__Descriptor;
          }
        }

        protected override FieldAccessorTable<DescriptorProto.Types.ExtensionRange, DescriptorProto.Types.ExtensionRange.Builder> InternalFieldAccessors
        {
          get
          {
            return DescriptorProtoFile.internal__static_google_protobuf_DescriptorProto_ExtensionRange__FieldAccessorTable;
          }
        }

        public bool HasStart => this.hasStart;

        public int Start => this.start_;

        public bool HasEnd => this.hasEnd;

        public int End => this.end_;

        public override bool IsInitialized => true;

        public override void WriteTo(CodedOutputStream output)
        {
          int serializedSize = this.SerializedSize;
          if (this.HasStart)
            output.WriteInt32(1, this.Start);
          if (this.HasEnd)
            output.WriteInt32(2, this.End);
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
            if (this.HasStart)
              num += CodedOutputStream.ComputeInt32Size(1, this.Start);
            if (this.HasEnd)
              num += CodedOutputStream.ComputeInt32Size(2, this.End);
            int serializedSize = num + this.UnknownFields.SerializedSize;
            this.memoizedSerializedSize = serializedSize;
            return serializedSize;
          }
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(ByteString data)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(
          ByteString data,
          ExtensionRegistry extensionRegistry)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(byte[] data)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(data).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(
          byte[] data,
          ExtensionRegistry extensionRegistry)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(Stream input)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(
          Stream input,
          ExtensionRegistry extensionRegistry)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseDelimitedFrom(Stream input)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseDelimitedFrom(
          Stream input,
          ExtensionRegistry extensionRegistry)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(CodedInputStream input)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(input).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange ParseFrom(
          CodedInputStream input,
          ExtensionRegistry extensionRegistry)
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
        }

        public static DescriptorProto.Types.ExtensionRange.Builder CreateBuilder()
        {
          return new DescriptorProto.Types.ExtensionRange.Builder();
        }

        public override DescriptorProto.Types.ExtensionRange.Builder ToBuilder()
        {
          return DescriptorProto.Types.ExtensionRange.CreateBuilder(this);
        }

        public override DescriptorProto.Types.ExtensionRange.Builder CreateBuilderForType()
        {
          return new DescriptorProto.Types.ExtensionRange.Builder();
        }

        public static DescriptorProto.Types.ExtensionRange.Builder CreateBuilder(
          DescriptorProto.Types.ExtensionRange prototype)
        {
          return new DescriptorProto.Types.ExtensionRange.Builder().MergeFrom(prototype);
        }

        static ExtensionRange()
        {
          object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
        }

        public sealed class Builder : 
          GeneratedBuilder<DescriptorProto.Types.ExtensionRange, DescriptorProto.Types.ExtensionRange.Builder>
        {
          private DescriptorProto.Types.ExtensionRange result = new DescriptorProto.Types.ExtensionRange();

          protected override DescriptorProto.Types.ExtensionRange.Builder ThisBuilder => this;

          protected override DescriptorProto.Types.ExtensionRange MessageBeingBuilt => this.result;

          public override DescriptorProto.Types.ExtensionRange.Builder Clear()
          {
            this.result = new DescriptorProto.Types.ExtensionRange();
            return this;
          }

          public override DescriptorProto.Types.ExtensionRange.Builder Clone()
          {
            return new DescriptorProto.Types.ExtensionRange.Builder().MergeFrom(this.result);
          }

          public override MessageDescriptor DescriptorForType
          {
            get => DescriptorProto.Types.ExtensionRange.Descriptor;
          }

          public override DescriptorProto.Types.ExtensionRange DefaultInstanceForType
          {
            get => DescriptorProto.Types.ExtensionRange.DefaultInstance;
          }

          public override DescriptorProto.Types.ExtensionRange BuildPartial()
          {
            DescriptorProto.Types.ExtensionRange extensionRange = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
            this.result = (DescriptorProto.Types.ExtensionRange) null;
            return extensionRange;
          }

          public override DescriptorProto.Types.ExtensionRange.Builder MergeFrom(IMessage other)
          {
            if (other is DescriptorProto.Types.ExtensionRange)
              return this.MergeFrom((DescriptorProto.Types.ExtensionRange) other);
            base.MergeFrom(other);
            return this;
          }

          public override DescriptorProto.Types.ExtensionRange.Builder MergeFrom(
            DescriptorProto.Types.ExtensionRange other)
          {
            if (other == DescriptorProto.Types.ExtensionRange.DefaultInstance)
              return this;
            if (other.HasStart)
              this.Start = other.Start;
            if (other.HasEnd)
              this.End = other.End;
            this.MergeUnknownFields(other.UnknownFields);
            return this;
          }

          public override DescriptorProto.Types.ExtensionRange.Builder MergeFrom(
            CodedInputStream input)
          {
            return this.MergeFrom(input, ExtensionRegistry.Empty);
          }

          public override DescriptorProto.Types.ExtensionRange.Builder MergeFrom(
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
                  this.Start = input.ReadInt32();
                  continue;
                case 16:
                  this.End = input.ReadInt32();
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

          public bool HasStart => this.result.HasStart;

          public int Start
          {
            get => this.result.Start;
            set => this.SetStart(value);
          }

          public DescriptorProto.Types.ExtensionRange.Builder SetStart(int value)
          {
            this.result.hasStart = true;
            this.result.start_ = value;
            return this;
          }

          public DescriptorProto.Types.ExtensionRange.Builder ClearStart()
          {
            this.result.hasStart = false;
            this.result.start_ = 0;
            return this;
          }

          public bool HasEnd => this.result.HasEnd;

          public int End
          {
            get => this.result.End;
            set => this.SetEnd(value);
          }

          public DescriptorProto.Types.ExtensionRange.Builder SetEnd(int value)
          {
            this.result.hasEnd = true;
            this.result.end_ = value;
            return this;
          }

          public DescriptorProto.Types.ExtensionRange.Builder ClearEnd()
          {
            this.result.hasEnd = false;
            this.result.end_ = 0;
            return this;
          }
        }
      }
    }

    public sealed class Builder : GeneratedBuilder<DescriptorProto, DescriptorProto.Builder>
    {
      private DescriptorProto result = new DescriptorProto();

      protected override DescriptorProto.Builder ThisBuilder => this;

      protected override DescriptorProto MessageBeingBuilt => this.result;

      public override DescriptorProto.Builder Clear()
      {
        this.result = new DescriptorProto();
        return this;
      }

      public override DescriptorProto.Builder Clone()
      {
        return new DescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => DescriptorProto.Descriptor;

      public override DescriptorProto DefaultInstanceForType => DescriptorProto.DefaultInstance;

      public override DescriptorProto BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.field_.MakeReadOnly();
        this.result.extension_.MakeReadOnly();
        this.result.nestedType_.MakeReadOnly();
        this.result.enumType_.MakeReadOnly();
        this.result.extensionRange_.MakeReadOnly();
        DescriptorProto result = this.result;
        this.result = (DescriptorProto) null;
        return result;
      }

      public override DescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is DescriptorProto)
          return this.MergeFrom((DescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override DescriptorProto.Builder MergeFrom(DescriptorProto other)
      {
        if (other == DescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.field_.Count != 0)
          this.AddRange<FieldDescriptorProto>((IEnumerable<FieldDescriptorProto>) other.field_, (IList<FieldDescriptorProto>) this.result.field_);
        if (other.extension_.Count != 0)
          this.AddRange<FieldDescriptorProto>((IEnumerable<FieldDescriptorProto>) other.extension_, (IList<FieldDescriptorProto>) this.result.extension_);
        if (other.nestedType_.Count != 0)
          this.AddRange<DescriptorProto>((IEnumerable<DescriptorProto>) other.nestedType_, (IList<DescriptorProto>) this.result.nestedType_);
        if (other.enumType_.Count != 0)
          this.AddRange<EnumDescriptorProto>((IEnumerable<EnumDescriptorProto>) other.enumType_, (IList<EnumDescriptorProto>) this.result.enumType_);
        if (other.extensionRange_.Count != 0)
          this.AddRange<DescriptorProto.Types.ExtensionRange>((IEnumerable<DescriptorProto.Types.ExtensionRange>) other.extensionRange_, (IList<DescriptorProto.Types.ExtensionRange>) this.result.extensionRange_);
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override DescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override DescriptorProto.Builder MergeFrom(
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
              FieldDescriptorProto.Builder builder1 = FieldDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder1, extensionRegistry);
              this.AddField(builder1.BuildPartial());
              continue;
            case 26:
              DescriptorProto.Builder builder2 = DescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder2, extensionRegistry);
              this.AddNestedType(builder2.BuildPartial());
              continue;
            case 34:
              EnumDescriptorProto.Builder builder3 = EnumDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder3, extensionRegistry);
              this.AddEnumType(builder3.BuildPartial());
              continue;
            case 42:
              DescriptorProto.Types.ExtensionRange.Builder builder4 = DescriptorProto.Types.ExtensionRange.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder4, extensionRegistry);
              this.AddExtensionRange(builder4.BuildPartial());
              continue;
            case 50:
              FieldDescriptorProto.Builder builder5 = FieldDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder5, extensionRegistry);
              this.AddExtension(builder5.BuildPartial());
              continue;
            case 58:
              MessageOptions.Builder builder6 = MessageOptions.CreateBuilder();
              if (this.HasOptions)
                builder6.MergeFrom(this.Options);
              input.ReadMessage((IBuilderLite) builder6, extensionRegistry);
              this.Options = builder6.BuildPartial();
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

      public DescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public DescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public IPopsicleList<FieldDescriptorProto> FieldList
      {
        get => (IPopsicleList<FieldDescriptorProto>) this.result.field_;
      }

      public int FieldCount => this.result.FieldCount;

      public FieldDescriptorProto GetField(int index) => this.result.GetField(index);

      public DescriptorProto.Builder SetField(int index, FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.field_[index] = value;
        return this;
      }

      public DescriptorProto.Builder SetField(
        int index,
        FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.field_[index] = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder AddField(FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.field_.Add(value);
        return this;
      }

      public DescriptorProto.Builder AddField(FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.field_.Add(builderForValue.Build());
        return this;
      }

      public DescriptorProto.Builder AddRangeField(IEnumerable<FieldDescriptorProto> values)
      {
        this.AddRange<FieldDescriptorProto>(values, (IList<FieldDescriptorProto>) this.result.field_);
        return this;
      }

      public DescriptorProto.Builder ClearField()
      {
        this.result.field_.Clear();
        return this;
      }

      public IPopsicleList<FieldDescriptorProto> ExtensionList
      {
        get => (IPopsicleList<FieldDescriptorProto>) this.result.extension_;
      }

      public int ExtensionCount => this.result.ExtensionCount;

      public FieldDescriptorProto GetExtension(int index) => this.result.GetExtension(index);

      public DescriptorProto.Builder SetExtension(int index, FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extension_[index] = value;
        return this;
      }

      public DescriptorProto.Builder SetExtension(
        int index,
        FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extension_[index] = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder AddExtension(FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extension_.Add(value);
        return this;
      }

      public DescriptorProto.Builder AddExtension(FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extension_.Add(builderForValue.Build());
        return this;
      }

      public DescriptorProto.Builder AddRangeExtension(IEnumerable<FieldDescriptorProto> values)
      {
        this.AddRange<FieldDescriptorProto>(values, (IList<FieldDescriptorProto>) this.result.extension_);
        return this;
      }

      public DescriptorProto.Builder ClearExtension()
      {
        this.result.extension_.Clear();
        return this;
      }

      public IPopsicleList<DescriptorProto> NestedTypeList
      {
        get => (IPopsicleList<DescriptorProto>) this.result.nestedType_;
      }

      public int NestedTypeCount => this.result.NestedTypeCount;

      public DescriptorProto GetNestedType(int index) => this.result.GetNestedType(index);

      public DescriptorProto.Builder SetNestedType(int index, DescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.nestedType_[index] = value;
        return this;
      }

      public DescriptorProto.Builder SetNestedType(
        int index,
        DescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.nestedType_[index] = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder AddNestedType(DescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.nestedType_.Add(value);
        return this;
      }

      public DescriptorProto.Builder AddNestedType(DescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.nestedType_.Add(builderForValue.Build());
        return this;
      }

      public DescriptorProto.Builder AddRangeNestedType(IEnumerable<DescriptorProto> values)
      {
        this.AddRange<DescriptorProto>(values, (IList<DescriptorProto>) this.result.nestedType_);
        return this;
      }

      public DescriptorProto.Builder ClearNestedType()
      {
        this.result.nestedType_.Clear();
        return this;
      }

      public IPopsicleList<EnumDescriptorProto> EnumTypeList
      {
        get => (IPopsicleList<EnumDescriptorProto>) this.result.enumType_;
      }

      public int EnumTypeCount => this.result.EnumTypeCount;

      public EnumDescriptorProto GetEnumType(int index) => this.result.GetEnumType(index);

      public DescriptorProto.Builder SetEnumType(int index, EnumDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.enumType_[index] = value;
        return this;
      }

      public DescriptorProto.Builder SetEnumType(
        int index,
        EnumDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.enumType_[index] = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder AddEnumType(EnumDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.enumType_.Add(value);
        return this;
      }

      public DescriptorProto.Builder AddEnumType(EnumDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.enumType_.Add(builderForValue.Build());
        return this;
      }

      public DescriptorProto.Builder AddRangeEnumType(IEnumerable<EnumDescriptorProto> values)
      {
        this.AddRange<EnumDescriptorProto>(values, (IList<EnumDescriptorProto>) this.result.enumType_);
        return this;
      }

      public DescriptorProto.Builder ClearEnumType()
      {
        this.result.enumType_.Clear();
        return this;
      }

      public IPopsicleList<DescriptorProto.Types.ExtensionRange> ExtensionRangeList
      {
        get => (IPopsicleList<DescriptorProto.Types.ExtensionRange>) this.result.extensionRange_;
      }

      public int ExtensionRangeCount => this.result.ExtensionRangeCount;

      public DescriptorProto.Types.ExtensionRange GetExtensionRange(int index)
      {
        return this.result.GetExtensionRange(index);
      }

      public DescriptorProto.Builder SetExtensionRange(
        int index,
        DescriptorProto.Types.ExtensionRange value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extensionRange_[index] = value;
        return this;
      }

      public DescriptorProto.Builder SetExtensionRange(
        int index,
        DescriptorProto.Types.ExtensionRange.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extensionRange_[index] = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder AddExtensionRange(DescriptorProto.Types.ExtensionRange value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extensionRange_.Add(value);
        return this;
      }

      public DescriptorProto.Builder AddExtensionRange(
        DescriptorProto.Types.ExtensionRange.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extensionRange_.Add(builderForValue.Build());
        return this;
      }

      public DescriptorProto.Builder AddRangeExtensionRange(
        IEnumerable<DescriptorProto.Types.ExtensionRange> values)
      {
        this.AddRange<DescriptorProto.Types.ExtensionRange>(values, (IList<DescriptorProto.Types.ExtensionRange>) this.result.extensionRange_);
        return this;
      }

      public DescriptorProto.Builder ClearExtensionRange()
      {
        this.result.extensionRange_.Clear();
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public MessageOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public DescriptorProto.Builder SetOptions(MessageOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public DescriptorProto.Builder SetOptions(MessageOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public DescriptorProto.Builder MergeOptions(MessageOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == MessageOptions.DefaultInstance ? value : MessageOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public DescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = MessageOptions.DefaultInstance;
        return this;
      }
    }
  }
}
