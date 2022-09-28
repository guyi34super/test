using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class ProductMap : BaseEntityMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
        }
    }
}