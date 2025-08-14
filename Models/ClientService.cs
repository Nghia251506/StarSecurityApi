using StarSecurityApi.Services;

namespace StarSecurityApi.Models
{
    public class ClientServices
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StaffCount { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Client Client { get; set; } = null!;
        public Services1 Service { get; set; } = null!;
    }
}
