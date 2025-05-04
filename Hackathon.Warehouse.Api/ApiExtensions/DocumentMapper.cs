using Hackathon.Warehouse.Api.Contracts.Documents;
using Hackathon.Warehouse.Core.Models.Documents;

namespace Hackathon.Warehouse.Api.ApiExtensions
{
    public static class DocumentMapper
    {
        public static ReceivingDocumentResponse ToResponse(this ReceivingDocument document)
        {
            return new ReceivingDocumentResponse(
                document.Id,
                document.SupplierName,
                document.CreatedAt,
                document.Status,
                document.Items.Select(i => i.ToResponse()),
                document.Warehouse.Id
                );
        }

        public static ReceivingItemResponse ToResponse(this ReceivingItem item) 
        {
            return new ReceivingItemResponse(
                item.Id, 
                item.ReceivingDocument?.Id ?? 0,
                item.ProductId, 
                item.ExpectedCount, 
                item.RecivedCount,
                item.Status);
        }
    }
}
