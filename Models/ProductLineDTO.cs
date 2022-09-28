using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class ProductLineDTO
    {
        [Required]
        [MaxLength(255)]
        public string ProductLineName { get; set; } = string.Empty;

        [Required]
        public int ProductTypeId { get; set; }
    }
}
