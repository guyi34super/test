using Elca.Sms.Api.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elca.Sms.Api.Domain.Entity
{
    [Table("OrderBatches")]
    public class OrderBatch: BaseEntity
    {

        DateTime OrderBatchDate { get; set; }

        public string OrderBatchDescription { get; set; } = string.Empty;

        [InverseProperty(nameof(OrderBatch))]
        public List<Order> Orders { get; set; } = new List<Order>();

        [InverseProperty(nameof(OrderBatch))]
        public List<OrderBatchSupplier> OrderBatchSuppliers { get; set; } = new List<OrderBatchSupplier>();


    }
}
