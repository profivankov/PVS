using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PVS.Persistance.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
