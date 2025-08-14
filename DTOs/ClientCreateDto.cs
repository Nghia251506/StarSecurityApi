namespace StarSecurityApi.Dtos.Client
{
    public class ClientCreateDto
    {
        public string Name { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
    }
}
