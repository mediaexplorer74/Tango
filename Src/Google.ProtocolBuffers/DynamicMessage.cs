// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DynamicMessage
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class DynamicMessage : AbstractMessage<DynamicMessage, DynamicMessage.Builder>
  {
    private readonly MessageDescriptor type;
    private readonly FieldSet fields;
    private readonly UnknownFieldSet unknownFields;
    private int memoizedSize = -1;

    private DynamicMessage(MessageDescriptor type, FieldSet fields, UnknownFieldSet unknownFields)
    {
      this.type = type;
      this.fields = fields;
      this.unknownFields = unknownFields;
    }

    public static DynamicMessage GetDefaultInstance(MessageDescriptor type)
    {
      return new DynamicMessage(type, FieldSet.DefaultInstance, UnknownFieldSet.DefaultInstance);
    }

    public static DynamicMessage ParseFrom(MessageDescriptor type, CodedInputStream input)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(input).BuildParsed();
    }

    public static DynamicMessage ParseFrom(
      MessageDescriptor type,
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static DynamicMessage ParseFrom(MessageDescriptor type, Stream input)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(input).BuildParsed();
    }

    public static DynamicMessage ParseFrom(
      MessageDescriptor type,
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static DynamicMessage ParseFrom(MessageDescriptor type, ByteString data)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(data).BuildParsed();
    }

    public static DynamicMessage ParseFrom(
      MessageDescriptor type,
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static DynamicMessage ParseFrom(MessageDescriptor type, byte[] data)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(data).BuildParsed();
    }

    public static DynamicMessage ParseFrom(
      MessageDescriptor type,
      byte[] data,
      ExtensionRegistry extensionRegistry)
    {
      return DynamicMessage.CreateBuilder(type).MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static DynamicMessage.Builder CreateBuilder(MessageDescriptor type)
    {
      return new DynamicMessage.Builder(type);
    }

    public static DynamicMessage.Builder CreateBuilder(IMessage prototype)
    {
      return new DynamicMessage.Builder(prototype.DescriptorForType).MergeFrom(prototype);
    }

    public override MessageDescriptor DescriptorForType => this.type;

    public override DynamicMessage DefaultInstanceForType
    {
      get => DynamicMessage.GetDefaultInstance(this.type);
    }

    public override IDictionary<FieldDescriptor, object> AllFields
    {
      get => this.fields.AllFieldDescriptors;
    }

    public override bool HasField(FieldDescriptor field)
    {
      this.VerifyContainingType(field);
      return this.fields.HasField((IFieldDescriptorLite) field);
    }

    public override object this[FieldDescriptor field]
    {
      get
      {
        this.VerifyContainingType(field);
        return this.fields[(IFieldDescriptorLite) field] ?? (object) DynamicMessage.GetDefaultInstance(field.MessageType);
      }
    }

    public override int GetRepeatedFieldCount(FieldDescriptor field)
    {
      this.VerifyContainingType(field);
      return this.fields.GetRepeatedFieldCount((IFieldDescriptorLite) field);
    }

    public override object this[FieldDescriptor field, int index]
    {
      get
      {
        this.VerifyContainingType(field);
        return this.fields[(IFieldDescriptorLite) field, index];
      }
    }

    public override UnknownFieldSet UnknownFields => this.unknownFields;

    public bool Initialized
    {
      get => this.fields.IsInitializedWithRespectTo((IEnumerable) this.type.Fields);
    }

    public override void WriteTo(CodedOutputStream output)
    {
      this.fields.WriteTo(output);
      if (this.type.Options.MessageSetWireFormat)
        this.unknownFields.WriteAsMessageSetTo(output);
      else
        this.unknownFields.WriteTo(output);
    }

    public override int SerializedSize
    {
      get
      {
        int memoizedSize = this.memoizedSize;
        if (memoizedSize != -1)
          return memoizedSize;
        int serializedSize1 = this.fields.SerializedSize;
        int serializedSize2 = !this.type.Options.MessageSetWireFormat ? serializedSize1 + this.unknownFields.SerializedSize : serializedSize1 + this.unknownFields.SerializedSizeAsMessageSet;
        this.memoizedSize = serializedSize2;
        return serializedSize2;
      }
    }

    public override DynamicMessage.Builder CreateBuilderForType()
    {
      return new DynamicMessage.Builder(this.type);
    }

    public override DynamicMessage.Builder ToBuilder()
    {
      return this.CreateBuilderForType().MergeFrom(this);
    }

    private void VerifyContainingType(FieldDescriptor field)
    {
      if (field.ContainingType != this.type)
        throw new ArgumentException("FieldDescriptor does not match message type.");
    }

    public sealed class Builder : AbstractBuilder<DynamicMessage, DynamicMessage.Builder>
    {
      private readonly MessageDescriptor type;
      private FieldSet fields;
      private UnknownFieldSet unknownFields;

      internal Builder(MessageDescriptor type)
      {
        this.type = type;
        this.fields = FieldSet.CreateInstance();
        this.unknownFields = UnknownFieldSet.DefaultInstance;
      }

      protected override DynamicMessage.Builder ThisBuilder => this;

      public override DynamicMessage.Builder Clear()
      {
        this.fields.Clear();
        return this;
      }

      public override DynamicMessage.Builder MergeFrom(IMessage other)
      {
        if (other.DescriptorForType != this.type)
          throw new ArgumentException("MergeFrom(IMessage) can only merge messages of the same type.");
        this.fields.MergeFrom(other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override DynamicMessage.Builder MergeFrom(DynamicMessage other)
      {
        return this.MergeFrom((IMessage) other);
      }

      public override DynamicMessage Build()
      {
        if (this.fields != null && !this.IsInitialized)
          throw new UninitializedMessageException((IMessage) new DynamicMessage(this.type, this.fields, this.unknownFields));
        return this.BuildPartial();
      }

      internal DynamicMessage BuildParsed()
      {
        if (!this.IsInitialized)
          throw new UninitializedMessageException((IMessage) new DynamicMessage(this.type, this.fields, this.unknownFields)).AsInvalidProtocolBufferException();
        return this.BuildPartial();
      }

      public override DynamicMessage BuildPartial()
      {
        if (this.fields == null)
          throw new InvalidOperationException("Build() has already been called on this Builder.");
        this.fields.MakeImmutable();
        DynamicMessage dynamicMessage = new DynamicMessage(this.type, this.fields, this.unknownFields);
        this.fields = (FieldSet) null;
        this.unknownFields = (UnknownFieldSet) null;
        return dynamicMessage;
      }

      public override DynamicMessage.Builder Clone()
      {
        DynamicMessage.Builder builder = new DynamicMessage.Builder(this.type);
        builder.fields.MergeFrom(this.fields);
        return builder;
      }

      public override bool IsInitialized
      {
        get => this.fields.IsInitializedWithRespectTo((IEnumerable) this.type.Fields);
      }

      public override DynamicMessage.Builder MergeFrom(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry)
      {
        UnknownFieldSet.Builder builder = UnknownFieldSet.CreateBuilder(this.unknownFields);
        builder.MergeFrom(input, extensionRegistry, (IBuilder) this);
        this.unknownFields = builder.Build();
        return this;
      }

      public override MessageDescriptor DescriptorForType => this.type;

      public override DynamicMessage DefaultInstanceForType
      {
        get => DynamicMessage.GetDefaultInstance(this.type);
      }

      public override IDictionary<FieldDescriptor, object> AllFields
      {
        get => this.fields.AllFieldDescriptors;
      }

      public override IBuilder CreateBuilderForField(FieldDescriptor field)
      {
        this.VerifyContainingType(field);
        return field.MappedType == MappedType.Message ? (IBuilder) new DynamicMessage.Builder(field.MessageType) : throw new ArgumentException("CreateBuilderForField is only valid for fields with message type.");
      }

      public override bool HasField(FieldDescriptor field)
      {
        this.VerifyContainingType(field);
        return this.fields.HasField((IFieldDescriptorLite) field);
      }

      public override object this[FieldDescriptor field, int index]
      {
        get
        {
          this.VerifyContainingType(field);
          return this.fields[(IFieldDescriptorLite) field, index];
        }
        set
        {
          this.VerifyContainingType(field);
          this.fields[(IFieldDescriptorLite) field, index] = value;
        }
      }

      public override object this[FieldDescriptor field]
      {
        get
        {
          this.VerifyContainingType(field);
          return this.fields[(IFieldDescriptorLite) field] ?? (object) DynamicMessage.GetDefaultInstance(field.MessageType);
        }
        set
        {
          this.VerifyContainingType(field);
          this.fields[(IFieldDescriptorLite) field] = value;
        }
      }

      public override DynamicMessage.Builder ClearField(FieldDescriptor field)
      {
        this.VerifyContainingType(field);
        this.fields.ClearField((IFieldDescriptorLite) field);
        return this;
      }

      public override int GetRepeatedFieldCount(FieldDescriptor field)
      {
        this.VerifyContainingType(field);
        return this.fields.GetRepeatedFieldCount((IFieldDescriptorLite) field);
      }

      public override DynamicMessage.Builder AddRepeatedField(FieldDescriptor field, object value)
      {
        this.VerifyContainingType(field);
        this.fields.AddRepeatedField((IFieldDescriptorLite) field, value);
        return this;
      }

      public override UnknownFieldSet UnknownFields
      {
        get => this.unknownFields;
        set => this.unknownFields = value;
      }

      private void VerifyContainingType(FieldDescriptor field)
      {
        if (field.ContainingType != this.type)
          throw new ArgumentException("FieldDescriptor does not match message type.");
      }
    }
  }
}
