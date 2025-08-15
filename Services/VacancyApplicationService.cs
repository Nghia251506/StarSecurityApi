using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.VacancyApplication;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class VacancyApplicationService : IVacancyApplicationService
    {
        private readonly AppDbContext _context;
        public VacancyApplicationService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<VacancyApplicationReadDto>> GetAllAsync()
        {
            return await _context.VacancyApplications
                .Include(a => a.Vacancy)
                .Select(a => new VacancyApplicationReadDto
                {
                    Id = a.Id,
                    VacancyId = a.VacancyId,
                    VacancyTitle = a.Vacancy.Title,
                    ApplicantName = a.ApplicantName,
                    ApplicantContact = a.ApplicantContact,
                    ResumeUrl = a.ResumeUrl,
                    AppliedAt = a.AppliedAt,
                    Status = a.Status
                })
                .ToListAsync();
        }

        public async Task<VacancyApplicationReadDto?> GetByIdAsync(int id)
        {
            var a = await _context.VacancyApplications
                .Include(v => v.Vacancy)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (a == null) return null;

            return new VacancyApplicationReadDto
            {
                Id = a.Id,
                VacancyId = a.VacancyId,
                VacancyTitle = a.Vacancy.Title,
                ApplicantName = a.ApplicantName,
                ApplicantContact = a.ApplicantContact,
                ResumeUrl = a.ResumeUrl,
                AppliedAt = a.AppliedAt,
                Status = a.Status
            };
        }

        public async Task<VacancyApplicationReadDto> CreateAsync(VacancyApplicationCreateDto dto)
        {
            var a = new VacancyApplication
            {
                VacancyId = dto.VacancyId,
                ApplicantName = dto.ApplicantName,
                ApplicantContact = dto.ApplicantContact,
                ResumeUrl = dto.ResumeUrl
            };

            _context.VacancyApplications.Add(a);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(a.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, VacancyApplicationUpdateDto dto)
        {
            var a = await _context.VacancyApplications.FindAsync(id);
            if (a == null) return false;

            a.Status = dto.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var a = await _context.VacancyApplications.FindAsync(id);
            if (a == null) return false;

            _context.VacancyApplications.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
