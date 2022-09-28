using Elca.Sms.Api.Domain.Communication;
using Elca.Sms.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Service.Interfaces
{
    public interface IOrderBatchService : IService<OrderBatch, OrderBatchResponse>
    {
    }
}
