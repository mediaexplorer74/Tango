// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Encoders
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

#nullable disable
namespace ImageTools.IO
{
  public static class Encoders
  {
    private static List<Type> _encoderTypes = new List<Type>();

    public static void AddEncoder<TEncoder>() where TEncoder : IImageEncoder
    {
      if (Encoders._encoderTypes.Contains(typeof (TEncoder)))
        return;
      Encoders._encoderTypes.Add(typeof (TEncoder));
    }

    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
    public static ReadOnlyCollection<IImageEncoder> GetAvailableEncoders()
    {
      Contract.Ensures(Contract.Result<ReadOnlyCollection<IImageEncoder>>() != null);
      List<IImageEncoder> list = new List<IImageEncoder>();
      foreach (Type encoderType in Encoders._encoderTypes)
      {
        if ((object) encoderType != null)
          list.Add(Activator.CreateInstance(encoderType) as IImageEncoder);
      }
      return new ReadOnlyCollection<IImageEncoder>((IList<IImageEncoder>) list);
    }
  }
}
