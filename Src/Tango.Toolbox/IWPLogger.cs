// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.IWPLogger
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace Tango.Toolbox
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("CF45BB10-B45C-46d3-A164-344A6989FCE1")]
  [ComImport]
  public interface IWPLogger
  {
    void DebugWriteLine(StringBuilder log);
  }
}
