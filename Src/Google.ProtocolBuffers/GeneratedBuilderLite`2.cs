// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedBuilderLite`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public abstract class GeneratedBuilderLite<TMessage, TBuilder> : 
    AbstractBuilderLite<TMessage, TBuilder>
    where TMessage : GeneratedMessageLite<TMessage, TBuilder>
    where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
  {
    protected abstract TMessage MessageBeingBuilt { get; }

    public override TBuilder MergeFrom(IMessageLite other) => this.ThisBuilder;

    public abstract TBuilder MergeFrom(TMessage other);

    public override bool IsInitialized => this.MessageBeingBuilt.IsInitialized;

    protected void AddRange<T>(IEnumerable<T> source, IList<T> destination)
    {
      ThrowHelper.ThrowIfNull((object) source);
      if ((object) default (T) == null)
        ThrowHelper.ThrowIfAnyNull<T>(source);
      if (destination is List<T> objList)
      {
        objList.AddRange(source);
      }
      else
      {
        foreach (T obj in source)
          destination.Add(obj);
      }
    }

    [CLSCompliant(false)]
    protected virtual bool ParseUnknownField(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry,
      uint tag)
    {
      return input.SkipField(tag);
    }

    public TMessage BuildParsed()
    {
      if (!this.IsInitialized)
        throw new UninitializedMessageException((IMessageLite) this.MessageBeingBuilt).AsInvalidProtocolBufferException();
      return this.BuildPartial();
    }

    public override TMessage Build()
    {
      if ((object) this.MessageBeingBuilt != null && !this.IsInitialized)
        throw new UninitializedMessageException((IMessageLite) this.MessageBeingBuilt);
      return this.BuildPartial();
    }
  }
}
