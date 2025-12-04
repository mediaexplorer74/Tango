// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IBuilder
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IBuilder : IBuilderLite
  {
    new bool IsInitialized { get; }

    IBuilder SetField(FieldDescriptor field, object value);

    IBuilder SetRepeatedField(FieldDescriptor field, int index, object value);

    IDictionary<FieldDescriptor, object> AllFields { get; }

    object this[FieldDescriptor field] { get; set; }

    MessageDescriptor DescriptorForType { get; }

    int GetRepeatedFieldCount(FieldDescriptor field);

    object this[FieldDescriptor field, int index] { get; set; }

    bool HasField(FieldDescriptor field);

    UnknownFieldSet UnknownFields { get; set; }

    IBuilder CreateBuilderForField(FieldDescriptor field);

    IBuilder WeakAddRepeatedField(FieldDescriptor field, object value);

    IBuilder WeakClear();

    IBuilder WeakClearField(FieldDescriptor field);

    IBuilder WeakMergeFrom(IMessage message);

    IBuilder WeakMergeFrom(ByteString data);

    IBuilder WeakMergeFrom(ByteString data, ExtensionRegistry registry);

    IBuilder WeakMergeFrom(CodedInputStream input);

    IBuilder WeakMergeFrom(CodedInputStream input, ExtensionRegistry registry);

    IMessage WeakBuild();

    IMessage WeakBuildPartial();

    IBuilder WeakClone();

    IMessage WeakDefaultInstanceForType { get; }
  }
}
