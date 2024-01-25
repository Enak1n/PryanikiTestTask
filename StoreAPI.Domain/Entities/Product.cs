namespace StoreAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
