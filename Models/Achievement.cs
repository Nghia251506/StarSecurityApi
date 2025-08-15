namespace StarSecurityApi.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DateAwarded { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public Employee Employee { get; set; } = null!;
    }
}
