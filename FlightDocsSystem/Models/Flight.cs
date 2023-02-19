using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FlightNo { get; set; } = string.Empty;

        public string Route { get; set; } = string.Empty;   

        public DateTime DepartureDate { get; set; }

        public User Creator { get; set; }

        public int UserId { get; set; }

    }
}
