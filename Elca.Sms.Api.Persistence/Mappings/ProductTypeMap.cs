using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class ProductTypeMap : BaseEntityMap<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            base.Configure(builder);
        }
    }
}