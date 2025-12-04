// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.MessageStreamWriter`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class MessageStreamWriter<T> where T : IMessage<T>
  {
    private readonly CodedOutputStream codedOutput;

    public MessageStreamWriter(Stream output)
    {
      this.codedOutput = CodedOutputStream.CreateInstance(output);
    }

    public void Write(T message) => this.codedOutput.WriteMessage(1, (IMessageLite) message);

    public void Flush() => this.codedOutput.Flush();
  }
}
