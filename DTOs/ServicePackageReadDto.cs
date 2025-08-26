using System;
using StarSecurityApi.Models;

namespace StarSecurityApi.Dtos.ServicePackage
{
    public class ServicePackageReadDto
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public Services1 Service { get; set; } 
        public string PackageName { get; set; } = null!;
        public string StaffRange { get; set; }= null!;
        public decimal Price { get; set; } = 0;
        public string Note { get; set; } = null!;
    }
}