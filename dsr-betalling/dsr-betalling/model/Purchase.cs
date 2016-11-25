using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class Purchase
    {
        public int Id { get; set; }
        public int FK_Account { get; set; }
        public int FK_User { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Created { get; set; }

        public Purchase()
        {
            
        }
    }
}
