using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassword";

        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            } 
        }

        private int Id { get; set; }
        public double BankAccountBallance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }
}
