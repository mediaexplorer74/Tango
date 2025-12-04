// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.RepeatedEnumAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal sealed class RepeatedEnumAccessor<TMessage, TBuilder> : 
    RepeatedPrimitiveAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly EnumDescriptor enumDescriptor;

    internal RepeatedEnumAccessor(FieldDescriptor field, string name)
      : base(name)
    {
      this.enumDescriptor = field.EnumType;
    }

    public override object GetValue(TMessage message)
    {
      List<EnumValueDescriptor> list = new List<EnumValueDescriptor>();
      foreach (int number in (IEnumerable) base.GetValue(message))
        list.Add(this.enumDescriptor.FindValueByNumber(number));
      return (object) Lists.AsReadOnly<EnumValueDescriptor>((IList<EnumValueDescriptor>) list);
    }

    public override object GetRepeatedValue(TMessage message, int index)
    {
      return (object) this.enumDescriptor.FindValueByNumber((int) base.GetRepeatedValue(message, index));
    }

    public override void AddRepeated(TBuilder builder, object value)
    {
      ThrowHelper.ThrowIfNull(value, nameof (value));
      base.AddRepeated(builder, (object) ((EnumValueDescriptor) value).Number);
    }

    public override void SetRepeated(TBuilder builder, int index, object value)
    {
      ThrowHelper.ThrowIfNull(value, nameof (value));
      base.SetRepeated(builder, index, (object) ((EnumValueDescriptor) value).Number);
    }
  }
}
