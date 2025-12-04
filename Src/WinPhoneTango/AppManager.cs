// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.AppManager
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public class AppManager
  {
    private static AppManager _instance;
    private SingletonHolder<DataManager> _dataManager = new SingletonHolder<DataManager>();
    private SingletonHolder<ToastNotificationClientImpl> _toastClient = new SingletonHolder<ToastNotificationClientImpl>();
    private SingletonHolder<EventManager> _eventManager = new SingletonHolder<EventManager>();
    private SingletonHolder<PushEventManager> _pushEventManager = new SingletonHolder<PushEventManager>();
    private SingletonHolder<CallBackManager> _callBackManager = new SingletonHolder<CallBackManager>();
    private SingletonHolder<EngineCom> _engineCom = new SingletonHolder<EngineCom>();

    public static AppManager Instance
    {
      get
      {
        if (AppManager._instance == null)
          AppManager._instance = new AppManager();
        return AppManager._instance;
      }
    }

    private AppManager()
    {
    }

    public bool IsStarted { get; private set; }

    public void Start(bool isDoLogin = true)
    {
      if (this.IsStarted || !this.EngineCom.IsEngineStarted)
        return;
      Logger.Trace("[AppManager] Send messages to start the engine.");
      this.IsStarted = true;
      if (isDoLogin)
        TangoEventPageBase.SendMessage((ISendableMessage) new LoginMessage(TangoEventPageBase.GetNextSeqId(), LoginPayload.CreateBuilder()));
      TangoEventPageBase.SendMessage((ISendableMessage) new AllowAccessAddressBookMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
      AppManager.Instance.ToastClient.Init(this.EngineCom.PushServiceName);
    }

    public void Stop() => this.IsStarted = false;

    public DataManager DataManager => this._dataManager.Instance;

    public ToastNotificationClientImpl ToastClient => this._toastClient.Instance;

    public EventManager EventManager => this._eventManager.Instance;

    public PushEventManager PushEventManager => this._pushEventManager.Instance;

    public CallBackManager CallBackManager => this._callBackManager.Instance;

    public EngineCom EngineCom => this._engineCom.Instance;
  }
}
