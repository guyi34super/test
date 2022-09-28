using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class OrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }       
        [Required]
        public int OrderBatchId { get; set; } = 0;
        [Required]
        public OrderStatus OrderStatus { get; set; }
    }
}
