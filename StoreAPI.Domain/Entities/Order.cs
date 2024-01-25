namespace StoreAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Address { get; set; }
        public double TotalCost { get; set; }
        public bool IsCanceled { get; set; } = false;
        public bool IsReady { get; set; } = false;
        public bool IsPaymented { get; set; } = false;
    }
}
