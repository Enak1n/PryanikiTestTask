using StoreAPI.Domain.Entities;

namespace StoreAPI.Service.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Create(Order product);
        Task<Order> IsReady(Guid id);
        Task<Order> IsPaymented(Guid id);
        Task<Order> Cancel(Guid id);
    }
}
