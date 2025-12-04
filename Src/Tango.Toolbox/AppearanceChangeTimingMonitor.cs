// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.AppearanceChangeTimingMonitor
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Tango.Toolbox
{
  public class AppearanceChangeTimingMonitor : IAppearanceChangeMonitable
  {
    protected bool _isAppearanceChanged;
    private TimeSpan _interval = TimeSpan.Zero;
    private TimeSpan _remainder = TimeSpan.Zero;
    private Stopwatch _watch = new Stopwatch();

    public AppearanceChangeTimingMonitor()
    {
    }

    public AppearanceChangeTimingMonitor(TimeSpan interval) => this.SetRefreshInterval(interval);

    bool IAppearanceChangeMonitable.GetAndResetIsChangedFlag()
    {
      if (!this._watch.IsRunning)
        this._watch.Start();
      bool resetIsChangedFlag = false;
      TimeSpan timeSpan = this._watch.Elapsed + this._remainder;
      if (timeSpan > this._interval)
      {
        if (this._interval.TotalMilliseconds > 0.0)
          this._remainder = TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds % this._interval.TotalMilliseconds);
        this._watch.Reset();
        resetIsChangedFlag = true;
      }
      return resetIsChangedFlag;
    }

    public void SetRefreshInterval(TimeSpan interval)
    {
      this._interval = interval;
      this._remainder = TimeSpan.Zero;
    }
  }
}
