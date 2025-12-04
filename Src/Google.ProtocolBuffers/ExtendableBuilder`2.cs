// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtendableBuilder`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class ExtendableBuilder<TMessage, TBuilder> : GeneratedBuilder<TMessage, TBuilder>
    where TMessage : ExtendableMessage<TMessage, TBuilder>
    where TBuilder : GeneratedBuilder<TMessage, TBuilder>
  {
    public bool HasExtension<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      return this.MessageBeingBuilt.HasExtension<TExtension>(extension);
    }

    public int GetExtensionCount<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension)
    {
      return this.MessageBeingBuilt.GetExtensionCount<TExtension>(extension);
    }

    public TExtension GetExtension<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      return this.MessageBeingBuilt.GetExtension<TExtension>(extension);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension,
      int index)
    {
      return this.MessageBeingBuilt.GetExtension<TExtension>(extension, index);
    }

    public TBuilder SetExtension<TExtension>(
      GeneratedExtensionBase<TExtension> extension,
      TExtension value)
    {
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<TExtension>(extension);
      messageBeingBuilt.Extensions[(IFieldDescriptorLite) extension.Descriptor] = extension.ToReflectionType((object) value);
      return this.ThisBuilder;
    }

    public TBuilder SetExtension<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension,
      int index,
      TExtension value)
    {
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<IList<TExtension>>(extension);
      messageBeingBuilt.Extensions[(IFieldDescriptorLite) extension.Descriptor, index] = extension.SingularToReflectionType((object) value);
      return this.ThisBuilder;
    }

    public TBuilder AddExtension<TExtension>(
      GeneratedExtensionBase<IList<TExtension>> extension,
      TExtension value)
    {
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<IList<TExtension>>(extension);
      messageBeingBuilt.Extensions.AddRepeatedField((IFieldDescriptorLite) extension.Descriptor, extension.SingularToReflectionType((object) value));
      return this.ThisBuilder;
    }

    public TBuilder ClearExtension<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<TExtension>(extension);
      messageBeingBuilt.Extensions.ClearField((IFieldDescriptorLite) extension.Descriptor);
      return this.ThisBuilder;
    }

    [CLSCompliant(false)]
    protected override bool ParseUnknownField(
      CodedInputStream input,
      UnknownFieldSet.Builder unknownFields,
      ExtensionRegistry extensionRegistry,
      uint tag)
    {
      return unknownFields.MergeFieldFrom(input, extensionRegistry, (IBuilder) this, tag);
    }

    public override object this[FieldDescriptor field, int index]
    {
      set
      {
        if (field.IsExtension)
        {
          ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
          messageBeingBuilt.VerifyContainingType(field);
          messageBeingBuilt.Extensions[(IFieldDescriptorLite) field, index] = value;
        }
        else
          base[field, index] = value;
      }
    }

    public override object this[FieldDescriptor field]
    {
      set
      {
        if (field.IsExtension)
        {
          ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
          messageBeingBuilt.VerifyContainingType(field);
          messageBeingBuilt.Extensions[(IFieldDescriptorLite) field] = value;
        }
        else
          base[field] = value;
      }
    }

    public override TBuilder ClearField(FieldDescriptor field)
    {
      if (!field.IsExtension)
        return base.ClearField(field);
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyContainingType(field);
      messageBeingBuilt.Extensions.ClearField((IFieldDescriptorLite) field);
      return this.ThisBuilder;
    }

    public override TBuilder AddRepeatedField(FieldDescriptor field, object value)
    {
      if (!field.IsExtension)
        return base.AddRepeatedField(field, value);
      ExtendableMessage<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessage<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyContainingType(field);
      messageBeingBuilt.Extensions.AddRepeatedField((IFieldDescriptorLite) field, value);
      return this.ThisBuilder;
    }

    protected void MergeExtensionFields(ExtendableMessage<TMessage, TBuilder> other)
    {
      this.MessageBeingBuilt.Extensions.MergeFrom(other.Extensions);
    }
  }
}
