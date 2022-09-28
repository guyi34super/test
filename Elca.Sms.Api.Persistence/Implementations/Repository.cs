using Elca.Sms.Api.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Elca.Sms.Api.Persistence.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;
        public Repository(AppDbContext context)
        {
            Context = context;
        }
        //public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    await Context.Set<TEntity>().AddRangeAsync(entities);
        //}

        public async Task AddSync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                Context.Set<TEntity>().Update(entity);
            });
        }

        //public void DeleteRangeSync(IEnumerable<TEntity> tEntities)  
        //{
        //      Context.Set<TEntity>().RemoveRange(tEntities);
        //}

        public void DeleteSync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}
