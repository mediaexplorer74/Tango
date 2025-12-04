// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtendableBuilderLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class ExtendableBuilderLite<TMessage, TBuilder> : 
    GeneratedBuilderLite<TMessage, TBuilder>
    where TMessage : ExtendableMessageLite<TMessage, TBuilder>
    where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
  {
    public bool HasExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      return this.MessageBeingBuilt.HasExtension<TExtension>(extension);
    }

    public int GetExtensionCount<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension)
    {
      return this.MessageBeingBuilt.GetExtensionCount<TExtension>(extension);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      return this.MessageBeingBuilt.GetExtension<TExtension>(extension);
    }

    public TExtension GetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension,
      int index)
    {
      return this.MessageBeingBuilt.GetExtension<TExtension>(extension, index);
    }

    public TBuilder SetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension,
      TExtension value)
    {
      ExtendableMessageLite<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessageLite<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<TExtension>(extension);
      messageBeingBuilt.Extensions[extension.Descriptor] = extension.ToReflectionType((object) value);
      return this.ThisBuilder;
    }

    public TBuilder SetExtension<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension,
      int index,
      TExtension value)
    {
      ExtendableMessageLite<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessageLite<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<IList<TExtension>>(extension);
      messageBeingBuilt.Extensions[extension.Descriptor, index] = extension.SingularToReflectionType((object) value);
      return this.ThisBuilder;
    }

    public TBuilder AddExtension<TExtension>(
      GeneratedExtensionLite<TMessage, IList<TExtension>> extension,
      TExtension value)
    {
      ExtendableMessageLite<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessageLite<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<IList<TExtension>>(extension);
      messageBeingBuilt.Extensions.AddRepeatedField(extension.Descriptor, extension.SingularToReflectionType((object) value));
      return this.ThisBuilder;
    }

    public TBuilder ClearExtension<TExtension>(
      GeneratedExtensionLite<TMessage, TExtension> extension)
    {
      ExtendableMessageLite<TMessage, TBuilder> messageBeingBuilt = (ExtendableMessageLite<TMessage, TBuilder>) this.MessageBeingBuilt;
      messageBeingBuilt.VerifyExtensionContainingType<TExtension>(extension);
      messageBeingBuilt.Extensions.ClearField(extension.Descriptor);
      return this.ThisBuilder;
    }

    [CLSCompliant(false)]
    protected override bool ParseUnknownField(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry,
      uint tag)
    {
      FieldSet extensions = this.MessageBeingBuilt.Extensions;
      WireFormat.WireType tagWireType = WireFormat.GetTagWireType(tag);
      int tagFieldNumber = WireFormat.GetTagFieldNumber(tag);
      IGeneratedExtensionLite generatedExtensionLite = extensionRegistry[(IMessageLite) this.DefaultInstanceForType, tagFieldNumber];
      bool flag1 = false;
      bool flag2 = false;
      if (generatedExtensionLite == null)
        flag1 = true;
      else if (tagWireType == FieldMappingAttribute.WireTypeFromFieldType(generatedExtensionLite.Descriptor.FieldType, false))
        flag2 = false;
      else if (generatedExtensionLite.Descriptor.IsRepeated && tagWireType == FieldMappingAttribute.WireTypeFromFieldType(generatedExtensionLite.Descriptor.FieldType, true))
        flag2 = true;
      else
        flag1 = true;
      if (flag1)
        return input.SkipField(tag);
      if (flag2)
      {
        int byteLimit = (int) Math.Min((uint) int.MaxValue, input.ReadRawVarint32());
        int oldLimit = input.PushLimit(byteLimit);
        if (generatedExtensionLite.Descriptor.FieldType == FieldType.Enum)
        {
          while (!input.ReachedLimit)
          {
            int number = input.ReadEnum();
            object valueByNumber = (object) generatedExtensionLite.Descriptor.EnumType.FindValueByNumber(number);
            if (valueByNumber == null)
              return true;
            extensions.AddRepeatedField(generatedExtensionLite.Descriptor, valueByNumber);
          }
        }
        else
        {
          while (!input.ReachedLimit)
          {
            object obj = input.ReadPrimitiveField(generatedExtensionLite.Descriptor.FieldType);
            extensions.AddRepeatedField(generatedExtensionLite.Descriptor, obj);
          }
        }
        input.PopLimit(oldLimit);
      }
      else
      {
        object obj;
        switch (generatedExtensionLite.Descriptor.MappedType)
        {
          case MappedType.Message:
            IBuilderLite builder = (IBuilderLite) null;
            if (!generatedExtensionLite.Descriptor.IsRepeated && extensions[generatedExtensionLite.Descriptor] is IMessageLite messageLite)
              builder = messageLite.WeakToBuilder();
            if (builder == null)
              builder = generatedExtensionLite.MessageDefaultInstance.WeakCreateBuilderForType();
            if (generatedExtensionLite.Descriptor.FieldType == FieldType.Group)
              input.ReadGroup(generatedExtensionLite.Number, builder, extensionRegistry);
            else
              input.ReadMessage(builder, extensionRegistry);
            obj = (object) builder.WeakBuild();
            break;
          case MappedType.Enum:
            int number = input.ReadEnum();
            obj = (object) generatedExtensionLite.Descriptor.EnumType.FindValueByNumber(number);
            if (obj == null)
              return true;
            break;
          default:
            obj = input.ReadPrimitiveField(generatedExtensionLite.Descriptor.FieldType);
            break;
        }
        if (generatedExtensionLite.Descriptor.IsRepeated)
          extensions.AddRepeatedField(generatedExtensionLite.Descriptor, obj);
        else
          extensions[generatedExtensionLite.Descriptor] = obj;
      }
      return true;
    }

    public object this[IFieldDescriptorLite field, int index]
    {
      set
      {
        if (!field.IsExtension)
          throw new NotSupportedException("Not supported in the lite runtime.");
        this.MessageBeingBuilt.Extensions[field, index] = value;
      }
    }

    public object this[IFieldDescriptorLite field]
    {
      set
      {
        if (!field.IsExtension)
          throw new NotSupportedException("Not supported in the lite runtime.");
        this.MessageBeingBuilt.Extensions[field] = value;
      }
    }

    public TBuilder ClearField(IFieldDescriptorLite field)
    {
      if (!field.IsExtension)
        throw new NotSupportedException("Not supported in the lite runtime.");
      this.MessageBeingBuilt.Extensions.ClearField(field);
      return this.ThisBuilder;
    }

    public TBuilder AddRepeatedField(IFieldDescriptorLite field, object value)
    {
      if (!field.IsExtension)
        throw new NotSupportedException("Not supported in the lite runtime.");
      this.MessageBeingBuilt.Extensions.AddRepeatedField(field, value);
      return this.ThisBuilder;
    }

    protected void MergeExtensionFields(ExtendableMessageLite<TMessage, TBuilder> other)
    {
      this.MessageBeingBuilt.Extensions.MergeFrom(other.Extensions);
    }
  }
}
