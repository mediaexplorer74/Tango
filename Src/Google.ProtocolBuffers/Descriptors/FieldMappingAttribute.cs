// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.FieldMappingAttribute
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  [AttributeUsage(AttributeTargets.Field)]
  internal sealed class FieldMappingAttribute : Attribute
  {
    private static readonly IDictionary<FieldType, FieldMappingAttribute> FieldTypeToMappedTypeMap = FieldMappingAttribute.MapFieldTypes();

    internal FieldMappingAttribute(MappedType mappedType, WireFormat.WireType wireType)
    {
      this.MappedType = mappedType;
      this.WireType = wireType;
    }

    internal MappedType MappedType { get; private set; }

    internal WireFormat.WireType WireType { get; private set; }

    private static IDictionary<FieldType, FieldMappingAttribute> MapFieldTypes()
    {
      Dictionary<FieldType, FieldMappingAttribute> dictionary = new Dictionary<FieldType, FieldMappingAttribute>();
      foreach (FieldInfo field in typeof (FieldType).GetFields(BindingFlags.Static | BindingFlags.Public))
      {
        FieldType key = (FieldType) field.GetValue((object) null);
        FieldMappingAttribute customAttribute = (FieldMappingAttribute) field.GetCustomAttributes(typeof (FieldMappingAttribute), false).FirstOrDefault();
        dictionary[key] = customAttribute;
      }
      return Dictionaries.AsReadOnly<FieldType, FieldMappingAttribute>((IDictionary<FieldType, FieldMappingAttribute>) dictionary);
    }

    internal static MappedType MappedTypeFromFieldType(FieldType type)
    {
      return FieldMappingAttribute.FieldTypeToMappedTypeMap[type].MappedType;
    }

    internal static WireFormat.WireType WireTypeFromFieldType(FieldType type, bool packed)
    {
      return !packed ? FieldMappingAttribute.FieldTypeToMappedTypeMap[type].WireType : WireFormat.WireType.LengthDelimited;
    }
  }
}
