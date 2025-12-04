// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.MonitableButton
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

#nullable disable
namespace Tango.Toolbox
{
  public class MonitableButton : Button, IAppearanceChangeMonitable
  {
    private bool _isAppearanceChanged;

    public MonitableButton()
    {
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnInit);
    }

    private void OnInit(object sender, RoutedEventArgs e)
    {
      ((FrameworkElement) this).Loaded -= new RoutedEventHandler(this.OnInit);
      ((UIElement) this).ManipulationStarted += (object o, ManipulationStartedRoutedEventArgs arg) => this._isAppearanceChanged = true;
      ((UIElement) this).ManipulationDelta += (object o, ManipulationDeltaRoutedEventArgs arg) => this._isAppearanceChanged = true;
      ((UIElement) this).ManipulationCompleted += (object o, ManipulationCompletedRoutedEventArgs arg) => this._isAppearanceChanged = true;
      this._isAppearanceChanged = true;
    }

    protected virtual void OnContentChanged(object oldContent, object newContent)
    {
      base.OnContentChanged(oldContent, newContent);
      this._isAppearanceChanged = true;
    }

    bool IAppearanceChangeMonitable.GetAndResetIsChangedFlag()
    {
      bool appearanceChanged = this._isAppearanceChanged;
      this._isAppearanceChanged = false;
      return appearanceChanged;
    }

    public virtual void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this._isAppearanceChanged = true;
    }
  }
}
