using System;
using dsr_betalling.Interface;
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable UnusedMember.Local

namespace dsr_betalling.Model
{
    public class ActivityLog : IWebUri, IGetByAccountId, IGetByUserId, IGetByActivityId
    {
        public ActivityLog()
        {
            ResourceUri = "ActivityLogs";
            VerboseName = "ActivityLogs";
            GetByAccountId = true;
            GetByUserId = true;
            GetByActivityId = true;
        }

        public ActivityLog(int fkActvity, int fkAccount, int fkUser, float amount, DateTime created) : this()
        {
            FK_Actvity = fkActvity;
            FK_Account = fkAccount;
            FK_User = fkUser;
            Amount = amount;
            Created = created;
        }

        private int Id { get; }
        private int FK_Actvity { get; }
        private int FK_Account { get; }
        private int FK_User { get; }
        private float Amount { get; set; }
        private DateTime Created { get; set; }

        // Interface Implementation
        public string ResourceUri { get; }
        public string VerboseName { get; }
        public bool GetByAccountId { get; }
        public bool GetByActivityId { get; }
        public bool GetByUserId { get; }
    }
}