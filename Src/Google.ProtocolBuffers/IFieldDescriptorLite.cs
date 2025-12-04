// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IFieldDescriptorLite
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IFieldDescriptorLite : IComparable<IFieldDescriptorLite>
  {
    bool IsRepeated { get; }

    bool IsRequired { get; }

    bool IsPacked { get; }

    bool IsExtension { get; }

    bool MessageSetWireFormat { get; }

    int FieldNumber { get; }

    string FullName { get; }

    IEnumLiteMap EnumType { get; }

    FieldType FieldType { get; }

    MappedType MappedType { get; }

    object DefaultValue { get; }
  }
}
