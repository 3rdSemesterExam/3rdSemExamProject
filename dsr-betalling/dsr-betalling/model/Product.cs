using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsr_betalling.model
{
    class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float Rebate { get; set; }

        public Product()
        {
            
        }
    }
}
