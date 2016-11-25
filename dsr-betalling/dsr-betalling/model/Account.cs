using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class Account
    {
        private int Id { get; set; }
        private string AccountHolderName { get; set; }
        private float Balance { get; set; }

        public Account(string accountHolderName, float balance)
        {
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public Account(int id, string accountHolderName, float balance)
        {
            Id = id;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }
    }
}
