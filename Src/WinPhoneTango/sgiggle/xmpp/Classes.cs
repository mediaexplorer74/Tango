using System;

namespace sgiggle.xmpp
{
    public class CallEntry
    {
        public string Name { get; set; }
        public string LastCallText { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CountryCode
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public int Id { get; set; }
    }
}