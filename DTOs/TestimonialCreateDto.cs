namespace StarSecurityApi.Dtos.Testimonial
{
    public class TestimonialCreateDto
    {
        public int? ClientId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorTitle { get; set; }
        public string Content { get; set; } = null!;
        public bool Visible { get; set; } = true;
    }
}
