using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderBatchRepository OrderBatches { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; } 
        IProductRepository Products { get; }
        IProductLineRepository ProductLines { get; }
        IProductItemRepository ProductItems { get; }
        IProductTypeRepository ProductTypes { get; }
        IRequestorRepository Requestors { get; } 
        ISupplierRepository Suppliers { get; }
        IItemRequestRepository ItemRequests { get; }
        IOrderBatchSupplierRepository OrderBatchSuppliers { get; }

        Task CompleteAsync();
    }
}
