using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    public class ChipHandler
    {
        private static IEnumerable<Chip> chipList;

        private static async void UpdateChipList()
        {
            chipList = await Facade.GetListAsync(new Chip());
        }

        public static async Task<bool> AddChipToAccountAsync(string chipId, int accountId)
        {
            return await Facade.PostAsync(new Chip(chipId, accountId));
        }

        public static async Task<bool> DeleteChipFromAccountAsync(string chipId)
        {
            var chip = GetChipByChipId(chipId);
            if (chip == null) return false;
            return await Facade.DeleteAsync(new Chip(), chip.Id);
        }

        public static int GetAccountIdFromChipId(string chipId)
        {
            UpdateChipList();
            return chipList.FirstOrDefault(chip => chip.ChipId == chipId).FK_Account;
        }

        private static Chip GetChipByChipId(string chipId)
        {
            UpdateChipList();
            return chipList.FirstOrDefault(chip => chip.ChipId == chipId);
        }
    }
}
