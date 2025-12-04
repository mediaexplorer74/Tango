// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ByteString
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class ByteString : IEnumerable<byte>, IEnumerable, IEquatable<ByteString>
  {
    private static readonly ByteString empty = new ByteString(new byte[0]);
    private readonly byte[] bytes;

    private ByteString(byte[] bytes) => this.bytes = bytes;

    public static ByteString Empty => ByteString.empty;

    public int Length => this.bytes.Length;

    public bool IsEmpty => this.Length == 0;

    public byte[] ToByteArray() => (byte[]) this.bytes.Clone();

    public static ByteString FromBase64(string bytes)
    {
      return new ByteString(Convert.FromBase64String(bytes));
    }

    public static ByteString CopyFrom(byte[] bytes) => new ByteString((byte[]) bytes.Clone());

    public static ByteString CopyFrom(byte[] bytes, int offset, int count)
    {
      byte[] numArray = new byte[count];
      Array.Copy((Array) bytes, offset, (Array) numArray, 0, count);
      return new ByteString(numArray);
    }

    public static ByteString CopyFrom(string text, Encoding encoding)
    {
      return new ByteString(encoding.GetBytes(text));
    }

    public static ByteString CopyFromUtf8(string text) => ByteString.CopyFrom(text, Encoding.UTF8);

    public byte this[int index] => this.bytes[index];

    public string ToString(Encoding encoding)
    {
      return encoding.GetString(this.bytes, 0, this.bytes.Length);
    }

    public string ToStringUtf8() => this.ToString(Encoding.UTF8);

    public IEnumerator<byte> GetEnumerator() => ((IEnumerable<byte>) this.bytes).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public CodedInputStream CreateCodedInput() => CodedInputStream.CreateInstance(this.bytes);

    public override bool Equals(object obj)
    {
      ByteString other = obj as ByteString;
      return obj != null && this.Equals(other);
    }

    public override int GetHashCode()
    {
      int hashCode = 23;
      foreach (byte num in this.bytes)
        hashCode = hashCode << 8 | (int) num;
      return hashCode;
    }

    public bool Equals(ByteString other)
    {
      if (other.bytes.Length != this.bytes.Length)
        return false;
      for (int index = 0; index < this.bytes.Length; ++index)
      {
        if ((int) other.bytes[index] != (int) this.bytes[index])
          return false;
      }
      return true;
    }

    internal sealed class CodedBuilder
    {
      private readonly CodedOutputStream output;
      private readonly byte[] buffer;

      internal CodedBuilder(int size)
      {
        this.buffer = new byte[size];
        this.output = CodedOutputStream.CreateInstance(this.buffer);
      }

      internal ByteString Build()
      {
        this.output.CheckNoSpaceLeft();
        return new ByteString(this.buffer);
      }

      internal CodedOutputStream CodedOutput => this.output;
    }
  }
}
