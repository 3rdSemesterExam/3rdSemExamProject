using System.ComponentModel.DataAnnotations.Schema;

namespace dsr_webservice
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        public int FK_Purchase { get; set; }

        public int FK_Product { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}