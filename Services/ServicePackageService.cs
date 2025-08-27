using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Dtos.ServicePackage;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class ServicePackageService : IServicePackageService
    {
        private readonly AppDbContext _context;
        public ServicePackageService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<ServicePackageReadDto>> GetAllAsync()
        {
            return (IEnumerable<ServicePackageReadDto>)await _context.ServicesPackages.Select(spg => new ServicePackageReadDto
            {
                Id = spg.Id,
                ServiceId = spg.ServiceId,
                PackageName = spg.PackageName,
                StaffRange = spg.StaffRange,
                Price = spg.Price,
                Note = spg.Note
            })
            .ToListAsync();
        }

        public async Task<ServicePackageReadDto?> GetByIdAsync(int id)
        {
            var s = await _context.ServicesPackages.Include(e => e.Service).FirstOrDefaultAsync(x => x.Id == id);
            if (s == null) return null;
            return new ServicePackageReadDto
            {
                Id = s.Id,
                ServiceId = s.ServiceId,
                PackageName = s.PackageName,
                StaffRange = s.StaffRange,
                Price = s.Price,
                Note = s.Note
            };
        }

        public async Task<ServicePackageReadDto> CreateAsync(ServicePackageCreateDto dto)
        {
            var s = new ServicesPackage
            {
                Id = dto.Id,
                ServiceId = dto.ServiceId,
                PackageName = dto.PackageName,
                StaffRange = dto.StaffRange,
                Price = dto.Price,
                Note = dto.Note
            };
            _context.ServicesPackages.Add(s);
            await _context.SaveChangesAsync();
            return (await GetByIdAsync(s.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, ServicePackageUpdateDto dto)
        {
            var s = await _context.ServicesPackages.FindAsync(id);
            if (s == null) return false;

            s.ServiceId = dto.ServiceId;
            s.PackageName = dto.PackageName;
            s.StaffRange = dto.StaffRange;
            s.Price = dto.Price;
            s.Note = dto.Note;
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var s = await _context.ServicesPackages.FindAsync(id);
            if (s == null) return false;
            _context.ServicesPackages.Remove(s);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}