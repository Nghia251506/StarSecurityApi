namespace StarSecurityApi.Dtos.StaffAssignment
{
    public class StaffAssignmentUpdateDto
    {
        public DateTime? AssignedFrom { get; set; }
        public DateTime? AssignedTo { get; set; }
        public string? RoleDescription { get; set; }
    }
}
