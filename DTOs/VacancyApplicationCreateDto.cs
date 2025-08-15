namespace StarSecurityApi.Dtos.VacancyApplication
{
    public class VacancyApplicationCreateDto
    {
        public int VacancyId { get; set; }
        public string ApplicantName { get; set; } = null!;
        public string? ApplicantContact { get; set; }
        public string? ResumeUrl { get; set; }
    }
}
