// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.WireFormat
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public static class WireFormat
  {
    internal const int Fixed32Size = 4;
    internal const int Fixed64Size = 8;
    internal const int SFixed32Size = 4;
    internal const int SFixed64Size = 8;
    internal const int FloatSize = 4;
    internal const int DoubleSize = 8;
    internal const int BoolSize = 1;
    private const int TagTypeBits = 3;
    private const uint TagTypeMask = 7;

    [CLSCompliant(false)]
    public static WireFormat.WireType GetTagWireType(uint tag)
    {
      return (WireFormat.WireType) ((int) tag & 7);
    }

    [CLSCompliant(false)]
    public static bool IsEndGroupTag(uint tag) => ((int) tag & 7) == 4;

    [CLSCompliant(false)]
    public static int GetTagFieldNumber(uint tag) => (int) tag >> 3;

    [CLSCompliant(false)]
    public static uint MakeTag(int fieldNumber, WireFormat.WireType wireType)
    {
      return (uint) ((WireFormat.WireType) (fieldNumber << 3) | wireType);
    }

    [CLSCompliant(false)]
    public static uint MakeTag(FieldDescriptor field)
    {
      return WireFormat.MakeTag(field.FieldNumber, WireFormat.GetWireType(field));
    }

    internal static WireFormat.WireType GetWireType(FieldDescriptor descriptor)
    {
      return !descriptor.IsPacked ? WireFormat.GetWireType(descriptor.FieldType) : WireFormat.WireType.LengthDelimited;
    }

    [CLSCompliant(false)]
    public static WireFormat.WireType GetWireType(FieldType fieldType)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          return WireFormat.WireType.Fixed64;
        case FieldType.Float:
          return WireFormat.WireType.Fixed32;
        case FieldType.Int64:
        case FieldType.UInt64:
        case FieldType.Int32:
          return WireFormat.WireType.Varint;
        case FieldType.Fixed64:
          return WireFormat.WireType.Fixed64;
        case FieldType.Fixed32:
          return WireFormat.WireType.Fixed32;
        case FieldType.Bool:
          return WireFormat.WireType.Varint;
        case FieldType.String:
          return WireFormat.WireType.LengthDelimited;
        case FieldType.Group:
          return WireFormat.WireType.StartGroup;
        case FieldType.Message:
        case FieldType.Bytes:
          return WireFormat.WireType.LengthDelimited;
        case FieldType.UInt32:
          return WireFormat.WireType.Varint;
        case FieldType.SFixed32:
          return WireFormat.WireType.Fixed32;
        case FieldType.SFixed64:
          return WireFormat.WireType.Fixed64;
        case FieldType.SInt32:
        case FieldType.SInt64:
        case FieldType.Enum:
          return WireFormat.WireType.Varint;
        default:
          throw new ArgumentOutOfRangeException("No such field type");
      }
    }

    [CLSCompliant(false)]
    public enum WireType : uint
    {
      Varint,
      Fixed64,
      LengthDelimited,
      StartGroup,
      EndGroup,
      Fixed32,
    }

    internal static class MessageSetField
    {
      internal const int Item = 1;
      internal const int TypeID = 2;
      internal const int Message = 3;
    }

    internal static class MessageSetTag
    {
      internal static readonly uint ItemStart = WireFormat.MakeTag(1, WireFormat.WireType.StartGroup);
      internal static readonly uint ItemEnd = WireFormat.MakeTag(1, WireFormat.WireType.EndGroup);
      internal static readonly uint TypeID = WireFormat.MakeTag(2, WireFormat.WireType.Varint);
      internal static readonly uint Message = WireFormat.MakeTag(3, WireFormat.WireType.LengthDelimited);
    }
  }
}
