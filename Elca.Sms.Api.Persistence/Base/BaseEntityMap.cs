using Elca.Sms.Api.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elca.Sms.Api.Persistence.Base
{
    public abstract class BaseEntityMap<TEntity> : IEntityMap<TEntity> where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}