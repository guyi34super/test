using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;

namespace Elca.Sms.Api.Persistence.Implementations
{
    public class OrderBatchRepo : Repository<OrderBatch>, IOrderBatchRepository
    {
        public OrderBatchRepo(AppDbContext context) : base(context)
        {
        }
        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
