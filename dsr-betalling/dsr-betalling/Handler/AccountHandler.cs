using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.common;
using dsr_betalling.model;

namespace dsr_betalling.handler
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
            try
            {
                return await facade.GetAsync(new Account(), accountId);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Creates an Account
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> CreateAccountAsync(Account account)
        {
            return await facade.PostAsync(account);
        }

        /// <summary>
        /// Updates an Account
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> UpdateAccountAsync(Account account)
        {
            return await facade.PutAsync(account, account.Id);
        }

        /// <summary>
        /// Deletes an Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns>Boolean</returns>
        public static async Task<bool> DeleteAccountAsync(int accountId)
        {
            return await facade.DeleteAsync(new Account(), accountId);
        }
    }
}
