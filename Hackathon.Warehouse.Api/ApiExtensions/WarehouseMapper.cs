using Hackathon.Warehouse.Api.Contracts;
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
    }
}
