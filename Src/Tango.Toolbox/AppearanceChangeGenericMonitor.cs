// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.AppearanceChangeGenericMonitor
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

#nullable disable
namespace Tango.Toolbox
{
  public class AppearanceChangeGenericMonitor : IAppearanceChangeMonitable
  {
    protected bool _isAppearanceChanged;
    private object _isAppearanceChangedLock = new object();

    bool IAppearanceChangeMonitable.GetAndResetIsChangedFlag()
    {
      bool appearanceChanged;
      lock (this._isAppearanceChangedLock)
      {
        appearanceChanged = this._isAppearanceChanged;
        this._isAppearanceChanged = false;
      }
      return appearanceChanged;
    }

    private void SetIsChangedFlag(bool value)
    {
      lock (this._isAppearanceChangedLock)
        this._isAppearanceChanged = value;
    }
  }
}
