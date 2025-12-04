// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedBuilder`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class GeneratedBuilder<TMessage, TBuilder> : AbstractBuilder<TMessage, TBuilder>
    where TMessage : GeneratedMessage<TMessage, TBuilder>
    where TBuilder : GeneratedBuilder<TMessage, TBuilder>
  {
    protected abstract TMessage MessageBeingBuilt { get; }

    protected internal FieldAccessorTable<TMessage, TBuilder> InternalFieldAccessors
    {
      get => this.MessageBeingBuilt.FieldAccessorsFromBuilder;
    }

    public override bool IsInitialized => this.MessageBeingBuilt.IsInitialized;

    public override IDictionary<FieldDescriptor, object> AllFields
    {
      get => this.MessageBeingBuilt.AllFields;
    }

    public override object this[FieldDescriptor field]
    {
      get
      {
        return !field.IsRepeated ? this.MessageBeingBuilt[field] : this.InternalFieldAccessors[field].GetRepeatedWrapper(this.ThisBuilder);
      }
      set => this.InternalFieldAccessors[field].SetValue(this.ThisBuilder, value);
    }

    protected void AddRange<T>(IEnumerable<T> source, IList<T> destination)
    {
      ThrowHelper.ThrowIfNull((object) source);
      if ((object) default (T) == null)
        ThrowHelper.ThrowIfAnyNull<T>(source);
      if (destination is List<T> objList)
      {
        objList.AddRange(source);
      }
      else
      {
        foreach (T obj in source)
          destination.Add(obj);
      }
    }

    [CLSCompliant(false)]
    protected virtual bool ParseUnknownField(
      CodedInputStream input,
      UnknownFieldSet.Builder unknownFields,
      ExtensionRegistry extensionRegistry,
      uint tag)
    {
      return unknownFields.MergeFieldFrom(tag, input);
    }

    public override MessageDescriptor DescriptorForType => this.MessageBeingBuilt.DescriptorForType;

    public override int GetRepeatedFieldCount(FieldDescriptor field)
    {
      return this.MessageBeingBuilt.GetRepeatedFieldCount(field);
    }

    public override object this[FieldDescriptor field, int index]
    {
      get => this.MessageBeingBuilt[field, index];
      set => this.InternalFieldAccessors[field].SetRepeated(this.ThisBuilder, index, value);
    }

    public override bool HasField(FieldDescriptor field) => this.MessageBeingBuilt.HasField(field);

    public override IBuilder CreateBuilderForField(FieldDescriptor field)
    {
      return this.InternalFieldAccessors[field].CreateBuilder();
    }

    public override TBuilder ClearField(FieldDescriptor field)
    {
      this.InternalFieldAccessors[field].Clear(this.ThisBuilder);
      return this.ThisBuilder;
    }

    public override TBuilder MergeFrom(TMessage other)
    {
      if (other.DescriptorForType != this.InternalFieldAccessors.Descriptor)
        throw new ArgumentException("Message type mismatch");
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) other.AllFields)
      {
        FieldDescriptor key = allField.Key;
        if (key.IsRepeated)
        {
          foreach (object obj in (IEnumerable) allField.Value)
            this.AddRepeatedField(key, obj);
        }
        else if (key.MappedType == MappedType.Message && this.HasField(key))
        {
          IMessageLite message = (IMessageLite) this[key];
          this[key] = (object) message.WeakCreateBuilderForType().WeakMergeFrom(message).WeakMergeFrom((IMessageLite) allField.Value).WeakBuildPartial();
        }
        else
          this[key] = allField.Value;
      }
      this.MergeUnknownFields(other.UnknownFields);
      return this.ThisBuilder;
    }

    public override TBuilder MergeUnknownFields(UnknownFieldSet unknownFields)
    {
      if (unknownFields != UnknownFieldSet.DefaultInstance)
      {
        TMessage messageBeingBuilt = this.MessageBeingBuilt;
        messageBeingBuilt.SetUnknownFields(UnknownFieldSet.CreateBuilder(messageBeingBuilt.UnknownFields).MergeFrom(unknownFields).Build());
      }
      return this.ThisBuilder;
    }

    public override TBuilder AddRepeatedField(FieldDescriptor field, object value)
    {
      this.InternalFieldAccessors[field].AddRepeated(this.ThisBuilder, value);
      return this.ThisBuilder;
    }

    public TMessage BuildParsed()
    {
      if (!this.IsInitialized)
        throw new UninitializedMessageException((IMessage) this.MessageBeingBuilt).AsInvalidProtocolBufferException();
      return this.BuildPartial();
    }

    public override TMessage Build()
    {
      if ((object) this.MessageBeingBuilt != null && !this.IsInitialized)
        throw new UninitializedMessageException((IMessage) this.MessageBeingBuilt);
      return this.BuildPartial();
    }

    public override UnknownFieldSet UnknownFields
    {
      get => this.MessageBeingBuilt.UnknownFields;
      set => this.MessageBeingBuilt.SetUnknownFields(value);
    }
  }
}
