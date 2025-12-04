// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.EnumValueDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class EnumValueDescriptor : 
    IndexedDescriptorBase<EnumValueDescriptorProto, EnumValueOptions>,
    IEnumLite
  {
    private readonly EnumDescriptor enumDescriptor;

    internal EnumValueDescriptor(
      EnumValueDescriptorProto proto,
      FileDescriptor file,
      EnumDescriptor parent,
      int index)
      : base(proto, file, parent.FullName + "." + proto.Name, index)
    {
      this.enumDescriptor = parent;
      file.DescriptorPool.AddSymbol((IDescriptor) this);
      file.DescriptorPool.AddEnumValueByNumber(this);
    }

    public int Number => this.Proto.Number;

    public EnumDescriptor EnumDescriptor => this.enumDescriptor;
  }
}
