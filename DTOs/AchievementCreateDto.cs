namespace StarSecurityApi.Dtos.Achievement
{
    public class AchievementCreateDto
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DateAwarded { get; set; }
    }
}
