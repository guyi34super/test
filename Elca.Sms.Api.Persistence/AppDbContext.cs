using Microsoft.EntityFrameworkCore;
using Elca.Sms.Api.Domain.Entity;
using Elca.Sms.Api.Persistence.Mappings;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Elca.Sms.Api.Persistence.Extension;
using Elca.Sms.Api.Persistence.Authentication;

namespace Elca.Sms.Api.Persistence
{
    public class AppDbContext:DbContext 
    {
        private readonly ICurrentUserRepo _currentUserService;

        public AppDbContext (DbContextOptions options, ICurrentUserRepo currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }
        
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderBatch> OrderBatch { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<ProductLine> ProductLine { get; set; }        
        public DbSet<Requestor> Requestor { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());

            modelBuilder.ApplyConfiguration(new OrderBatchMap());
            modelBuilder.ApplyConfiguration(new OrderBatchSupplierMap()); 
            modelBuilder.ApplyConfiguration(new ProductMap());

            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new ProductItemMap());


            modelBuilder.ApplyConfiguration(new ProductLineMap());
            modelBuilder.ApplyConfiguration(new RequestorMap());

            modelBuilder.ApplyConfiguration(new SupplierMap());
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties(_currentUserService);
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
