// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedExtensionBase`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class GeneratedExtensionBase<TExtension>
  {
    private readonly FieldDescriptor descriptor;
    private readonly IMessageLite messageDefaultInstance;

    protected GeneratedExtensionBase(FieldDescriptor descriptor, Type singularExtensionType)
    {
      this.descriptor = descriptor.IsExtension ? descriptor : throw new ArgumentException("GeneratedExtension given a regular (non-extension) field.");
      if (descriptor.MappedType != MappedType.Message)
        return;
      this.messageDefaultInstance = (IMessageLite) (singularExtensionType.GetProperty("DefaultInstance", BindingFlags.Static | BindingFlags.Public) ?? throw new ArgumentException("No public static DefaultInstance property for type " + typeof (TExtension).Name)).GetValue((object) null, (object[]) null);
    }

    public FieldDescriptor Descriptor => this.descriptor;

    public int Number => this.Descriptor.FieldNumber;

    public IMessageLite MessageDefaultInstance => this.messageDefaultInstance;

    public object SingularFromReflectionType(object value)
    {
      switch (this.Descriptor.MappedType)
      {
        case MappedType.Message:
          return value is TExtension ? value : (object) this.MessageDefaultInstance.WeakCreateBuilderForType().WeakMergeFrom((IMessageLite) value).WeakBuild();
        case MappedType.Enum:
          return (object) ((EnumValueDescriptor) value).Number;
        default:
          return value;
      }
    }

    public object ToReflectionType(object value)
    {
      if (!this.descriptor.IsRepeated)
        return this.SingularToReflectionType(value);
      if (this.descriptor.MappedType != MappedType.Enum)
        return value;
      IList<object> reflectionType = (IList<object>) new List<object>();
      foreach (object obj in (IEnumerable) value)
        reflectionType.Add(this.SingularToReflectionType(obj));
      return (object) reflectionType;
    }

    internal object SingularToReflectionType(object value)
    {
      return this.descriptor.MappedType != MappedType.Enum ? value : (object) this.descriptor.EnumType.FindValueByNumber((int) value);
    }

    public abstract object FromReflectionType(object value);
  }
}
