using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.DTOs;
using StarSecurityApi.Models;

namespace StarSecurityApi.Service
{
    public class AuthRoleService : IAuthRoleService
    {
        private readonly AppDbContext _context;

        public AuthRoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuthRoleReadDto>> GetAllAsync()
        {
            return await _context.AuthRoles
                .Select(r => new AuthRoleReadDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CanManageEmployees = r.CanManageEmployees,
                    CanManageServices = r.CanManageServices,
                    CanManageVacancies = r.CanManageVacancies,
                    CanManageClients = r.CanManageClients,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<AuthRoleReadDto?> GetByIdAsync(int id)
        {
            return await _context.AuthRoles
                .Where(r => r.Id == id)
                .Select(r => new AuthRoleReadDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CanManageEmployees = r.CanManageEmployees,
                    CanManageServices = r.CanManageServices,
                    CanManageVacancies = r.CanManageVacancies,
                    CanManageClients = r.CanManageClients,
                    CreatedAt = r.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AuthRoleReadDto> CreateAsync(AuthRoleCreateDto dto)
        {
            var role = new AuthRole
            {
                Name = dto.Name,
                Description = dto.Description,
                CanManageEmployees = dto.CanManageEmployees,
                CanManageServices = dto.CanManageServices,
                CanManageVacancies = dto.CanManageVacancies,
                CanManageClients = dto.CanManageClients,
                CreatedAt = DateTime.Now
            };

            _context.AuthRoles.Add(role);
            await _context.SaveChangesAsync();

            return new AuthRoleReadDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                CanManageEmployees = role.CanManageEmployees,
                CanManageServices = role.CanManageServices,
                CanManageVacancies = role.CanManageVacancies,
                CanManageClients = role.CanManageClients,
                CreatedAt = role.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(int id, AuthRoleUpdateDto dto)
        {
            var role = await _context.AuthRoles.FindAsync(id);
            if (role == null) return false;

            role.Description = dto.Description;
            role.CanManageEmployees = dto.CanManageEmployees;
            role.CanManageServices = dto.CanManageServices;
            role.CanManageVacancies = dto.CanManageVacancies;
            role.CanManageClients = dto.CanManageClients;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.AuthRoles.FindAsync(id);
            if (role == null) return false;

            _context.AuthRoles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
