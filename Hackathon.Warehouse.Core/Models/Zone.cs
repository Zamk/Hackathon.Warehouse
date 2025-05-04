namespace Hackathon.Warehouse.Core.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfSections { get; set; }
        public int NumberOfTires { get; set; }

        public double MaxWidth { get; set; }
        public double MaxDepth { get; set; }
        public double MaxHeight { get; set; }
    }
}
