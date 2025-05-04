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
    }
}
