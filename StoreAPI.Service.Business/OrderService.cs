using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Exceptions;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Service.Interfaces;

namespace StoreAPI.Service.Business
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Cancel(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with Id {id} not found!");

            if (order.IsCanceled)
                throw new Exception("Order has been already canceled!");

            order.IsCanceled = true;

            await _unitOfWork.SaveChangesAsync();

            return order;
        }

        public async Task<Order> Create(Order order, List<Product> products)
        {
            double totalCost = 0;

            foreach (var product in products) 
            {
                totalCost += product.Price;
            }

            order.TotalCost = totalCost;
            await _unitOfWork.Orders.AddAsync(order);

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if(order == null)
            {
                throw new NotFoundException($"Order with id {id} not found!");
            }

            return order;
        }

        public async Task<Order> IsPaymented(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found!");

            if (order.IsPaymented)
                throw new Exception("Order has been already paid!");

            if (order.IsCanceled)
                throw new Exception("Order was canceled!");

            order.IsPaymented = true;

            await _unitOfWork.SaveChangesAsync();

            return order;
        }

        public async Task<Order> IsReady(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with this Id {id} not found!");

            if (order.IsCanceled)
                throw new Exception("Order has been canceled!");

            if (order.IsReady)
                throw new Exception("Order has been already readied!");

            order.IsReady = true;

            await _unitOfWork.SaveChangesAsync();

            return order;
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.Orders.RemoveAsync(id);
        }
    }
}
