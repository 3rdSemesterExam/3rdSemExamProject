using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class PurchaseItems
    {
        public int Id { get; set; }
        public int FK_Purchase { get; set; }
        public int FK_Product { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }

        public PurchaseItems()
        {
            
        }
    }
}
