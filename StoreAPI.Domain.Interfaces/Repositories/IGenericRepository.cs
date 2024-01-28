using System.Linq.Expressions;

namespace StoreAPI.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        TEntity GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<List<TEntity>> GetByPage(int page, int pageSize);
    }
}
