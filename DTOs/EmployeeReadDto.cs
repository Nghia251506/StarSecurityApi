using StarSecurityApi.Models;
using ServiceEmplement = StarSecurityApi.Models.ServiceRequest;
namespace StarSecurityApi.Dtos.Employee
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Education { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Department? Department { get; set; }
        public int? GradeId { get; set; }
        public string GradeName { get; set; }
        public Grade Grade { get; set; }
        public int? JobId { get; set; }
        public ServiceEmplement Job { get; set; }
        public string JobName { get; set; }
        public int? ServiceId { get; set; }
        public Services1 service { get; set; }
        public string ServiceName { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string Status { get; set; } = "active";
    }
}
