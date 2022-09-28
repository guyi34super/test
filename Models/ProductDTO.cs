using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ProductLineId { get; set; }
    }
}
