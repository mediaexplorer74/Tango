// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.SingletonHolder`1
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

#nullable disable
namespace Tango.Toolbox
{
  public class SingletonHolder<T> where T : new()
  {
    private T _obj = default (T);
    private object instanceLock = new object();

    public T Instance
    {
      get
      {
        if ((object) this._obj == null)
        {
          lock (this.instanceLock)
          {
            if ((object) this._obj == null)
              this._obj = new T();
          }
        }
        return this._obj;
      }
    }
  }
}
