namespace Hackathon.Warehouse.Core.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Zone> Zones { get; set; } = new List<Zone>();
        public List<StorageItem> StorageItems { get; set; } = new List<StorageItem>();
    }
}
