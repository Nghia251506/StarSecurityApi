namespace StarSecurityApi.Dtos.Achievement
{
    public class AchievementReadDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DateAwarded { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
