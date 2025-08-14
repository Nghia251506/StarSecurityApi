namespace StarSecurityApi.Dtos.ServiceRequest
{
    public class ServiceRequestReadDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public string? Address { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? RequestDetails { get; set; }
        public string Status { get; set; } = "pending";
        public int? AssignedEmployeeId { get; set; }
        public string? AssignedEmployeeName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
