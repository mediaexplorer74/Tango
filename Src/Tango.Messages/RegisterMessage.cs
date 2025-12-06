using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango.Messages
{
    public class RegisterMessage
    {
        private WinPhoneTango.RegisterUserPayload _builder1;

        // Experimental
        public RegisterMessage(long SeqId)
        { 
            // ...
        }

        public RegisterMessage(long SeqId, WinPhoneTango.RegisterUserPayload builder1) : this(SeqId)
        {
            _builder1 = builder1;
        }
    }
}
