// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldSet
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  internal sealed class FieldSet
  {
    private static readonly FieldSet defaultInstance = new FieldSet((IDictionary<IFieldDescriptorLite, object>) new Dictionary<IFieldDescriptorLite, object>()).MakeImmutable();
    private IDictionary<IFieldDescriptorLite, object> fields;

    private FieldSet(IDictionary<IFieldDescriptorLite, object> fields) => this.fields = fields;

    public static FieldSet CreateInstance()
    {
      return new FieldSet((IDictionary<IFieldDescriptorLite, object>) new SortedList<IFieldDescriptorLite, object>());
    }

    internal FieldSet MakeImmutable()
    {
      bool flag = false;
      foreach (object obj in (IEnumerable<object>) this.fields.Values)
      {
        if (obj is IList<object> objectList && !objectList.IsReadOnly)
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        SortedList<IFieldDescriptorLite, object> sortedList = new SortedList<IFieldDescriptorLite, object>();
        foreach (KeyValuePair<IFieldDescriptorLite, object> field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.fields)
        {
          IList<object> list = field.Value as IList<object>;
          sortedList[field.Key] = list == null ? field.Value : (object) Lists.AsReadOnly<object>(list);
        }
        this.fields = (IDictionary<IFieldDescriptorLite, object>) sortedList;
      }
      this.fields = Dictionaries.AsReadOnly<IFieldDescriptorLite, object>(this.fields);
      return this;
    }

    internal static FieldSet DefaultInstance => FieldSet.defaultInstance;

    internal IDictionary<IFieldDescriptorLite, object> AllFields
    {
      get => Dictionaries.AsReadOnly<IFieldDescriptorLite, object>(this.fields);
    }

    internal IDictionary<FieldDescriptor, object> AllFieldDescriptors
    {
      get
      {
        SortedList<FieldDescriptor, object> sortedList = new SortedList<FieldDescriptor, object>();
        foreach (KeyValuePair<IFieldDescriptorLite, object> @field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.fields)
          sortedList.Add((FieldDescriptor) @field.Key, @field.Value);
        return Dictionaries.AsReadOnly<FieldDescriptor, object>((IDictionary<FieldDescriptor, object>) sortedList);
      }
    }

    public bool HasField(IFieldDescriptorLite field)
    {
      return !field.IsRepeated ? this.fields.ContainsKey(field) : throw new ArgumentException("HasField() can only be called on non-repeated fields.");
    }

    internal void Clear() => this.fields.Clear();

    internal object this[IFieldDescriptorLite field]
    {
      get
      {
        object obj;
        if (this.fields.TryGetValue(field, out obj))
          return obj;
        if (field.MappedType != MappedType.Message)
          return field.DefaultValue;
        return field.IsRepeated ? (object) new List<object>() : (object) null;
      }
      set
      {
        if (field.IsRepeated)
        {
          List<object> objectList = value is List<object> collection ? new List<object>((IEnumerable<object>) collection) : throw new ArgumentException("Wrong object type used with protocol message reflection.");
          foreach (object obj in objectList)
            FieldSet.VerifyType(field, obj);
          value = (object) objectList;
        }
        else
          FieldSet.VerifyType(field, value);
        this.fields[field] = value;
      }
    }

    internal object this[IFieldDescriptorLite field, int index]
    {
      get
      {
        return field.IsRepeated ? ((IList<object>) this[field])[index] : throw new ArgumentException("Indexer specifying field and index can only be called on repeated fields.");
      }
      set
      {
        if (!field.IsRepeated)
          throw new ArgumentException("Indexer specifying field and index can only be called on repeated fields.");
        FieldSet.VerifyType(field, value);
        object obj;
        if (!this.fields.TryGetValue(field, out obj))
          throw new ArgumentOutOfRangeException();
        ((IList<object>) obj)[index] = value;
      }
    }

    internal void AddRepeatedField(IFieldDescriptorLite field, object value)
    {
      if (!field.IsRepeated)
        throw new ArgumentException("AddRepeatedField can only be called on repeated fields.");
      FieldSet.VerifyType(field, value);
      object obj;
      if (!this.fields.TryGetValue(field, out obj))
      {
        obj = (object) new List<object>();
        this.fields[field] = obj;
      }
      ((ICollection<object>) obj).Add(value);
    }

    internal IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> GetEnumerator()
    {
      return this.fields.GetEnumerator();
    }

    internal bool IsInitialized
    {
      get
      {
        foreach (KeyValuePair<IFieldDescriptorLite, object> @field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.fields)
        {
          IFieldDescriptorLite key = @field.Key;
          if (key.MappedType == MappedType.Message)
          {
            if (!this.IsInitializedField(@field))
              return false;
          }
        }
        return true;
      }
    }

    private bool IsInitializedField(KeyValuePair<IFieldDescriptorLite, object> field)
    {
      if (field.Value is IMessageLite message)
        return message.IsInitialized;

      if (field.Value is IEnumerable enumerable)
      {
        foreach (var item in enumerable)
        {
          if (item is IMessageLite msg && !msg.IsInitialized)
            return false;
        }
      }
      return true;
    }

    internal bool IsInitializedWithRespectTo(IEnumerable typeFields)
    {
      foreach (IFieldDescriptorLite typeField in typeFields)
      {
        if (typeField.IsRequired && !this.HasField(typeField))
          return false;
      }
      return this.IsInitialized;
    }

    public void ClearField(IFieldDescriptorLite field) => this.fields.Remove(field);

    public int GetRepeatedFieldCount(IFieldDescriptorLite field)
    {
      return field.IsRepeated ? ((ICollection<object>) this[field]).Count : throw new ArgumentException("GetRepeatedFieldCount() can only be called on repeated fields.");
    }

    public void MergeFrom(IMessage other)
    {
      foreach (KeyValuePair<FieldDescriptor, object> allField in (IEnumerable<KeyValuePair<FieldDescriptor, object>>) other.AllFields)
        this.MergeField((IFieldDescriptorLite) allField.Key, allField.Value);
    }

    public void MergeFrom(FieldSet other)
    {
      foreach (KeyValuePair<IFieldDescriptorLite, object> field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) other.fields)
        this.MergeField(field.Key, field.Value);
    }

    private void MergeField(IFieldDescriptorLite field, object mergeValue)
    {
      object obj1;
      this.fields.TryGetValue(field, out obj1);
      if (field.IsRepeated)
      {
        if (obj1 == null)
        {
          obj1 = (object) new List<object>();
          this.fields[field] = obj1;
        }
        IList<object> objectList = (IList<object>) obj1;
        foreach (object obj2 in (IEnumerable) mergeValue)
          objectList.Add(obj2);
      }
      else if (field.MappedType == MappedType.Message && obj1 != null)
      {
        IMessageLite messageLite = ((IMessageLite) obj1).WeakToBuilder().WeakMergeFrom((IMessageLite) mergeValue).WeakBuild();
        this[field] = (object) messageLite;
      }
      else
        this[field] = mergeValue;
    }

    public void WriteTo(CodedOutputStream output)
    {
      foreach (KeyValuePair<IFieldDescriptorLite, object> field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.fields)
        this.WriteField(field.Key, field.Value, output);
    }

    public void WriteField(IFieldDescriptorLite field, object value, CodedOutputStream output)
    {
      if (field.IsExtension && field.MessageSetWireFormat)
        output.WriteMessageSetExtension(field.FieldNumber, (IMessageLite) value);
      else if (field.IsRepeated)
      {
        IEnumerable enumerable = (IEnumerable) value;
        if (field.IsPacked)
        {
          output.WriteTag(field.FieldNumber, WireFormat.WireType.LengthDelimited);
          int num = 0;
          foreach (object obj in enumerable)
            num += CodedOutputStream.ComputeFieldSizeNoTag(field.FieldType, obj);
          output.WriteRawVarint32((uint) num);
          foreach (object obj in enumerable)
            output.WriteFieldNoTag(field.FieldType, obj);
        }
        else
        {
          foreach (object obj in enumerable)
            output.WriteField(field.FieldType, field.FieldNumber, obj);
        }
      }
      else
        output.WriteField(field.FieldType, field.FieldNumber, value);
    }

    public int SerializedSize
    {
      get
      {
        int serializedSize = 0;
        foreach (KeyValuePair<IFieldDescriptorLite, object> @field in (IEnumerable<KeyValuePair<IFieldDescriptorLite, object>>) this.fields)
        {
          IFieldDescriptorLite key = @field.Key;
          object obj1 = @field.Value;
          if (key.IsExtension && key.MessageSetWireFormat)
            serializedSize += CodedOutputStream.ComputeMessageSetExtensionSize(key.FieldNumber, (IMessageLite) obj1);
          else if (key.IsRepeated)
          {
            IEnumerable enumerable = (IEnumerable) obj1;
            if (key.IsPacked)
            {
              int num = 0;
              foreach (object obj2 in enumerable)
                num += CodedOutputStream.ComputeFieldSizeNoTag(key.FieldType, obj2);
              serializedSize += num + CodedOutputStream.ComputeTagSize(key.FieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint) num);
            }
            else
            {
              foreach (object obj3 in enumerable)
                serializedSize += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, obj3);
            }
          }
          else
            serializedSize += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, obj1);
        }
        return serializedSize;
      }
    }

    private static void VerifyType(IFieldDescriptorLite field, object value)
    {
      ThrowHelper.ThrowIfNull(value, nameof (value));
      bool flag = false;
      switch (field.MappedType)
      {
        case MappedType.Int32:
          flag = value is int;
          break;
        case MappedType.Int64:
          flag = value is long;
          break;
        case MappedType.UInt32:
          flag = value is uint;
          break;
        case MappedType.UInt64:
          flag = value is ulong;
          break;
        case MappedType.Single:
          flag = value is float;
          break;
        case MappedType.Double:
          flag = value is double;
          break;
        case MappedType.Boolean:
          flag = value is bool;
          break;
        case MappedType.String:
          flag = value is string;
          break;
        case MappedType.ByteString:
          flag = value is ByteString;
          break;
        case MappedType.Message:
          IMessageLite messageLite = value as IMessageLite;
          flag = messageLite != null;
          if (flag && messageLite is IMessage && field is FieldDescriptor)
          {
            flag = ((IMessage) messageLite).DescriptorForType == ((FieldDescriptor) field).MessageType;
            break;
          }
          break;
        case MappedType.Enum:
          flag = value is IEnumLite enumLite && field.EnumType.IsValidValue(enumLite);
          break;
      }
      if (!flag)
      {
        string message = "Wrong object type used with protocol message reflection.";
        if (field is FieldDescriptor fieldDescriptor)
          message = message + "Message type \"" + fieldDescriptor.ContainingType.FullName + "\", field \"" + (fieldDescriptor.IsExtension ? fieldDescriptor.FullName : fieldDescriptor.Name) + "\", value was type \"" + value.GetType().Name + "\".";
        throw new ArgumentException(message);
      }
    }
  }
}
