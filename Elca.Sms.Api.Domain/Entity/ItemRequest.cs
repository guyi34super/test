using Elca.Sms.Api.Domain.Common;
using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    public class ItemRequest:BaseEntity
    {
        [Required]
        public DateTime RequestDate { get; set; }
        [Required]
        public int ItemOrderId { get; set; }

        [Required]
        public int RequestorId { get; set; }
        [Required]
        public string RequestDescription { get; set; } = string.Empty; 
        public int ItemQuantity { get; set; }
        [Required]
        public RequestStatus RequestStatus { get; set; } 

        [ForeignKey(nameof(RequestorId))]
        public Requestor Requestor { get; set; }

        [ForeignKey(nameof(ItemOrderId))]
        public OrderItem OrderItem { get; set; }



    }
}
