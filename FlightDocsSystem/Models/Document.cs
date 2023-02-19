using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DocumentName { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public DateTime UpdatedDate { get; set; }

        public string File { get; set; } = string.Empty;

        public string LatestVersion { get; set; } = string.Empty;

        public string? Note { get; set; } = string.Empty;

        public User User { get; set; } 

        public Flight Flight { get; set; } 

        public List<Group>? Groups { get; set; }

    }
}
