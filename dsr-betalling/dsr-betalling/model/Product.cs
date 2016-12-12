using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class Product : IWebUri
    {
        public Product()
        {
            ResourceUri = "Products";
            VerboseName = "Products";
        }

        public int Id { get; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float Rebate { get; set; }

        // Interface Implementation
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}