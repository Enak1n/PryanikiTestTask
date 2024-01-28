using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;

namespace StoreAPI.Infrastructure.UnitOfWork.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context){ }
    }
}
