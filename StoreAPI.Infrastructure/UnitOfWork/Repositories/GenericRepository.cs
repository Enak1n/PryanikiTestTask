using Microsoft.EntityFrameworkCore;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;
using System.Linq.Expressions;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _dataBase;

        public GenericRepository(Context context)
        {
            _context = context;
            _dataBase = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dataBase.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dataBase.AsNoTracking().ToListAsync();
        }

        public TEntity GetByIdAsync(Guid id)
        {
            return _dataBase.Find(id);
        }

        public async Task<List<TEntity>> GetByPage(int page, int pageSize)
        {
            return await _dataBase.AsNoTracking().
                Skip((page - 1) * pageSize).
                Take(pageSize).ToListAsync();
        }

        public Task RemoveAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
