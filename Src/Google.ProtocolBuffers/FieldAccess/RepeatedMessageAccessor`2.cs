// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.RepeatedMessageAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal sealed class RepeatedMessageAccessor<TMessage, TBuilder> : 
    RepeatedPrimitiveAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly Google.ProtocolBuffers.Func<IBuilder> createBuilderDelegate;

    internal RepeatedMessageAccessor(string name)
      : base(name)
    {
      this.createBuilderDelegate = ReflectionUtil.CreateStaticUpcastDelegate(this.ClrType.GetMethod("CreateBuilder", RepeatedPrimitiveAccessor<TMessage, TBuilder>.EmptyTypes) ?? throw new ArgumentException("No public static CreateBuilder method declared in " + this.ClrType.Name));
    }

    private object CoerceType(object value)
    {
      Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, nameof (value));
      if (this.ClrType.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()))
        return value;
      IMessageLite message = (IMessageLite) value;
      return (object) this.CreateBuilder().WeakMergeFrom(message).WeakBuild();
    }

    public override void SetRepeated(TBuilder builder, int index, object value)
    {
      base.SetRepeated(builder, index, this.CoerceType(value));
    }

    public override IBuilder CreateBuilder() => this.createBuilderDelegate();

    public override void AddRepeated(TBuilder builder, object value)
    {
      base.AddRepeated(builder, this.CoerceType(value));
    }
  }
}
