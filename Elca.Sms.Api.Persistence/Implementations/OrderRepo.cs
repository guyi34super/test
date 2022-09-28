using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Persistence.Implementations
{
    public class OrderRepo : Repository<Order>, IOrderRepository
    {
        public OrderRepo(AppDbContext context) : base(context)
        {
        }
        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
