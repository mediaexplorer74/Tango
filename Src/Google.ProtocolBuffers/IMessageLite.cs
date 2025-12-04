// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IMessageLite
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IMessageLite
  {
    bool IsInitialized { get; }

    void WriteTo(CodedOutputStream output);

    void WriteDelimitedTo(Stream output);

    int SerializedSize { get; }

    bool Equals(object other);

    int GetHashCode();

    string ToString();

    void PrintTo(TextWriter writer);

    ByteString ToByteString();

    byte[] ToByteArray();

    void WriteTo(Stream output);

    IBuilderLite WeakCreateBuilderForType();

    IBuilderLite WeakToBuilder();

    IMessageLite WeakDefaultInstanceForType { get; }
  }
}
