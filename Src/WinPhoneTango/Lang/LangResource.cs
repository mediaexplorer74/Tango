using System;
using System.Resources;

namespace WinPhoneTango.Lang
{
    public class LangResource
    {
        private static ResourceManager _resourceManager = new ResourceManager("WinPhoneTango.Lang.LangResource", typeof(LangResource).Assembly);

        public string SettingsTitle
        {
            get { return _resourceManager.GetString("SettingsTitle"); }
        }

        public string ContactsAll
        {
            get { return _resourceManager.GetString("ContactsAll"); }
        }

        public string ContactsTango
        {
            get { return _resourceManager.GetString("ContactsTango"); }
        }

        public string AllCallTitle
        {
            get { return _resourceManager.GetString("AllCallTitle"); }
        }

        public string MissedCallTitle
        {
            get { return _resourceManager.GetString("MissedCallTitle"); }
        }

        public string CallHistoryTitle
        {
            get { return _resourceManager.GetString("CallHistoryTitle"); }
        }

        public string CallLogNoCallsMsg
        {
            get { return _resourceManager.GetString("CallLogNoCallsMsg"); }
        }

        public string CallLogNoMissedCallsMsg
        {
            get { return _resourceManager.GetString("CallLogNoMissedCallsMsg"); }
        }

        public string InviteContactPrompt
        {
            get { return _resourceManager.GetString("InviteContactPrompt"); }
        }

        public string InviteSms
        {
            get { return _resourceManager.GetString("InviteSms"); }
        }

        public string InviteEmail
        {
            get { return _resourceManager.GetString("InviteEmail"); }
        }

        public string NoSearchResult
        {
            get { return _resourceManager.GetString("NoSearchResult"); }
        }

        public string NoContactsMsg
        {
            get { return _resourceManager.GetString("NoContactsMsg"); }
        }

        public string Copyright
        {
            get { return _resourceManager.GetString("Copyright"); }
        }

        public string Version
        {
            get { return _resourceManager.GetString("Version"); }
        }

        public string TipsButton
        {
            get { return _resourceManager.GetString("TipsButton"); }
        }
    }
}