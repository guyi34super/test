using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Elca.Sms.Api.Service.Interfaces
{
    public interface IService<TEntity, TResponse>
        where TEntity : class
        where TResponse : class
    {
        Task<TEntity> GetAsync(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> ListAsync();
        Task<TResponse> PostAsync(TEntity tEntity);
        Task<TResponse> UpdateAsync(int id, TEntity tEntity);
        Task<TResponse> DeleteAsync(int id);
    }
}
