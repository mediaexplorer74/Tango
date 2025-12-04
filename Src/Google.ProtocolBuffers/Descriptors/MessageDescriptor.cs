// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.MessageDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class MessageDescriptor : IndexedDescriptorBase<DescriptorProto, MessageOptions>
  {
    private readonly MessageDescriptor containingType;
    private readonly IList<MessageDescriptor> nestedTypes;
    private readonly IList<EnumDescriptor> enumTypes;
    private readonly IList<FieldDescriptor> fields;
    private readonly IList<FieldDescriptor> extensions;
    private bool hasRequiredFields;

    internal MessageDescriptor(
      DescriptorProto proto,
      FileDescriptor file,
      MessageDescriptor parent,
      int typeIndex)
      : base(proto, file, DescriptorBase<DescriptorProto, MessageOptions>.ComputeFullName(file, parent, proto.Name), typeIndex)
    {
      MessageDescriptor parent1 = this;
      this.containingType = parent;
      this.nestedTypes = DescriptorUtil.ConvertAndMakeReadOnly<DescriptorProto, MessageDescriptor>(proto.NestedTypeList, (DescriptorUtil.IndexedConverter<DescriptorProto, MessageDescriptor>) ((type, index) => new MessageDescriptor(type, file, parent1, index)));
      this.enumTypes = DescriptorUtil.ConvertAndMakeReadOnly<EnumDescriptorProto, EnumDescriptor>(proto.EnumTypeList, (DescriptorUtil.IndexedConverter<EnumDescriptorProto, EnumDescriptor>) ((type, index) => new EnumDescriptor(type, file, parent1, index)));
      this.fields = DescriptorUtil.ConvertAndMakeReadOnly<FieldDescriptorProto, FieldDescriptor>(proto.FieldList, (DescriptorUtil.IndexedConverter<FieldDescriptorProto, FieldDescriptor>) ((field, index) => new FieldDescriptor(field, file, parent1, index, false)));
      this.extensions = DescriptorUtil.ConvertAndMakeReadOnly<FieldDescriptorProto, FieldDescriptor>(proto.ExtensionList, (DescriptorUtil.IndexedConverter<FieldDescriptorProto, FieldDescriptor>) ((field, index) => new FieldDescriptor(field, file, parent1, index, true)));
      file.DescriptorPool.AddSymbol((IDescriptor) this);
    }

    public MessageDescriptor ContainingType => this.containingType;

    public IList<FieldDescriptor> Fields => this.fields;

    public IList<FieldDescriptor> Extensions => this.extensions;

    public IList<MessageDescriptor> NestedTypes => this.nestedTypes;

    public IList<EnumDescriptor> EnumTypes => this.enumTypes;

    internal bool HasRequiredFields => this.hasRequiredFields;

    public bool IsExtensionNumber(int number)
    {
      foreach (DescriptorProto.Types.ExtensionRange extensionRange in (IEnumerable<DescriptorProto.Types.ExtensionRange>) this.Proto.ExtensionRangeList)
      {
        if (extensionRange.Start <= number && number < extensionRange.End)
          return true;
      }
      return false;
    }

    public FieldDescriptor FindFieldByName(string name)
    {
      return this.File.DescriptorPool.FindSymbol<FieldDescriptor>(this.FullName + "." + name);
    }

    public FieldDescriptor FindFieldByNumber(int number)
    {
      return this.File.DescriptorPool.FindFieldByNumber(this, number);
    }

    public FieldDescriptor FindFieldByPropertyName(string propertyName)
    {
      foreach (FieldDescriptor field in (IEnumerable<FieldDescriptor>) this.Fields)
      {
        if (field.CSharpOptions.PropertyName == propertyName)
          return field;
      }
      return (FieldDescriptor) null;
    }

    public T FindDescriptor<T>(string name) where T : class, IDescriptor
    {
      return this.File.DescriptorPool.FindSymbol<T>(this.FullName + "." + name);
    }

    internal void CrossLink()
    {
      foreach (MessageDescriptor nestedType in (IEnumerable<MessageDescriptor>) this.nestedTypes)
        nestedType.CrossLink();
      foreach (FieldDescriptor field in (IEnumerable<FieldDescriptor>) this.fields)
        field.CrossLink();
      foreach (FieldDescriptor extension in (IEnumerable<FieldDescriptor>) this.extensions)
        extension.CrossLink();
    }

    internal void CheckRequiredFields()
    {
      this.hasRequiredFields = this.CheckRequiredFields((IDictionary<MessageDescriptor, byte>) new Dictionary<MessageDescriptor, byte>());
    }

    private bool CheckRequiredFields(IDictionary<MessageDescriptor, byte> alreadySeen)
    {
      if (alreadySeen.ContainsKey(this))
        return false;
      alreadySeen[this] = (byte) 0;
      if (this.Proto.ExtensionRangeCount != 0)
        return true;
      foreach (FieldDescriptor field in (IEnumerable<FieldDescriptor>) this.Fields)
      {
        if (field.IsRequired || field.MappedType == MappedType.Message && field.MessageType.CheckRequiredFields(alreadySeen))
          return true;
      }
      return false;
    }

    internal override void ReplaceProto(DescriptorProto newProto)
    {
      base.ReplaceProto(newProto);
      for (int index = 0; index < this.nestedTypes.Count; ++index)
        this.nestedTypes[index].ReplaceProto(newProto.GetNestedType(index));
      for (int index = 0; index < this.enumTypes.Count; ++index)
        this.enumTypes[index].ReplaceProto(newProto.GetEnumType(index));
      for (int index = 0; index < this.fields.Count; ++index)
        this.fields[index].ReplaceProto(newProto.GetField(index));
      for (int index = 0; index < this.extensions.Count; ++index)
        this.extensions[index].ReplaceProto(newProto.GetExtension(index));
    }
  }
}
