using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsing, ICalling
    {
        public Smartphone()
        {

        }
        public string Browsing(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLExcMsg();
            }
            return $"Browsing: {url}!";
        }

        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberErr();
            }
            return $"Calling... {phoneNumber}";
        }
    }
}