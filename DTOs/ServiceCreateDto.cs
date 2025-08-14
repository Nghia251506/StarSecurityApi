namespace StarSecurityApi.Dtos.Service
{
    public class ServiceCreateDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Division { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
