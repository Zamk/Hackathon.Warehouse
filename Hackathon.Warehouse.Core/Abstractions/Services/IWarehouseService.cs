using Hackathon.Warehouse.Core.Models;
using CSharpFunctionalExtensions;

namespace Hackathon.Warehouse.Core.Abstractions.Services
{
    public interface IWarehouseService
    {
        Task<Result<WarehouseModel>> GetById(long id);
        Task<Result<WarehouseModel>> Create(string name);
        Task<Result<WarehouseModel>> CreateZone(
            int warehouseId,
            string name,
            int numberOfRows,
            int numberOfSections,
            int numberOfTires,
            double maxWidth,
            double maxHeight,
            double maxDepth
            );

        Task<Result<WarehouseModel>> RemoveZone(int warehouseId, int zoneId);
    }
}
