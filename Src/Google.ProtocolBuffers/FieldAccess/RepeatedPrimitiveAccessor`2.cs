// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.RepeatedPrimitiveAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal class RepeatedPrimitiveAccessor<TMessage, TBuilder> : IFieldAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly Type clrType;
    private readonly Google.ProtocolBuffers.Func<TMessage, object> getValueDelegate;
    private readonly Google.ProtocolBuffers.Func<TBuilder, IBuilder> clearDelegate;
    private readonly Google.ProtocolBuffers.Action<TBuilder, object> addValueDelegate;
    private readonly Google.ProtocolBuffers.Func<TBuilder, object> getRepeatedWrapperDelegate;
    private readonly Google.ProtocolBuffers.Func<TMessage, int> countDelegate;
    private readonly MethodInfo getElementMethod;
    private readonly MethodInfo setElementMethod;
    internal static readonly Type[] EmptyTypes = new Type[0];

    protected Type ClrType => this.clrType;

    internal RepeatedPrimitiveAccessor(string name)
    {
      PropertyInfo property1 = typeof (TMessage).GetProperty(name + "List");
      PropertyInfo property2 = typeof (TBuilder).GetProperty(name + "List");
      PropertyInfo property3 = typeof (TMessage).GetProperty(name + "Count");
      MethodInfo method1 = typeof (TBuilder).GetMethod("Clear" + name, RepeatedPrimitiveAccessor<TMessage, TBuilder>.EmptyTypes);
      this.getElementMethod = typeof (TMessage).GetMethod("Get" + name, new Type[1]
      {
        typeof (int)
      });
      this.clrType = this.getElementMethod.ReturnType;
      MethodInfo method2 = typeof (TBuilder).GetMethod("Add" + name, new Type[1]
      {
        this.ClrType
      });
      this.setElementMethod = typeof (TBuilder).GetMethod("Set" + name, new Type[2]
      {
        typeof (int),
        this.ClrType
      });
      if ((object) property1 == null || (object) property2 == null || (object) property3 == null || (object) method1 == null || (object) method2 == null || (object) this.getElementMethod == null || (object) this.setElementMethod == null)
        throw new ArgumentException("Not all required properties/methods available");
      // Stub for UWP - Delegate.CreateDelegate is not available
      // this.clearDelegate = (Google.ProtocolBuffers.Func<TBuilder, IBuilder>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TBuilder, IBuilder>), (object) null, method1);
      // this.countDelegate = (Google.ProtocolBuffers.Func<TMessage, int>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TMessage, int>), (object) null, property3.GetGetMethod());
      this.clearDelegate = builder => (IBuilder)method1.Invoke(builder, null);
      this.countDelegate = message => (int)property3.GetGetMethod().Invoke(message, null);
      this.getValueDelegate = ReflectionUtil.CreateUpcastDelegate<TMessage>(property1.GetGetMethod());
      this.addValueDelegate = ReflectionUtil.CreateDowncastDelegateIgnoringReturn<TBuilder>(method2);
      this.getRepeatedWrapperDelegate = ReflectionUtil.CreateUpcastDelegate<TBuilder>(property2.GetGetMethod());
    }

    public bool Has(TMessage message) => throw new InvalidOperationException();

    public virtual IBuilder CreateBuilder() => throw new InvalidOperationException();

    public virtual object GetValue(TMessage message) => this.getValueDelegate(message);

    public void SetValue(TBuilder builder, object value)
    {
      this.Clear(builder);
      foreach (object obj in (IEnumerable) value)
        this.AddRepeated(builder, obj);
    }

    public void Clear(TBuilder builder)
    {
      IBuilder builder1 = this.clearDelegate(builder);
    }

    public int GetRepeatedCount(TMessage message) => this.countDelegate(message);

    public virtual object GetRepeatedValue(TMessage message, int index)
    {
      return this.getElementMethod.Invoke((object) message, new object[1]
      {
        (object) index
      });
    }

    public virtual void SetRepeated(TBuilder builder, int index, object value)
    {
      Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, nameof (value));
      this.setElementMethod.Invoke((object) builder, new object[2]
      {
        (object) index,
        value
      });
    }

    public virtual void AddRepeated(TBuilder builder, object value)
    {
      Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, nameof (value));
      this.addValueDelegate(builder, value);
    }

    public object GetRepeatedWrapper(TBuilder builder) => this.getRepeatedWrapperDelegate(builder);
  }
}
