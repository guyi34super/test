using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Interfaces;

namespace Elca.Sms.Api.Persistence.Implementations
{
    public class ProductTypeRepo : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepo(AppDbContext context) : base(context)
        {
        }
        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
