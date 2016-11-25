using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dsr_webservice
{
    [Table("Chip")]
    public class Chip
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ChipId { get; set; }

        public int FK_Account { get; set; }

        public virtual Account Account { get; set; }
    }
}