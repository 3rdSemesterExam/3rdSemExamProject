using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    class PurchaseItems : IWebUri
    {
        private int Id { get; set; }
        private int FK_Purchase { get; set; }
        private int FK_Product { get; set; }
        private int Amount { get; set; }
        private float Price { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

        private PurchaseItems()
        {
            ResourceUri = "PurchaseItems";
            VerboseName = "PurchaseItems";
        }

        public PurchaseItems(int fkProduct, int amount, float price) : this()
        {
            Id = 0;
            FK_Purchase = 0;
            FK_Product = fkProduct;
            Amount = amount;
            Price = price;
        }
    }
}
