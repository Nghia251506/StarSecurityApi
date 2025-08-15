using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Vacancy;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly AppDbContext _context;
        public VacancyService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<VacancyReadDto>> GetAllAsync()
        {
            return await _context.Vacancies
                .Include(v => v.Branche)
                .Include(v => v.Department)
                .Include(v => v.PostedUser)
                .Select(v => new VacancyReadDto
                {
                    Id = v.Id,
                    Title = v.Title,
                    Description = v.Description,
                    BranchId = v.BranchId,
                    BranchName = v.Branche != null ? v.Branche.Name : null,
                    DepartmentId = v.DepartmentId,
                    DepartmentName = v.Department != null ? v.Department.Name : null,
                    PostedBy = v.PostedBy,
                    PostedByUsername = v.PostedUser != null ? v.PostedUser.Username : null,
                    PostedAt = v.PostedAt,
                    Status = v.Status,
                    MinEducation = v.MinEducation,
                    SalaryMin = v.SalaryMin,
                    SalaryMax = v.SalaryMax,
                    ApplicationsCount = v.ApplicationsCount,
                    FilledAt = v.FilledAt,
                    CreatedAt = v.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<VacancyReadDto?> GetByIdAsync(int id)
        {
            var v = await _context.Vacancies
                .Include(b => b.Branche)
                .Include(d => d.Department)
                .Include(u => u.PostedUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (v == null) return null;

            return new VacancyReadDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                BranchId = v.BranchId,
                BranchName = v.Branche?.Name,
                DepartmentId = v.DepartmentId,
                DepartmentName = v.Department?.Name,
                PostedBy = v.PostedBy,
                PostedByUsername = v.PostedUser?.Username,
                PostedAt = v.PostedAt,
                Status = v.Status,
                MinEducation = v.MinEducation,
                SalaryMin = v.SalaryMin,
                SalaryMax = v.SalaryMax,
                ApplicationsCount = v.ApplicationsCount,
                FilledAt = v.FilledAt,
                CreatedAt = v.CreatedAt
            };
        }

        public async Task<VacancyReadDto> CreateAsync(VacancyCreateDto dto)
        {
            var v = new Vacancy
            {
                Title = dto.Title,
                Description = dto.Description,
                BranchId = dto.BranchId,
                DepartmentId = dto.DepartmentId,
                PostedBy = dto.PostedBy,
                MinEducation = dto.MinEducation,
                SalaryMin = dto.SalaryMin,
                SalaryMax = dto.SalaryMax,
                CreatedAt = DateTime.Now
            };

            _context.Vacancies.Add(v);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(v.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, VacancyUpdateDto dto)
        {
            var v = await _context.Vacancies.FindAsync(id);
            if (v == null) return false;

            v.Title = dto.Title;
            v.Description = dto.Description;
            v.BranchId = dto.BranchId;
            v.DepartmentId = dto.DepartmentId;
            v.Status = dto.Status;
            v.MinEducation = dto.MinEducation;
            v.SalaryMin = dto.SalaryMin;
            v.SalaryMax = dto.SalaryMax;
            v.ApplicationsCount = dto.ApplicationsCount;
            v.FilledAt = dto.FilledAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var v = await _context.Vacancies.FindAsync(id);
            if (v == null) return false;

            _context.Vacancies.Remove(v);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
