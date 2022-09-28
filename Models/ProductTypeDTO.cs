using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class ProductTypeDTO
    {
        [Required]
        [MaxLength(255)]
        public string ProductTypeName { get; set; } = string.Empty;
    }
}
