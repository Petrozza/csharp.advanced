using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountTests
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; set; }
    }
}
