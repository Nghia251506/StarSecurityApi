using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;
using StarSecurityApi.Services;

namespace StarSecurityApi.Service
{
    public class BranchService 
    {
        private readonly AppDbContext _context;

        public BranchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchReadDto>> GetAllSync()
        {
            return await _context.Branches
                .Select(b => new BranchReadDto
                {
                    Id = b.Id,
                    Region = b.Region,
                    Name = b.Name,
                    Address = b.Address,
                    ContactPerson = b.ContactPerson,
                    Phone = b.Phone,
                    Email = b.Email
                }).ToListAsync();
        }

        public async Task<BranchReadDto?> GetByIdAsync(int id)
        {
            return await _context.Branches
                .Where(b => b.Id == id)
                .Select(b => new BranchReadDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    ContactPerson = b.ContactPerson,
                    Phone = b.Phone,
                    Email = b.Email,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BranchReadDto> CreateAsync(BranchCreateDto dto)
        {
            var branche = new Branche
            {
                Region = dto.Region,
                Name = dto.Name,
                Address = dto.Address,
                ContactPerson = dto.ContactPerson,
                Phone = dto.Phone,
                Email = dto.Email,
                CreateAt = DateTime.Now
            };
            _context.Branches.Add(branche);
            await _context.SaveChangesAsync();
            return new BranchReadDto
            {
                Region = branche.Region,
                Name = branche.Name,
                Address = branche.Address,
                ContactPerson = branche.ContactPerson,
                Phone = branche.Phone,
                Email = branche.Email,
                CreateAt = branche.CreateAt
            };
        }

        public async Task<bool> UpdateAsync(int id, BranchUpdateDto dto)
        {
            var branche = await _context.Branches.FindAsync(id);
            if (branche == null) return false;

            branche.Region = dto.Region;
            branche.Name = dto.Name;
            branche.Address = dto.Address;
            branche.ContactPerson = dto.ContactPerson;
            branche.Phone = dto.Phone;
            branche.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var branche = await _context.Branches.FindAsync(id);
            if (branche == null) return false;

            _context.Branches.Remove(branche);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}