// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.AbstractMessageLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class AbstractMessageLite<TMessage, TBuilder> : 
    IMessageLite<TMessage, TBuilder>,
    IMessageLite<TMessage>,
    IMessageLite
    where TMessage : AbstractMessageLite<TMessage, TBuilder>
    where TBuilder : AbstractBuilderLite<TMessage, TBuilder>
  {
    public abstract TBuilder CreateBuilderForType();

    public abstract TBuilder ToBuilder();

    public abstract TMessage DefaultInstanceForType { get; }

    public abstract bool IsInitialized { get; }

    public abstract void WriteTo(CodedOutputStream output);

    public abstract int SerializedSize { get; }

    public abstract void PrintTo(TextWriter writer);

    public ByteString ToByteString()
    {
      ByteString.CodedBuilder codedBuilder = new ByteString.CodedBuilder(this.SerializedSize);
      this.WriteTo(codedBuilder.CodedOutput);
      return codedBuilder.Build();
    }

    public byte[] ToByteArray()
    {
      byte[] flatArray = new byte[this.SerializedSize];
      CodedOutputStream instance = CodedOutputStream.CreateInstance(flatArray);
      this.WriteTo(instance);
      instance.CheckNoSpaceLeft();
      return flatArray;
    }

    public void WriteTo(Stream output)
    {
      CodedOutputStream instance = CodedOutputStream.CreateInstance(output);
      this.WriteTo(instance);
      instance.Flush();
    }

    public void WriteDelimitedTo(Stream output)
    {
      CodedOutputStream instance = CodedOutputStream.CreateInstance(output);
      instance.WriteRawVarint32((uint) this.SerializedSize);
      this.WriteTo(instance);
      instance.Flush();
    }

    IBuilderLite IMessageLite.WeakCreateBuilderForType()
    {
      return (IBuilderLite) this.CreateBuilderForType();
    }

    IBuilderLite IMessageLite.WeakToBuilder() => (IBuilderLite) this.ToBuilder();

    IMessageLite IMessageLite.WeakDefaultInstanceForType
    {
      get => (IMessageLite) this.DefaultInstanceForType;
    }
  }
}
