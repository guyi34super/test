using Elca.Sms.Api.Domain.Common;
using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("OrderItems")]
    public class OrderItem : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemRequestId { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public OrderItemStatus OrderItemStatus { get; set; }

        [ForeignKey(nameof(OrderId))] 
        public Order Order { get; set; }

        [InverseProperty(nameof(OrderItem))]
        public List<ItemRequest> ItemRequests { get; set; } = new List<ItemRequest>(); 
    }
}
