// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.MethodDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class MethodDescriptor : IndexedDescriptorBase<MethodDescriptorProto, MethodOptions>
  {
    private readonly ServiceDescriptor service;
    private MessageDescriptor inputType;
    private MessageDescriptor outputType;

    public ServiceDescriptor Service => this.service;

    public MessageDescriptor InputType => this.inputType;

    public MessageDescriptor OutputType => this.outputType;

    internal MethodDescriptor(
      MethodDescriptorProto proto,
      FileDescriptor file,
      ServiceDescriptor parent,
      int index)
      : base(proto, file, parent.FullName + "." + proto.Name, index)
    {
      this.service = parent;
      file.DescriptorPool.AddSymbol((IDescriptor) this);
    }

    internal void CrossLink()
    {
      IDescriptor descriptor1 = this.File.DescriptorPool.LookupSymbol(this.Proto.InputType, (IDescriptor) this);
      this.inputType = descriptor1 is MessageDescriptor ? (MessageDescriptor) descriptor1 : throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.InputType + "\" is not a message type.");
      IDescriptor descriptor2 = this.File.DescriptorPool.LookupSymbol(this.Proto.OutputType, (IDescriptor) this);
      this.outputType = descriptor2 is MessageDescriptor ? (MessageDescriptor) descriptor2 : throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.OutputType + "\" is not a message type.");
    }
  }
}
