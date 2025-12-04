// UWP compatible stubs for WP7/WinRT APIs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

// Add stubs for missing XNA types
namespace Microsoft.Xna.Framework
{
    public class GameComponent { }
    public class DrawableGameComponent : GameComponent { }
    public class GameTime { }
}

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsDevice { }
    public class PresentationParameters { }
    public enum SurfaceFormat
    {
        Color,
        Bgr565,
        Bgra5551,
        Bgra4444,
        Dxt1,
        Dxt3,
        Dxt5,
        NormalizedByte2,
        NormalizedByte4,
        Rgba1010102,
        Rg32,
        Rgba64,
        Single,
        HalfSingle,
        HalfVector2,
        HalfVector4,
        Alpha8,
        Bgr32,
        Rgba32,
        Unknown
    }
}

// Add stubs for missing Windows types
namespace System.Windows.Controls
{
    public class UserControl { }
    public class Grid { }
    public class TextBlock { }
    public class Button { }
    public class Image { }
}

namespace System.Windows.Media
{
    public class SolidColorBrush { }
    public class Color { }
}

namespace System.Windows.Media.Imaging
{
    public abstract class BitmapSource : ImageSource
    {
        public void SetSource(Stream stream) { }
    }

    public class BitmapImage : BitmapSource
    {
        public void SetSource(Stream stream) { }
    }

    public abstract class ImageSource : DependencyObject
    {
    }
}

namespace System.Windows
{
    public class DependencyObject { }
}

namespace System.Windows.Resources
{
    public class StreamResourceInfo
    {
        public Stream Stream { get; set; }
    }
}

namespace Microsoft.Phone.UserData
{
    public class Contacts
    {
        public event EventHandler<ContactsSearchEventArgs> SearchCompleted;
        
        public void SearchAsync(string filter, FilterKind filterKind, object state)
        {
            // UWP stub - contacts not available
            Task.Run(() => 
            {
                SearchCompleted?.Invoke(this, new ContactsSearchEventArgs());
            });
        }
    }

    public enum FilterKind
    {
        PhoneNumber,
        Email,
        DisplayName
    }

    public enum PhoneNumberKind
    {
        Home,
        Work,
        Mobile,
        Other
    }

    public enum PhoneType
    {
        Home,
        Work,
        Mobile,
        Other
    }

    public class Contact
    {
        public string DisplayName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Email { get; set; }
        public ContactEmailAddresses EmailAddresses { get; set; }

        public Stream GetPicture() => null;
    }

    public class PhoneNumber
    {
        public string SubscriberNumber { get; set; }
    }

    public class ContactEmailAddresses : List<ContactEmailAddress> { }

    public class ContactEmailAddress
    {
        public string EmailAddress { get; set; }
    }

    public class ContactsSearchEventArgs : EventArgs
    {
        public IEnumerable<Contact> Results { get; set; }
        public object State { get; set; }
    }
}

namespace System.Windows.Media.Imaging
{
    public abstract class BitmapSource : ImageSource
    {
        public void SetSource(Stream stream) { }
    }

    public class BitmapImage : BitmapSource
    {
        public void SetSource(Stream stream) { }
    }

    public abstract class ImageSource : DependencyObject
    {
    }
}

namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffectInstance
    {
        public bool IsLooped { get; set; }
        public void Play() { }
        public void Stop() { }
        public void Pause() { }
        public void Resume() { }
    }
}

namespace Microsoft.Devices
{
    public class PhotoCamera
    {
        public event EventHandler<CameraOperationCompletedEventArgs> CaptureImageAvailable;
        public FlashMode FlashMode { get; set; }
        
        public void CaptureImage() { }
        public void Dispose() { }
    }

    public enum FlashMode
    {
        On, Off, Auto
    }

    public class CameraOperationCompletedEventArgs : EventArgs
    {
        public Stream ImageStream { get; set; }
    }
}

namespace sgiggle.xmpp
{
    public class ContactsPayload
    {
        // Stub implementation
    }

    public class InviteContactMessage
    {
        public InviteContactMessage(long id, ContactsPayload payload) { }
        public string MsgByteString { get; set; }
        public object MsgPayload { get; set; }
    }
}

namespace Tango.Drivers
{
    public interface IDevInfoDriverConnector { }
    public interface ICapturerDriverConnector { }
    public interface IScreenDriverConnector { }
    public interface IContactsDriverConnector { }
    public interface IConnectivityDriverConnector { }
    public interface ISoundEffPlayerDriverConnector { }
    public interface IPlayerDriverConnector { }
    public interface IRecorderDriverConnector { }
    public interface IAudioModeMonitorDriverConnector { }

    public class SamsungRegistryManager
    {
        public static SamsungRegistryManager Instance { get; } = new SamsungRegistryManager();
        public const uint HKEY_LOCAL_MACHINE = 0x80000002;

        public bool IsSamsungDevice()
        {
            return false; // UWP stub - not a Samsung device
        }

        public void SetRegistryValue(string key, string value)
        {
            throw new NotSupportedException("Registry access not available in UWP");
        }
    }
}

namespace System.Threading
{
    public class Thread
    {
        public Thread(ThreadStart start) { }
        public void Start() { }
        public static void Sleep(int milliseconds) { }
    }
}
