using System;
using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class ActivityLog : IWebUri
    {
        public int Id { get; }
        public int FK_Actvity { get; }
        public int FK_Account { get; }
        public int FK_User { get; }
        public float Amount { get; set; }
        public DateTime Created { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public ActivityLog()
        {

        }

    }
}
