using System.Linq.Expressions;


namespace Elca.Sms.Api.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> ListAsync();
        Task<TEntity> GetAsync(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task AddSync(TEntity entity);
        //Task AddRangeAsync(IEnumerable<TEntity> entities);

        void DeleteSync(TEntity entity);
        // void DeleteRangeSync(IEnumerable<TEntity> entities);  
    }
}
