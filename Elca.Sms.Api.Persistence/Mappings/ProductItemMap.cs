using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class ProductItemMap : BaseEntityMap<ProductItem>
    {
        public override void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            base.Configure(builder);
        }
    }
}