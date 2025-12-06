namespace sgiggle.xmpp
{
    // Payload classes
    public class RegisterUserPayload
    {
        public static RegisterUserPayload CreateBuilder()
        {
            return new RegisterUserPayload();
        }
        
        public class Builder
        {
            public RegisterUserPayload Build()
            {
                return new RegisterUserPayload();
            }
        }
    }
    
    public class MediaSessionPayload
    {
        public static MediaSessionPayload CreateBuilder()
        {
            return new MediaSessionPayload();
        }
        
        public class Builder
        {
            public MediaSessionPayload Build()
            {
                return new MediaSessionPayload();
            }
        }
    }
    
    public class ContactsPayload
    {
        public static ContactsPayload CreateBuilder()
        {
            return new ContactsPayload();
        }
        
        public class Builder
        {
            public ContactsPayload Build()
            {
                return new ContactsPayload();
            }
        }
    }
    
    public class CallEntriesPayload
    {
        public static CallEntriesPayload CreateBuilder()
        {
            return new CallEntriesPayload();
        }
        
        public class Builder
        {
            public CallEntriesPayload Build()
            {
                return new CallEntriesPayload();
            }
        }
    }
    
    public class InviteEmailSelectionPayload
    {
        public static InviteEmailSelectionPayload CreateBuilder()
        {
            return new InviteEmailSelectionPayload();
        }
        
        public class Builder
        {
            public InviteEmailSelectionPayload Build()
            {
                return new InviteEmailSelectionPayload();
            }
        }
    }
    
    public class InviteOptionsPayload
    {
        public static InviteOptionsPayload CreateBuilder()
        {
            return new InviteOptionsPayload();
        }
        
        public class Builder
        {
            public InviteOptionsPayload Build()
            {
                return new InviteOptionsPayload();
            }
        }
    }
    
    public class InviteSMSSelectedPayload
    {
        public static InviteSMSSelectedPayload CreateBuilder()
        {
            return new InviteSMSSelectedPayload();
        }
        
        public class Builder
        {
            public InviteSMSSelectedPayload Build()
            {
                return new InviteSMSSelectedPayload();
            }
        }
    }
    
    public class InviteEmailComposerPayload
    {
        public static InviteEmailComposerPayload CreateBuilder()
        {
            return new InviteEmailComposerPayload();
        }
        
        public class Builder
        {
            public InviteEmailComposerPayload Build()
            {
                return new InviteEmailComposerPayload();
            }
        }
    }
    
    public class OperationalAlert
    {
        public static OperationalAlert CreateBuilder()
        {
            return new OperationalAlert();
        }
        
        public class Builder
        {
            public OperationalAlert Build()
            {
                return new OperationalAlert();
            }
        }
    }
    
    public class InCallAlertPayload
    {
        public static InCallAlertPayload CreateBuilder()
        {
            return new InCallAlertPayload();
        }
        
        public class Builder
        {
            public InCallAlertPayload Build()
            {
                return new InCallAlertPayload();
            }
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
            
            public AudioModePayload SetDoLogin(bool doLogin)
            {
                return new AudioModePayload();
            }
        }
    }
    
    public class VideoModePayload
    {
        public static VideoModePayload CreateBuilder()
        {
            return new VideoModePayload();
        }
        
        public class Builder
        {
            public VideoModePayload Build()
            {
                return new VideoModePayload();
            }
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
            
            public DeviceTokenPayload SetDeviceToken(string token)
            {
                return new DeviceTokenPayload();
            }
            
            public DeviceTokenPayload SetDeviceTokenType(int type)
            {
                return new DeviceTokenPayload();
            }
        }
    }
}