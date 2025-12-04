// Decompiled with JetBrains decompiler
// Type: ImageTools.ImageFormatException
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools
{
  public class ImageFormatException : Exception
  {
    public ImageFormatException()
    {
    }

    public ImageFormatException(string errorMessage)
      : base(errorMessage)
    {
    }

    public ImageFormatException(string errorMessage, Exception innerEx)
      : base(errorMessage, innerEx)
    {
    }
  }
}
