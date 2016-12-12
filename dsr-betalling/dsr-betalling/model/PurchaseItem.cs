using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class PurchaseItem : IWebUri
    {
        private PurchaseItem()
        {
            ResourceUri = "PurchaseItem";
            VerboseName = "PurchaseItem";
        }

        public PurchaseItem(int fkPurchase, int fkProduct, int amount, float price) : this()
        {
            FK_Purchase = fkPurchase;
            FK_Product = fkProduct;
            Amount = amount;
            Price = price;
        }

        private int Id { get; set; }
        internal int FK_Purchase { get; set; }
        private int FK_Product { get; set; }
        internal int Amount { get; set; }
        internal float Price { get; set; }

        // Interface Implementation
        public string ResourceUri { get; }
        public string VerboseName { get; }
    }
}