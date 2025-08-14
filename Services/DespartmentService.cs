using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;
using StarSecurityApi.DTOs;
using StarSecurityApi.Dtos;

namespace StarSecurityApi.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllSync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<DepartmentReadDto> CreateAsync(DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description,
                CreateAt = DateTime.Now
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return new DepartmentReadDto
            {
                Name = department.Name,
                Description = department.Description,
                CreateAt = department.CreateAt
            };
        }

        public async Task<bool> UpdateAsync(int id, Department department)
        {
            var existing = await _context.Departments.FindAsync(id);
            if (existing == null) return false;
            existing.Name = department.Name;
            existing.Description = department.Description;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _context.Departments.FindAsync(id);
            if (emp == null) return false;

            _context.Departments.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}