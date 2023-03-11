namespace FlightDocsSystem.Models
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string Permission { get; set; } = string.Empty;
    }
}
