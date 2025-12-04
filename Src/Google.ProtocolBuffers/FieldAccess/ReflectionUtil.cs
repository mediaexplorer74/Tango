// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.ReflectionUtil
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal static class ReflectionUtil
  {
    public static Google.ProtocolBuffers.Func<T, object> CreateUpcastDelegate<T>(MethodInfo method)
    {
      return (Google.ProtocolBuffers.Func<T, object>) typeof (ReflectionUtil).GetMethod("CreateUpcastDelegateImpl").MakeGenericMethod(typeof (T), method.ReturnType).Invoke((object) null, new object[1]
      {
        (object) method
      });
    }

    public static Google.ProtocolBuffers.Func<TSource, object> CreateUpcastDelegateImpl<TSource, TResult>(
      MethodInfo method)
    {
      // Stub for UWP - Delegate.CreateDelegate is not available
      // Google.ProtocolBuffers.Func<TSource, TResult> getter = (Google.ProtocolBuffers.Func<TSource, TResult>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TSource, TResult>), (object) null, method);
      return (Google.ProtocolBuffers.Func<TSource, object>) (source => (object) method.Invoke((object) null, new object[1] { source }));
    }

    public static Google.ProtocolBuffers.Action<T, object> CreateDowncastDelegate<T>(
      MethodInfo method)
    {
      return (Google.ProtocolBuffers.Action<T, object>) typeof (ReflectionUtil).GetMethod("CreateDowncastDelegateImpl").MakeGenericMethod(typeof (T), method.GetParameters()[0].ParameterType).Invoke((object) null, new object[1]
      {
        (object) method
      });
    }

    public static Google.ProtocolBuffers.Action<TSource, object> CreateDowncastDelegateImpl<TSource, TParam>(
      MethodInfo method)
    {
      // Stub for UWP - Delegate.CreateDelegate is not available
      // Google.ProtocolBuffers.Action<TSource, TParam> call = (Google.ProtocolBuffers.Action<TSource, TParam>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Action<TSource, TParam>), (object) null, method);
      return (Google.ProtocolBuffers.Action<TSource, object>) ((source, parameter) => method.Invoke((object) null, new object[2] { source, parameter }));
    }

    public static Google.ProtocolBuffers.Action<T, object> CreateDowncastDelegateIgnoringReturn<T>(
      MethodInfo method)
    {
      return (Google.ProtocolBuffers.Action<T, object>) typeof (ReflectionUtil).GetMethod("CreateDowncastDelegateIgnoringReturnImpl").MakeGenericMethod(typeof (T), method.GetParameters()[0].ParameterType, method.ReturnType).Invoke((object) null, new object[1]
      {
        (object) method
      });
    }

    public static Google.ProtocolBuffers.Action<TSource, object> CreateDowncastDelegateIgnoringReturnImpl<TSource, TParam, TReturn>(
      MethodInfo method)
    {
      // Stub for UWP - Delegate.CreateDelegate is not available
      // Google.ProtocolBuffers.Func<TSource, TParam, TReturn> call = (Google.ProtocolBuffers.Func<TSource, TParam, TReturn>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<TSource, TParam, TReturn>), (object) null, method);
      return (Google.ProtocolBuffers.Action<TSource, object>) ((source, parameter) => method.Invoke((object) null, new object[2] { source, parameter }));
    }

    public static Google.ProtocolBuffers.Func<IBuilder> CreateStaticUpcastDelegate(MethodInfo method)
    {
      return (Google.ProtocolBuffers.Func<IBuilder>) typeof (ReflectionUtil).GetMethod("CreateStaticUpcastDelegateImpl").MakeGenericMethod(method.ReturnType).Invoke((object) null, new object[1]
      {
        (object) method
      });
    }

    public static Google.ProtocolBuffers.Func<IBuilder> CreateStaticUpcastDelegateImpl<T>(
      MethodInfo method)
    {
      // Stub for UWP - Delegate.CreateDelegate is not available
      // Google.ProtocolBuffers.Func<T> call = (Google.ProtocolBuffers.Func<T>) Delegate.CreateDelegate(typeof (Google.ProtocolBuffers.Func<T>), (object) null, method);
      return (Google.ProtocolBuffers.Func<IBuilder>) (() => (IBuilder) method.Invoke((object) null, null));
    }
  }
}
