using CSharpFunctionalExtensions;
using Hackathon.Warehouse.Core.Abstractions.Services;
using Hackathon.Warehouse.Core.Models;

namespace Hackathon.Warehouse.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly List<WarehouseModel> _warehouses = new List<WarehouseModel>();

        public async Task<Result<WarehouseModel>> Create(string name)
        {
            var warehouse = new WarehouseModel
            {
                Id = _warehouses.Count() + 1,
                Name = name,
                StorageItems = new List<StorageItem>(),
                Zones = new List<Zone>(),
            };
            
            _warehouses.Add(warehouse);

            return Result.Success(warehouse);
        }

        public async Task<Result<WarehouseModel>> GetById(long id)
        {
            var warehouse = _warehouses.FirstOrDefault(w => w.Id == id);

            if (warehouse is null)
                return Result.Failure<WarehouseModel>($"Warehouse with id {id} not found");

            return Result.Success(warehouse);
        }

        public async Task<Result<WarehouseModel>> CreateZone(
            int warehouseId, 
            string name, 
            int numberOfRows, 
            int numberOfSections, 
            int numberOfTires, 
            double maxWidth, 
            double maxHeight, 
            double maxDepth
            )
        {
            var warehouse = _warehouses.FirstOrDefault(w => w.Id == warehouseId);

            if (warehouse is null)
                return Result.Failure<WarehouseModel>($"Warehouse with id {warehouseId} not found");

            var zone = new Zone
            {
                Id = Random.Shared.Next(),
                Name = name,
                NumberOfRows = numberOfRows,
                NumberOfSections = numberOfSections,
                NumberOfTires = numberOfTires,
                MaxWidth = maxWidth,
                MaxDepth = maxDepth,
                MaxHeight = maxHeight
            };

            warehouse.Zones.Add(zone);

            return Result.Success(warehouse);
        }

        public async Task<Result<WarehouseModel>> RemoveZone(int warehouseId, int zoneId)
        {
            var warehouse = _warehouses.FirstOrDefault(w => w.Id == warehouseId);

            if (warehouse is null)
                return Result.Failure<WarehouseModel>($"Warehouse with id {warehouseId} not found");

            var zone = warehouse.Zones.FirstOrDefault(z => z.Id == zoneId);

            if (zone is null)
                return Result.Failure<WarehouseModel>($"Zone with id {zoneId} not found");

            warehouse.Zones.Remove(zone);

            return Result.Success(warehouse);
        }
    }
}
