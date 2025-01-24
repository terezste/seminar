using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        Random rng = new Random();

        public int accountNumber;
        public string holderName;
        public string currency;
        public int balance;

        public void Deposit(int ammount);

        public void Withdraw(int ammount);

        public void Transfer(int ammount, int accountNumberFrom, int accountNumberTo);

        public BankAccount (string holderName, string currency)
        {
            this.holderName = holderName;
            this.currency = currency;

            this.accountNumber = rng.Next(100000000, 10000000000);

        }
    }
}
