using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    public  class ProductLine: BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ProductLineName { get; set; } = string.Empty; 
            


        [Required]
        public int ProductTypeId { get; set; }

        [ForeignKey(nameof(ProductTypeId))]
        public ProductType ProductType { get; set; }


    }
}
