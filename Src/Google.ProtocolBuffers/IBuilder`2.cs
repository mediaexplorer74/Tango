// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IBuilder`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IBuilder<TMessage, TBuilder> : 
    IBuilder,
    IBuilderLite<TMessage, TBuilder>,
    IBuilderLite
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    TBuilder SetUnknownFields(UnknownFieldSet unknownFields);

    new TBuilder Clear();

    TBuilder MergeFrom(IMessage other);

    new TMessage Build();

    new TMessage BuildPartial();

    new TBuilder Clone();

    new TBuilder MergeFrom(CodedInputStream input);

    new TBuilder MergeFrom(CodedInputStream input, ExtensionRegistry extensionRegistry);

    new TMessage DefaultInstanceForType { get; }

    TBuilder ClearField(FieldDescriptor field);

    TBuilder AddRepeatedField(FieldDescriptor field, object value);

    TBuilder MergeUnknownFields(UnknownFieldSet unknownFields);

    new TBuilder MergeDelimitedFrom(Stream input);

    new TBuilder MergeDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry);

    new TBuilder MergeFrom(ByteString data);

    new TBuilder MergeFrom(ByteString data, ExtensionRegistry extensionRegistry);

    new TBuilder MergeFrom(byte[] data);

    new TBuilder MergeFrom(byte[] data, ExtensionRegistry extensionRegistry);

    new TBuilder MergeFrom(Stream input);

    new TBuilder MergeFrom(Stream input, ExtensionRegistry extensionRegistry);
  }
}
