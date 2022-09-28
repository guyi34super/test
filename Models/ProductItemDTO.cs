using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class ProductItemDTO
    {
        [Required]
        [MaxLength(255)]
        public string ItemName { get; set; } = string.Empty;
        [Required]
        public int CurrentItemQuantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderBatchId { get; set; }
    }
}
