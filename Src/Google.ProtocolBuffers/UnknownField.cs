// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.UnknownField
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class UnknownField
  {
    private static readonly UnknownField defaultInstance = UnknownField.CreateBuilder().Build();
    private readonly ReadOnlyCollection<ulong> varintList;
    private readonly ReadOnlyCollection<uint> fixed32List;
    private readonly ReadOnlyCollection<ulong> fixed64List;
    private readonly ReadOnlyCollection<ByteString> lengthDelimitedList;
    private readonly ReadOnlyCollection<UnknownFieldSet> groupList;

    private UnknownField(
      ReadOnlyCollection<ulong> varintList,
      ReadOnlyCollection<uint> fixed32List,
      ReadOnlyCollection<ulong> fixed64List,
      ReadOnlyCollection<ByteString> lengthDelimitedList,
      ReadOnlyCollection<UnknownFieldSet> groupList)
    {
      this.varintList = varintList;
      this.fixed32List = fixed32List;
      this.fixed64List = fixed64List;
      this.lengthDelimitedList = lengthDelimitedList;
      this.groupList = groupList;
    }

    public static UnknownField DefaultInstance => UnknownField.defaultInstance;

    public IList<ulong> VarintList => (IList<ulong>) this.varintList;

    public IList<uint> Fixed32List => (IList<uint>) this.fixed32List;

    public IList<ulong> Fixed64List => (IList<ulong>) this.fixed64List;

    public IList<ByteString> LengthDelimitedList => (IList<ByteString>) this.lengthDelimitedList;

    public IList<UnknownFieldSet> GroupList => (IList<UnknownFieldSet>) this.groupList;

    public override bool Equals(object other)
    {
      if (object.ReferenceEquals((object) this, other))
        return true;
      return other is UnknownField unknownField && Lists.Equals<ulong>((IList<ulong>) this.varintList, (IList<ulong>) unknownField.varintList) && Lists.Equals<uint>((IList<uint>) this.fixed32List, (IList<uint>) unknownField.fixed32List) && Lists.Equals<ulong>((IList<ulong>) this.fixed64List, (IList<ulong>) unknownField.fixed64List) && Lists.Equals<ByteString>((IList<ByteString>) this.lengthDelimitedList, (IList<ByteString>) unknownField.lengthDelimitedList) && Lists.Equals<UnknownFieldSet>((IList<UnknownFieldSet>) this.groupList, (IList<UnknownFieldSet>) unknownField.groupList);
    }

    public override int GetHashCode()
    {
      return ((((43 * 47 + Lists.GetHashCode<ulong>((IList<ulong>) this.varintList)) * 47 + Lists.GetHashCode<uint>((IList<uint>) this.fixed32List)) * 47 + Lists.GetHashCode<ulong>((IList<ulong>) this.fixed64List)) * 47 + Lists.GetHashCode<ByteString>((IList<ByteString>) this.lengthDelimitedList)) * 47 + Lists.GetHashCode<UnknownFieldSet>((IList<UnknownFieldSet>) this.groupList);
    }

    public static UnknownField.Builder CreateBuilder() => new UnknownField.Builder();

    public static UnknownField.Builder CreateBuilder(UnknownField copyFrom)
    {
      return new UnknownField.Builder().MergeFrom(copyFrom);
    }

    public void WriteTo(int fieldNumber, CodedOutputStream output)
    {
      foreach (ulong varint in this.varintList)
        output.WriteUInt64(fieldNumber, varint);
      foreach (uint fixed32 in this.fixed32List)
        output.WriteFixed32(fieldNumber, fixed32);
      foreach (ulong fixed64 in this.fixed64List)
        output.WriteFixed64(fieldNumber, fixed64);
      foreach (ByteString lengthDelimited in this.lengthDelimitedList)
        output.WriteBytes(fieldNumber, lengthDelimited);
      foreach (UnknownFieldSet group in this.groupList)
        output.WriteUnknownGroup(fieldNumber, (IMessageLite) group);
    }

    public int GetSerializedSize(int fieldNumber)
    {
      int serializedSize = 0;
      foreach (ulong varint in this.varintList)
        serializedSize += CodedOutputStream.ComputeUInt64Size(fieldNumber, varint);
      foreach (uint fixed32 in this.fixed32List)
        serializedSize += CodedOutputStream.ComputeFixed32Size(fieldNumber, fixed32);
      foreach (ulong fixed64 in this.fixed64List)
        serializedSize += CodedOutputStream.ComputeFixed64Size(fieldNumber, fixed64);
      foreach (ByteString lengthDelimited in this.lengthDelimitedList)
        serializedSize += CodedOutputStream.ComputeBytesSize(fieldNumber, lengthDelimited);
      foreach (UnknownFieldSet group in this.groupList)
        serializedSize += CodedOutputStream.ComputeUnknownGroupSize(fieldNumber, (IMessageLite) group);
      return serializedSize;
    }

    public void WriteAsMessageSetExtensionTo(int fieldNumber, CodedOutputStream output)
    {
      foreach (ByteString lengthDelimited in this.lengthDelimitedList)
        output.WriteRawMessageSetExtension(fieldNumber, lengthDelimited);
    }

    public int GetSerializedSizeAsMessageSetExtension(int fieldNumber)
    {
      int messageSetExtension = 0;
      foreach (ByteString lengthDelimited in this.lengthDelimitedList)
        messageSetExtension += CodedOutputStream.ComputeRawMessageSetExtensionSize(fieldNumber, lengthDelimited);
      return messageSetExtension;
    }

    public sealed class Builder
    {
      private List<ulong> varintList;
      private List<uint> fixed32List;
      private List<ulong> fixed64List;
      private List<ByteString> lengthDelimitedList;
      private List<UnknownFieldSet> groupList;

      public UnknownField Build()
      {
        return new UnknownField(UnknownField.Builder.MakeReadOnly<ulong>(ref this.varintList), UnknownField.Builder.MakeReadOnly<uint>(ref this.fixed32List), UnknownField.Builder.MakeReadOnly<ulong>(ref this.fixed64List), UnknownField.Builder.MakeReadOnly<ByteString>(ref this.lengthDelimitedList), UnknownField.Builder.MakeReadOnly<UnknownFieldSet>(ref this.groupList));
      }

      public UnknownField.Builder MergeFrom(UnknownField other)
      {
        this.varintList = UnknownField.Builder.AddAll<ulong>(this.varintList, other.VarintList);
        this.fixed32List = UnknownField.Builder.AddAll<uint>(this.fixed32List, other.Fixed32List);
        this.fixed64List = UnknownField.Builder.AddAll<ulong>(this.fixed64List, other.Fixed64List);
        this.lengthDelimitedList = UnknownField.Builder.AddAll<ByteString>(this.lengthDelimitedList, other.LengthDelimitedList);
        this.groupList = UnknownField.Builder.AddAll<UnknownFieldSet>(this.groupList, other.GroupList);
        return this;
      }

      private static List<T> AddAll<T>(List<T> current, IList<T> extras)
      {
        if (extras.Count == 0)
          return current;
        if (current == null)
          current = new List<T>((IEnumerable<T>) extras);
        else
          current.AddRange((IEnumerable<T>) extras);
        return current;
      }

      public UnknownField.Builder Clear()
      {
        this.varintList = (List<ulong>) null;
        this.fixed32List = (List<uint>) null;
        this.fixed64List = (List<ulong>) null;
        this.lengthDelimitedList = (List<ByteString>) null;
        this.groupList = (List<UnknownFieldSet>) null;
        return this;
      }

      [CLSCompliant(false)]
      public UnknownField.Builder AddVarint(ulong value)
      {
        this.varintList = UnknownField.Builder.Add<ulong>(this.varintList, value);
        return this;
      }

      [CLSCompliant(false)]
      public UnknownField.Builder AddFixed32(uint value)
      {
        this.fixed32List = UnknownField.Builder.Add<uint>(this.fixed32List, value);
        return this;
      }

      [CLSCompliant(false)]
      public UnknownField.Builder AddFixed64(ulong value)
      {
        this.fixed64List = UnknownField.Builder.Add<ulong>(this.fixed64List, value);
        return this;
      }

      public UnknownField.Builder AddLengthDelimited(ByteString value)
      {
        this.lengthDelimitedList = UnknownField.Builder.Add<ByteString>(this.lengthDelimitedList, value);
        return this;
      }

      public UnknownField.Builder AddGroup(UnknownFieldSet value)
      {
        this.groupList = UnknownField.Builder.Add<UnknownFieldSet>(this.groupList, value);
        return this;
      }

      private static List<T> Add<T>(List<T> list, T value)
      {
        if (list == null)
          list = new List<T>();
        list.Add(value);
        return list;
      }

      private static ReadOnlyCollection<T> MakeReadOnly<T>(ref List<T> list)
      {
        ReadOnlyCollection<T> readOnlyCollection = list == null ? Lists<T>.Empty : new ReadOnlyCollection<T>((IList<T>) list);
        list = (List<T>) null;
        return readOnlyCollection;
      }
    }
  }
}
