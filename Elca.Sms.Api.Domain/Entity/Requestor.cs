using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    public class Requestor:BaseEntity
    {
        [Required]
        [MaxLength(4)]
        public string Visa { get; set; } =  string.Empty; 
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;       

        [InverseProperty(nameof(Requestor))]
        public List<ItemRequest> ItemRequests { get; set; } = new List<ItemRequest>();
        
    }
}
