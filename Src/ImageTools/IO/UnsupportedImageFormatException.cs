// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.UnsupportedImageFormatException
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools.IO
{
  public class UnsupportedImageFormatException : Exception
  {
    public UnsupportedImageFormatException()
    {
    }

    public UnsupportedImageFormatException(string errorMessage)
      : base(errorMessage)
    {
    }

    public UnsupportedImageFormatException(string errorMessage, Exception innerEx)
      : base(errorMessage, innerEx)
    {
    }
  }
}
