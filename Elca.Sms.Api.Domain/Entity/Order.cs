using Elca.Sms.Api.Domain.Common;
using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("Orders")]
    public class Order:BaseEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }
        
        [Required]
        public int OrderBatchId { get; set; } = 0;
        [Required]
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey(nameof(OrderBatchId))]
        public OrderBatch OrderBatch { get; set; } 

        [InverseProperty(nameof(Order))]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
