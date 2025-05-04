namespace Hackathon.Warehouse.Core.Models.Documents
{
    public class ReceivingDocument
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public ReceivingDocumentStatus Status { get; set; }
        public List<ReceivingItem> Items { get; set; }
        public WarehouseModel Warehouse { get; set; }
    }

    public enum ReceivingDocumentStatus
    {
        Draft,
        Queued,
        Confirmed,
        Rejected,
    }
}
