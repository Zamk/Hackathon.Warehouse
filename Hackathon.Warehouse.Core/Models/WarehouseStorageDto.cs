namespace Hackathon.Warehouse.Core.Models
{
    public class WarehouseStorageDto
    {
        public int WarehouseId { get; set; }
        public IEnumerable<StorageItem> Items { get; set; }
    }
}
