using System;
namespace jogovelha.Models
{
    public class MovementDto
    {
        public string player { get; set; }
        public Guid id { get; set; }
        public PositionDto position { get; set; }
    }
}