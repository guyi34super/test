using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class OrderBatchSupplierDTO
    {
        [Required]
        public int OrderBatchId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
