namespace StarSecurityApi.Dtos.StaffAssignment
{
    public class StaffAssignmentReadDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public DateTime? AssignedFrom { get; set; }
        public DateTime? AssignedTo { get; set; }
        public string? RoleDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
