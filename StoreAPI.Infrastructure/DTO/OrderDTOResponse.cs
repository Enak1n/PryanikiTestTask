namespace StoreAPI.Infrastructure.DTO
{
    public class OrderDTOResponse
    {
        public string Address { get; set; }
        public double TotalCost { get; set; }
        public bool IsCanceled { get; set; } = false;
        public bool IsReady { get; set; } = false;
        public bool IsPaymented { get; set; } = false;
        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}
