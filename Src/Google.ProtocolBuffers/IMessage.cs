// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IMessage
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IMessage : IMessageLite
  {
    MessageDescriptor DescriptorForType { get; }

    IDictionary<FieldDescriptor, object> AllFields { get; }

    bool HasField(FieldDescriptor field);

    object this[FieldDescriptor field] { get; }

    int GetRepeatedFieldCount(FieldDescriptor field);

    object this[FieldDescriptor field, int index] { get; }

    UnknownFieldSet UnknownFields { get; }

    new bool IsInitialized { get; }

    new void WriteTo(CodedOutputStream output);

    new void WriteDelimitedTo(Stream output);

    new int SerializedSize { get; }

    new bool Equals(object other);

    new int GetHashCode();

    new string ToString();

    new ByteString ToByteString();

    new byte[] ToByteArray();

    new void WriteTo(Stream output);

    IBuilder WeakCreateBuilderForType();

    IBuilder WeakToBuilder();

    IMessage WeakDefaultInstanceForType { get; }
  }
}
