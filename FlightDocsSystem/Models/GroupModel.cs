using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.Models
{
    public class GroupModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}
