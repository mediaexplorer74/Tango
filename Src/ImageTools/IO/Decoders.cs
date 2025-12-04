// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Decoders
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace ImageTools.IO
{
  public static class Decoders
  {
    private static List<Type> _decoderTypes = new List<Type>();

    public static void AddDecoder<TDecoder>() where TDecoder : IImageDecoder
    {
      if (Decoders._decoderTypes.Contains(typeof (TDecoder)))
        return;
      Decoders._decoderTypes.Add(typeof (TDecoder));
    }

    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
    public static ReadOnlyCollection<IImageDecoder> GetAvailableDecoders()
    {
      List<IImageDecoder> list = new List<IImageDecoder>();
      foreach (Type decoderType in Decoders._decoderTypes)
      {
        if ((object) decoderType != null)
          list.Add(Activator.CreateInstance(decoderType) as IImageDecoder);
      }
      return new ReadOnlyCollection<IImageDecoder>((IList<IImageDecoder>) list);
    }
  }
}
