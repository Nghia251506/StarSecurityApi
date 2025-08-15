namespace StarSecurityApi.Dtos.Vacancy
{
    public class VacancyUpdateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public string Status { get; set; } = "open";
        public string? MinEducation { get; set; }
        public ulong? SalaryMin { get; set; }
        public ulong? SalaryMax { get; set; }
        public int ApplicationsCount { get; set; }
        public DateTime? FilledAt { get; set; }
    }
}
