// UWP compatible DriversManager
using Tango.Toolbox;

#nullable disable
namespace Tango.Drivers
{
  public class DriversManager
  {
    private static DriversManager _instance;
    private SingletonHolder<DevInfoDriver> _devInfoDriver = new SingletonHolder<DevInfoDriver>();
    private SingletonHolder<ContactsDriver> _contactsDriver = new SingletonHolder<ContactsDriver>();
    private SingletonHolder<ConnectivityDriver> _connectivityDriver = new SingletonHolder<ConnectivityDriver>();
    private SingletonHolder<SoundEffPlayerDriver> _soundEffPlayerDriver = new SingletonHolder<SoundEffPlayerDriver>();
    private SingletonHolder<RecorderDriver> _recorderDriver = new SingletonHolder<RecorderDriver>();
    private SingletonHolder<PlayerDriver> _playerDriver = new SingletonHolder<PlayerDriver>();
    private SingletonHolder<AudioModeMonitorDriver> _audioModeMonitorDriver = new SingletonHolder<AudioModeMonitorDriver>();
    private SingletonHolder<ScreenDriver> _screenDriver = new SingletonHolder<ScreenDriver>();
    private SingletonHolder<CapturerDriver> _capturerDriver = new SingletonHolder<CapturerDriver>();
    private SingletonHolder<RendererDriver> _rendererDriver = new SingletonHolder<RendererDriver>();

    public static DriversManager Instance
    {
      get
      {
        if (DriversManager._instance == null)
          DriversManager._instance = new DriversManager();
        return DriversManager._instance;
      }
    }

    private DriversManager()
    {
    }

    public UIManagerInterface UIManager { get; set; }

    public DevInfoDriver DevInfoDriver => this._devInfoDriver.Instance;

    public ContactsDriver ContactsDriver => this._contactsDriver.Instance;

    public ConnectivityDriver ConnectivityDriver => this._connectivityDriver.Instance;

    public SoundEffPlayerDriver SoundEffPlayerDriver => this._soundEffPlayerDriver.Instance;

    public RecorderDriver RecorderDriver => this._recorderDriver.Instance;

    public PlayerDriver PlayerDriver => this._playerDriver.Instance;

    public AudioModeMonitorDriver AudioModeMonitorDriver => this._audioModeMonitorDriver.Instance;

    public ScreenDriver ScreenDriver => this._screenDriver.Instance;

    public CapturerDriver CapturerDriver => this._capturerDriver.Instance;

    public RendererDriver RendererDriver => this._rendererDriver.Instance;
  }
}
