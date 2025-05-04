namespace Hackathon.Warehouse.Core.Models
{
    public class Position
    {
        public Zone Zone { get; set; }
        public int Row { get; set; }
        public int Section { get; set; }
        public int Tier { get; set; }
    }
}
