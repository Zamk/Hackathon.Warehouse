namespace Hackathon.Warehouse.Core.Models.Documents
{
    public class ReceivingItem
    {
        public int Id { get; set; }
        public ReceivingDocument ReceivingDocument { get; set; }
        public int ProductId { get; set; }
        public int ExpectedCount { get; set; }
        public int RecivedCount { get; set; }
        public ReceivingItemStatus Status { get; set; }
    }

    public enum ReceivingItemStatus
    {
        Pending, 
        Received,
        Discrepancy,
    }
}
