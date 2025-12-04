// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.CodedInputStream
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class CodedInputStream
  {
    internal const int DefaultRecursionLimit = 64;
    internal const int DefaultSizeLimit = 67108864;
    internal const int BufferSize = 4096;
    private readonly byte[] buffer;
    private int bufferSize;
    private int bufferSizeAfterLimit;
    private int bufferPos;
    private readonly Stream input;
    private uint lastTag;
    private int totalBytesRetired;
    private int currentLimit = int.MaxValue;
    private int recursionDepth;
    private int recursionLimit = 64;
    private int sizeLimit = 67108864;

    public static CodedInputStream CreateInstance(Stream input) => new CodedInputStream(input);

    public static CodedInputStream CreateInstance(byte[] buf)
    {
      return new CodedInputStream(buf, 0, buf.Length);
    }

    public static CodedInputStream CreateInstance(byte[] buf, int offset, int length)
    {
      return new CodedInputStream(buf, offset, length);
    }

    private CodedInputStream(byte[] buffer, int offset, int length)
    {
      this.buffer = buffer;
      this.bufferPos = offset;
      this.bufferSize = offset + length;
      this.input = (Stream) null;
    }

    private CodedInputStream(Stream input)
    {
      this.buffer = new byte[4096];
      this.bufferSize = 0;
      this.input = input;
    }

    [CLSCompliant(false)]
    public void CheckLastTagWas(uint value)
    {
      if ((int) this.lastTag != (int) value)
        throw InvalidProtocolBufferException.InvalidEndTag();
    }

    [CLSCompliant(false)]
    public uint ReadTag()
    {
      if (this.IsAtEnd)
      {
        this.lastTag = 0U;
        return 0;
      }
      this.lastTag = this.ReadRawVarint32();
      return this.lastTag != 0U ? this.lastTag : throw InvalidProtocolBufferException.InvalidTag();
    }

    public double ReadDouble() => BitConverter.ToDouble(this.ReadRawBytes(8), 0);

    public float ReadFloat()
    {
      return BitConverter.ToSingle(BitConverter.GetBytes(this.ReadRawLittleEndian32()), 0);
    }

    [CLSCompliant(false)]
    public ulong ReadUInt64() => this.ReadRawVarint64();

    public long ReadInt64() => (long) this.ReadRawVarint64();

    public int ReadInt32() => (int) this.ReadRawVarint32();

    [CLSCompliant(false)]
    public ulong ReadFixed64() => this.ReadRawLittleEndian64();

    [CLSCompliant(false)]
    public uint ReadFixed32() => this.ReadRawLittleEndian32();

    public bool ReadBool() => this.ReadRawVarint32() != 0U;

    public string ReadString()
    {
      int num = (int) this.ReadRawVarint32();
      if (num == 0)
        return "";
      if (num > this.bufferSize - this.bufferPos)
        return Encoding.UTF8.GetString(this.ReadRawBytes(num), 0, num);
      string str = Encoding.UTF8.GetString(this.buffer, this.bufferPos, num);
      this.bufferPos += num;
      return str;
    }

    public void ReadGroup(
      int fieldNumber,
      IBuilderLite builder,
      ExtensionRegistry extensionRegistry)
    {
      if (this.recursionDepth >= this.recursionLimit)
        throw InvalidProtocolBufferException.RecursionLimitExceeded();
      ++this.recursionDepth;
      builder.WeakMergeFrom(this, extensionRegistry);
      this.CheckLastTagWas(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.EndGroup));
      --this.recursionDepth;
    }

    [Obsolete]
    public void ReadUnknownGroup(int fieldNumber, IBuilderLite builder)
    {
      if (this.recursionDepth >= this.recursionLimit)
        throw InvalidProtocolBufferException.RecursionLimitExceeded();
      ++this.recursionDepth;
      builder.WeakMergeFrom(this);
      this.CheckLastTagWas(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.EndGroup));
      --this.recursionDepth;
    }

    public void ReadMessage(IBuilderLite builder, ExtensionRegistry extensionRegistry)
    {
      int byteLimit = (int) this.ReadRawVarint32();
      if (this.recursionDepth >= this.recursionLimit)
        throw InvalidProtocolBufferException.RecursionLimitExceeded();
      int oldLimit = this.PushLimit(byteLimit);
      ++this.recursionDepth;
      builder.WeakMergeFrom(this, extensionRegistry);
      this.CheckLastTagWas(0U);
      --this.recursionDepth;
      this.PopLimit(oldLimit);
    }

    public ByteString ReadBytes()
    {
      int num = (int) this.ReadRawVarint32();
      if (num >= this.bufferSize - this.bufferPos || num <= 0)
        return ByteString.CopyFrom(this.ReadRawBytes(num));
      ByteString byteString = ByteString.CopyFrom(this.buffer, this.bufferPos, num);
      this.bufferPos += num;
      return byteString;
    }

    [CLSCompliant(false)]
    public uint ReadUInt32() => this.ReadRawVarint32();

    public int ReadEnum() => (int) this.ReadRawVarint32();

    public int ReadSFixed32() => (int) this.ReadRawLittleEndian32();

    public long ReadSFixed64() => (long) this.ReadRawLittleEndian64();

    public int ReadSInt32() => CodedInputStream.DecodeZigZag32(this.ReadRawVarint32());

    public long ReadSInt64() => CodedInputStream.DecodeZigZag64(this.ReadRawVarint64());

    public object ReadPrimitiveField(FieldType fieldType)
    {
      switch (fieldType)
      {
        case FieldType.Double:
          return (object) this.ReadDouble();
        case FieldType.Float:
          return (object) this.ReadFloat();
        case FieldType.Int64:
          return (object) this.ReadInt64();
        case FieldType.UInt64:
          return (object) this.ReadUInt64();
        case FieldType.Int32:
          return (object) this.ReadInt32();
        case FieldType.Fixed64:
          return (object) this.ReadFixed64();
        case FieldType.Fixed32:
          return (object) this.ReadFixed32();
        case FieldType.Bool:
          return (object) this.ReadBool();
        case FieldType.String:
          return (object) this.ReadString();
        case FieldType.Group:
          throw new ArgumentException("ReadPrimitiveField() cannot handle nested groups.");
        case FieldType.Message:
          throw new ArgumentException("ReadPrimitiveField() cannot handle embedded messages.");
        case FieldType.Bytes:
          return (object) this.ReadBytes();
        case FieldType.UInt32:
          return (object) this.ReadUInt32();
        case FieldType.SFixed32:
          return (object) this.ReadSFixed32();
        case FieldType.SFixed64:
          return (object) this.ReadSFixed64();
        case FieldType.SInt32:
          return (object) this.ReadSInt32();
        case FieldType.SInt64:
          return (object) this.ReadSInt64();
        case FieldType.Enum:
          throw new ArgumentException("ReadPrimitiveField() cannot handle enums.");
        default:
          throw new ArgumentOutOfRangeException("Invalid field type " + (object) fieldType);
      }
    }

    private uint SlowReadRawVarint32()
    {
      int num1 = (int) this.ReadRawByte();
      if (num1 < 128)
        return (uint) num1;
      int num2 = num1 & (int) sbyte.MaxValue;
      int num3;
      int num4;
      if ((num3 = (int) this.ReadRawByte()) < 128)
      {
        num4 = num2 | num3 << 7;
      }
      else
      {
        int num5 = num2 | (num3 & (int) sbyte.MaxValue) << 7;
        int num6;
        if ((num6 = (int) this.ReadRawByte()) < 128)
        {
          num4 = num5 | num6 << 14;
        }
        else
        {
          int num7 = num5 | (num6 & (int) sbyte.MaxValue) << 14;
          int num8;
          if ((num8 = (int) this.ReadRawByte()) < 128)
          {
            num4 = num7 | num8 << 21;
          }
          else
          {
            int num9;
            num4 = num7 | (num8 & (int) sbyte.MaxValue) << 21 | (num9 = (int) this.ReadRawByte()) << 28;
            if (num9 >= 128)
            {
              for (int index = 0; index < 5; ++index)
              {
                if (this.ReadRawByte() < (byte) 128)
                  return (uint) num4;
              }
              throw InvalidProtocolBufferException.MalformedVarint();
            }
          }
        }
      }
      return (uint) num4;
    }

    [CLSCompliant(false)]
    public uint ReadRawVarint32()
    {
      if (this.bufferPos + 5 > this.bufferSize)
        return this.SlowReadRawVarint32();
      int num1 = (int) this.buffer[this.bufferPos++];
      if (num1 < 128)
        return (uint) num1;
      int num2 = num1 & (int) sbyte.MaxValue;
      byte[] buffer1 = this.buffer;
      int index1 = this.bufferPos++;
      int num3;
      int num4;
      if ((num3 = (int) buffer1[index1]) < 128)
      {
        num4 = num2 | num3 << 7;
      }
      else
      {
        int num5 = num2 | (num3 & (int) sbyte.MaxValue) << 7;
        byte[] buffer2 = this.buffer;
        int index2 = this.bufferPos++;
        int num6;
        if ((num6 = (int) buffer2[index2]) < 128)
        {
          num4 = num5 | num6 << 14;
        }
        else
        {
          int num7 = num5 | (num6 & (int) sbyte.MaxValue) << 14;
          byte[] buffer3 = this.buffer;
          int index3 = this.bufferPos++;
          int num8;
          if ((num8 = (int) buffer3[index3]) < 128)
          {
            num4 = num7 | num8 << 21;
          }
          else
          {
            int num9 = num7 | (num8 & (int) sbyte.MaxValue) << 21;
            byte[] buffer4 = this.buffer;
            int index4 = this.bufferPos++;
            int num10;
            int num11 = (num10 = (int) buffer4[index4]) << 28;
            num4 = num9 | num11;
            if (num10 >= 128)
            {
              for (int index5 = 0; index5 < 5; ++index5)
              {
                if (this.ReadRawByte() < (byte) 128)
                  return (uint) num4;
              }
              throw InvalidProtocolBufferException.MalformedVarint();
            }
          }
        }
      }
      return (uint) num4;
    }

    internal static uint ReadRawVarint32(Stream input)
    {
      int num1 = 0;
      int num2;
      for (num2 = 0; num2 < 32; num2 += 7)
      {
        int num3 = input.ReadByte();
        if (num3 == -1)
          throw InvalidProtocolBufferException.TruncatedMessage();
        num1 |= (num3 & (int) sbyte.MaxValue) << num2;
        if ((num3 & 128) == 0)
          return (uint) num1;
      }
      for (; num2 < 64; num2 += 7)
      {
        int num4 = input.ReadByte();
        if (num4 == -1)
          throw InvalidProtocolBufferException.TruncatedMessage();
        if ((num4 & 128) == 0)
          return (uint) num1;
      }
      throw InvalidProtocolBufferException.MalformedVarint();
    }

    [CLSCompliant(false)]
    public ulong ReadRawVarint64()
    {
      int num1 = 0;
      ulong num2 = 0;
      for (; num1 < 64; num1 += 7)
      {
        byte num3 = this.ReadRawByte();
        num2 |= (ulong) ((int) num3 & (int) sbyte.MaxValue) << num1;
        if (((int) num3 & 128) == 0)
          return num2;
      }
      throw InvalidProtocolBufferException.MalformedVarint();
    }

    [CLSCompliant(false)]
    public uint ReadRawLittleEndian32()
    {
      return (uint) ((int) this.ReadRawByte() | (int) this.ReadRawByte() << 8 | (int) this.ReadRawByte() << 16 | (int) this.ReadRawByte() << 24);
    }

    [CLSCompliant(false)]
    public ulong ReadRawLittleEndian64()
    {
      return (ulong) ((long) this.ReadRawByte() | (long) this.ReadRawByte() << 8 | (long) this.ReadRawByte() << 16 | (long) this.ReadRawByte() << 24 | (long) this.ReadRawByte() << 32 | (long) this.ReadRawByte() << 40 | (long) this.ReadRawByte() << 48 | (long) this.ReadRawByte() << 56);
    }

    [CLSCompliant(false)]
    public static int DecodeZigZag32(uint n) => (int) (n >> 1) ^ -((int) n & 1);

    [CLSCompliant(false)]
    public static long DecodeZigZag64(ulong n) => (long) (n >> 1) ^ -((long) n & 1L);

    public int SetRecursionLimit(int limit)
    {
      if (limit < 0)
        throw new ArgumentOutOfRangeException("Recursion limit cannot be negative: " + (object) limit);
      int recursionLimit = this.recursionLimit;
      this.recursionLimit = limit;
      return recursionLimit;
    }

    public int SetSizeLimit(int limit)
    {
      if (limit < 0)
        throw new ArgumentOutOfRangeException("Size limit cannot be negative: " + (object) limit);
      int sizeLimit = this.sizeLimit;
      this.sizeLimit = limit;
      return sizeLimit;
    }

    public void ResetSizeCounter() => this.totalBytesRetired = 0;

    public int PushLimit(int byteLimit)
    {
      if (byteLimit < 0)
        throw InvalidProtocolBufferException.NegativeSize();
      byteLimit += this.totalBytesRetired + this.bufferPos;
      int currentLimit = this.currentLimit;
      this.currentLimit = byteLimit <= currentLimit ? byteLimit : throw InvalidProtocolBufferException.TruncatedMessage();
      this.RecomputeBufferSizeAfterLimit();
      return currentLimit;
    }

    private void RecomputeBufferSizeAfterLimit()
    {
      this.bufferSize += this.bufferSizeAfterLimit;
      int num = this.totalBytesRetired + this.bufferSize;
      if (num > this.currentLimit)
      {
        this.bufferSizeAfterLimit = num - this.currentLimit;
        this.bufferSize -= this.bufferSizeAfterLimit;
      }
      else
        this.bufferSizeAfterLimit = 0;
    }

    public void PopLimit(int oldLimit)
    {
      this.currentLimit = oldLimit;
      this.RecomputeBufferSizeAfterLimit();
    }

    public bool ReachedLimit
    {
      get
      {
        return this.currentLimit != int.MaxValue && this.totalBytesRetired + this.bufferPos >= this.currentLimit;
      }
    }

    public bool IsAtEnd => this.bufferPos == this.bufferSize && !this.RefillBuffer(false);

    private bool RefillBuffer(bool mustSucceed)
    {
      if (this.bufferPos < this.bufferSize)
        throw new InvalidOperationException("RefillBuffer() called when buffer wasn't empty.");
      if (this.totalBytesRetired + this.bufferSize == this.currentLimit)
      {
        if (mustSucceed)
          throw InvalidProtocolBufferException.TruncatedMessage();
        return false;
      }
      this.totalBytesRetired += this.bufferSize;
      this.bufferPos = 0;
      this.bufferSize = this.input == null ? 0 : this.input.Read(this.buffer, 0, this.buffer.Length);
      if (this.bufferSize < 0)
        throw new InvalidOperationException("Stream.Read returned a negative count");
      if (this.bufferSize == 0)
      {
        if (mustSucceed)
          throw InvalidProtocolBufferException.TruncatedMessage();
        return false;
      }
      this.RecomputeBufferSizeAfterLimit();
      int num = this.totalBytesRetired + this.bufferSize + this.bufferSizeAfterLimit;
      if (num > this.sizeLimit || num < 0)
        throw InvalidProtocolBufferException.SizeLimitExceeded();
      return true;
    }

    public byte ReadRawByte()
    {
      if (this.bufferPos == this.bufferSize)
        this.RefillBuffer(true);
      return this.buffer[this.bufferPos++];
    }

    public byte[] ReadRawBytes(int size)
    {
      if (size < 0)
        throw InvalidProtocolBufferException.NegativeSize();
      if (this.totalBytesRetired + this.bufferPos + size > this.currentLimit)
      {
        this.SkipRawBytes(this.currentLimit - this.totalBytesRetired - this.bufferPos);
        throw InvalidProtocolBufferException.TruncatedMessage();
      }
      if (size <= this.bufferSize - this.bufferPos)
      {
        byte[] destinationArray = new byte[size];
        Array.Copy((Array) this.buffer, this.bufferPos, (Array) destinationArray, 0, size);
        this.bufferPos += size;
        return destinationArray;
      }
      if (size < 4096)
      {
        byte[] destinationArray = new byte[size];
        int num = this.bufferSize - this.bufferPos;
        Array.Copy((Array) this.buffer, this.bufferPos, (Array) destinationArray, 0, num);
        this.bufferPos = this.bufferSize;
        this.RefillBuffer(true);
        while (size - num > this.bufferSize)
        {
          Array.Copy((Array) this.buffer, 0, (Array) destinationArray, num, this.bufferSize);
          num += this.bufferSize;
          this.bufferPos = this.bufferSize;
          this.RefillBuffer(true);
        }
        Array.Copy((Array) this.buffer, 0, (Array) destinationArray, num, size - num);
        this.bufferPos = size - num;
        return destinationArray;
      }
      int bufferPos = this.bufferPos;
      int bufferSize = this.bufferSize;
      this.totalBytesRetired += this.bufferSize;
      this.bufferPos = 0;
      this.bufferSize = 0;
      int val1 = size - (bufferSize - bufferPos);
      List<byte[]> numArrayList = new List<byte[]>();
      while (val1 > 0)
      {
        byte[] buffer = new byte[Math.Min(val1, 4096)];
        int num;
        for (int offset = 0; offset < buffer.Length; offset += num)
        {
          num = this.input == null ? -1 : this.input.Read(buffer, offset, buffer.Length - offset);
          if (num <= 0)
            throw InvalidProtocolBufferException.TruncatedMessage();
          this.totalBytesRetired += num;
        }
        val1 -= buffer.Length;
        numArrayList.Add(buffer);
      }
      byte[] destinationArray1 = new byte[size];
      int num1 = bufferSize - bufferPos;
      Array.Copy((Array) this.buffer, bufferPos, (Array) destinationArray1, 0, num1);
      foreach (byte[] sourceArray in numArrayList)
      {
        Array.Copy((Array) sourceArray, 0, (Array) destinationArray1, num1, sourceArray.Length);
        num1 += sourceArray.Length;
      }
      return destinationArray1;
    }

    [CLSCompliant(false)]
    public bool SkipField(uint tag)
    {
      switch (WireFormat.GetTagWireType(tag))
      {
        case WireFormat.WireType.Varint:
          this.ReadInt32();
          return true;
        case WireFormat.WireType.Fixed64:
          long num1 = (long) this.ReadRawLittleEndian64();
          return true;
        case WireFormat.WireType.LengthDelimited:
          this.SkipRawBytes((int) this.ReadRawVarint32());
          return true;
        case WireFormat.WireType.StartGroup:
          this.SkipMessage();
          this.CheckLastTagWas(WireFormat.MakeTag(WireFormat.GetTagFieldNumber(tag), WireFormat.WireType.EndGroup));
          return true;
        case WireFormat.WireType.EndGroup:
          return false;
        case WireFormat.WireType.Fixed32:
          int num2 = (int) this.ReadRawLittleEndian32();
          return true;
        default:
          throw InvalidProtocolBufferException.InvalidWireType();
      }
    }

    public void SkipMessage()
    {
      uint tag;
      do
      {
        tag = this.ReadTag();
      }
      while (tag != 0U && this.SkipField(tag));
    }

    public void SkipRawBytes(int size)
    {
      if (size < 0)
        throw InvalidProtocolBufferException.NegativeSize();
      if (this.totalBytesRetired + this.bufferPos + size > this.currentLimit)
      {
        this.SkipRawBytes(this.currentLimit - this.totalBytesRetired - this.bufferPos);
        throw InvalidProtocolBufferException.TruncatedMessage();
      }
      if (size <= this.bufferSize - this.bufferPos)
      {
        this.bufferPos += size;
      }
      else
      {
        int num = this.bufferSize - this.bufferPos;
        this.totalBytesRetired += num;
        this.bufferPos = 0;
        this.bufferSize = 0;
        if (num >= size)
          return;
        if (this.input == null)
          throw InvalidProtocolBufferException.TruncatedMessage();
        this.SkipImpl(size - num);
        this.totalBytesRetired += size - num;
      }
    }

    private void SkipImpl(int amountToSkip)
    {
      if (this.input.CanSeek)
      {
        long position = this.input.Position;
        this.input.Position += (long) amountToSkip;
        if (this.input.Position != position + (long) amountToSkip)
          throw InvalidProtocolBufferException.TruncatedMessage();
      }
      else
      {
        byte[] buffer = new byte[1024];
        int num;
        for (; amountToSkip > 0; amountToSkip -= num)
        {
          num = this.input.Read(buffer, 0, buffer.Length);
          if (num <= 0)
            throw InvalidProtocolBufferException.TruncatedMessage();
        }
      }
    }
  }
}
