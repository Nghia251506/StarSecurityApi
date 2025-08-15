using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.StaffAssignment;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class StaffAssignmentService : IStaffAssignmentService
    {
        private readonly AppDbContext _context;
        public StaffAssignmentService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<StaffAssignmentReadDto>> GetAllAsync()
        {
            return await _context.StaffAssignments
                .Include(sa => sa.Employee)
                .Include(sa => sa.Client)
                .Include(sa => sa.Service)
                .Select(sa => new StaffAssignmentReadDto
                {
                    Id = sa.Id,
                    EmployeeId = sa.EmployeeId,
                    EmployeeName = sa.Employee.FullName, // nhớ sửa theo tên property trong Employee
                    ClientId = sa.ClientId,
                    ClientName = sa.Client.Name,
                    ServiceId = sa.ServiceId,
                    ServiceName = sa.Service.Name,
                    AssignedFrom = sa.AssignedFrom,
                    AssignedTo = sa.AssignedTo,
                    RoleDescription = sa.RoleDescription,
                    CreatedAt = sa.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<StaffAssignmentReadDto?> GetByIdAsync(int id)
        {
            var sa = await _context.StaffAssignments
                .Include(s => s.Employee)
                .Include(s => s.Client)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sa == null) return null;

            return new StaffAssignmentReadDto
            {
                Id = sa.Id,
                EmployeeId = sa.EmployeeId,
                EmployeeName = sa.Employee.FullName,
                ClientId = sa.ClientId,
                ClientName = sa.Client.Name,
                ServiceId = sa.ServiceId,
                ServiceName = sa.Service.Name,
                AssignedFrom = sa.AssignedFrom,
                AssignedTo = sa.AssignedTo,
                RoleDescription = sa.RoleDescription,
                CreatedAt = sa.CreatedAt
            };
        }

        public async Task<StaffAssignmentReadDto> CreateAsync(StaffAssignmentCreateDto dto)
        {
            var sa = new StaffAssignment
            {
                EmployeeId = dto.EmployeeId,
                ClientId = dto.ClientId,
                ServiceId = dto.ServiceId,
                AssignedFrom = dto.AssignedFrom,
                AssignedTo = dto.AssignedTo,
                RoleDescription = dto.RoleDescription,
                CreatedAt = DateTime.Now
            };

            _context.StaffAssignments.Add(sa);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(sa.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, StaffAssignmentUpdateDto dto)
        {
            var sa = await _context.StaffAssignments.FindAsync(id);
            if (sa == null) return false;

            sa.AssignedFrom = dto.AssignedFrom;
            sa.AssignedTo = dto.AssignedTo;
            sa.RoleDescription = dto.RoleDescription;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sa = await _context.StaffAssignments.FindAsync(id);
            if (sa == null) return false;

            _context.StaffAssignments.Remove(sa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
