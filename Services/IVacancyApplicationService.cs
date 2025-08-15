using StarSecurityApi.Dtos.VacancyApplication;

namespace StarSecurityApi.Services
{
    public interface IVacancyApplicationService
    {
        Task<IEnumerable<VacancyApplicationReadDto>> GetAllAsync();
        Task<VacancyApplicationReadDto?> GetByIdAsync(int id);
        Task<VacancyApplicationReadDto> CreateAsync(VacancyApplicationCreateDto dto);
        Task<bool> UpdateAsync(int id, VacancyApplicationUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
