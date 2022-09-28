using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class OrderItemDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ItemRequestId { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public OrderItemStatus OrderItemStatus { get; set; }
    }
}
