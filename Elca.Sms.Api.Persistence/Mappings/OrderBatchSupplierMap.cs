using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class OrderBatchSupplierMap : BaseEntityMap<OrderBatchSupplier>
    {
        public override void Configure(EntityTypeBuilder<OrderBatchSupplier> builder)
        {
            base.Configure(builder);
        }
    }
}