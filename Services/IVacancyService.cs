using StarSecurityApi.Dtos.Vacancy;

namespace StarSecurityApi.Services
{
    public interface IVacancyService
    {
        Task<IEnumerable<VacancyReadDto>> GetAllAsync();
        Task<VacancyReadDto?> GetByIdAsync(int id);
        Task<VacancyReadDto> CreateAsync(VacancyCreateDto dto);
        Task<bool> UpdateAsync(int id, VacancyUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
