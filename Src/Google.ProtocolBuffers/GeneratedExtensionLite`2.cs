// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedExtensionLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public class GeneratedExtensionLite<TContainingType, TExtensionType> : IGeneratedExtensionLite where TContainingType : IMessageLite
  {
    private readonly TContainingType containingTypeDefaultInstance;
    private readonly TExtensionType defaultValue;
    private readonly IMessageLite messageDefaultInstance;
    private readonly ExtensionDescriptorLite descriptor;
    private static readonly IList<object> Empty = (IList<object>) new object[0];

    protected GeneratedExtensionLite(
      TContainingType containingTypeDefaultInstance,
      TExtensionType defaultValue,
      IMessageLite messageDefaultInstance,
      ExtensionDescriptorLite descriptor)
    {
      this.containingTypeDefaultInstance = containingTypeDefaultInstance;
      this.messageDefaultInstance = messageDefaultInstance;
      this.defaultValue = defaultValue;
      this.descriptor = descriptor;
    }

    public GeneratedExtensionLite(
      string fullName,
      TContainingType containingTypeDefaultInstance,
      TExtensionType defaultValue,
      IMessageLite messageDefaultInstance,
      IEnumLiteMap enumTypeMap,
      int number,
      FieldType type)
      : this(containingTypeDefaultInstance, defaultValue, messageDefaultInstance, new ExtensionDescriptorLite(fullName, enumTypeMap, number, type, (object) defaultValue, false, false))
    {
    }

    protected GeneratedExtensionLite(
      string fullName,
      TContainingType containingTypeDefaultInstance,
      TExtensionType defaultValue,
      IMessageLite messageDefaultInstance,
      IEnumLiteMap enumTypeMap,
      int number,
      FieldType type,
      bool isPacked)
      : this(containingTypeDefaultInstance, defaultValue, messageDefaultInstance, new ExtensionDescriptorLite(fullName, enumTypeMap, number, type, (object) GeneratedExtensionLite<TContainingType, TExtensionType>.Empty, true, isPacked))
    {
    }

    public IFieldDescriptorLite Descriptor => (IFieldDescriptorLite) this.descriptor;

    public TExtensionType DefaultValue => this.defaultValue;

    object IGeneratedExtensionLite.ContainingType => (object) this.ContainingTypeDefaultInstance;

    public TContainingType ContainingTypeDefaultInstance => this.containingTypeDefaultInstance;

    public int Number => this.descriptor.FieldNumber;

    public IMessageLite MessageDefaultInstance => this.messageDefaultInstance;

    public virtual object ToReflectionType(object value) => this.SingularToReflectionType(value);

    public object SingularToReflectionType(object value)
    {
      return this.descriptor.MappedType != MappedType.Enum ? value : (object) this.descriptor.EnumType.FindValueByNumber((int) value);
    }

    public virtual object FromReflectionType(object value)
    {
      return this.SingularFromReflectionType(value);
    }

    public object SingularFromReflectionType(object value)
    {
      switch (this.Descriptor.MappedType)
      {
        case MappedType.Message:
          return value is TExtensionType ? value : (object) this.MessageDefaultInstance.WeakCreateBuilderForType().WeakMergeFrom((IMessageLite) value).WeakBuild();
        case MappedType.Enum:
          return (object) ((IEnumLite) value).Number;
        default:
          return value;
      }
    }
  }
}
