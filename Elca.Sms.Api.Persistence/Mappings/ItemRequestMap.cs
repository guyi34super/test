using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Persistence.Mappings
{
    internal class ItemRequestMap: BaseEntityMap<ItemRequest>
    {
        public override void Configure(EntityTypeBuilder<ItemRequest> builder)
    {
        base.Configure(builder);
    }
}
}