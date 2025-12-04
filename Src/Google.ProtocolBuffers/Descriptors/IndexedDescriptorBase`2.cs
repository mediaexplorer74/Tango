// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.IndexedDescriptorBase`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public abstract class IndexedDescriptorBase<TProto, TOptions> : DescriptorBase<TProto, TOptions> where TProto : IMessage<TProto>, IDescriptorProto<TOptions>
  {
    private readonly int index;

    protected IndexedDescriptorBase(TProto proto, FileDescriptor file, string fullName, int index)
      : base(proto, file, fullName)
    {
      this.index = index;
    }

    public int Index => this.index;
  }
}
