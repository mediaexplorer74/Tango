// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.RpcUtil
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public static class RpcUtil
  {
    public static Action<T> SpecializeCallback<T>(Action<IMessage> action) where T : IMessage<T>
    {
      return (Action<T>) (message => action((IMessage) message));
    }

    public static Action<IMessage> GeneralizeCallback<TMessage, TBuilder>(
      Action<TMessage> action,
      TMessage defaultInstance)
      where TMessage : class, IMessage<TMessage, TBuilder>
      where TBuilder : IBuilder<TMessage, TBuilder>
    {
      return (Action<IMessage>) (message =>
      {
        if (!(message is TMessage message2))
          message2 = defaultInstance.CreateBuilderForType().MergeFrom(message).Build();
        action(message2);
      });
    }
  }
}
