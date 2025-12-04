// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.DescriptorValidationException
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class DescriptorValidationException : Exception
  {
    private readonly string name;
    private readonly IMessage proto;
    private readonly string description;

    public string ProblemSymbolName => this.name;

    public IMessage ProblemProto => this.proto;

    public string Description => this.description;

    internal DescriptorValidationException(IDescriptor problemDescriptor, string description)
      : base(problemDescriptor.FullName + ": " + description)
    {
      this.name = problemDescriptor.FullName;
      this.proto = problemDescriptor.Proto;
      this.description = description;
    }

    internal DescriptorValidationException(
      IDescriptor problemDescriptor,
      string description,
      Exception cause)
      : base(problemDescriptor.FullName + ": " + description, cause)
    {
      this.name = problemDescriptor.FullName;
      this.proto = problemDescriptor.Proto;
      this.description = description;
    }
  }
}
