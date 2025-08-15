namespace StarSecurityApi.Models
{
    public class StaffAssignment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? AssignedFrom { get; set; }
        public DateTime? AssignedTo { get; set; }
        public string? RoleDescription { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Employee Employee { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public Services1 Service { get; set; } = null!;
    }
}
