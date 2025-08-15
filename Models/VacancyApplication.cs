namespace StarSecurityApi.Models
{
    public class VacancyApplication
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public string ApplicantName { get; set; } = null!;
        public string? ApplicantContact { get; set; }
        public string? ResumeUrl { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = "applied";

        // Navigation property
        public Vacancy Vacancy { get; set; } = null!;
    }
}
