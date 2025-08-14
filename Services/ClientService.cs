using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Client;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;
        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientReadDto>> GetAllAsync()
        {
            return await _context.Clients
                .Select(c => new ClientReadDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ContactName = c.ContactName,
                    ContactPhone = c.ContactPhone,
                    ContactEmail = c.ContactEmail,
                    Address = c.Address,
                    Notes = c.Notes,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ClientReadDto?> GetByIdAsync(int id)
        {
            var c = await _context.Clients.FindAsync(id);
            if (c == null) return null;

            return new ClientReadDto
            {
                Id = c.Id,
                Name = c.Name,
                ContactName = c.ContactName,
                ContactPhone = c.ContactPhone,
                ContactEmail = c.ContactEmail,
                Address = c.Address,
                Notes = c.Notes,
                CreatedAt = c.CreatedAt
            };
        }

        public async Task<ClientReadDto> CreateAsync(ClientCreateDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                ContactName = dto.ContactName,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                Address = dto.Address,
                Notes = dto.Notes,
                CreatedAt = DateTime.Now
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(client.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, ClientUpdateDto dto)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            client.Name = dto.Name;
            client.ContactName = dto.ContactName;
            client.ContactPhone = dto.ContactPhone;
            client.ContactEmail = dto.ContactEmail;
            client.Address = dto.Address;
            client.Notes = dto.Notes;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
