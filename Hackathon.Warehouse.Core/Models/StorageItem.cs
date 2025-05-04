namespace Hackathon.Warehouse.Core.Models
{
    public class StorageItem
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public Position Position { get; set; }
        public int ProductsCount { get; set; }
    }
}
