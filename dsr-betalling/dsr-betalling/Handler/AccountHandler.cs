using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    class AccountHandler
    {
        /// <summary>
        /// Fetches an Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns>Account Object</returns>
        public static async Task<Account> GetAccountAsync(int accountId)
        {
            return await Facade.GetAsync(new Account(), accountId);
        }

        /// <summary>
        /// Creates an Account
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> CreateAccountAsync(Account account)
        {
            return await Facade.PostAsync(account);
        }

        /// <summary>
        /// Updates an Account
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> UpdateAccountAsync(Account account)
        {
            return await Facade.PutAsync(account, account.Id);
        }

        /// <summary>
        /// Deletes an Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> DeleteAccountAsync(int accountId)
        {
            return await Facade.DeleteAsync(new Account(), accountId);
        }
    }
}
