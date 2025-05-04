namespace Hackathon.Warehouse.Api.Contracts
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
