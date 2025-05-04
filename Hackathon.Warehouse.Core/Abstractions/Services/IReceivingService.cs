using CSharpFunctionalExtensions;
using Hackathon.Warehouse.Core.Models.Documents;

namespace Hackathon.Warehouse.Core.Abstractions.Services
{
    public interface IReceivingService
    {
        public Task<Result<ReceivingDocument>> CreateReceivingDocument(
            int warehouseId,
            string supplierName,
            List<ReceivingItem> items
            );
        public Task<Result<ReceivingDocument>> GetRecievingDocumentById(int id);
        public Task<Result<ReceivingDocument>> QueueeReceivingDocument(int id);
        public Task<Result<IEnumerable<ReceivingDocument>>> GetReceivingDocuments();
        public Task<Result<ReceivingDocument>> ConfirmReceivingItem(int receivingDocumentId, int receivingItemId, int receivedCount);
        public Task<Result<ReceivingDocument>> ConfirmReceivingDocument(int id);
        public Task<Result<ReceivingDocument>> RejectReceivingDocument(int id);
    }
}
