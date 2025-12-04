// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedRepeatExtensionLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public class GeneratedRepeatExtensionLite<TContainingType, TExtensionType>(
    string fullName,
    TContainingType containingTypeDefaultInstance,
    IMessageLite messageDefaultInstance,
    IEnumLiteMap enumTypeMap,
    int number,
    FieldType type,
    bool isPacked) : GeneratedExtensionLite<TContainingType, IList<TExtensionType>>(fullName, containingTypeDefaultInstance, (IList<TExtensionType>) new List<TExtensionType>(), messageDefaultInstance, enumTypeMap, number, type, isPacked)
    where TContainingType : IMessageLite
  {
    public override object ToReflectionType(object value)
    {
      IList<object> reflectionType = (IList<object>) new List<object>();
      foreach (object obj in (IEnumerable) value)
        reflectionType.Add(this.SingularToReflectionType(obj));
      return (object) reflectionType;
    }

    public override object FromReflectionType(object value)
    {
      List<TExtensionType> extensionTypeList = new List<TExtensionType>();
      foreach (object obj in (IEnumerable) value)
        extensionTypeList.Add((TExtensionType) this.SingularFromReflectionType(obj));
      return (object) extensionTypeList;
    }
  }
}
