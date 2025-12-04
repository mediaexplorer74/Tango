// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.DescriptorUtil
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  internal static class DescriptorUtil
  {
    internal static IList<TOutput> ConvertAndMakeReadOnly<TInput, TOutput>(
      IList<TInput> input,
      DescriptorUtil.IndexedConverter<TInput, TOutput> converter)
    {
      TOutput[] list = new TOutput[input.Count];
      for (int index = 0; index < list.Length; ++index)
        list[index] = converter(input[index], index);
      return Lists<TOutput>.AsReadOnly((IList<TOutput>) list);
    }

    internal delegate TOutput IndexedConverter<TInput, TOutput>(TInput element, int index);
  }
}
