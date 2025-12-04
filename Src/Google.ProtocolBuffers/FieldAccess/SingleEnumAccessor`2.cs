// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.SingleEnumAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal sealed class SingleEnumAccessor<TMessage, TBuilder> : 
    SinglePrimitiveAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    private readonly EnumDescriptor enumDescriptor;

    internal SingleEnumAccessor(FieldDescriptor field, string name)
      : base(name)
    {
      this.enumDescriptor = field.EnumType;
    }

    public override object GetValue(TMessage message)
    {
      return (object) this.enumDescriptor.FindValueByNumber((int) base.GetValue(message));
    }

    public override void SetValue(TBuilder builder, object value)
    {
      ThrowHelper.ThrowIfNull(value, nameof (value));
      EnumValueDescriptor enumValueDescriptor = (EnumValueDescriptor) value;
      base.SetValue(builder, (object) enumValueDescriptor.Number);
    }
  }
}
