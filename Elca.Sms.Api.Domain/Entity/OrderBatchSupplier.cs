using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("OrderBatchSuppliers")]
    public class OrderBatchSupplier: BaseEntity
    {
        [Required]
        public int OrderBatchId { get; set; }
        [Required]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(OrderBatchId))]
        public OrderBatch OrderBatch { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        
    }
}
