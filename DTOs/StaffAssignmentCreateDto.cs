namespace StarSecurityApi.Dtos.StaffAssignment
{
    public class StaffAssignmentCreateDto
    {
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? AssignedFrom { get; set; }
        public DateTime? AssignedTo { get; set; }
        public string? RoleDescription { get; set; }
    }
}
