using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.ClientService;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class ClientServiceService : IClientServiceService
    {
        private readonly AppDbContext _context;
        public ClientServiceService(AppDbContext context)
        {
            _context = context;
        }

        public ClientServiceService(){}

        public async Task<IEnumerable<ClientServiceReadDto>> GetAllAsync()
        {
            return await _context.ClientServices
                .Include(cs => cs.Client)
                .Include(cs => cs.Service)
                .Select(cs => new ClientServiceReadDto
                {
                    Id = cs.Id,
                    ClientId = cs.ClientId,
                    ClientName = cs.Client.Name,
                    ServiceId = cs.ServiceId,
                    ServiceName = cs.Service.Name,
                    StartDate = cs.StartDate,
                    EndDate = cs.EndDate,
                    StaffCount = cs.StaffCount,
                    Notes = cs.Notes,
                    CreatedAt = cs.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ClientServiceReadDto?> GetByIdAsync(int id)
        {
            var cs = await _context.ClientServices
                .Include(c => c.Client)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cs == null) return null;

            return new ClientServiceReadDto
            {
                Id = cs.Id,
                ClientId = cs.ClientId,
                ClientName = cs.Client.Name,
                ServiceId = cs.ServiceId,
                ServiceName = cs.Service.Name,
                StartDate = cs.StartDate,
                EndDate = cs.EndDate,
                StaffCount = cs.StaffCount,
                Notes = cs.Notes,
                CreatedAt = cs.CreatedAt
            };
        }

        public async Task<ClientServiceReadDto> CreateAsync(ClientServiceCreateDto dto)
        {
            var cs = new ClientServices
            {
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StaffCount = dto.StaffCount,
                Notes = dto.Notes,
                CreatedAt = DateTime.Now
            };

            _context.ClientServices.Add(cs);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(cs.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, ClientServiceUpdateDto dto)
        {
            var cs = await _context.ClientServices.FindAsync(id);
            if (cs == null) return false;

            cs.StartDate = dto.StartDate;
            cs.EndDate = dto.EndDate;
            cs.StaffCount = dto.StaffCount;
            cs.Notes = dto.Notes;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cs = await _context.ClientServices.FindAsync(id);
            if (cs == null) return false;

            _context.ClientServices.Remove(cs);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
