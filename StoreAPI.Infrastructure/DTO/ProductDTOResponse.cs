namespace StoreAPI.Infrastructure.DTO
{
    public class ProductDTOResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
    }
}
