using StoreAPI.Domain.Entities;

namespace StoreAPI.Infrastructure.DTO
{
    public class OrderDTORequest
    {
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
