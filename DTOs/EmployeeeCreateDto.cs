using System.ComponentModel.DataAnnotations;

namespace StarSecurityApi.DTOs
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
        public string? Address { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Education { get; set; }
        public int? DepartmentId { get; set; }
        public int? GradeId { get; set; }
        public string? JobTitle { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfJoin { get; set; }
    }
}
