using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Elca.Sms.Api.Domain.Entity
{
    [Table("ProductTypes")]
    public class ProductType: BaseEntity
    {
        [Required]
        [MaxLength(255)]

        public string ProductTypeName { get; set; } = string.Empty; 

        [InverseProperty(nameof(ProductType))]
        public List<ProductLine> ProductLines { get; set; } = new List<ProductLine>();
    }
}
