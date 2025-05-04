namespace Hackathon.Warehouse.Core.Models.Documents
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product {  get; set; }
        public int OrderedCount {  get; set; }
        public int PickedCount { get; set; }
        public OrderItemStatus Status { get; set; }
    }

    public enum OrderItemStatus
    {
        Pending,
        Picked,
        Discrepancy,
    }
}
