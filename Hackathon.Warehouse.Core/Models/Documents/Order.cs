namespace Hackathon.Warehouse.Core.Models.Documents
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Picked,
        Shipped,
    }
}
