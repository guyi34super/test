using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class OrderItemMap : BaseEntityMap<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);
        }
    }
}