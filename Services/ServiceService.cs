using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Service;
using StarSecurityApi.Dtos.ServicePackage;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext _context;
        public ServiceService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<ServiceReadDto>> GetAllAsync()
        {
            return await _context.Services
                .Select(s => new ServiceReadDto
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Division = s.Division,
                    Description = s.Description,
                    CreatedAt = s.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ServiceReadDto?> GetByIdAsync(int id)
        {
            var s = await _context.Services
                .Include(x => x.Packages)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (s == null) return null;

            return new ServiceReadDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Division = s.Division,
                Description = s.Description,
                CreatedAt = s.CreatedAt,
                Packages = s.Packages.Select(p => new ServicePackageReadDto
                {
                    Id = p.Id,
                    PackageName = p.PackageName,
                    StaffRange = p.StaffRange,
                    Price = p.Price,
                    Note = p.Note
                }).ToList()
            };
        }

        public async Task<ServiceReadDto> CreateAsync(ServiceCreateDto dto)
        {
            var s = new Services1
            {
                Code = dto.Code,
                Name = dto.Name,
                Division = dto.Division,
                Description = dto.Description
            };
            _context.Services.Add(s);
            await _context.SaveChangesAsync();
            return (await GetByIdAsync(s.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, ServiceUpdateDto dto)
        {
            var s = await _context.Services.FindAsync(id);
            if (s == null) return false;

            s.Code = dto.Code;
            s.Name = dto.Name;
            s.Division = dto.Division;
            s.Description = dto.Description;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var s = await _context.Services.FindAsync(id);
            if (s == null) return false;
            _context.Services.Remove(s);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
