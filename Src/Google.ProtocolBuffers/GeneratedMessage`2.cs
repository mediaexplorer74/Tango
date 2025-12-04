// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedMessage`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class GeneratedMessage<TMessage, TBuilder> : AbstractMessage<TMessage, TBuilder>
    where TMessage : GeneratedMessage<TMessage, TBuilder>
    where TBuilder : GeneratedBuilder<TMessage, TBuilder>
  {
    private UnknownFieldSet unknownFields = UnknownFieldSet.DefaultInstance;

    protected abstract TMessage ThisMessage { get; }

    internal FieldAccessorTable<TMessage, TBuilder> FieldAccessorsFromBuilder
    {
      get => this.InternalFieldAccessors;
    }

    protected abstract FieldAccessorTable<TMessage, TBuilder> InternalFieldAccessors { get; }

    public override MessageDescriptor DescriptorForType => this.InternalFieldAccessors.Descriptor;

    internal IDictionary<FieldDescriptor, object> GetMutableFieldMap()
    {
      SortedList<FieldDescriptor, object> mutableFieldMap = new SortedList<FieldDescriptor, object>();
      foreach (FieldDescriptor field in (IEnumerable<FieldDescriptor>) this.DescriptorForType.Fields)
      {
        IFieldAccessor<TMessage, TBuilder> internalFieldAccessor = this.InternalFieldAccessors[field];
        if (field.IsRepeated)
        {
          if (internalFieldAccessor.GetRepeatedCount(this.ThisMessage) != 0)
            mutableFieldMap[field] = internalFieldAccessor.GetValue(this.ThisMessage);
        }
        else if (this.HasField(field))
          mutableFieldMap[field] = internalFieldAccessor.GetValue(this.ThisMessage);
      }
      return (IDictionary<FieldDescriptor, object>) mutableFieldMap;
    }

    public override bool IsInitialized
    {
      get
      {
        foreach (FieldDescriptor @field in (IEnumerable<FieldDescriptor>) this.DescriptorForType.Fields)
        {
          if (@field.IsRequired && !this.HasField(@field))
            return false;
          if (@field.MappedType == MappedType.Message)
          {
            if (@field.IsRepeated)
            {
              foreach (IMessageLite messageLite in (IEnumerable) this[@field])
              {
                if (!messageLite.IsInitialized)
                  return false;
              }
            }
            else if (this.HasField(@field) && !((IMessageLite) this[@field]).IsInitialized)
              return false;
          }
        }
        return true;
      }
    }

    public override IDictionary<FieldDescriptor, object> AllFields
    {
      get => Dictionaries.AsReadOnly<FieldDescriptor, object>(this.GetMutableFieldMap());
    }

    public override bool HasField(FieldDescriptor field)
    {
      return this.InternalFieldAccessors[field].Has(this.ThisMessage);
    }

    public override int GetRepeatedFieldCount(FieldDescriptor field)
    {
      return this.InternalFieldAccessors[field].GetRepeatedCount(this.ThisMessage);
    }

    public override object this[FieldDescriptor field, int index]
    {
      get => this.InternalFieldAccessors[field].GetRepeatedValue(this.ThisMessage, index);
    }

    public override object this[FieldDescriptor field]
    {
      get => this.InternalFieldAccessors[field].GetValue(this.ThisMessage);
    }

    public override UnknownFieldSet UnknownFields => this.unknownFields;

    internal void SetUnknownFields(UnknownFieldSet fieldSet) => this.unknownFields = fieldSet;
  }
}
