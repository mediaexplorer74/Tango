// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.EnumLiteMap`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers
{
  public class EnumLiteMap<TEnum> : IEnumLiteMap<IEnumLite>, IEnumLiteMap where TEnum : struct, IComparable, IFormattable
  {
    private readonly SortedList<int, IEnumLite> items;

    public EnumLiteMap()
    {
      this.items = new SortedList<int, IEnumLite>();
      foreach (FieldInfo field in typeof (TEnum).GetFields(BindingFlags.Static | BindingFlags.Public))
      {
        TEnum @enum = (TEnum) field.GetValue((object) null);
        this.items.Add(Convert.ToInt32((object) @enum), (IEnumLite) new EnumLiteMap<TEnum>.EnumValue(@enum));
      }
    }

    IEnumLite IEnumLiteMap.FindValueByNumber(int number) => this.FindValueByNumber(number);

    public IEnumLite FindValueByNumber(int number)
    {
      IEnumLite enumLite;
      return !this.items.TryGetValue(number, out enumLite) ? (IEnumLite) null : enumLite;
    }

    public bool IsValidValue(IEnumLite value) => this.items.ContainsKey(value.Number);

    private struct EnumValue(TEnum value) : IEnumLite
    {
      private readonly TEnum value = value;

      int IEnumLite.Number => Convert.ToInt32((object) this.value);

      string IEnumLite.Name => this.value.ToString();
    }
  }
}
