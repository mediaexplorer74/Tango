using System;
using System.Runtime.InteropServices;

namespace WinPhoneTango
{
    [ComImport]
    [Guid("C1FF8E39-B5F9-4E1E-A6C0-9C9F411BF61D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPTangoEngine
    {
        void set_environment(IWPLogger wpLogger, string appDir);
        void init();
        void register_msg_receiver(IEventCallback callback);
        void fini();
        void start();
        void stop();
        void get_next_sequence_id(ref long nextSid);
        void register_devinfo_driver(IDevInfoDriver devinfoDriver);
        void set_and_lookup_country_code(out int retCountryId, char isoCode0, char isoCode1);
        void get_version(int versionSize, byte[] versionData, out int dataLen);
        void get_push_service_name(int nameSize, byte[] nameData, out int nameLen);
        void get_target_device(int bufferSize, byte[] buffer, out int bufLen);
    }
}
