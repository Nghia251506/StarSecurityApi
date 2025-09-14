using StarSecurityApi.Models;
using ServiceEmplement = StarSecurityApi.Models.ServiceRequest;
namespace StarSecurityApi.Dtos.Employee
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Education { get; set; }
        public int? DepartmentId { get; set; }
        public int? GradeId { get; set; }
        public int? JobId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string Status { get; set; } = "active";
    }
}
