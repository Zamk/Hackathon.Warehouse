namespace Hackathon.Warehouse.Api.Contracts.Warehouse
{
    public record AddZoneRequest(
        int WarehouseId,
        string Name,
        int NumberOfRows,
        int NumberOfSections,
        int NumberOfTires,
        double MaxWidth,
        double MaxDepth,
        double MaxHeight
        );
}
