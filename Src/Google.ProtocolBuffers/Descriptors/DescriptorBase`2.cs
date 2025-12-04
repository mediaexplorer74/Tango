// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.DescriptorBase`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public abstract class DescriptorBase<TProto, TOptions> : IDescriptor<TProto>, IDescriptor where TProto : IMessage, IDescriptorProto<TOptions>
  {
    private TProto proto;
    private readonly FileDescriptor file;
    private readonly string fullName;

    protected DescriptorBase(TProto proto, FileDescriptor file, string fullName)
    {
      this.proto = proto;
      this.file = file;
      this.fullName = fullName;
    }

    internal virtual void ReplaceProto(TProto newProto) => this.proto = newProto;

    protected static string ComputeFullName(
      FileDescriptor file,
      MessageDescriptor parent,
      string name)
    {
      if (parent != null)
        return parent.FullName + "." + name;
      return file.Package.Length > 0 ? file.Package + "." + name : name;
    }

    IMessage IDescriptor.Proto => (IMessage) this.proto;

    public TProto Proto => this.proto;

    public TOptions Options => this.proto.Options;

    public string FullName => this.fullName;

    public string Name => this.proto.Name;

    public FileDescriptor File => this.file;
  }
}
