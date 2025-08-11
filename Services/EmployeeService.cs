using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EmployeeReadDto> CreateAsync(EmployeeCreateDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "CALL sp_add_employee({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})",
                dto.FirstName,
                dto.LastName ?? "",
                dto.Address ?? "",
                dto.Phone ?? "",
                dto.Email ?? "",
                dto.Education ?? "",
                dto.DepartmentId ?? (object)DBNull.Value,
                dto.GradeId ?? (object)DBNull.Value,
                dto.JobTitle ?? "",
                dto.DateOfJoin?.ToString("yyyy-MM-dd")
            );

            var newEmp = await _context.Employees
                .OrderByDescending(e => e.Id)
                .FirstOrDefaultAsync();

            return new EmployeeReadDto
            {
                Id = newEmp.Id,
                EmployeeCode = newEmp.EmployeeCode,
                FullName = newEmp.FullName ?? $"{newEmp.FirstName} {newEmp.LastName}",
                Address = newEmp.Address,
                Phone = newEmp.Phone,
                Email = newEmp.Email,
                JobTitle = newEmp.JobTitle,
                Status = newEmp.Status
            };
        }
        public async Task<bool> UpdateAsync(int id, Employee employee)
        {
            var existing = await _context.Employees.FindAsync(id);
            if (existing == null) return false;

            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Address = employee.Address;
            existing.Phone = employee.Phone;
            existing.Email = employee.Email;
            existing.Education = employee.Education;
            existing.DepartmentId = employee.DepartmentId;
            existing.GradeId = employee.GradeId;
            existing.JobTitle = employee.JobTitle;
            existing.DateOfJoin = employee.DateOfJoin;
            existing.Status = employee.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return false;

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
