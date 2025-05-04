namespace Hackathon.Warehouse.Api.Contracts
{
    public record RemoveZoneRequest(
        int WarehouseId,
        int ZoneId
        );
}
