// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtendableMessage`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class ExtendableMessage<TMessage, TBuilder> : GeneratedMessage<TMessage, TBuilder>
    where TMessage : GeneratedMessage<TMessage, TBuilder>
    where TBuilder : GeneratedBuilder<TMessage, TBuilder>
  {
    private readonly FieldSet extensions = FieldSet.CreateInstance();

    internal FieldSet Extensions => this.extensions;

    public bool HasExtension<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      return this.extensions.HasField((IFieldDescriptorLite) extension.Descriptor);
    }

    public int GetExtensionCount<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension)
    {
      return this.extensions.GetRepeatedFieldCount((IFieldDescriptorLite) extension.Descriptor);
    }

    public TExtension GetExtension<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      object extension1 = this.extensions[(IFieldDescriptorLite) extension.Descriptor];
      return extension1 == null ? (TExtension) extension.MessageDefaultInstance : (TExtension) extension.FromReflectionType(extension1);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension,
      int index)
    {
      return (TExtension) extension.SingularFromReflectionType(this.extensions[(IFieldDescriptorLite) extension.Descriptor, index]);
    }

    protected bool ExtensionsAreInitialized => this.extensions.IsInitialized;

    public override bool IsInitialized => base.IsInitialized && this.ExtensionsAreInitialized;

    public override IDictionary<FieldDescriptor, object> AllFields
    {
      get
      {
        IDictionary<FieldDescriptor, object> mutableFieldMap = this.GetMutableFieldMap();
        foreach (KeyValuePair<IFieldDescriptorLite, object> allField in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.extensions.AllFields)
          mutableFieldMap[(FieldDescriptor) allField.Key] = allField.Value;
        return Dictionaries.AsReadOnly<FieldDescriptor, object>(mutableFieldMap);
      }
    }

    public override bool HasField(FieldDescriptor field)
    {
      if (!field.IsExtension)
        return base.HasField(field);
      this.VerifyContainingType(field);
      return this.extensions.HasField((IFieldDescriptorLite) field);
    }

    public override object this[FieldDescriptor field]
    {
      get
      {
        if (!field.IsExtension)
          return base[field];
        this.VerifyContainingType(field);
        return this.extensions[(IFieldDescriptorLite) field] ?? (object) DynamicMessage.GetDefaultInstance(field.MessageType);
      }
    }

    public override int GetRepeatedFieldCount(FieldDescriptor field)
    {
      if (!field.IsExtension)
        return base.GetRepeatedFieldCount(field);
      this.VerifyContainingType(field);
      return this.extensions.GetRepeatedFieldCount((IFieldDescriptorLite) field);
    }

    public override object this[FieldDescriptor field, int index]
    {
      get
      {
        if (!field.IsExtension)
          return base[field, index];
        this.VerifyContainingType(field);
        return this.extensions[(IFieldDescriptorLite) field, index];
      }
    }

    internal void VerifyContainingType(FieldDescriptor field)
    {
      if (field.ContainingType != this.DescriptorForType)
        throw new ArgumentException("FieldDescriptor does not match message type.");
    }

    protected ExtendableMessage<TMessage, TBuilder>.ExtensionWriter CreateExtensionWriter(
      ExtendableMessage<TMessage, TBuilder> message)
    {
      return new ExtendableMessage<TMessage, TBuilder>.ExtensionWriter(message);
    }

    protected int ExtensionsSerializedSize => this.extensions.SerializedSize;

    internal void VerifyExtensionContainingType<TExtension>(
      GeneratedExtensionBase<TExtension> extension)
    {
      if (extension.Descriptor.ContainingType != this.DescriptorForType)
        throw new ArgumentException("Extension is for type \"" + extension.Descriptor.ContainingType.FullName + "\" which does not match message type \"" + this.DescriptorForType.FullName + "\".");
    }

    protected class ExtensionWriter
    {
      private readonly IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> iterator;
      private readonly FieldSet extensions;
      private KeyValuePair<IFieldDescriptorLite, object>? next = new KeyValuePair<IFieldDescriptorLite, object>?();

      internal ExtensionWriter(ExtendableMessage<TMessage, TBuilder> message)
      {
        this.extensions = message.extensions;
        this.iterator = message.extensions.GetEnumerator();
        if (!this.iterator.MoveNext())
          return;
        this.next = new KeyValuePair<IFieldDescriptorLite, object>?(this.iterator.Current);
      }

      public void WriteUntil(int end, CodedOutputStream output)
      {
        for (; this.next.HasValue && this.next.Value.Key.FieldNumber < end; this.next = !this.iterator.MoveNext() ? new KeyValuePair<IFieldDescriptorLite, object>?() : new KeyValuePair<IFieldDescriptorLite, object>?(this.iterator.Current))
          this.extensions.WriteField(this.next.Value.Key, this.next.Value.Value, output);
      }
    }
  }
}
