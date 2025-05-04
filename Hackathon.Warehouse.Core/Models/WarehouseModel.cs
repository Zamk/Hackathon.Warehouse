
namespace Hackathon.Warehouse.Core.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Zone> Zones { get; set; } = new List<Zone>();
        public List<StorageItem> StorageItems { get; set; } = new List<StorageItem>();

        public Position? FindAppropriateEmptyPlace()
        {
            var busyPlaces = StorageItems.Select(si => si.Position);

            List<Position> positions = new List<Position>();

            var availablePosition = Zones
                .SelectMany(zone =>
                    Enumerable.Range(1, zone.NumberOfRows)
                        .SelectMany(row =>
                            Enumerable.Range(1, zone.NumberOfSections)
                                .SelectMany(section =>
                                    Enumerable.Range(1, zone.NumberOfTires)
                                        .Select(tier => new Position
                                        {
                                            Zone = zone,
                                            Row = row,
                                            Section = section,
                                            Tier = tier
                                        })
                                )
                        )
                )
                .FirstOrDefault(pos => !busyPlaces.Contains(pos));
            return availablePosition;
        }
    }
}
