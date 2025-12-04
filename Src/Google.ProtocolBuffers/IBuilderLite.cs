// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IBuilderLite
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IBuilderLite
  {
    bool IsInitialized { get; }

    IBuilderLite WeakClear();

    IBuilderLite WeakMergeFrom(IMessageLite message);

    IBuilderLite WeakMergeFrom(ByteString data);

    IBuilderLite WeakMergeFrom(ByteString data, ExtensionRegistry registry);

    IBuilderLite WeakMergeFrom(CodedInputStream input);

    IBuilderLite WeakMergeFrom(CodedInputStream input, ExtensionRegistry registry);

    IMessageLite WeakBuild();

    IMessageLite WeakBuildPartial();

    IBuilderLite WeakClone();

    IMessageLite WeakDefaultInstanceForType { get; }
  }
}
