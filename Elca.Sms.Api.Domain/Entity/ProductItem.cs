using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("ProductItems")]
    public class ProductItem : BaseEntity
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

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = default!;
        
        [ForeignKey(nameof(OrderBatchId))]
        public OrderBatch OrderBatch { get; set; } = default!;     
    }
}
