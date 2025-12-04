// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.CodedOutputStream
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class CodedOutputStream
  {
    private const int LittleEndian64Size = 8;
    private const int LittleEndian32Size = 4;
    public static readonly int DefaultBufferSize = 4096;
    private readonly byte[] buffer;
    private readonly int limit;
    private int position;
    private readonly Stream output;

    private CodedOutputStream(byte[] buffer, int offset, int length)
    {
      this.output = (Stream) null;
      this.buffer = buffer;
      this.position = offset;
      this.limit = offset + length;
    }

    private CodedOutputStream(Stream output, byte[] buffer)
    {
      this.output = output;
      this.buffer = buffer;
      this.position = 0;
      this.limit = buffer.Length;
    }

    public static CodedOutputStream CreateInstance(Stream output)
    {
      return CodedOutputStream.CreateInstance(output, CodedOutputStream.DefaultBufferSize);
    }

    public static CodedOutputStream CreateInstance(Stream output, int bufferSize)
    {
      return new CodedOutputStream(output, new byte[bufferSize]);
    }

    public static CodedOutputStream CreateInstance(byte[] flatArray)
    {
      return CodedOutputStream.CreateInstance(flatArray, 0, flatArray.Length);
    }

    public static CodedOutputStream CreateInstance(byte[] flatArray, int offset, int length)
    {
      return new CodedOutputStream(flatArray, offset, length);
    }

    public void WriteDouble(int fieldNumber, double value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
      this.WriteDoubleNoTag(value);
    }

    public void WriteFloat(int fieldNumber, float value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
      this.WriteFloatNoTag(value);
    }

    [CLSCompliant(false)]
    public void WriteUInt64(int fieldNumber, ulong value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint64(value);
    }

    public void WriteInt64(int fieldNumber, long value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint64((ulong) value);
    }

    public void WriteInt32(int fieldNumber, int value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      if (value >= 0)
        this.WriteRawVarint32((uint) value);
      else
        this.WriteRawVarint64((ulong) value);
    }

    [CLSCompliant(false)]
    public void WriteFixed64(int fieldNumber, ulong value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
      this.WriteRawLittleEndian64(value);
    }

    [CLSCompliant(false)]
    public void WriteFixed32(int fieldNumber, uint value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
      this.WriteRawLittleEndian32(value);
    }

    public void WriteBool(int fieldNumber, bool value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawByte(value ? (byte) 1 : (byte) 0);
    }

    public void WriteString(int fieldNumber, string value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
      int byteCount = Encoding.UTF8.GetByteCount(value);
      this.WriteRawVarint32((uint) byteCount);
      if (this.limit - this.position >= byteCount)
      {
        Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.position);
        this.position += byteCount;
      }
      else
        this.WriteRawBytes(Encoding.UTF8.GetBytes(value));
    }

    public void WriteGroup(int fieldNumber, IMessageLite value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.StartGroup);
      value.WriteTo(this);
      this.WriteTag(fieldNumber, WireFormat.WireType.EndGroup);
    }

    [Obsolete]
    public void WriteUnknownGroup(int fieldNumber, IMessageLite value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.StartGroup);
      value.WriteTo(this);
      this.WriteTag(fieldNumber, WireFormat.WireType.EndGroup);
    }

    public void WriteMessage(int fieldNumber, IMessageLite value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
      this.WriteRawVarint32((uint) value.SerializedSize);
      value.WriteTo(this);
    }

    public void WriteBytes(int fieldNumber, ByteString value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
      byte[] byteArray = value.ToByteArray();
      this.WriteRawVarint32((uint) byteArray.Length);
      this.WriteRawBytes(byteArray);
    }

    [CLSCompliant(false)]
    public void WriteUInt32(int fieldNumber, uint value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint32(value);
    }

    public void WriteEnum(int fieldNumber, int value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint32((uint) value);
    }

    public void WriteSFixed32(int fieldNumber, int value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
      this.WriteRawLittleEndian32((uint) value);
    }

    public void WriteSFixed64(int fieldNumber, long value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
      this.WriteRawLittleEndian64((ulong) value);
    }

    public void WriteSInt32(int fieldNumber, int value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint32(CodedOutputStream.EncodeZigZag32(value));
    }

    public void WriteSInt64(int fieldNumber, long value)
    {
      this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
      this.WriteRawVarint64(CodedOutputStream.EncodeZigZag64(value));
    }

    public void WriteMessageSetExtension(int fieldNumber, IMessageLite value)
    {
      this.WriteTag(1, WireFormat.WireType.StartGroup);
      this.WriteUInt32(2, (uint) fieldNumber);
      this.WriteMessage(3, value);
      this.WriteTag(1, WireFormat.WireType.EndGroup);
    }

    public void WriteRawMessageSetExtension(int fieldNumber, ByteString value)
    {
      this.WriteTag(1, WireFormat.WireType.StartGroup);
      this.WriteUInt32(2, (uint) fieldNumber);
      this.WriteBytes(3, value);
      this.WriteTag(1, WireFormat.WireType.EndGroup);
    }

    public void WriteField(FieldType fieldType, int fieldNumber, object value)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          this.WriteDouble(fieldNumber, (double) value);
          break;
        case FieldType.Float:
          this.WriteFloat(fieldNumber, (float) value);
          break;
        case FieldType.Int64:
          this.WriteInt64(fieldNumber, (long) value);
          break;
        case FieldType.UInt64:
          this.WriteUInt64(fieldNumber, (ulong) value);
          break;
        case FieldType.Int32:
          this.WriteInt32(fieldNumber, (int) value);
          break;
        case FieldType.Fixed64:
          this.WriteFixed64(fieldNumber, (ulong) value);
          break;
        case FieldType.Fixed32:
          this.WriteFixed32(fieldNumber, (uint) value);
          break;
        case FieldType.Bool:
          this.WriteBool(fieldNumber, (bool) value);
          break;
        case FieldType.String:
          this.WriteString(fieldNumber, (string) value);
          break;
        case FieldType.Group:
          this.WriteGroup(fieldNumber, (IMessageLite) value);
          break;
        case FieldType.Message:
          this.WriteMessage(fieldNumber, (IMessageLite) value);
          break;
        case FieldType.Bytes:
          this.WriteBytes(fieldNumber, (ByteString) value);
          break;
        case FieldType.UInt32:
          this.WriteUInt32(fieldNumber, (uint) value);
          break;
        case FieldType.SFixed32:
          this.WriteSFixed32(fieldNumber, (int) value);
          break;
        case FieldType.SFixed64:
          this.WriteSFixed64(fieldNumber, (long) value);
          break;
        case FieldType.SInt32:
          this.WriteSInt32(fieldNumber, (int) value);
          break;
        case FieldType.SInt64:
          this.WriteSInt64(fieldNumber, (long) value);
          break;
        case FieldType.Enum:
          this.WriteEnum(fieldNumber, ((IEnumLite) value).Number);
          break;
      }
    }

    public void WriteFieldNoTag(FieldType fieldType, object value)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          this.WriteDoubleNoTag((double) value);
          break;
        case FieldType.Float:
          this.WriteFloatNoTag((float) value);
          break;
        case FieldType.Int64:
          this.WriteInt64NoTag((long) value);
          break;
        case FieldType.UInt64:
          this.WriteUInt64NoTag((ulong) value);
          break;
        case FieldType.Int32:
          this.WriteInt32NoTag((int) value);
          break;
        case FieldType.Fixed64:
          this.WriteFixed64NoTag((ulong) value);
          break;
        case FieldType.Fixed32:
          this.WriteFixed32NoTag((uint) value);
          break;
        case FieldType.Bool:
          this.WriteBoolNoTag((bool) value);
          break;
        case FieldType.String:
          this.WriteStringNoTag((string) value);
          break;
        case FieldType.Group:
          this.WriteGroupNoTag((IMessageLite) value);
          break;
        case FieldType.Message:
          this.WriteMessageNoTag((IMessageLite) value);
          break;
        case FieldType.Bytes:
          this.WriteBytesNoTag((ByteString) value);
          break;
        case FieldType.UInt32:
          this.WriteUInt32NoTag((uint) value);
          break;
        case FieldType.SFixed32:
          this.WriteSFixed32NoTag((int) value);
          break;
        case FieldType.SFixed64:
          this.WriteSFixed64NoTag((long) value);
          break;
        case FieldType.SInt32:
          this.WriteSInt32NoTag((int) value);
          break;
        case FieldType.SInt64:
          this.WriteSInt64NoTag((long) value);
          break;
        case FieldType.Enum:
          this.WriteEnumNoTag(((IEnumLite) value).Number);
          break;
      }
    }

    public void WriteDoubleNoTag(double value)
    {
      this.WriteRawBytes(BitConverter.GetBytes(value), 0, 8);
    }

    public void WriteFloatNoTag(float value)
    {
      this.WriteRawLittleEndian32(BitConverter.ToUInt32(BitConverter.GetBytes(value), 0));
    }

    [CLSCompliant(false)]
    public void WriteUInt64NoTag(ulong value) => this.WriteRawVarint64(value);

    public void WriteInt64NoTag(long value) => this.WriteRawVarint64((ulong) value);

    public void WriteInt32NoTag(int value)
    {
      if (value >= 0)
        this.WriteRawVarint32((uint) value);
      else
        this.WriteRawVarint64((ulong) value);
    }

    [CLSCompliant(false)]
    public void WriteFixed64NoTag(ulong value) => this.WriteRawLittleEndian64(value);

    [CLSCompliant(false)]
    public void WriteFixed32NoTag(uint value) => this.WriteRawLittleEndian32(value);

    public void WriteBoolNoTag(bool value) => this.WriteRawByte(value ? (byte) 1 : (byte) 0);

    public void WriteStringNoTag(string value)
    {
      int byteCount = Encoding.UTF8.GetByteCount(value);
      this.WriteRawVarint32((uint) byteCount);
      if (this.limit - this.position >= byteCount)
      {
        Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.position);
        this.position += byteCount;
      }
      else
        this.WriteRawBytes(Encoding.UTF8.GetBytes(value));
    }

    public void WriteGroupNoTag(IMessageLite value) => value.WriteTo(this);

    public void WriteMessageNoTag(IMessageLite value)
    {
      this.WriteRawVarint32((uint) value.SerializedSize);
      value.WriteTo(this);
    }

    public void WriteBytesNoTag(ByteString value)
    {
      byte[] byteArray = value.ToByteArray();
      this.WriteRawVarint32((uint) byteArray.Length);
      this.WriteRawBytes(byteArray);
    }

    [CLSCompliant(false)]
    public void WriteUInt32NoTag(uint value) => this.WriteRawVarint32(value);

    public void WriteEnumNoTag(int value) => this.WriteRawVarint32((uint) value);

    public void WriteSFixed32NoTag(int value) => this.WriteRawLittleEndian32((uint) value);

    public void WriteSFixed64NoTag(long value) => this.WriteRawLittleEndian64((ulong) value);

    public void WriteSInt32NoTag(int value)
    {
      this.WriteRawVarint32(CodedOutputStream.EncodeZigZag32(value));
    }

    public void WriteSInt64NoTag(long value)
    {
      this.WriteRawVarint64(CodedOutputStream.EncodeZigZag64(value));
    }

    [CLSCompliant(false)]
    public void WriteTag(int fieldNumber, WireFormat.WireType type)
    {
      this.WriteRawVarint32(WireFormat.MakeTag(fieldNumber, type));
    }

    private void SlowWriteRawVarint32(uint value)
    {
      for (; ((long) value & (long) sbyte.MinValue) != 0L; value >>= 7)
        this.WriteRawByte((uint) ((int) value & (int) sbyte.MaxValue | 128));
      this.WriteRawByte(value);
    }

    [CLSCompliant(false)]
    public void WriteRawVarint32(uint value)
    {
      if (this.position + 5 > this.limit)
      {
        this.SlowWriteRawVarint32(value);
      }
      else
      {
        for (; ((long) value & (long) sbyte.MinValue) != 0L; value >>= 7)
          this.buffer[this.position++] = (byte) ((int) value & (int) sbyte.MaxValue | 128);
        this.buffer[this.position++] = (byte) value;
      }
    }

    [CLSCompliant(false)]
    public void WriteRawVarint64(ulong value)
    {
      for (; ((long) value & (long) sbyte.MinValue) != 0L; value >>= 7)
        this.WriteRawByte((uint) ((int) (uint) value & (int) sbyte.MaxValue | 128));
      this.WriteRawByte((uint) value);
    }

    [CLSCompliant(false)]
    public void WriteRawLittleEndian32(uint value)
    {
      this.WriteRawByte((byte) value);
      this.WriteRawByte((byte) (value >> 8));
      this.WriteRawByte((byte) (value >> 16));
      this.WriteRawByte((byte) (value >> 24));
    }

    [CLSCompliant(false)]
    public void WriteRawLittleEndian64(ulong value)
    {
      this.WriteRawByte((byte) value);
      this.WriteRawByte((byte) (value >> 8));
      this.WriteRawByte((byte) (value >> 16));
      this.WriteRawByte((byte) (value >> 24));
      this.WriteRawByte((byte) (value >> 32));
      this.WriteRawByte((byte) (value >> 40));
      this.WriteRawByte((byte) (value >> 48));
      this.WriteRawByte((byte) (value >> 56));
    }

    public void WriteRawByte(byte value)
    {
      if (this.position == this.limit)
        this.RefreshBuffer();
      this.buffer[this.position++] = value;
    }

    [CLSCompliant(false)]
    public void WriteRawByte(uint value) => this.WriteRawByte((byte) value);

    public void WriteRawBytes(byte[] value) => this.WriteRawBytes(value, 0, value.Length);

    public void WriteRawBytes(byte[] value, int offset, int length)
    {
      if (this.limit - this.position >= length)
      {
        Array.Copy((Array) value, offset, (Array) this.buffer, this.position, length);
        this.position += length;
      }
      else
      {
        int length1 = this.limit - this.position;
        Array.Copy((Array) value, offset, (Array) this.buffer, this.position, length1);
        offset += length1;
        length -= length1;
        this.position = this.limit;
        this.RefreshBuffer();
        if (length <= this.limit)
        {
          Array.Copy((Array) value, offset, (Array) this.buffer, 0, length);
          this.position = length;
        }
        else
          this.output.Write(value, offset, length);
      }
    }

    public static int ComputeDoubleSize(int fieldNumber, double value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
    }

    public static int ComputeFloatSize(int fieldNumber, float value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
    }

    [CLSCompliant(false)]
    public static int ComputeUInt64Size(int fieldNumber, ulong value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size(value);
    }

    public static int ComputeInt64Size(int fieldNumber, long value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size((ulong) value);
    }

    public static int ComputeInt32Size(int fieldNumber, int value)
    {
      return value >= 0 ? CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) value) : CodedOutputStream.ComputeTagSize(fieldNumber) + 10;
    }

    [CLSCompliant(false)]
    public static int ComputeFixed64Size(int fieldNumber, ulong value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
    }

    [CLSCompliant(false)]
    public static int ComputeFixed32Size(int fieldNumber, uint value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
    }

    public static int ComputeBoolSize(int fieldNumber, bool value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 1;
    }

    public static int ComputeStringSize(int fieldNumber, string value)
    {
      int byteCount = Encoding.UTF8.GetByteCount(value);
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) byteCount) + byteCount;
    }

    public static int ComputeGroupSize(int fieldNumber, IMessageLite value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) * 2 + value.SerializedSize;
    }

    [Obsolete]
    public static int ComputeUnknownGroupSize(int fieldNumber, IMessageLite value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) * 2 + value.SerializedSize;
    }

    public static int ComputeMessageSize(int fieldNumber, IMessageLite value)
    {
      int serializedSize = value.SerializedSize;
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) serializedSize) + serializedSize;
    }

    public static int ComputeBytesSize(int fieldNumber, ByteString value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) value.Length) + value.Length;
    }

    [CLSCompliant(false)]
    public static int ComputeUInt32Size(int fieldNumber, uint value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size(value);
    }

    public static int ComputeEnumSize(int fieldNumber, int value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) value);
    }

    public static int ComputeSFixed32Size(int fieldNumber, int value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
    }

    public static int ComputeSFixed64Size(int fieldNumber, long value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
    }

    public static int ComputeSInt32Size(int fieldNumber, int value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size(CodedOutputStream.EncodeZigZag32(value));
    }

    public static int ComputeSInt64Size(int fieldNumber, long value)
    {
      return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size(CodedOutputStream.EncodeZigZag64(value));
    }

    public static int ComputeDoubleSizeNoTag(double value) => 8;

    public static int ComputeFloatSizeNoTag(float value) => 4;

    [CLSCompliant(false)]
    public static int ComputeUInt64SizeNoTag(ulong value)
    {
      return CodedOutputStream.ComputeRawVarint64Size(value);
    }

    public static int ComputeInt64SizeNoTag(long value)
    {
      return CodedOutputStream.ComputeRawVarint64Size((ulong) value);
    }

    public static int ComputeInt32SizeNoTag(int value)
    {
      return value >= 0 ? CodedOutputStream.ComputeRawVarint32Size((uint) value) : 10;
    }

    [CLSCompliant(false)]
    public static int ComputeFixed64SizeNoTag(ulong value) => 8;

    [CLSCompliant(false)]
    public static int ComputeFixed32SizeNoTag(uint value) => 4;

    public static int ComputeBoolSizeNoTag(bool value) => 1;

    public static int ComputeStringSizeNoTag(string value)
    {
      int byteCount = Encoding.UTF8.GetByteCount(value);
      return CodedOutputStream.ComputeRawVarint32Size((uint) byteCount) + byteCount;
    }

    public static int ComputeGroupSizeNoTag(IMessageLite value) => value.SerializedSize;

    [Obsolete]
    public static int ComputeUnknownGroupSizeNoTag(IMessageLite value) => value.SerializedSize;

    public static int ComputeMessageSizeNoTag(IMessageLite value)
    {
      int serializedSize = value.SerializedSize;
      return CodedOutputStream.ComputeRawVarint32Size((uint) serializedSize) + serializedSize;
    }

    public static int ComputeBytesSizeNoTag(ByteString value)
    {
      return CodedOutputStream.ComputeRawVarint32Size((uint) value.Length) + value.Length;
    }

    [CLSCompliant(false)]
    public static int ComputeUInt32SizeNoTag(uint value)
    {
      return CodedOutputStream.ComputeRawVarint32Size(value);
    }

    public static int ComputeEnumSizeNoTag(int value)
    {
      return CodedOutputStream.ComputeRawVarint32Size((uint) value);
    }

    public static int ComputeSFixed32SizeNoTag(int value) => 4;

    public static int ComputeSFixed64SizeNoTag(long value) => 8;

    public static int ComputeSInt32SizeNoTag(int value)
    {
      return CodedOutputStream.ComputeRawVarint32Size(CodedOutputStream.EncodeZigZag32(value));
    }

    public static int ComputeSInt64SizeNoTag(long value)
    {
      return CodedOutputStream.ComputeRawVarint64Size(CodedOutputStream.EncodeZigZag64(value));
    }

    public static int ComputeMessageSetExtensionSize(int fieldNumber, IMessageLite value)
    {
      return CodedOutputStream.ComputeTagSize(1) * 2 + CodedOutputStream.ComputeUInt32Size(2, (uint) fieldNumber) + CodedOutputStream.ComputeMessageSize(3, value);
    }

    public static int ComputeRawMessageSetExtensionSize(int fieldNumber, ByteString value)
    {
      return CodedOutputStream.ComputeTagSize(1) * 2 + CodedOutputStream.ComputeUInt32Size(2, (uint) fieldNumber) + CodedOutputStream.ComputeBytesSize(3, value);
    }

    [CLSCompliant(false)]
    public static int ComputeRawVarint32Size(uint value)
    {
      if (((int) value & (int) sbyte.MinValue) == 0)
        return 1;
      if (((int) value & -16384) == 0)
        return 2;
      if (((int) value & -2097152) == 0)
        return 3;
      return ((int) value & -268435456) == 0 ? 4 : 5;
    }

    [CLSCompliant(false)]
    public static int ComputeRawVarint64Size(ulong value)
    {
      if (((long) value & (long) sbyte.MinValue) == 0L)
        return 1;
      if (((long) value & -16384L) == 0L)
        return 2;
      if (((long) value & -2097152L) == 0L)
        return 3;
      if (((long) value & -268435456L) == 0L)
        return 4;
      if (((long) value & -34359738368L) == 0L)
        return 5;
      if (((long) value & -4398046511104L) == 0L)
        return 6;
      if (((long) value & -562949953421312L) == 0L)
        return 7;
      if (((long) value & -72057594037927936L) == 0L)
        return 8;
      return ((long) value & long.MinValue) == 0L ? 9 : 10;
    }

    public static int ComputeFieldSize(FieldType fieldType, int fieldNumber, object value)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          return CodedOutputStream.ComputeDoubleSize(fieldNumber, (double) value);
        case FieldType.Float:
          return CodedOutputStream.ComputeFloatSize(fieldNumber, (float) value);
        case FieldType.Int64:
          return CodedOutputStream.ComputeInt64Size(fieldNumber, (long) value);
        case FieldType.UInt64:
          return CodedOutputStream.ComputeUInt64Size(fieldNumber, (ulong) value);
        case FieldType.Int32:
          return CodedOutputStream.ComputeInt32Size(fieldNumber, (int) value);
        case FieldType.Fixed64:
          return CodedOutputStream.ComputeFixed64Size(fieldNumber, (ulong) value);
        case FieldType.Fixed32:
          return CodedOutputStream.ComputeFixed32Size(fieldNumber, (uint) value);
        case FieldType.Bool:
          return CodedOutputStream.ComputeBoolSize(fieldNumber, (bool) value);
        case FieldType.String:
          return CodedOutputStream.ComputeStringSize(fieldNumber, (string) value);
        case FieldType.Group:
          return CodedOutputStream.ComputeGroupSize(fieldNumber, (IMessageLite) value);
        case FieldType.Message:
          return CodedOutputStream.ComputeMessageSize(fieldNumber, (IMessageLite) value);
        case FieldType.Bytes:
          return CodedOutputStream.ComputeBytesSize(fieldNumber, (ByteString) value);
        case FieldType.UInt32:
          return CodedOutputStream.ComputeUInt32Size(fieldNumber, (uint) value);
        case FieldType.SFixed32:
          return CodedOutputStream.ComputeSFixed32Size(fieldNumber, (int) value);
        case FieldType.SFixed64:
          return CodedOutputStream.ComputeSFixed64Size(fieldNumber, (long) value);
        case FieldType.SInt32:
          return CodedOutputStream.ComputeSInt32Size(fieldNumber, (int) value);
        case FieldType.SInt64:
          return CodedOutputStream.ComputeSInt64Size(fieldNumber, (long) value);
        case FieldType.Enum:
          return CodedOutputStream.ComputeEnumSize(fieldNumber, ((IEnumLite) value).Number);
        default:
          throw new ArgumentOutOfRangeException("Invalid field type " + (object) fieldType);
      }
    }

    public static int ComputeFieldSizeNoTag(FieldType fieldType, object value)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          return CodedOutputStream.ComputeDoubleSizeNoTag((double) value);
        case FieldType.Float:
          return CodedOutputStream.ComputeFloatSizeNoTag((float) value);
        case FieldType.Int64:
          return CodedOutputStream.ComputeInt64SizeNoTag((long) value);
        case FieldType.UInt64:
          return CodedOutputStream.ComputeUInt64SizeNoTag((ulong) value);
        case FieldType.Int32:
          return CodedOutputStream.ComputeInt32SizeNoTag((int) value);
        case FieldType.Fixed64:
          return CodedOutputStream.ComputeFixed64SizeNoTag((ulong) value);
        case FieldType.Fixed32:
          return CodedOutputStream.ComputeFixed32SizeNoTag((uint) value);
        case FieldType.Bool:
          return CodedOutputStream.ComputeBoolSizeNoTag((bool) value);
        case FieldType.String:
          return CodedOutputStream.ComputeStringSizeNoTag((string) value);
        case FieldType.Group:
          return CodedOutputStream.ComputeGroupSizeNoTag((IMessageLite) value);
        case FieldType.Message:
          return CodedOutputStream.ComputeMessageSizeNoTag((IMessageLite) value);
        case FieldType.Bytes:
          return CodedOutputStream.ComputeBytesSizeNoTag((ByteString) value);
        case FieldType.UInt32:
          return CodedOutputStream.ComputeUInt32SizeNoTag((uint) value);
        case FieldType.SFixed32:
          return CodedOutputStream.ComputeSFixed32SizeNoTag((int) value);
        case FieldType.SFixed64:
          return CodedOutputStream.ComputeSFixed64SizeNoTag((long) value);
        case FieldType.SInt32:
          return CodedOutputStream.ComputeSInt32SizeNoTag((int) value);
        case FieldType.SInt64:
          return CodedOutputStream.ComputeSInt64SizeNoTag((long) value);
        case FieldType.Enum:
          return CodedOutputStream.ComputeEnumSizeNoTag(((IEnumLite) value).Number);
        default:
          throw new ArgumentOutOfRangeException("Invalid field type " + (object) fieldType);
      }
    }

    public static int ComputeTagSize(int fieldNumber)
    {
      return CodedOutputStream.ComputeRawVarint32Size(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.Varint));
    }

    [CLSCompliant(false)]
    public static uint EncodeZigZag32(int n) => (uint) (n << 1 ^ n >> 31);

    [CLSCompliant(false)]
    public static ulong EncodeZigZag64(long n) => (ulong) (n << 1 ^ n >> 63);

    private void RefreshBuffer()
    {
      if (this.output == null)
        throw new CodedOutputStream.OutOfSpaceException();
      this.output.Write(this.buffer, 0, this.position);
      this.position = 0;
    }

    public void Flush()
    {
      if (this.output == null)
        return;
      this.RefreshBuffer();
    }

    public void CheckNoSpaceLeft()
    {
      if (this.SpaceLeft != 0)
        throw new InvalidOperationException("Did not write as much data as expected.");
    }

    public int SpaceLeft
    {
      get
      {
        if (this.output == null)
          return this.limit - this.position;
        throw new InvalidOperationException("SpaceLeft can only be called on CodedOutputStreams that are writing to a flat array.");
      }
    }

    public sealed class OutOfSpaceException : IOException
    {
      internal OutOfSpaceException()
        : base("CodedOutputStream was writing to a flat byte array and ran out of space.")
      {
      }
    }
  }
}
