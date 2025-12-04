// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.ApplicationBarController
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Tango.Toolbox
{
  public class ApplicationBarController : IApplicationBarController
  {
    private ICollection<ApplicationBarIconButton> buttons;
    private IApplicationBar _appBar;

    public event EventHandler AppBarVisibilityChange;

    IApplicationBar IApplicationBarController.AppBar
    {
      get => this._appBar;
      set => this._appBar = value;
    }

    public ApplicationBarController()
    {
      this.buttons = (ICollection<ApplicationBarIconButton>) new LinkedList<ApplicationBarIconButton>();
    }

    void IApplicationBarController.RegisterApplicationBarButton(ApplicationBarIconButton button)
    {
      if (button == null)
        return;
      this.buttons.Add(button);
    }

    bool IApplicationBarController.RemoveApplicationBarButton(ApplicationBarIconButton button)
    {
      return this.buttons.Remove(button);
    }

    void IApplicationBarController.EnableButton(ApplicationBarIconButton button)
    {
      if (this._appBar != null && !this._appBar.IsVisible)
      {
        this._appBar.IsVisible = true;
        this.AppBarVisibilityChange((object) this, (EventArgs) new AppBarChangedEventArgs());
      }
      if (button == null || button.IsEnabled)
        return;
      button.IsEnabled = true;
    }

    void IApplicationBarController.DisableButton(ApplicationBarIconButton button)
    {
      if (button != null && button.IsEnabled)
        button.IsEnabled = false;
      if (this._appBar == null || !this._appBar.IsVisible)
        return;
      IEnumerator<ApplicationBarIconButton> enumerator = this.buttons.GetEnumerator();
      while (enumerator.MoveNext())
      {
        if (enumerator.Current.IsEnabled)
          return;
      }
      this._appBar.IsVisible = false;
      this.AppBarVisibilityChange((object) this, (EventArgs) new AppBarChangedEventArgs());
    }
  }
}
