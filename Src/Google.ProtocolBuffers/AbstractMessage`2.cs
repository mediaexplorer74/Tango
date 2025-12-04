// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.AbstractMessage`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class AbstractMessage<TMessage, TBuilder> : 
    AbstractMessageLite<TMessage, TBuilder>,
    IMessage<TMessage, TBuilder>,
    IMessage<TMessage>,
    IMessage,
    IMessageLite<TMessage, TBuilder>,
    IMessageLite<TMessage>,
    IMessageLite
    where TMessage : AbstractMessage<TMessage, TBuilder>
    where TBuilder : AbstractBuilder<TMessage, TBuilder>
  {
    private int? memoizedSize = new int?();

    public abstract MessageDescriptor DescriptorForType { get; }

    public abstract IDictionary<FieldDescriptor, object> AllFields { get; }

    public abstract bool HasField(FieldDescriptor field);

    public abstract object this[FieldDescriptor field] { get; }

    public abstract int GetRepeatedFieldCount(FieldDescriptor field);

    public abstract object this[FieldDescriptor field, int index] { get; }

    public abstract UnknownFieldSet UnknownFields { get; }

    public override bool IsInitialized
    {
      get
      {
        foreach (FieldDescriptor @field in (IEnumerable<FieldDescriptor>) this.DescriptorForType.Fields)
        {
          if (@field.IsRequired && !this.HasField(@field))
            return false;
        }
        foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) this.AllFields)
        {
          FieldDescriptor key = allField.Key;
          if (key.MappedType == MappedType.Message)
          {
            if (key.IsRepeated)
            {
              foreach (IMessageLite messageLite in (IEnumerable) allField.Value)
              {
                if (!messageLite.IsInitialized)
                  return false;
              }
            }
            else if (!((IMessageLite) allField.Value).IsInitialized)
              return false;
          }
        }
        return true;
      }
    }

    public override sealed string ToString() => TextFormat.PrintToString((IMessage) this);

    public override sealed void PrintTo(TextWriter writer)
    {
      TextFormat.Print((IMessage) this, writer);
    }

    public override void WriteTo(CodedOutputStream output)
    {
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) this.AllFields)
      {
        FieldDescriptor key = allField.Key;
        if (key.IsRepeated)
        {
          IEnumerable enumerable = (IEnumerable) allField.Value;
          if (key.IsPacked)
          {
            output.WriteTag(key.FieldNumber, WireFormat.WireType.LengthDelimited);
            int num = 0;
            foreach (object obj in enumerable)
              num += CodedOutputStream.ComputeFieldSizeNoTag(key.FieldType, obj);
            output.WriteRawVarint32((uint) num);
            foreach (object obj in enumerable)
              output.WriteFieldNoTag(key.FieldType, obj);
          }
          else
          {
            foreach (object obj in enumerable)
              output.WriteField(key.FieldType, key.FieldNumber, obj);
          }
        }
        else
          output.WriteField(key.FieldType, key.FieldNumber, allField.Value);
      }
      UnknownFieldSet unknownFields = this.UnknownFields;
      if (this.DescriptorForType.Options.MessageSetWireFormat)
        unknownFields.WriteAsMessageSetTo(output);
      else
        unknownFields.WriteTo(output);
    }

    public override int SerializedSize
    {
      get
      {
        if (this.memoizedSize.HasValue)
          return this.memoizedSize.Value;
        int num1 = 0;
        foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) this.AllFields)
        {
          FieldDescriptor key = allField.Key;
          if (key.IsRepeated)
          {
            IEnumerable enumerable = (IEnumerable) allField.Value;
            if (key.IsPacked)
            {
              int num2 = 0;
              foreach (object obj in enumerable)
                num2 += CodedOutputStream.ComputeFieldSizeNoTag(key.FieldType, obj);
              num1 += num2;
              num1 += CodedOutputStream.ComputeTagSize(key.FieldNumber);
              num1 += CodedOutputStream.ComputeRawVarint32Size((uint) num2);
            }
            else
            {
              foreach (object obj in enumerable)
                num1 += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, obj);
            }
          }
          else
            num1 += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, allField.Value);
        }
        UnknownFieldSet unknownFields = this.UnknownFields;
        int serializedSize = !this.DescriptorForType.Options.MessageSetWireFormat ? num1 + unknownFields.SerializedSize : num1 + unknownFields.SerializedSizeAsMessageSet;
        this.memoizedSize = new int?(serializedSize);
        return serializedSize;
      }
    }

    public override bool Equals(object other)
    {
      if (other == this)
        return true;
      return other is IMessage message && message.DescriptorForType == this.DescriptorForType && Dictionaries.Equals<FieldDescriptor, object>(this.AllFields, message.AllFields) && this.UnknownFields.Equals((object) message.UnknownFields);
    }

    public override int GetHashCode()
    {
      return 29 * (53 * (19 * 41 + this.DescriptorForType.GetHashCode()) + Dictionaries.GetHashCode<FieldDescriptor, object>(this.AllFields)) + this.UnknownFields.GetHashCode();
    }

    IBuilder IMessage.WeakCreateBuilderForType() => (IBuilder) this.CreateBuilderForType();

    IBuilder IMessage.WeakToBuilder() => (IBuilder) this.ToBuilder();

    IMessage IMessage.WeakDefaultInstanceForType => (IMessage) this.DefaultInstanceForType;
  }
}
