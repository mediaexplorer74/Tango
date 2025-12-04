// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.FieldAccessorTable`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  public sealed class FieldAccessorTable<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly IFieldAccessor<TMessage, TBuilder>[] accessors;
    private readonly MessageDescriptor descriptor;

    public MessageDescriptor Descriptor => this.descriptor;

    public FieldAccessorTable(MessageDescriptor descriptor, string[] propertyNames)
    {
      this.descriptor = descriptor;
      this.accessors = new IFieldAccessor<TMessage, TBuilder>[descriptor.Fields.Count];
      for (int index = 0; index < this.accessors.Length; ++index)
        this.accessors[index] = FieldAccessorTable<TMessage, TBuilder>.CreateAccessor(descriptor.Fields[index], propertyNames[index]);
    }

    private static IFieldAccessor<TMessage, TBuilder> CreateAccessor(
      FieldDescriptor field,
      string name)
    {
      if (field.IsRepeated)
      {
        switch (field.MappedType)
        {
          case MappedType.Message:
            return (IFieldAccessor<TMessage, TBuilder>) new RepeatedMessageAccessor<TMessage, TBuilder>(name);
          case MappedType.Enum:
            return (IFieldAccessor<TMessage, TBuilder>) new RepeatedEnumAccessor<TMessage, TBuilder>(field, name);
          default:
            return (IFieldAccessor<TMessage, TBuilder>) new RepeatedPrimitiveAccessor<TMessage, TBuilder>(name);
        }
      }
      else
      {
        switch (field.MappedType)
        {
          case MappedType.Message:
            return (IFieldAccessor<TMessage, TBuilder>) new SingleMessageAccessor<TMessage, TBuilder>(name);
          case MappedType.Enum:
            return (IFieldAccessor<TMessage, TBuilder>) new SingleEnumAccessor<TMessage, TBuilder>(field, name);
          default:
            return (IFieldAccessor<TMessage, TBuilder>) new SinglePrimitiveAccessor<TMessage, TBuilder>(name);
        }
      }
    }

    internal IFieldAccessor<TMessage, TBuilder> this[FieldDescriptor field]
    {
      get
      {
        if (field.ContainingType != this.descriptor)
          throw new ArgumentException("FieldDescriptor does not match message type.");
        if (field.IsExtension)
          throw new ArgumentException("This type does not have extensions.");
        return this.accessors[field.Index];
      }
    }
  }
}
