using System;
using StarSecurityApi.Models;

namespace StarSecurityApi.Dtos.ServicePackage
{
    public class ServicePackageUpdateDto
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public string PackageName { get; set; } 
        public string StaffRange { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
    }
}