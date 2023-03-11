using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
    public class FlightModel
    {
        public string FlightNo { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public DateTime DepartureDate { get; set; }
        public int UserId { get; set; }
    }
}
