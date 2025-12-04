// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.ServiceDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class ServiceDescriptor : 
    IndexedDescriptorBase<ServiceDescriptorProto, ServiceOptions>
  {
    private readonly IList<MethodDescriptor> methods;

    public ServiceDescriptor(ServiceDescriptorProto proto, FileDescriptor file, int index)
      : base(proto, file, DescriptorBase<ServiceDescriptorProto, ServiceOptions>.ComputeFullName(file, (MessageDescriptor) null, proto.Name), index)
    {
      ServiceDescriptor parent = this;
      this.methods = DescriptorUtil.ConvertAndMakeReadOnly<MethodDescriptorProto, MethodDescriptor>(proto.MethodList, (DescriptorUtil.IndexedConverter<MethodDescriptorProto, MethodDescriptor>) ((method, i) => new MethodDescriptor(method, file, parent, i)));
      file.DescriptorPool.AddSymbol((IDescriptor) this);
    }

    public IList<MethodDescriptor> Methods => this.methods;

    public MethodDescriptor FindMethodByName(string name)
    {
      return this.File.DescriptorPool.FindSymbol<MethodDescriptor>(this.FullName + "." + name);
    }

    internal void CrossLink()
    {
      foreach (MethodDescriptor method in (IEnumerable<MethodDescriptor>) this.methods)
        method.CrossLink();
    }

    internal override void ReplaceProto(ServiceDescriptorProto newProto)
    {
      base.ReplaceProto(newProto);
      for (int index = 0; index < this.methods.Count; ++index)
        this.methods[index].ReplaceProto(newProto.GetMethod(index));
    }
  }
}
