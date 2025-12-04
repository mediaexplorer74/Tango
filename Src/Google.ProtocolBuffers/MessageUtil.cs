// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.MessageUtil
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers
{
  public static class MessageUtil
  {
    public static IMessage GetDefaultMessage(Type type)
    {
      if ((object) type == null)
        throw new ArgumentNullException(nameof (type), "No type specified.");
      if (type.GetTypeInfo().IsAbstract || type.GetTypeInfo().IsGenericTypeDefinition)
        throw new ArgumentException("Unable to get a default message for an abstract or generic type (" + type.FullName + ")");
      PropertyInfo propertyInfo = typeof (IMessage).IsAssignableFrom(type) ? type.GetProperty("DefaultInstance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) : throw new ArgumentException("Unable to get a default message for non-message type (" + type.FullName + ")");
      if ((object) propertyInfo == null)
        throw new ArgumentException(type.FullName + " doesn't have a static DefaultInstance property");
      if ((object) propertyInfo.PropertyType != (object) type)
        throw new ArgumentException(type.FullName + ".DefaultInstance property is of the wrong type");
      return (IMessage) propertyInfo.GetValue((object) null, (object[]) null);
    }

    public static IMessage GetDefaultMessage(string typeName)
    {
      return MessageUtil.GetDefaultMessage((typeName != null ? Type.GetType(typeName) : throw new ArgumentNullException(nameof (typeName), "No type name specified.")) ?? throw new ArgumentException("Unable to load type " + typeName));
    }
  }
}
