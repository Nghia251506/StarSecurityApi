namespace StarSecurityApi.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public string? Address { get; set; }
        public int ServiceId { get; set; }
        public string? RequestDetails { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public string Status { get; set; } = "pending";
        public int? AssignedEmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Services1 Service { get; set; } = null!;
        public Employee? AssignedEmployee { get; set; }
    }
}
