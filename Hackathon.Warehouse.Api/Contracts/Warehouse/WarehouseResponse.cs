namespace Hackathon.Warehouse.Api.Contracts.Warehouse
{
    public record WarehouseResponse(
        int Id,
        string Name,
        IEnumerable<ZoneResponse> Zones
        );
}
