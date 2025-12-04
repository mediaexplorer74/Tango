// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.INavigatable
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;

#nullable disable
namespace WinPhoneTango
{
  public interface INavigatable
  {
    bool Navigate(Uri source);

    bool GoBack();
  }
}
