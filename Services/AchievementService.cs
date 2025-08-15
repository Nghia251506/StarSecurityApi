using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Data;
using StarSecurityApi.Dtos.Achievement;
using StarSecurityApi.Models;

namespace StarSecurityApi.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly AppDbContext _context;
        public AchievementService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<AchievementReadDto>> GetAllAsync()
        {
            return await _context.Achievements
                .Include(a => a.Employee)
                .Select(a => new AchievementReadDto
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    EmployeeName = a.Employee.FullName, // đổi thành property thật trong Employee
                    Title = a.Title,
                    Description = a.Description,
                    DateAwarded = a.DateAwarded,
                    CreatedAt = a.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<AchievementReadDto?> GetByIdAsync(int id)
        {
            var a = await _context.Achievements
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (a == null) return null;

            return new AchievementReadDto
            {
                Id = a.Id,
                EmployeeId = a.EmployeeId,
                EmployeeName = a.Employee.FullName,
                Title = a.Title,
                Description = a.Description,
                DateAwarded = a.DateAwarded,
                CreatedAt = a.CreatedAt
            };
        }

        public async Task<AchievementReadDto> CreateAsync(AchievementCreateDto dto)
        {
            var a = new Achievement
            {
                EmployeeId = dto.EmployeeId,
                Title = dto.Title,
                Description = dto.Description,
                DateAwarded = dto.DateAwarded,
                CreatedAt = DateTime.Now
            };

            _context.Achievements.Add(a);
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(a.Id))!;
        }

        public async Task<bool> UpdateAsync(int id, AchievementUpdateDto dto)
        {
            var a = await _context.Achievements.FindAsync(id);
            if (a == null) return false;

            a.Title = dto.Title;
            a.Description = dto.Description;
            a.DateAwarded = dto.DateAwarded;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var a = await _context.Achievements.FindAsync(id);
            if (a == null) return false;

            _context.Achievements.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
