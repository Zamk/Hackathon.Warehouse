using Hackathon.Warehouse.Core.Models;

namespace Hackathon.Warehouse.Api.Contracts.Warehouse
{
    public record WarehouseStorageResponse(
        int WarehouseId,
        IEnumerable<StorageItemResponse> Items
        );

    public record StorageItemResponse
    (
      long Id,
      string? Description,
      int ProductId,
      Position Position,
      int ProductsCount
    );

}
