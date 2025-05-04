using Hackathon.Warehouse.Api.Contracts.Warehouse;
using Hackathon.Warehouse.Core.Models;

namespace Hackathon.Warehouse.Api.ApiExtensions
{
    public static class WarehouseMapper
    {
        public static ZoneResponse ToResponse(this Zone zone)
        {
            return new ZoneResponse(zone.Id, zone.Name);
        }

        public static WarehouseResponse ToResponse(this WarehouseModel warehouse)
        {
            return new WarehouseResponse(warehouse.Id, warehouse.Name, warehouse.Zones.Select(z => z.ToResponse()));
        }

        public static StorageItemResponse ToResponse(this StorageItem storageItem)
        {
            return new StorageItemResponse(
                storageItem.Id,
                storageItem.Description,
                storageItem.ProductId,
                storageItem.Position,
                storageItem.ProductsCount
                );
        }

        public static WarehouseStorageResponse ToResponse(this WarehouseStorageDto storageDto)
        {
            return new WarehouseStorageResponse(storageDto.WarehouseId, storageDto.Items.Select(i => i.ToResponse()));
        }
    }
}
