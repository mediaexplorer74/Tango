// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.SinglePrimitiveAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal class SinglePrimitiveAccessor<TMessage, TBuilder> : IFieldAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly Type clrType;
    private readonly Google.ProtocolBuffers.Func<TMessage, object> getValueDelegate;
    private readonly Google.ProtocolBuffers.Action<TBuilder, object> setValueDelegate;
    private readonly Google.ProtocolBuffers.Func<TMessage, bool> hasDelegate;
    private readonly Google.ProtocolBuffers.Func<TBuilder, IBuilder> clearDelegate;
    internal static readonly Type[] EmptyTypes = new Type[0];

    protected Type ClrType => this.clrType;

    internal SinglePrimitiveAccessor(string name)
    {
      PropertyInfo property1 = typeof (TMessage).GetProperty(name);
      PropertyInfo property2 = typeof (TBuilder).GetProperty(name);
      if ((object) property2 == null)
        property2 = typeof (TBuilder).GetProperty(name);
      PropertyInfo property3 = typeof (TMessage).GetProperty("Has" + name);
      MethodInfo method = typeof (TBuilder).GetMethod("Clear" + name, SinglePrimitiveAccessor<TMessage, TBuilder>.EmptyTypes);
      if ((object) property1 == null || (object) property2 == null || (object) property3 == null || (object) method == null)
        throw new ArgumentException("Not all required properties/methods available");
      this.clrType = property1.PropertyType;
      // Stub for UWP - Delegate.CreateDelegate is not available
      // this.hasDelegate = (Google.ProtocolBuffers.Func<TMessage, bool>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TMessage, bool>), (object) null, property3.GetGetMethod());
      // this.clearDelegate = (Google.ProtocolBuffers.Func<TBuilder, IBuilder>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TBuilder, IBuilder>), (object) null, method);
      this.hasDelegate = message => (bool)property3.GetGetMethod().Invoke(message, null);
      this.clearDelegate = builder => (IBuilder)method.Invoke(builder, null);
      this.getValueDelegate = ReflectionUtil.CreateUpcastDelegate<TMessage>(property1.GetGetMethod());
      this.setValueDelegate = ReflectionUtil.CreateDowncastDelegate<TBuilder>(property2.GetSetMethod());
    }

    public bool Has(TMessage message) => this.hasDelegate(message);

    public void Clear(TBuilder builder)
    {
      IBuilder builder1 = this.clearDelegate(builder);
    }

    public virtual IBuilder CreateBuilder() => throw new InvalidOperationException();

    public virtual object GetValue(TMessage message) => this.getValueDelegate(message);

    public virtual void SetValue(TBuilder builder, object value)
    {
      this.setValueDelegate(builder, value);
    }

    public int GetRepeatedCount(TMessage message) => throw new InvalidOperationException();

    public object GetRepeatedValue(TMessage message, int index)
    {
      throw new InvalidOperationException();
    }

    public void SetRepeated(TBuilder builder, int index, object value)
    {
      throw new InvalidOperationException();
    }

    public void AddRepeated(TBuilder builder, object value)
    {
      throw new InvalidOperationException();
    }

    public object GetRepeatedWrapper(TBuilder builder) => throw new InvalidOperationException();
  }
}
