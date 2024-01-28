using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context) { }
    }
}
