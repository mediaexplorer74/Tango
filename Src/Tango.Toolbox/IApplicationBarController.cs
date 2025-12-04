// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.IApplicationBarController
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;

#nullable disable
namespace Tango.Toolbox
{
  public interface IApplicationBarController
  {
    IApplicationBar AppBar { get; set; }

    void RegisterApplicationBarButton(ApplicationBarIconButton button);

    bool RemoveApplicationBarButton(ApplicationBarIconButton button);

    void EnableButton(ApplicationBarIconButton button);

    void DisableButton(ApplicationBarIconButton button);

    event EventHandler AppBarVisibilityChange;
  }

  // Simple UWP-safe stubs to replace deprecated Microsoft.Phone.Shell types.
  public interface IApplicationBar
  {
    bool IsVisible { get; set; }
  }

  public class ApplicationBarIconButton
  {
    public bool IsEnabled { get; set; }
  }
}
