using StoreAPI.Domain.Entities;

namespace StoreAPI.Service.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Create(Product product);
        Task Update(Guid id, string name, double price);
        Task DeleteById(Guid id);
    }
}
