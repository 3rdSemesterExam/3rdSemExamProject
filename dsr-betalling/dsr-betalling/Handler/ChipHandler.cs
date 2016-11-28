using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.common;
using dsr_betalling.model;

namespace dsr_betalling.handler
{
    class ChipHandler
    {
        public static async Task<bool> AddChipToAccountAsync(string chipId, int accountId)
        {
            return await facade.PostAsync(new Chip(chipId, accountId));
        }

        public static async Task<bool> DeleteChipFromAccountAsync(int chipId)
        {
            return await facade.DeleteAsync(new Chip(), chipId);
        }

    }
}
