using System;

namespace sgiggle.xmpp
{
    public interface IWPTangoEngine
    {
        void set_environment(IWPLogger logger, string app_dir);
        void init();
        void register_msg_receiver(IEventCallback callback);
        void fini();
        void start();
        void stop();
        void get_next_seq_id(ref long next_sid);
        void register_devinfo_driver(IDevInfoDriver devinfo_driver);
        void set_and_lookup_country_code(out int retCountryId, char isoCode0, char isoCode1);
        void get_version(int version_size, byte[] version_data, out int datalen);
        void get_push_service_name(int name_size, byte[] name_data, out int datalen);
        void get_target_device(int buffer_size, byte[] buffer, out int buflen);
    }
}