namespace Hackathon.Warehouse.Api.Contracts.Documents
{
    public record CreateReceivingDocumentRequest(
        int WarehouseId, 
        string SupplierName,
        List<CreateReceivingItemRequest> Items
        );

    public record CreateReceivingItemRequest(
        int ProductId,
        int ExpectedCount
        );
}
