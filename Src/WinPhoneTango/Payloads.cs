using System;

namespace WinPhoneTango
{
    public class RegisterUserPayload
    {
        public static RegisterUserPayload CreateBuilder()
        {
            return new RegisterUserPayload();
        }
    }
    
    public class MediaSessionPayload
    {
        public static MediaSessionPayload CreateBuilder()
        {
            return new MediaSessionPayload();
        }
    }
    
    public class ContactsPayload
    {
        public static ContactsPayload CreateBuilder()
        {
            return new ContactsPayload();
        }
    }
    
    public class CallEntriesPayload
    {
        public static CallEntriesPayload CreateBuilder()
        {
            return new CallEntriesPayload();
        }
    }
    
    public class InviteEmailSelectionPayload
    {
        public static InviteEmailSelectionPayload CreateBuilder()
        {
            return new InviteEmailSelectionPayload();
        }
    }
    
    public class InviteOptionsPayload
    {
        public static InviteOptionsPayload CreateBuilder()
        {
            return new InviteOptionsPayload();
        }
    }
    
    public class InviteSMSSelectedPayload
    {
        public static InviteSMSSelectedPayload CreateBuilder()
        {
            return new InviteSMSSelectedPayload();
        }
    }
    
    public class InviteEmailComposerPayload
    {
        public static InviteEmailComposerPayload CreateBuilder()
        {
            return new InviteEmailComposerPayload();
        }
    }
    
    
    public class InCallAlertPayload
    {
        public static InCallAlertPayload CreateBuilder()
        {
            return new InCallAlertPayload();
        }
    }
    
    public class AudioModePayload
    {
        public static AudioModePayload CreateBuilder()
        {
            return new AudioModePayload();
        }
        
        public class Builder
        {
            public AudioModePayload Build()
            {
                return new AudioModePayload();
            }
            
            public Builder SetDoLogin(bool doLogin)
            {
                return this;
            }
        }
    }
    
    public class VideoModePayload
    {
        public static VideoModePayload CreateBuilder()
        {
            return new VideoModePayload();
        }
    }
    
    public class DeviceTokenPayload
    {
        public static DeviceTokenPayload CreateBuilder()
        {
            return new DeviceTokenPayload();
        }
        
        public class Builder
        {
            public DeviceTokenPayload Build()
            {
                return new DeviceTokenPayload();
            }
            
            public Builder SetDeviceToken(string token)
            {
                return this;
            }
            
            public Builder SetDeviceTokenType(int type)
            {
                return this;
            }
        }
    }
}