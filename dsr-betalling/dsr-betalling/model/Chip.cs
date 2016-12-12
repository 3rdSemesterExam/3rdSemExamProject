using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class Chip : IWebUri, IGetByAccountId
    {
        public Chip()
        {
            ResourceUri = "Chips";
            VerboseName = "Chips";
            GetByAccountId = true;
        }

        public Chip(string chipId, int accountId) : this()
        {
            ChipId = chipId;
            FK_Account = accountId;
        }

        public Chip(int id, string chipId, int accountId) : this()
        {
            Id = id;
            ChipId = chipId;
            FK_Account = accountId;
        }

        public int Id { get; }
        public string ChipId { get; set; }
        public int FK_Account { get; }

        // Interface Implentation
        public bool GetByAccountId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}