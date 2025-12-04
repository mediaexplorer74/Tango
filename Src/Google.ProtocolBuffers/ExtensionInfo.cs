// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtensionInfo
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class ExtensionInfo : IGeneratedExtensionLite
  {
    public FieldDescriptor Descriptor { get; private set; }

    IFieldDescriptorLite IGeneratedExtensionLite.Descriptor
    {
      get => (IFieldDescriptorLite) this.Descriptor;
    }

    public IMessageLite DefaultInstance { get; private set; }

    internal ExtensionInfo(FieldDescriptor descriptor)
      : this(descriptor, (IMessageLite) null)
    {
    }

    internal ExtensionInfo(FieldDescriptor descriptor, IMessageLite defaultInstance)
    {
      this.Descriptor = descriptor;
      this.DefaultInstance = defaultInstance;
    }

    int IGeneratedExtensionLite.Number => this.Descriptor.FieldNumber;

    object IGeneratedExtensionLite.ContainingType => (object) this.Descriptor;

    IMessageLite IGeneratedExtensionLite.MessageDefaultInstance => this.DefaultInstance;
  }
}
