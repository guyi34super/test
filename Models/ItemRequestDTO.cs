using Elca.Sms.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ELCAStock.Models
{
    public class ItemRequestDTO
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
    }
}
