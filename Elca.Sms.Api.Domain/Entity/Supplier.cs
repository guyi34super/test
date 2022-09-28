using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("Suppliers")]
    public class Supplier: BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Organisation { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string OrganisationAddress { get; set; } = default!;
        [Required]
        [MaxLength(255)]
        public string ContactPerson { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public int IsActive { get; set; } = default!;

        [InverseProperty(nameof(Supplier))]
        public List<OrderBatchSupplier> OrderBatchSuppliers { get; set; } = new List<OrderBatchSupplier>();  
    }
}
