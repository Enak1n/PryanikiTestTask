using Microsoft.EntityFrameworkCore;
using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;
using System.Linq.Expressions;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
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

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dataBase.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dataBase.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dataBase.FindAsync(id);
        }

        public async Task<List<TEntity>> GetByPage(int page, int pageSize)
        {
            return await _dataBase.AsNoTracking().
                Skip((page - 1) * pageSize).
                Take(pageSize).ToListAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _dataBase.Where(e => e.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
