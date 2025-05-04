using Hackathon.Warehouse.Core.Models.Documents;

namespace Hackathon.Warehouse.Api.Contracts.Documents
{
    public record ReceivingDocumentResponse(
        int Id,
        string SupplierName,
        DateTimeOffset CreatedAt,
        ReceivingDocumentStatus Status,
        IEnumerable<ReceivingItemResponse> Items,
        int WarehouseId
        );
}
