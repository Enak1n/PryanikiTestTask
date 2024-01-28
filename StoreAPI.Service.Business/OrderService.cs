using StoreAPI.Domain.Entities;
using StoreAPI.Service.Interfaces;

namespace StoreAPI.Service.Business
{
    public class OrderService : IOrderService
    {
        public Task<Order> Cancel(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Create(Order product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> IsPaymented(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> IsReady(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
