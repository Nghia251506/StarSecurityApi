namespace StarSecurityApi.DTOs
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? JobTitle { get; set; }
        public string Status { get; set; } = "active";
    }
}
