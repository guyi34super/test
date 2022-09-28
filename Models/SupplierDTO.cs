using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class SupplierDTO
    {
        [Required]
        [MaxLength(255)]
        public string Organisation { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string OrganisationAddress { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string ContactPerson { get; set; } = default!;
        [Required]
        public string ContactNumber { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        [Required]
        public int IsActive { get; set; } = default!;
    }
}
