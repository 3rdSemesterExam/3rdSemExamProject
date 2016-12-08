using System;
using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class Purchase:IWebUri
    {
        public int Id { get; set; }
        public int FK_Account { get; set; }
        public int FK_User { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public Purchase()
        {
            ResourceUri = "Purchases";
            VerboseName = "Purchases";
        }

    }
}
