// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.PackageDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  internal sealed class PackageDescriptor : IDescriptor<IMessage>, IDescriptor
  {
    private readonly string name;
    private readonly string fullName;
    private readonly FileDescriptor file;

    internal PackageDescriptor(string name, string fullName, FileDescriptor file)
    {
      this.file = file;
      this.fullName = fullName;
      this.name = name;
    }

    public IMessage Proto => (IMessage) this.file.Proto;

    public string Name => this.name;

    public string FullName => this.fullName;

    public FileDescriptor File => this.file;
  }
}
