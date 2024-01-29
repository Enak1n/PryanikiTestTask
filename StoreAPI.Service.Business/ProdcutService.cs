using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Exceptions;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Service.Interfaces;

namespace StoreAPI.Service.Business
{
    public class ProdcutService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdcutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Create(Product product)
        {
            var res = await _unitOfWork.Products.FindAsync(x => x.Name == product.Name);

            if(res != null)
            {
                throw new UniqueException($"Product with name {product.Name} already exist!");
            }

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task DeleteById(Guid id)
        {
            await _unitOfWork.Products.RemoveAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if(product == null)
            {
                throw new NotFoundException($"Product with {id} not found!");
            }

            return product;
        }

        public async Task Update(Guid id, string name, double price)
        {
            await _unitOfWork.Products.EditAsync(id, name, price);
        }
    }
}
