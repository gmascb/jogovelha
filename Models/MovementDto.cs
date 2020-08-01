using System;
namespace jogovelha.Models
{
    public class MovementDto
    {
        public string player { get; set; }
        public Guid id { get; set; }
        public PositionDto position { get; set; }
    }

    public class PositionDto
    {
        public int x { get; set; }
        public int y { get; set; }

        public void ConvertPositionTable()
        {
            this.y = this.y == 2 ? 0 : this.y;
            this.y = this.y == 0 ? 2 : this.y;
        }
    }
}