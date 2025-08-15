namespace StarSecurityApi.Dtos.VacancyApplication
{
    public class VacancyApplicationReadDto
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public string VacancyTitle { get; set; } = null!;
        public string ApplicantName { get; set; } = null!;
        public string? ApplicantContact { get; set; }
        public string? ResumeUrl { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = "applied";
    }
}
