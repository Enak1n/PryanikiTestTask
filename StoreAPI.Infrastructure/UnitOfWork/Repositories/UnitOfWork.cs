using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context _context;

        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            Products = new ProductRepository(context);
            Orders = new OrderRepository(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
