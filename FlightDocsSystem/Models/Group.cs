using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public string? Note { get; set; }

        public List<User> Users { get; set; }

        public List<Document>? Documents { get; set; }

    }
}
