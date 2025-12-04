// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtendableMessageLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class ExtendableMessageLite<TMessage, TBuilder> : 
    GeneratedMessageLite<TMessage, TBuilder>
    where TMessage : GeneratedMessageLite<TMessage, TBuilder>
    where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
  {
    private readonly FieldSet extensions = FieldSet.CreateInstance();

    internal FieldSet Extensions => this.extensions;

    public override bool Equals(object obj)
    {
      ExtendableMessageLite<TMessage, TBuilder> objB = obj as ExtendableMessageLite<TMessage, TBuilder>;
      return !object.ReferenceEquals((object) null, (object) objB) && Dictionaries.Equals<IFieldDescriptorLite, object>(this.extensions.AllFields, objB.extensions.AllFields);
    }

    public override int GetHashCode()
    {
      return Dictionaries.GetHashCode<IFieldDescriptorLite, object>(this.extensions.AllFields);
    }

    public override void PrintTo(TextWriter writer)
    {
      foreach (KeyValuePair<IFieldDescriptorLite, object> allField in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.extensions.AllFields)
      {
        string name = string.Format("[{0}]", (object) allField.Key.FullName);
        if (allField.Key.IsRepeated)
        {
          foreach (object obj in (IEnumerable) allField.Value)
            GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, obj, writer);
        }
        else
          GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, allField.Value, writer);
      }
    }

    public bool HasExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      this.VerifyExtensionContainingType<TExtension>(extension);
      return this.extensions.HasField(extension.Descriptor);
    }

    public int GetExtensionCount<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension)
    {
      this.VerifyExtensionContainingType<IList<TExtension>>(extension);
      return this.extensions.GetRepeatedFieldCount(extension.Descriptor);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      this.VerifyExtensionContainingType<TExtension>(extension);
      object extension1 = this.extensions[extension.Descriptor];
      return extension1 == null ? extension.DefaultValue : (TExtension) extension.FromReflectionType(extension1);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension,
      int index)
    {
      this.VerifyExtensionContainingType<IList<TExtension>>(extension);
      return (TExtension) extension.SingularFromReflectionType(this.extensions[extension.Descriptor, index]);
    }

    protected bool ExtensionsAreInitialized => this.extensions.IsInitialized;

    public override bool IsInitialized => this.ExtensionsAreInitialized;

    protected ExtendableMessageLite<TMessage, TBuilder>.ExtensionWriter CreateExtensionWriter(
      ExtendableMessageLite<TMessage, TBuilder> message)
    {
      return new ExtendableMessageLite<TMessage, TBuilder>.ExtensionWriter(message);
    }

    protected int ExtensionsSerializedSize => this.extensions.SerializedSize;

    internal void VerifyExtensionContainingType<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      if (!object.ReferenceEquals((object) extension.ContainingTypeDefaultInstance, (object) this.DefaultInstanceForType))
        throw new ArgumentException(string.Format("Extension is for type \"{0}\" which does not match message type \"{1}\".", (object) extension.ContainingTypeDefaultInstance, (object) this.DefaultInstanceForType));
    }

    protected class ExtensionWriter
    {
      private readonly IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> iterator;
      private readonly FieldSet extensions;
      private KeyValuePair<IFieldDescriptorLite, object>? next = new KeyValuePair<IFieldDescriptorLite, object>?();

      internal ExtensionWriter(ExtendableMessageLite<TMessage, TBuilder> message)
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
