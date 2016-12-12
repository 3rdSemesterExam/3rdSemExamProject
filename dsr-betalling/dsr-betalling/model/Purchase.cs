using System;
using dsr_betalling.Interface;
// ReSharper disable UnusedMember.Local

namespace dsr_betalling.Model
{
    public class Purchase : IWebUri, IGetByAccountId, IGetByUserId
    {
        public Purchase()
        {
            ResourceUri = "Purchases";
            VerboseName = "Purchases";
            GetByAccountId = true;
            GetByUserId = true;
        }

        public Purchase(int accountId, int dsrUserId, float totalPrice, DateTime created) : this()
        {
            FK_Account = accountId;
            FK_User = dsrUserId;
            TotalPrice = totalPrice;
            Created = created;
        }

        private int Id { get; set; }
        private int FK_Account { get; set; }
        private int FK_User { get; set; }
        private float TotalPrice { get; set; }
        private DateTime Created { get; set; }

        // Interface Implementation
        public bool GetByAccountId { get; }
        public string ResourceUri { get; }
        public string VerboseName { get; }
        public bool GetByUserId { get; }
    }
}