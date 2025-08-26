using System;

namespace StarSecurityApi.Models
{
    public class ServicesPackage
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public Services1 Service { get; set; }
        public string PackageName { get; set; } 
        public string StaffRange { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
    }
}