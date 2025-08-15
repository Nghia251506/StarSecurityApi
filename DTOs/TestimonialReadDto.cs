namespace StarSecurityApi.Dtos.Testimonial
{
    public class TestimonialReadDto
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorTitle { get; set; }
        public string Content { get; set; } = null!;
        public bool Visible { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
