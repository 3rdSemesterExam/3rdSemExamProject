using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsr_betalling.@interface;

namespace dsr_betalling.model
{
    class Chip: IWebUri
    {
        private int Id { get; set; }
        public string ChipId { get; set; }
        private int FK_Account { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Chip()
        {
            ResourceUri = "";
            VerboseName = "";
        }

        public Chip(string chipId, int accountId): this()
        {
            ChipId = chipId;
            FK_Account = accountId;
        }

        public Chip(int id, string chipId, int accountId): this()
        {
            Id = id;
            ChipId = chipId;
            FK_Account = accountId;
        }

    }
}
