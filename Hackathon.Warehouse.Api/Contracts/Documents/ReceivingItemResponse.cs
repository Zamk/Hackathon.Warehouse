using Hackathon.Warehouse.Core.Models.Documents;

namespace Hackathon.Warehouse.Api.Contracts.Documents
{
    public record ReceivingItemResponse(
        int Id,
        int ReceivingDocumentId,
        long ProductId,
        int ExpectedCount,
        int RecivedCount,
        ReceivingItemStatus Status
        );
}
