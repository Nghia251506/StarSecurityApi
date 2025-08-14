namespace StarSecurityApi.Dtos.ClientService
{
    public class ClientServiceCreateDto
    {
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StaffCount { get; set; }
        public string? Notes { get; set; }
    }
}
