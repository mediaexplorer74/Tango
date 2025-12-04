// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.SingleMessageAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal sealed class SingleMessageAccessor<TMessage, TBuilder> : 
    SinglePrimitiveAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly Google.ProtocolBuffers.Func<IBuilder> createBuilderDelegate;

    internal SingleMessageAccessor(string name)
      : base(name)
    {
      this.createBuilderDelegate = ReflectionUtil.CreateStaticUpcastDelegate(this.ClrType.GetMethod("CreateBuilder", SinglePrimitiveAccessor<TMessage, TBuilder>.EmptyTypes) ?? throw new ArgumentException("No public static CreateBuilder method declared in " + this.ClrType.Name));
    }

    private object CoerceType(object value)
    {
      Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, nameof (value));
      if (this.ClrType.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()))
        return value;
      IMessageLite message = (IMessageLite) value;
      return (object) this.CreateBuilder().WeakMergeFrom(message).WeakBuild();
    }

    public override void SetValue(TBuilder builder, object value)
    {
      base.SetValue(builder, this.CoerceType(value));
    }

    public override IBuilder CreateBuilder() => this.createBuilderDelegate();
  }
}
