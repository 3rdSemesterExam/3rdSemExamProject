using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class PurchaseItems : IWebUri
    {
        public int Id { get; set; }
        public int FK_Purchase { get; set; }
        public int FK_Product { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        public PurchaseItems()
        {
            ResourceUri = "PurchaseItems";
            VerboseName = "PurchaseItems";
        }

    }
}
