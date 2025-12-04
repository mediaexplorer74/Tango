// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtensionDescriptorLite
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public class ExtensionDescriptorLite : IFieldDescriptorLite, IComparable<IFieldDescriptorLite>
  {
    private readonly string fullName;
    private readonly IEnumLiteMap enumTypeMap;
    private readonly int number;
    private readonly FieldType type;
    private readonly bool isRepeated;
    private readonly bool isPacked;
    private readonly MappedType mapType;
    private readonly object defaultValue;

    public ExtensionDescriptorLite(
      string fullName,
      IEnumLiteMap enumTypeMap,
      int number,
      FieldType type,
      object defaultValue,
      bool isRepeated,
      bool isPacked)
    {
      this.fullName = fullName;
      this.enumTypeMap = enumTypeMap;
      this.number = number;
      this.type = type;
      this.mapType = FieldMappingAttribute.MappedTypeFromFieldType(type);
      this.isRepeated = isRepeated;
      this.isPacked = isPacked;
      this.defaultValue = defaultValue;
    }

    public string FullName => this.fullName;

    public bool IsRepeated => this.isRepeated;

    public bool IsRequired => false;

    public bool IsPacked => this.isPacked;

    public bool IsExtension => true;

    public bool MessageSetWireFormat => false;

    public int FieldNumber => this.number;

    public IEnumLiteMap EnumType => this.enumTypeMap;

    public FieldType FieldType => this.type;

    public MappedType MappedType => this.mapType;

    public object DefaultValue => this.defaultValue;

    public int CompareTo(IFieldDescriptorLite other)
    {
      return this.FieldNumber.CompareTo(other.FieldNumber);
    }
  }
}
