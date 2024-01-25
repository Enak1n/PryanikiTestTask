namespace StoreAPI.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
