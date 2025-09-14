using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Models;
using StarSecurityApi.Dtos.Employee;


namespace StarSecurityApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeReadDto>> GetAllAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeReadDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FullName = e.FullName,
                    Phone = e.Phone,
                    Email = e.Email,
                    Job = e.Job,
                    Status = e.Status,
                })
                .ToListAsync();
        }

        public async Task<EmployeeReadDto?> GetByIdAsync(int id)
        {
            var emp = await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Grade)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (emp == null) return null;

            return new EmployeeReadDto
            {
                Id = emp.Id,
                EmployeeCode = emp.EmployeeCode,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                FullName = emp.FullName,
                Address = emp.Address,
                Phone = emp.Phone,
                Email = emp.Email,
                Education = emp.Education,
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Department.Name,
                GradeId = emp.GradeId,
                GradeName = emp.Grade.Name,
                Job = emp.Job,
                Status = emp.Status,
            };
        }

        public async Task<EmployeeReadDto> CreateAsync(EmployeeCreateDto dto)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "CALL sp_add_employee({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})",
                dto.FirstName,
                dto.LastName ?? "",
                dto.Address ?? "",
                dto.Phone ?? "",
                dto.Email ?? "",
                dto.Education ?? "",
                dto.DepartmentId ?? (object)null,
                dto.GradeId ?? (object)null,
                dto.JobId ?? (object)null,
                dto.ServiceId ?? (object)null,
                dto.DateOfJoin,
                dto.Status ?? ""
            );

            var newEmp = await _context.Employees
                .OrderByDescending(e => e.Id)
                .FirstOrDefaultAsync();

            return new EmployeeReadDto
            {
                Id = newEmp.Id,
                EmployeeCode = newEmp.EmployeeCode,
                FullName = newEmp.FullName ?? $"{newEmp.FirstName} {newEmp.LastName}",
                Phone = newEmp.Phone,
                Email = newEmp.Email,
                Job = newEmp.Job,
                Status = newEmp.Status
            };
        }
        public async Task<bool> UpdateAsync(int id, EmployeeUpdateDto dto)
        {
            var existing = await _context.Employees.FindAsync(id);
            if (existing == null) return false;

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.Address = dto.Address;
            existing.Phone = dto.Phone;
            existing.Email = dto.Email;
            existing.Education = dto.Education;
            existing.DepartmentId = dto.DepartmentId;
            existing.GradeId = dto.GradeId;
            existing.JobId = dto.JobId;
            existing.DateOfJoin = dto.DateOfJoin;
            existing.Status = dto.Status;

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
