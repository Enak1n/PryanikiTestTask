using Microsoft.EntityFrameworkCore;
using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Exceptions;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task EditAsync(Guid id, string name, double price)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                throw new NotFoundException("Product not found!");

            await _context.Products.Where(p => p.Id == id).
                                    ExecuteUpdateAsync(p => p.SetProperty(c => c.Name, name)
                                                             .SetProperty(c => c.Price, price));
        }
    }
}
