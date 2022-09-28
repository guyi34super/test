using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class ProductLineMap : BaseEntityMap<ProductLine>
    {
        public override void Configure(EntityTypeBuilder<ProductLine> builder)
        {
            base.Configure(builder);
        }
    }
}