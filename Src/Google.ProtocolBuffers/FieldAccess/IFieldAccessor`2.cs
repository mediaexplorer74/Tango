// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.FieldAccess.IFieldAccessor`2
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

#nullable disable
namespace Google.ProtocolBuffers.FieldAccess
{
  internal interface IFieldAccessor<TMessage, TBuilder>
    where TMessage : IMessage<TMessage, TBuilder>
    where TBuilder : IBuilder<TMessage, TBuilder>
  {
    bool Has(TMessage message);

    int GetRepeatedCount(TMessage message);

    void Clear(TBuilder builder);

    IBuilder CreateBuilder();

    object GetValue(TMessage message);

    void SetValue(TBuilder builder, object value);

    object GetRepeatedValue(TMessage message, int index);

    void SetRepeated(TBuilder builder, int index, object value);

    void AddRepeated(TBuilder builder, object value);

    object GetRepeatedWrapper(TBuilder builder);
  }
}
