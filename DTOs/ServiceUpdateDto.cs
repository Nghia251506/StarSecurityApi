namespace StarSecurityApi.Dtos.Service
{
    public class ServiceUpdateDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Division { get; set; } = null!;
        public string? Description { get; set; }
    }
}
