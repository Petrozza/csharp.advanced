using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class InvalidPhoneNumberErr : Exception
    {
        private const string INV_URL_MSG = "Invalid number!";

        public InvalidPhoneNumberErr() : base(INV_URL_MSG)
        {

        }
    }
}
