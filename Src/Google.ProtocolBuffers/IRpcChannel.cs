// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IRpcChannel
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IRpcChannel
  {
    void CallMethod(
      MethodDescriptor method,
      IRpcController controller,
      IMessage request,
      IMessage responsePrototype,
      Action<IMessage> done);
  }
}
