namespace StarSecurityApi.Dtos.Achievement
{
    public class AchievementUpdateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DateAwarded { get; set; }
    }
}
