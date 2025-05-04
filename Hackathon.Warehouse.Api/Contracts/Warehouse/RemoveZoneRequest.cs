namespace Hackathon.Warehouse.Api.Contracts.Warehouse
{
    public record RemoveZoneRequest(
        int WarehouseId,
        int ZoneId
        );
}
