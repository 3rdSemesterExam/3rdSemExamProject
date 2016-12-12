using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

// ReSharper disable MemberCanBePrivate.Global

namespace dsr_betalling.Handler
{
    public static class ChipHandler
    {
        private static IEnumerable<Chip> chipList;

        /// <summary>
        ///     Refreshes the Chip List
        /// </summary>
        private static async void UpdateChipList()
        {
            chipList = await GetChipList();
        }

        /// <summary>
        ///     Associates a chip with an Account
        /// </summary>
        /// <param name="chipId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static async Task<bool> AddChipToAccountAsync(string chipId, int accountId)
        {
            return await Facade.PostAsync(new Chip(chipId, accountId));
        }

        /// <summary>
        ///     Removes association between chip and account, and removes the chip
        /// </summary>
        /// <param name="chipId"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteChipFromAccountAsync(string chipId)
        {
            var chip = GetChipByChipId(chipId);
            if (chip == null) return false;
            return await Facade.DeleteAsync(new Chip(), chip.Id);
        }

        /// <summary>
        ///     Gets the Account Id associated with a chip, based on Chip Id
        /// </summary>
        /// <param name="chipId"></param>
        /// <returns></returns>
        public static int GetAccountIdFromChipId(string chipId)
        {
            UpdateChipList();
            return chipList.FirstOrDefault(chip => chip.ChipId == chipId).FK_Account;
        }

        /// <summary>
        ///     Gets a Chip Object from a Chip Id
        /// </summary>
        /// <param name="chipId"></param>
        /// <returns></returns>
        private static Chip GetChipByChipId(string chipId)
        {
            UpdateChipList();
            return chipList.FirstOrDefault(chip => chip.ChipId == chipId);
        }

        /// <summary>
        ///     Gets a list of Chips
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Chip>> GetChipList()
        {
            return await Facade.GetListAsync(new Chip());
        }
    }
}