namespace Hackathon.Warehouse.Api.Contracts
{
    public record WarehouseResponse(
        int Id,
        string Name,
        IEnumerable<ZoneResponse> Zones
        );
}
