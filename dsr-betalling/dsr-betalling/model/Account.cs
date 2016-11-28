using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.@interface;

namespace dsr_betalling.model
{
    class Account : IWebUri
    {
        public int Id { get; private set; }
        public string AccountHolderName { get; set; }
        public float Balance { get; private set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Account()
        {
            ResourceUri = "";
            VerboseName = "";
        }

        public Account(string accountHolderName, float balance) : this()
        {
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public Account(int id, string accountHolderName, float balance) : this()
        {
            Id = id;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public bool AddFunds(float amount)
        {
            if (amount < 0 || amount > 500) return false;
            Balance += amount;
            return true;
        }

        public bool WithdrawFunds(float amount)
        {
            if (amount > Balance || amount < 0) return false;
            Balance -= amount;
            return true;
        }

        public float GetAccountBalance()
        {
            return Balance;
        }

    }
}
