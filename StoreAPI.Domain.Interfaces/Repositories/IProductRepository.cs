using StoreAPI.Domain.Entities;

namespace StoreAPI.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task EditAsync(Guid id, string name, double price);
    }
}
