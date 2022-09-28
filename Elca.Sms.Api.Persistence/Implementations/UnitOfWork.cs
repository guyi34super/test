using Elca.Sms.Api.Persistence.Interfaces;


namespace Elca.Sms.Api.Persistence.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable 
    {
        private readonly AppDbContext _context;      

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            OrderBatches = new OrderBatchRepo(_context);
            Orders = new OrderRepo(_context);
            OrderItems = new OrderItemRepo(_context);
            ProductTypes = new ProductTypeRepo(_context);
            ProductLines = new ProductLineRepo(_context);
            Products = new ProductRepo(_context);
            ProductItems = new ProductItemRepo(_context);
            Requestors = new RequestorRepo(_context);
            Suppliers = new SupplierRepo(_context);
            ItemRequests = new ItemRequestRepo(_context);
            OrderBatchSuppliers = new OrderBatchSupplierRepo(_context);
        }

        public IOrderBatchRepository OrderBatches { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }

        public IProductTypeRepository ProductTypes { get; private set; } 
        public IProductLineRepository ProductLines { get; private set; }
        public IProductRepository Products { get; private set; }

        public IProductItemRepository ProductItems { get; private set; }
        public IRequestorRepository Requestors { get; private set; } 
        public ISupplierRepository Suppliers { get; private set; }
        public IItemRequestRepository ItemRequests { get; private set; }
        public IOrderBatchSupplierRepository OrderBatchSuppliers { get; private set; }

        public async Task CompleteAsync()
        {            
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
