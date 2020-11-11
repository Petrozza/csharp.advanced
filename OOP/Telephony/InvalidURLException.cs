using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class InvalidURLExcMsg : Exception
    {
        private const string URL_EXC_MSG = "Invalid URL!";

        public InvalidURLExcMsg() : base(URL_EXC_MSG)
        {

        }
    }
}
