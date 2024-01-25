namespace StoreAPI.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }

        Task SaveChangesAsync();
    }
}
