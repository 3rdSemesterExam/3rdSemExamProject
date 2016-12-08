using dsr_betalling.Interface;

namespace dsr_betalling.Model
{
    public class PurchaseItem : IWebUri
    {
        public int Id { get; set; }
        public int FK_Purchase { get; set; }
        public int FK_Product { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string ResourceUri { get; }
        public string VerboseName { get; }

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
    }
}
