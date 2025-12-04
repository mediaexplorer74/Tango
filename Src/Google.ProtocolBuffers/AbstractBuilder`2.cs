// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.AbstractBuilder`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class AbstractBuilder<TMessage, TBuilder> : 
    AbstractBuilderLite<TMessage, TBuilder>,
    IBuilder<TMessage, TBuilder>,
    IBuilder,
    IBuilderLite<TMessage, TBuilder>,
    IBuilderLite
    where TMessage : AbstractMessage<TMessage, TBuilder>
    where TBuilder : AbstractBuilder<TMessage, TBuilder>
  {
    public abstract UnknownFieldSet UnknownFields { get; set; }

    public abstract IDictionary<FieldDescriptor, object> AllFields { get; }

    public abstract object this[FieldDescriptor field] { get; set; }

    public abstract MessageDescriptor DescriptorForType { get; }

    public abstract int GetRepeatedFieldCount(FieldDescriptor field);

    public abstract object this[FieldDescriptor field, int index] { get; set; }

    public abstract bool HasField(FieldDescriptor field);

    public abstract IBuilder CreateBuilderForField(FieldDescriptor field);

    public abstract TBuilder ClearField(FieldDescriptor field);

    public abstract TBuilder AddRepeatedField(FieldDescriptor field, object value);

    public TBuilder SetUnknownFields(UnknownFieldSet fields)
    {
      this.UnknownFields = fields;
      return this.ThisBuilder;
    }

    public override TBuilder Clear()
    {
      foreach (FieldDescriptor key in (IEnumerable<FieldDescriptor>) this.AllFields.Keys)
        this.ClearField(key);
      return this.ThisBuilder;
    }

    public override sealed TBuilder MergeFrom(IMessageLite other)
    {
      return other is IMessage ? this.MergeFrom((IMessage) other) : throw new ArgumentException("MergeFrom(Message) can only merge messages of the same type.");
    }

    public abstract TBuilder MergeFrom(TMessage other);

    public virtual TBuilder MergeFrom(IMessage other)
    {
      if (other.DescriptorForType != this.DescriptorForType)
        throw new ArgumentException("MergeFrom(IMessage) can only merge messages of the same type.");
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) other.AllFields)
      {
        FieldDescriptor key = allField.Key;
        if (key.IsRepeated)
        {
          foreach (object obj in (IEnumerable) allField.Value)
            this.AddRepeatedField(key, obj);
        }
        else if (key.MappedType == MappedType.Message)
        {
          IMessageLite message = (IMessageLite) this[key];
          this[key] = message != message.WeakDefaultInstanceForType ? (object) message.WeakCreateBuilderForType().WeakMergeFrom(message).WeakMergeFrom((IMessageLite) allField.Value).WeakBuild() : allField.Value;
        }
        else
          this[key] = allField.Value;
      }
      this.MergeUnknownFields(other.UnknownFields);
      return this.ThisBuilder;
    }

    public override TBuilder MergeFrom(CodedInputStream input, ExtensionRegistry extensionRegistry)
    {
      UnknownFieldSet.Builder builder = UnknownFieldSet.CreateBuilder(this.UnknownFields);
      builder.MergeFrom(input, extensionRegistry, (IBuilder) this);
      this.UnknownFields = builder.Build();
      return this.ThisBuilder;
    }

    public virtual TBuilder MergeUnknownFields(UnknownFieldSet unknownFields)
    {
      this.UnknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields).MergeFrom(unknownFields).Build();
      return this.ThisBuilder;
    }

    public virtual IBuilder SetField(FieldDescriptor field, object value)
    {
      this[field] = value;
      return (IBuilder) this.ThisBuilder;
    }

    public virtual IBuilder SetRepeatedField(FieldDescriptor field, int index, object value)
    {
      this[field, index] = value;
      return (IBuilder) this.ThisBuilder;
    }

    IMessage IBuilder.WeakBuild() => (IMessage) this.Build();

    IBuilder IBuilder.WeakAddRepeatedField(FieldDescriptor field, object value)
    {
      return (IBuilder) this.AddRepeatedField(field, value);
    }

    IBuilder IBuilder.WeakClear() => (IBuilder) this.Clear();

    IBuilder IBuilder.WeakMergeFrom(IMessage message) => (IBuilder) this.MergeFrom(message);

    IBuilder IBuilder.WeakMergeFrom(CodedInputStream input) => (IBuilder) this.MergeFrom(input);

    IBuilder IBuilder.WeakMergeFrom(CodedInputStream input, ExtensionRegistry registry)
    {
      return (IBuilder) this.MergeFrom(input, registry);
    }

    IBuilder IBuilder.WeakMergeFrom(ByteString data) => (IBuilder) this.MergeFrom(data);

    IBuilder IBuilder.WeakMergeFrom(ByteString data, ExtensionRegistry registry)
    {
      return (IBuilder) this.MergeFrom(data, registry);
    }

    IMessage IBuilder.WeakBuildPartial() => (IMessage) this.BuildPartial();

    IBuilder IBuilder.WeakClone() => (IBuilder) this.Clone();

    IMessage IBuilder.WeakDefaultInstanceForType => (IMessage) this.DefaultInstanceForType;

    IBuilder IBuilder.WeakClearField(FieldDescriptor field) => (IBuilder) this.ClearField(field);
  }
}
