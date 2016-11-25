using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class Chip
    {
        private int Id { get; set; }
        private string ChipId { get; set; }
        private int FK_Account { get; set; }

        public Chip(string chipId)
        {
            ChipId = chipId;
        }

        private Chip(int id, string chipId)
        {
            Id = id;
            ChipId = chipId;
        }
    }
}
