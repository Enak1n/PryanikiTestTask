using StoreAPI.Domain.Entities;
using StoreAPI.Service.Interfaces;

namespace StoreAPI.Service.Business
{
    public class ProdcutService : IProductService
    {
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
