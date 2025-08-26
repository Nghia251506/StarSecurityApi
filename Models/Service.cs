using System;

namespace StarSecurityApi.Models
{
    public class Services1
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Division { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ServicesPackage> Packages { get; set; }
    }
}
