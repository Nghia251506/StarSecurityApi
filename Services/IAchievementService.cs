using StarSecurityApi.Dtos.Achievement;

namespace StarSecurityApi.Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<AchievementReadDto>> GetAllAsync();
        Task<AchievementReadDto?> GetByIdAsync(int id);
        Task<AchievementReadDto> CreateAsync(AchievementCreateDto dto);
        Task<bool> UpdateAsync(int id, AchievementUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
