using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("Products")]
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductLineId { get; set; }

        [ForeignKey(nameof(ProductLineId))]
        public ProductLine ProductLine { get; set; } 
       
    }
}
