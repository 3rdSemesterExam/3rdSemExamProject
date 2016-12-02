using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dsr_webservice
{
    [Table("ActivityLog")]
    public class ActivityLog
    {
        public int Id { get; set; }

        public int FK_Activity { get; set; }

        public int FK_Account { get; set; }

        public int FK_User { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public DateTime? Created { get; set; }

        public virtual Account Account { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual User User { get; set; }
    }
}