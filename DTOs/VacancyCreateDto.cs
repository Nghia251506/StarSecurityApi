namespace StarSecurityApi.Dtos.Vacancy
{
    public class VacancyCreateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? BranchId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PostedBy { get; set; }
        public string? MinEducation { get; set; }
        public ulong? SalaryMin { get; set; }
        public ulong? SalaryMax { get; set; }
    }
}
