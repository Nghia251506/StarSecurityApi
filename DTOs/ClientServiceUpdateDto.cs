namespace StarSecurityApi.Dtos.ClientService
{
    public class ClientServiceUpdateDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StaffCount { get; set; }
        public string? Notes { get; set; }
    }
}
