// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IBuilderLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IBuilderLite<TMessage, TBuilder> : IBuilderLite
    where TMessage : IMessageLite<TMessage, TBuilder>
    where TBuilder : IBuilderLite<TMessage, TBuilder>
  {
    TBuilder Clear();

    TBuilder MergeFrom(IMessageLite other);

    TMessage Build();

    TMessage BuildPartial();

    TBuilder Clone();

    TBuilder MergeFrom(CodedInputStream input);

    TBuilder MergeFrom(CodedInputStream input, ExtensionRegistry extensionRegistry);

    TMessage DefaultInstanceForType { get; }

    TBuilder MergeDelimitedFrom(Stream input);

    TBuilder MergeDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry);

    TBuilder MergeFrom(ByteString data);

    TBuilder MergeFrom(ByteString data, ExtensionRegistry extensionRegistry);

    TBuilder MergeFrom(byte[] data);

    TBuilder MergeFrom(byte[] data, ExtensionRegistry extensionRegistry);

    TBuilder MergeFrom(Stream input);

    TBuilder MergeFrom(Stream input, ExtensionRegistry extensionRegistry);
  }
}
