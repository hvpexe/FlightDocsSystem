using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
    public class GroupVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string? Note { get; set; }
    }
}
