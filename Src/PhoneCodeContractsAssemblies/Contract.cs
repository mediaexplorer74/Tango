// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Contracts.Contract
// Assembly: PhoneCodeContractsAssemblies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D0A1BAE3-B9EF-44D4-B942-720D2D30E6F2
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\PhoneCodeContractsAssemblies.dll

#nullable disable
namespace System.Diagnostics.Contracts
{
  public static class Contract
  {
    public static void Assume(bool condition)
    {
    }

    public static void Ensures(bool condition)
    {
    }

    public static void Ensures(bool condition, string userMessage)
    {
    }

    public static void Invariant(bool condition)
    {
    }

    public static void Invariant(bool condition, string userMessage)
    {
    }

    public static void Requires(bool condition)
    {
    }

    public static void Requires<TException>(bool condition) where TException : Exception
    {
      if (!condition)
        throw (object) Activator.CreateInstance<TException>();
    }

    public static void Requires(bool condition, string userMessage)
    {
    }

    public static void Requires<TException>(bool condition, string userMessage) where TException : Exception
    {
      if (!condition)
        throw (object) (Activator.CreateInstance(typeof (TException), (object) userMessage) as TException);
    }

    public static T Result<T>() => default (T);
  }
}
