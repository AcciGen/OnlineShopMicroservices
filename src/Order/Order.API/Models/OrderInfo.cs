namespace Order.API.Models
{
    public class OrderInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public long Quantity { get; set; }
    }
}
