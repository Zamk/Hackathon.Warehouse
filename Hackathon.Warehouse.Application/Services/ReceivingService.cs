using CSharpFunctionalExtensions;
using Hackathon.Warehouse.Core.Abstractions.Services;
using Hackathon.Warehouse.Core.Models;
using Hackathon.Warehouse.Core.Models.Documents;

namespace Hackathon.Warehouse.Application.Services
{
    public class ReceivingService : IReceivingService
    {
        private readonly List<ReceivingDocument> _receivingDocuments = new ();
        private readonly IWarehouseService _warehouseService;

        public ReceivingService(
            IWarehouseService warehouseService
            )
        {
            _warehouseService = warehouseService;
        }

        public async Task<Result<ReceivingDocument>> CreateReceivingDocument(int warehouseId, string supplierName, List<ReceivingItem> items)
        {
            var warehouseResult = await _warehouseService.GetById(warehouseId);

            if (warehouseResult.IsFailure)
                return Result.Failure<ReceivingDocument>(warehouseResult.Error);

            var receivingDocument = new ReceivingDocument
            {
                Id = _receivingDocuments.Count() + 1,
                CreatedAt = DateTimeOffset.Now,
                Warehouse = warehouseResult.Value,
                SupplierName = supplierName,
                Items = items,
                Status = ReceivingDocumentStatus.Draft,
            };

            foreach (var item in receivingDocument.Items)
            {
                item.ReceivingDocument = receivingDocument;
                item.Status = ReceivingItemStatus.Pending;
                item.Id = Random.Shared.Next();
            }

            _receivingDocuments.Add(receivingDocument);

            return Result.Success(receivingDocument);
        }

        public async Task<Result<IEnumerable<ReceivingDocument>>> GetReceivingDocuments()
        {
            return Result.Success<IEnumerable<ReceivingDocument>>(_receivingDocuments);
        }

        public async Task<Result<ReceivingDocument>> GetRecievingDocumentById(int id)
        {
            var document = _receivingDocuments.FirstOrDefault(d => d.Id == id);

            if (document is null)
                return Result.Failure<ReceivingDocument>($"ReceivingDocument with id {id} not found");

            return Result.Success(document);
        }

        public async Task<Result<ReceivingDocument>> ConfirmReceivingItem(int receivingDocumentId, int receivingItemId, int receivedCount)
        {
            var document = _receivingDocuments.FirstOrDefault(d => d.Id == receivingDocumentId);

            if (document is null)
                return Result.Failure<ReceivingDocument>($"ReceivingDocument with id {receivingDocumentId} not found");

            var item = document.Items.FirstOrDefault(i => i.Id == receivingItemId);

            if (item is null)
                return Result.Failure<ReceivingDocument>($"ReceivingItem with id {receivingDocumentId} not found");

            item.RecivedCount = receivedCount;

            if (item.RecivedCount != item.ExpectedCount)
                item.Status = ReceivingItemStatus.Discrepancy;
            else
                item.Status = ReceivingItemStatus.Received;

            return document;
        }

        public async Task<Result<ReceivingDocument>> QueueeReceivingDocument(int id)
        {
            var document = _receivingDocuments.FirstOrDefault(d => d.Id == id);

            if (document is null)
                return Result.Failure<ReceivingDocument>($"ReceivingDocument with id {id} not found");

            document.Status = ReceivingDocumentStatus.Queued;

            return Result.Success(document);
        }

        public async Task<Result<WarehouseStorageDto>> ConfirmReceivingDocument(int id)
        {
            var document = _receivingDocuments.FirstOrDefault(d => d.Id == id);

            if (document is null)
                return Result.Failure<WarehouseStorageDto>($"ReceivingDocument with id {id} not found");

            var storageItems = document.Items.Select(i => new StorageItem
            {
                Id = Random.Shared.Next(),
                ProductId = i.ProductId,
                ProductsCount = i.RecivedCount,
            });

            var itemsResult = await _warehouseService.PutItemsToWarehouse(document.Warehouse.Id, storageItems);

            document.Status = ReceivingDocumentStatus.Confirmed;

            var response = new WarehouseStorageDto
            {
                WarehouseId = id,
                Items = itemsResult.Value
            };

            return Result.Success(response);
        }

        public async Task<Result<ReceivingDocument>> RejectReceivingDocument(int id)
        {
            var document = _receivingDocuments.FirstOrDefault(d => d.Id == id);

            if (document is null)
                return Result.Failure<ReceivingDocument>($"ReceivingDocument with id {id} not found");

            document.Status = ReceivingDocumentStatus.Rejected;

            return Result.Success(document);
        }
    }
}
