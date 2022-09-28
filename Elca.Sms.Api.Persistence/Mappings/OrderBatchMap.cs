using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class OrderBatchMap : BaseEntityMap<OrderBatch>
    {
        public override void Configure(EntityTypeBuilder<OrderBatch> builder)
        {
            base.Configure(builder);
        }
    }
}