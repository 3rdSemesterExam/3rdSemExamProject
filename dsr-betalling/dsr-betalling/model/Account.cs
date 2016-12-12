using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class Account : IWebUri
    {
        public Account()
        {
            ResourceUri = "Accounts";
            VerboseName = "Accounts";
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

        public int Id { get; }
        public string AccountHolderName { get; set; }
        private float Balance { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        /// <summary>
        ///     Adds Funds to Account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddFunds(float amount)
        {
            if ((amount < 0f) || (amount > 500f)) return false;
            Balance += amount;
            return true;
        }

        /// <summary>
        ///     Withdraws Funds from Account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool WithdrawFunds(float amount)
        {
            if ((amount > Balance) || (amount < 0)) return false;
            Balance -= amount;
            return true;
        }

        /// <summary>
        ///     Gets the current Account Balance
        /// </summary>
        /// <returns></returns>
        public float GetAccountBalance()
        {
            return Balance;
        }
    }
}