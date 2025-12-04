// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.IDescriptorProto`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public interface IDescriptorProto<TOptions>
  {
    string Name { get; }

    TOptions Options { get; }
  }
}
