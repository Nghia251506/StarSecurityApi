namespace StarSecurityApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Education { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? JobId { get; set; }
        public ServiceRequest Job { get; set; }
        public int? ServiceId { get; set; }
        public Services1 Services1 { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string Status { get; set; } = "active";
        public DateTime CreatedAt { get; set; }
    }
}
