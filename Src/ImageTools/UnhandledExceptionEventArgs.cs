// Decompiled with JetBrains decompiler
// Type: ImageTools.UnhandledExceptionEventArgs
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools
{
  public class UnhandledExceptionEventArgs : EventArgs
  {
    public Exception ExceptionObject { get; set; }
    public bool IsTerminating { get; set; }

    public UnhandledExceptionEventArgs()
    {
    }

    public UnhandledExceptionEventArgs(Exception exceptionObject, bool isTerminating)
    {
      this.ExceptionObject = exceptionObject;
      this.IsTerminating = isTerminating;
    }
  }
}
