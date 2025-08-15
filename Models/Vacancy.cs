namespace StarSecurityApi.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PostedBy { get; set; }
        public DateTime PostedAt { get; set; }
        public string Status { get; set; } = "open";
        public string? MinEducation { get; set; }
        public ulong? SalaryMin { get; set; }
        public ulong? SalaryMax { get; set; }
        public int ApplicationsCount { get; set; } = 0;
        public DateTime? FilledAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Branche? Branche { get; set; }
        public Department? Department { get; set; }
        public User? PostedUser { get; set; }
    }
}
