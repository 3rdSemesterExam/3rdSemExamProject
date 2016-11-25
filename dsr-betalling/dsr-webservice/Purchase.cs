using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace dsr_webservice
{
    [Table("Purchase")]
    public class Purchase
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            PurchaseItems = new HashSet<PurchaseItem>();
        }

        public int Id { get; set; }

        public int FK_Account { get; set; }

        public int FK_User { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public DateTime? Created { get; set; }

        public virtual Account Account { get; set; }

        public virtual User User { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}