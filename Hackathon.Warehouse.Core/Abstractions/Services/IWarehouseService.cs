using Hackathon.Warehouse.Core.Models;
using CSharpFunctionalExtensions;

namespace Hackathon.Warehouse.Core.Abstractions.Services
{
    public interface IWarehouseService
    {
        Task<Result<WarehouseModel>> GetById(long id);
        Task<Result<WarehouseModel>> Create(string name);
    }
}
