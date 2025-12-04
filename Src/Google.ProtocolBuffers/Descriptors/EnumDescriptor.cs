// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.EnumDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class EnumDescriptor : 
    IndexedDescriptorBase<EnumDescriptorProto, EnumOptions>,
    IEnumLiteMap<EnumValueDescriptor>,
    IEnumLiteMap
  {
    private readonly MessageDescriptor containingType;
    private readonly IList<EnumValueDescriptor> values;

    internal EnumDescriptor(
      EnumDescriptorProto proto,
      FileDescriptor file,
      MessageDescriptor parent,
      int index)
      : base(proto, file, DescriptorBase<EnumDescriptorProto, EnumOptions>.ComputeFullName(file, parent, proto.Name), index)
    {
      EnumDescriptor parent1 = this;
      this.containingType = parent;
      if (proto.ValueCount == 0)
        throw new DescriptorValidationException((IDescriptor) this, "Enums must contain at least one value.");
      this.values = DescriptorUtil.ConvertAndMakeReadOnly<EnumValueDescriptorProto, EnumValueDescriptor>(proto.ValueList, (DescriptorUtil.IndexedConverter<EnumValueDescriptorProto, EnumValueDescriptor>) ((value, i) => new EnumValueDescriptor(value, file, parent1, i)));
      this.File.DescriptorPool.AddSymbol((IDescriptor) this);
    }

    public MessageDescriptor ContainingType => this.containingType;

    public IList<EnumValueDescriptor> Values => this.values;

    public bool IsValidValue(IEnumLite value)
    {
      return value is EnumValueDescriptor && ((EnumValueDescriptor) value).EnumDescriptor == this;
    }

    public EnumValueDescriptor FindValueByNumber(int number)
    {
      return this.File.DescriptorPool.FindEnumValueByNumber(this, number);
    }

    IEnumLite IEnumLiteMap.FindValueByNumber(int number)
    {
      return (IEnumLite) this.FindValueByNumber(number);
    }

    internal EnumValueDescriptor FindValueByName(string name)
    {
      return this.File.DescriptorPool.FindSymbol<EnumValueDescriptor>(this.FullName + "." + name);
    }

    internal override void ReplaceProto(EnumDescriptorProto newProto)
    {
      base.ReplaceProto(newProto);
      for (int index = 0; index < this.values.Count; ++index)
        this.values[index].ReplaceProto(newProto.GetValue(index));
    }
  }
}
