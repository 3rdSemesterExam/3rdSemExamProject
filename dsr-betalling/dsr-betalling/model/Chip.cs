using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class Chip : IWebUri
    {
        public int Id { get; }
        public string ChipId { get; set; }
        public int FK_Account { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Chip()
        {
            ResourceUri = "Chips";
            VerboseName = "Chips";
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

    }
}
