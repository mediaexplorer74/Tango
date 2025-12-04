using System;

namespace WinPhoneTango
{
    public interface IContactsDriverConnector
    {
        void RegisterContactsDriver(IContactsDriver driver);
    }
    
    public interface ISoundEffPlayerDriverConnector
    {
        void RegisterDriver(ISoundEffPlayerDriver driver);
    }
    
    public interface IConnectivityDriverConnector
    {
        void RegisterConnectivityDriver(IConnectivityDriver driver);
    }
    
    public interface IScreenDriverConnector
    {
        void RegisterDriver(IScreenDriver driver);
    }
    
    public interface IRecorderDriverConnector
    {
        void RegisterRecorderDriver(IRecorderDriver driver);
    }
    
    public interface IPlayerDriverConnector
    {
        void RegisterPlayerDriver(IPlayerDriver driver);
    }
    
    public interface ICapturerDriverConnector
    {
        void RegisterCapturerDriver(ICapturerDriver driver);
    }
    
    public interface IRendererDriverConnector
    {
        void RegisterRendererDriver(IRendererDriver driver);
    }
    
    public interface IAudioModeMonitorDriverConnector
    {
        void RegisterDriver(IAudioModeMonitorDriver driver);
    }
    
    // Driver interfaces
    public interface IContactsDriver
    {
        void Initialize();
        IContactsDriverConnector ContactsDriverConnector { get; set; }
    }
    
    public interface ISoundEffPlayerDriver
    {
        void PlaySound(string soundFile);
        void StopSound();
    }
    
    public interface IConnectivityDriver
    {
        bool IsConnected();
        string GetConnectionType();
    }
    
    public interface IScreenDriver
    {
        void SetBrightness(double brightness);
        void SetOrientation(string orientation);
    }
    
    public interface IRecorderDriver
    {
        void StartRecording();
        void StopRecording();
        string GetRecordedFilePath();
        IRecorderDriverConnector Connector { get; set; }
    }
    
    public interface IPlayerDriver
    {
        void Play(string filePath);
        void Pause();
        void Stop();
        IPlayerDriverConnector Connector { get; set; }
    }
    
    public interface ICapturerDriver
    {
        void StartCapture();
        void StopCapture();
        string GetCapturedFilePath();
        ICapturerDriverConnector Connector { get; set; }
    }
    
    public interface IRendererDriver
    {
        void Render();
        void SetRenderTarget(object target);
        IRendererDriverConnector Connector { get; set; }
    }
    
    public interface IAudioModeMonitorDriver
    {
        void StartMonitoring();
        void StopMonitoring();
        string GetCurrentAudioMode();
    }
    
    // Driver connector implementations
    public class ContactsDriverConnector : IContactsDriverConnector
    {
        public void RegisterContactsDriver(IContactsDriver driver) {}
    }
    
    public class SoundEffPlayerDriverConnector : ISoundEffPlayerDriverConnector
    {
        public void RegisterDriver(ISoundEffPlayerDriver driver) {}
    }
    
    public class ConnectivityDriverConnector : IConnectivityDriverConnector
    {
        public void RegisterConnectivityDriver(IConnectivityDriver driver) {}
    }
    
    public class ScreenDriverConnector : IScreenDriverConnector
    {
        public void RegisterDriver(IScreenDriver driver) {}
    }
    
    public class RecorderDriverConnector : IRecorderDriverConnector
    {
        public void RegisterRecorderDriver(IRecorderDriver driver) {}
    }
    
    public class PlayerDriverConnector : IPlayerDriverConnector
    {
        public void RegisterPlayerDriver(IPlayerDriver driver) {}
    }
    
    public class CapturerDriverConnector : ICapturerDriverConnector
    {
        public void RegisterCapturerDriver(ICapturerDriver driver) {}
    }
    
    public class RendererDriverConnector : IRendererDriverConnector
    {
        public void RegisterRendererDriver(IRendererDriver driver) {}
    }
    
    public class AudioModeMonitorDriverConnector : IAudioModeMonitorDriverConnector
    {
        public void RegisterDriver(IAudioModeMonitorDriver driver) {}
    }
}