// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.UninitializedMessageException
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class UninitializedMessageException : Exception
  {
    private readonly IList<string> missingFields;

    private UninitializedMessageException(IList<string> missingFields)
      : base(UninitializedMessageException.BuildDescription((IEnumerable<string>) missingFields))
    {
      this.missingFields = (IList<string>) new List<string>((IEnumerable<string>) missingFields);
    }

    public IList<string> MissingFields => this.missingFields;

    public InvalidProtocolBufferException AsInvalidProtocolBufferException()
    {
      return new InvalidProtocolBufferException(this.Message);
    }

    private static string BuildDescription(IEnumerable<string> missingFields)
    {
      StringBuilder stringBuilder = new StringBuilder("Message missing required fields: ");
      bool flag = true;
      foreach (string missingField in missingFields)
      {
        if (flag)
          flag = false;
        else
          stringBuilder.Append(", ");
        stringBuilder.Append(missingField);
      }
      return stringBuilder.ToString();
    }

    public UninitializedMessageException(IMessageLite message)
      : base(string.Format("Message {0} is missing required fields", (object) message.GetType()))
    {
      this.missingFields = (IList<string>) new List<string>();
    }

    public UninitializedMessageException(IMessage message)
      : this(UninitializedMessageException.FindMissingFields(message))
    {
    }

    private static IList<string> FindMissingFields(IMessage message)
    {
      List<string> results = new List<string>();
      UninitializedMessageException.FindMissingFields(message, "", results);
      return (IList<string>) results;
    }

    private static void FindMissingFields(IMessage message, string prefix, List<string> results)
    {
      foreach (FieldDescriptor field in (IEnumerable<FieldDescriptor>) message.DescriptorForType.Fields)
      {
        if (field.IsRequired && !message.HasField(field))
          results.Add(prefix + field.Name);
      }
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) message.AllFields)
      {
        FieldDescriptor key = allField.Key;
        object obj1 = allField.Value;
        if (key.MappedType == MappedType.Message)
        {
          if (key.IsRepeated)
          {
            int num = 0;
            foreach (object obj2 in (IEnumerable) obj1)
            {
              if (obj2 is IMessage)
                UninitializedMessageException.FindMissingFields((IMessage) obj2, UninitializedMessageException.SubMessagePrefix(prefix, key, num++), results);
              else
                results.Add(prefix + key.Name);
            }
          }
          else if (message.HasField(key))
          {
            if (obj1 is IMessage)
              UninitializedMessageException.FindMissingFields((IMessage) obj1, UninitializedMessageException.SubMessagePrefix(prefix, key, -1), results);
            else
              results.Add(prefix + key.Name);
          }
        }
      }
    }

    private static string SubMessagePrefix(string prefix, FieldDescriptor field, int index)
    {
      StringBuilder stringBuilder = new StringBuilder(prefix);
      if (field.IsExtension)
        stringBuilder.Append('(').Append(field.FullName).Append(')');
      else
        stringBuilder.Append(field.Name);
      if (index != -1)
        stringBuilder.Append('[').Append(index).Append(']');
      stringBuilder.Append('.');
      return stringBuilder.ToString();
    }
  }
}
