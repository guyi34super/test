using Elca.Sms.Api.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Elca.Sms.Api.Persistence.Authentication;

namespace Elca.Sms.Api.Persistence.Extension
{
    public static class ChangeTrackerExtensions
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker, ICurrentUserRepo currentUserService)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities =
                changeTracker
                    .Entries()
                    .Where(t => t.Entity is IEntity &&
                    (
                        t.State == EntityState.Deleted
                        || t.State == EntityState.Added
                        || t.State == EntityState.Modified
                    ));

            if (entities.Any())
            {
                DateTimeOffset timestamp = DateTimeOffset.UtcNow;

                string user = currentUserService.GetCurrentUser().LoginName;

                foreach (EntityEntry entry in entities)
                {
                    IEntity entity = (IEntity)entry.Entity;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = timestamp;
                            entity.CreatedBy = user;
                            entity.UpdatedOn = timestamp;
                            entity.UpdatedBy = user;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedOn = timestamp;
                            entity.UpdatedBy = user;
                            break;
                        case EntityState.Deleted:
                            entity.IsDeleted = true;
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }
}
