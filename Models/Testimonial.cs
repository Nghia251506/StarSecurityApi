namespace StarSecurityApi.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorTitle { get; set; }
        public string Content { get; set; } = null!;
        public bool Visible { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Client? Client { get; set; }
    }
}
