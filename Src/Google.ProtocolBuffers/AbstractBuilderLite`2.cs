// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.AbstractBuilderLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class AbstractBuilderLite<TMessage, TBuilder> : 
    IBuilderLite<TMessage, TBuilder>,
    IBuilderLite
    where TMessage : AbstractMessageLite<TMessage, TBuilder>
    where TBuilder : AbstractBuilderLite<TMessage, TBuilder>
  {
    protected abstract TBuilder ThisBuilder { get; }

    public abstract bool IsInitialized { get; }

    public abstract TBuilder Clear();

    public abstract TBuilder Clone();

    public abstract TMessage Build();

    public abstract TMessage BuildPartial();

    public abstract TBuilder MergeFrom(IMessageLite other);

    public abstract TBuilder MergeFrom(CodedInputStream input, ExtensionRegistry extensionRegistry);

    public abstract TMessage DefaultInstanceForType { get; }

    public virtual TBuilder MergeFrom(CodedInputStream input)
    {
      return this.MergeFrom(input, ExtensionRegistry.CreateInstance());
    }

    public TBuilder MergeDelimitedFrom(Stream input)
    {
      return this.MergeDelimitedFrom(input, ExtensionRegistry.CreateInstance());
    }

    public TBuilder MergeDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      int size = (int) CodedInputStream.ReadRawVarint32(input);
      return this.MergeFrom((Stream) new AbstractBuilderLite<TMessage, TBuilder>.LimitedInputStream(input, size), extensionRegistry);
    }

    public TBuilder MergeFrom(ByteString data)
    {
      return this.MergeFrom(data, ExtensionRegistry.CreateInstance());
    }

    public TBuilder MergeFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      CodedInputStream codedInput = data.CreateCodedInput();
      this.MergeFrom(codedInput, extensionRegistry);
      codedInput.CheckLastTagWas(0U);
      return this.ThisBuilder;
    }

    public TBuilder MergeFrom(byte[] data)
    {
      CodedInputStream instance = CodedInputStream.CreateInstance(data);
      this.MergeFrom(instance);
      instance.CheckLastTagWas(0U);
      return this.ThisBuilder;
    }

    public TBuilder MergeFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      CodedInputStream instance = CodedInputStream.CreateInstance(data);
      this.MergeFrom(instance, extensionRegistry);
      instance.CheckLastTagWas(0U);
      return this.ThisBuilder;
    }

    public TBuilder MergeFrom(Stream input)
    {
      CodedInputStream instance = CodedInputStream.CreateInstance(input);
      this.MergeFrom(instance);
      instance.CheckLastTagWas(0U);
      return this.ThisBuilder;
    }

    public TBuilder MergeFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      CodedInputStream instance = CodedInputStream.CreateInstance(input);
      this.MergeFrom(instance, extensionRegistry);
      instance.CheckLastTagWas(0U);
      return this.ThisBuilder;
    }

    IBuilderLite IBuilderLite.WeakClear() => (IBuilderLite) this.Clear();

    IBuilderLite IBuilderLite.WeakMergeFrom(IMessageLite message)
    {
      return (IBuilderLite) this.MergeFrom(message);
    }

    IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data) => (IBuilderLite) this.MergeFrom(data);

    IBuilderLite IBuilderLite.WeakMergeFrom(ByteString data, ExtensionRegistry registry)
    {
      return (IBuilderLite) this.MergeFrom(data, registry);
    }

    IBuilderLite IBuilderLite.WeakMergeFrom(CodedInputStream input)
    {
      return (IBuilderLite) this.MergeFrom(input);
    }

    IBuilderLite IBuilderLite.WeakMergeFrom(CodedInputStream input, ExtensionRegistry registry)
    {
      return (IBuilderLite) this.MergeFrom(input, registry);
    }

    IMessageLite IBuilderLite.WeakBuild() => (IMessageLite) this.Build();

    IMessageLite IBuilderLite.WeakBuildPartial() => (IMessageLite) this.BuildPartial();

    IBuilderLite IBuilderLite.WeakClone() => (IBuilderLite) this.Clone();

    IMessageLite IBuilderLite.WeakDefaultInstanceForType
    {
      get => (IMessageLite) this.DefaultInstanceForType;
    }

    private class LimitedInputStream : Stream
    {
      private readonly Stream proxied;
      private int bytesLeft;

      internal LimitedInputStream(Stream proxied, int size)
      {
        this.proxied = proxied;
        this.bytesLeft = size;
      }

      public override bool CanRead => true;

      public override bool CanSeek => false;

      public override bool CanWrite => false;

      public override void Flush()
      {
      }

      public override long Length => throw new NotSupportedException();

      public override long Position
      {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
      }

      public override int Read(byte[] buffer, int offset, int count)
      {
        if (this.bytesLeft <= 0)
          return 0;
        int num = this.proxied.Read(buffer, offset, Math.Min(this.bytesLeft, count));
        this.bytesLeft -= num;
        return num;
      }

      public override long Seek(long offset, SeekOrigin origin)
      {
        throw new NotSupportedException();
      }

      public override void SetLength(long value) => throw new NotSupportedException();

      public override void Write(byte[] buffer, int offset, int count)
      {
        throw new NotSupportedException();
      }
    }
  }
}
