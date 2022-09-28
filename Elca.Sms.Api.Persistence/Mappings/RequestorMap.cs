using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Mappings
{
    public class RequestorMap : BaseEntityMap<Requestor>
    {
        public override void Configure(EntityTypeBuilder<Requestor> builder)
        {
            base.Configure(builder);
        }
    }
}