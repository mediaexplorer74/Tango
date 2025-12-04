// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedRepeatExtension`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class GeneratedRepeatExtension<TExtensionElement> : 
    GeneratedExtensionBase<IList<TExtensionElement>>
  {
    private GeneratedRepeatExtension(FieldDescriptor field)
      : base(field, typeof (TExtensionElement))
    {
    }

    public static GeneratedExtensionBase<IList<TExtensionElement>> CreateInstance(
      FieldDescriptor descriptor)
    {
      return descriptor.IsRepeated ? (GeneratedExtensionBase<IList<TExtensionElement>>) new GeneratedRepeatExtension<TExtensionElement>(descriptor) : throw new ArgumentException("Must call GeneratedRepeatExtension.CreateInstance() for repeated types.");
    }

    public override object FromReflectionType(object value)
    {
      if (this.Descriptor.MappedType != MappedType.Message && this.Descriptor.MappedType != MappedType.Enum)
        return value;
      List<TExtensionElement> extensionElementList = new List<TExtensionElement>();
      foreach (object obj in (IEnumerable) value)
        extensionElementList.Add((TExtensionElement) this.SingularFromReflectionType(obj));
      return (object) extensionElementList;
    }
  }
}
