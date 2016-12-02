using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    class ChipHandler
    {
        public static async Task<bool> AddChipToAccountAsync(string chipId, int accountId)
        {
            return await Facade.PostAsync(new Chip(chipId, accountId));
        }

        public static async Task<bool> DeleteChipFromAccountAsync(string chipId)
        {
            var chip = await GetChipByChipId(chipId);
            if (chip == null) return false;
            return await Facade.DeleteAsync(new Chip(), chip.Id);
        }

        public static async Task<int> GetAccountIdFromChipId(string chipId)
        {
            var chips = await Facade.GetListAsync(new Chip());
            foreach (var chip in chips)
            {
                if (chip.ChipId==chipId)
                    return chip.FK_Account;
            }
            return -1;
        }

        public static async Task<Chip> GetChipByChipId(string chipId)
        {
            var chips = await Facade.GetListAsync(new Chip());
            //return chips.FirstOrDefault(chip => chip.ChipId == chipId);
            foreach (var chip in chips)
            {
                if (chip.ChipId == chipId)
                {
                    return chip;
                }
            }
            return null;
        }
    }
}
